using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   
    public Vector3 speed;



    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed;
    }
}
