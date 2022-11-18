using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float padding = 4f;
    [SerializeField] float speed = 100f;
    float xMin, xMax;
    void Start()
    {
        ViewPortToWorldPoint();
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePosition();
    }

    void MovePosition()
    {
        //var: generic variable. It will set its type depending on the value
        var differenceInX = Input.GetAxis("Horizontal");
        //newXPos is updated with the current postion + differenceInX
        var newXPos = transform.position.x + differenceInX * Time.deltaTime * speed;

        // clamp the x-postion between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //update the position of the Player Ship
        transform.position = new Vector2(newXPos, -4);
    }

    void ViewPortToWorldPoint()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }  
}
