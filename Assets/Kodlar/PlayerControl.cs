using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    Rigidbody phys;
    AudioSource fire;
    public GameObject laser;
    public GameObject weapon1;
    public GameObject weapon2;
    Vector3 velo;
    Transform laserPosition1;
    Transform laserPosition2;

    float horizontal = 0;
    float vertical = 0;
    float laserTimer = 0;
    public float speed;
    public float egim;


    void Start()
    {
        phys = GetComponent<Rigidbody>();
        fire = GetComponent<AudioSource>();
        laserPosition1 = weapon1.GetComponent<Transform>();
        laserPosition2 = weapon2.GetComponent<Transform>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Jump") && Time.time > laserTimer)
        {
            laserTimer = Time.time + 0.3f;
            Instantiate(laser, laserPosition1.position, Quaternion.Euler(90,0,0));
            Instantiate(laser, laserPosition2.position, Quaternion.Euler(90,0,0));
            fire.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        vertical = CrossPlatformInputManager.GetAxis("Vertical");
        velo = new Vector3(horizontal, vertical, 0);
        phys.velocity = velo * speed;
        phys.position = new Vector3(
            Mathf.Clamp(phys.position.x, -15, 15), 
            Mathf.Clamp(phys.position.y, -5, 7), 
            phys.position.z);
        phys.rotation = Quaternion.Euler(0, 0, phys.velocity.x * -egim);

    }
}
