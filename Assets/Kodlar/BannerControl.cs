﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerControl : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }

}
