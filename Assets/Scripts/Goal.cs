using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform initialBallTransform;
    public string opponentTeamName;

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = this.initialBallTransform.position;
        other.gameObject.GetComponent<Rigidbody>().inertiaTensor = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log(this.opponentTeamName + " scored !");
    }
}
