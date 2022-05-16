using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour, IBound
{
    Camera cam;
    Vector2 screenSize;

   private void Awake()
    {
        cam = Camera.main;
        
    }

    private void Update()
    {
        GetScreenSize();
        SetBoundary();
    }
    private void GetScreenSize() => screenSize = new Vector2((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2, (1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f)) / 2);
    public void SetBoundary()
    {
        Vector3 pos = transform.position;

        if (pos.x >= screenSize.x) pos.x = screenSize.x;
        if (pos.x <= -screenSize.x) pos.x = -screenSize.x;
        if (pos.y >= screenSize.y) pos.y = screenSize.y;
        if (pos.y <= -screenSize.y) pos.y = -screenSize.y;


        transform.position = pos;
    }






}
