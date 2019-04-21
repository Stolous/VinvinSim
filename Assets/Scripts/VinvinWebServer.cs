using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Web;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System;

namespace UniWebServer
{


    public class VinvinWebServer : MonoBehaviour
    {
        public bool startOnAwake = true;
        public int port = 8079;
        public int workerThreads = 2;
        public bool processRequestsInMainThread = true;
        public bool logRequests = true;

        public VinvinDatabase vinvinDB;

        WebServer server;
        Dictionary<string, IWebResource> resources = new Dictionary<string, IWebResource>();

        void Start()
        {
            if(processRequestsInMainThread)
                Application.runInBackground = true;
            
            server = new WebServer(port, workerThreads, processRequestsInMainThread);
            server.logRequests = logRequests;
            server.HandleRequest += HandleRequest;
            
            if(startOnAwake) {
                server.Start();
            }
        }

        void OnApplicationQuit()
        {
            server.Dispose ();
        }

        void Update()
        {
            if(server.processRequestsInMainThread) {
                server.ProcessRequests();    
            }
        }

        void HandleRequest(Request request, Response response)
        {
            NameValueCollection parsedUri = HttpUtility.ParseQueryString(request.uri.Query);
            
            if(request.uri.LocalPath == "/control") {
                int id = int.Parse(parsedUri.Get("id"));
                float left = float.Parse(parsedUri.Get("left"));
                float right = float.Parse(parsedUri.Get("right"));
                Debug.Log("id=" + id + "   left=" + left + "   right=" + right);
                vinvinDB.references[id].setTorques(left, right);
            }
        }

        public void AddResource(string path, IWebResource resource)
        {
            resources[path] = resource;
        }

    }



}