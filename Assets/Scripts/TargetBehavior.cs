using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    [SerializeField]
    private int pointsWorth = 10;

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Hit by: " + collider.gameObject.name);
        GameObject collidingObject = collider.gameObject;
        //If shot by player's bullet,
        if(collidingObject.GetComponentInChildren<EnergyBulletBehavior>() != null)
        {
            //Deactivate target.
            this.gameObject.SetActive(false);
            //Give player points.

        }
    }
}
