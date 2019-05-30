using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.tag == "Player")
        {
            // Stop camera move
            GameObject.FindGameObjectWithTag("MoveController").SetActive(false);
            // Disable panel control
            GameObject.FindGameObjectWithTag("TouchController").GetComponent<PanelScript>().enabled = false;
            // Stop player, player is destroyed and replaced with particles
            collision.gameObject.GetComponent<PlayerScript>().DeathWithHonor();
            //Show restart window
            Debug.Log("Opening restart window");
        }
    }
}
