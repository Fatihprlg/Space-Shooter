using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject asteroid;
    public Text text;

    Vector3 vec;

    int score = 0;
    void Start()
    {
        StartCoroutine(Asteroid());
    }

    IEnumerator Asteroid()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                vec = new Vector3(Random.Range(-15, 15), Random.Range(-5, 7), 150);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(3);
            }
            yield return new WaitForSeconds(10);
        }

    }

    public void IncrScore(int score1)
    {
        score += score1;
        text.text = "Skor = " + score;
    }
}
