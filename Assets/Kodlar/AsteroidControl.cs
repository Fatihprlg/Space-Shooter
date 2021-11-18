using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidControl : MonoBehaviour
{
    Rigidbody phys;
    AudioSource explosionAudio;

    public GameObject explosion;
    public GameObject playerExplosion;
    GameObject control;
    GameControl gameControl;

    void Start()
    {
        phys = GetComponent<Rigidbody>();
        explosionAudio = GetComponent<AudioSource>();
        control = GameObject.FindGameObjectWithTag("GameController");
        gameControl = control.GetComponent<GameControl>();
        phys.angularVelocity = Random.insideUnitSphere;
        phys.velocity = new Vector3(0, 0, Random.Range(-20,-30));
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.tag != "banner")
        {
            explosionAudio.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            gameControl.IncrScore(10);
        }
        if (col.tag == "Player")
        {
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
        }


    }

}
