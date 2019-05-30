using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed;

    public GameObject player;
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        mainCamera.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        player.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
