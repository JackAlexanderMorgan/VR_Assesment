using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinFull : MonoBehaviour
{
    public GameObject Walls;
    public Transform fallPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoinTrigger"))
        {
            Rigidbody wallRb = Walls.GetComponent<Rigidbody>();
            wallRb.isKinematic = false;
            wallRb.useGravity = true;

            Collider wallCollider = Walls.GetComponent<Collider>();
            Collider floorCollider = GameObject.Find("Floor")?.GetComponent<Collider>();

            if (floorCollider != null && wallCollider != null)
            {
                Physics.IgnoreCollision(wallCollider, floorCollider);
            }

            Debug.Log("triggered");
        }
    }
}


