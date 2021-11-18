using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{

    Rigidbody phys;


    public float speed = 40;

    void Start()
    {
        phys = GetComponent<Rigidbody>();

        phys.velocity = new Vector3(0,0, speed);

    }


}
