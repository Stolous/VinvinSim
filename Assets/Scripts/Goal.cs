using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform initialBallTransform;
    public string opponentTeamName;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.opponentTeamName + " scored !");
        Application.LoadLevel(Application.loadedLevel);
    }
}
