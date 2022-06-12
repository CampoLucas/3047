using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFadeout : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject,3f);
    }
}
