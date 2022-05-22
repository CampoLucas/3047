using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//El parallax loopeable infinito esta en la parte 1 de la clase 8

    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float _speedX=0;
        [SerializeField] private BoxCollider _repeatLimit;
        Camera cam;
        Vector2 screenSize;
        private float _width;

        private void Awake()
        {
            _width = _repeatLimit.bounds.size.x;
            cam = Camera.main;
            GetScreenSize();
        }
        private void GetScreenSize() => screenSize = new Vector2((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2, (1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f)) / 2);
        private void Update()
        {
            transform.position -= new Vector3( _speedX, 0, 0f) * Time.deltaTime;
            float distanceWithBounds = -screenSize.x - transform.position.x;
            if (Mathf.Abs(distanceWithBounds) >= _width)
            {
                if (distanceWithBounds > 0)
                {
                    transform.position = new Vector3(_width, transform.position.y, transform.position.z);
                    
                }
            }
        }
    }
