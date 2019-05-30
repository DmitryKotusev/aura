using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class playerClamp : MonoBehaviour
{

    public float min;
    public float max;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), 0, transform.position.z);
    }

}
