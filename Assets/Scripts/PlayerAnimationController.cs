using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public ParticleSystem stoneParticles;
    public ParticleSystem dustParticles;
    public float stoneParticlesEmissionMultiplier = 1f;
    public float dustParticlesEmissionMultiplier = 3f;
    public float maxStoneParticlesEmission;
    public float maxDustParticlesEmission;
    public float smoothFactor = 0.2f;
    PanelScript panelScript;
    MoveController moveController;
    Animator animator;
    float currentForwardValue;
    float currentRightValue;
    void Start()
    {
        panelScript = GameObject.FindGameObjectWithTag("TouchController").GetComponent<PanelScript>();
        moveController = GameObject.FindGameObjectWithTag("MoveController").GetComponent<MoveController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float forward = GetForwardMove();
        float right = GetRightMove();
        currentForwardValue = Mathf.Lerp(currentForwardValue, forward, smoothFactor);
        currentRightValue = Mathf.Lerp(currentRightValue, right, smoothFactor);

        SetStoneParticlesEmission();
        SetDustParticlesEmission();

        animator.SetFloat("Forward", currentForwardValue);
        animator.SetFloat("Right", currentRightValue);
    }

    void SetStoneParticlesEmission()
    {
        Vector2 particlesVector = new Vector2(currentRightValue, currentForwardValue);
        ParticleSystem.EmissionModule particlesEmission = stoneParticles.emission;
        particlesEmission.rateOverTime
            = Mathf.Clamp(particlesVector.magnitude * stoneParticlesEmissionMultiplier, 0, maxStoneParticlesEmission);
    }

    void SetDustParticlesEmission()
    {
        Vector2 particlesVector = new Vector2(currentRightValue, currentForwardValue);
        ParticleSystem.EmissionModule particlesEmission = dustParticles.emission;
        particlesEmission.rateOverTime
            = Mathf.Clamp(particlesVector.magnitude * dustParticlesEmissionMultiplier, 0, maxDustParticlesEmission);
    }

    float GetForwardMove()
    {
        float moveControllerMove = moveController.enabled
            && moveController.gameObject.activeInHierarchy ? moveController.moveSpeed : 0;
        float panelMove = panelScript.enabled
            && panelScript.gameObject.activeInHierarchy ? panelScript.realMoveVector.y : 0;
        return moveControllerMove + panelMove;
    }

    float GetRightMove()
    {
        float panelMove = panelScript.enabled
            && panelScript.gameObject.activeInHierarchy ? panelScript.realMoveVector.x : 0;
        return panelMove;
    }
}
