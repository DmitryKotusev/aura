using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyParticles;
    public float particlesLiveTime = 1.5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("KeyCounter")
                .GetComponent<KeyCounter>().AddKey();
            GameObject keyParticlesClone = Instantiate(keyParticles,
                transform.position, keyParticles.transform.rotation);
            Destroy(keyParticlesClone, particlesLiveTime);
            Destroy(gameObject);
        }
    }
}
