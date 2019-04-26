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
        Debug.Log(this.opponentTeamName + " scored !");
    }
}
