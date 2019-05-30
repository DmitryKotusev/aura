using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGatesTrigger : MonoBehaviour
{
    public GameObject gates;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent != null && collider.gameObject.transform.parent.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("TouchController").GetComponent<PanelScript>().enabled = false;
            gates.SetActive(true);
        }
    }
}
