using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip1Ctrl : MonoBehaviour
{
    Rigidbody phys;
    AudioSource explosionAudio;

    GameObject gameControl;
    GameControl control;
    public GameObject explosion;
    public GameObject playerExplosion;


    float targetMenuever;
    float newMenuever;
    void Start()
    {
        phys = GetComponent<Rigidbody>();
        gameControl = GameObject.FindGameObjectWithTag("GameController");
        control = gameControl.GetComponent<GameControl>();
        StartCoroutine(Evade());
        
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            targetMenuever = Random.Range(8, 15) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(1.5f);
            targetMenuever = 0;
            yield return new WaitForSeconds(1.5f);
            
        } 
    }
    private void OnTriggerEnter(Collider col)
    {

        if (col.tag != "banner")
        {
            explosionAudio.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            control.IncrScore(30);
        }
        if (col.tag == "Player")
        {
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
        }


    }
    void FixedUpdate()
    {
        newMenuever = Mathf.MoveTowards(phys.velocity.x, targetMenuever, Time.deltaTime * 7.5f);
        phys.velocity = new Vector3(newMenuever, 0, -30);
        phys.position = new Vector3(Mathf.Clamp(phys.position.x, -15, 15), Mathf.Clamp(phys.position.y, -5, 7), phys.position.z);
        phys.rotation = Quaternion.Euler(0, 180, phys.velocity.x);

    }
}
