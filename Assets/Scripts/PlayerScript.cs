using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject deathParticles;
    public float deathParticlesLiveTime = 2f;

    public void DeathWithHonor()
    {
        GameObject deathParticlesClone = Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
        Destroy(deathParticlesClone, deathParticlesLiveTime);
        Destroy(gameObject);
    }
}
