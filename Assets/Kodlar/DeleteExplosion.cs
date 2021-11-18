using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }
}
