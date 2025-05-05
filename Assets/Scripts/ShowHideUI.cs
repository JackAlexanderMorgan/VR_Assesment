using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShowHideUI : MonoBehaviour
{
    public Canvas Panel;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Panel.enabled = true;
            Debug.Log("Triggered Pannel");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Panel.enabled = false;
            Debug.Log("Hidden Pannel");
        }
    }
    
}
