﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DespawnController : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
