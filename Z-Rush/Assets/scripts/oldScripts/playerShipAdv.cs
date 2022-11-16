using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShipAdv : MonoBehaviour
{
    [SerializeField] float padding = 4f;
    [SerializeField] float paddingTop = 8f;
    [SerializeField] float paddingBot = 2f;
    [SerializeField] float speed = 100f;
    [SerializeField] Object playerLazer;
    [SerializeField] float lSpeed = 20f;
    [SerializeField] float fRate = 0.4f;
    [SerializeField] Vector3 lazOffset = new Vector3(0, 0.3f, 0);
    bool allowfire = true;
    float xMin, xMax, yMin, yMax;
    void Start()
    {
        boundsSettup();
    }
    void Update()
    {
        routinefire();
    }

    void FixedUpdate()
    {
        MovePosition();
    }

    void MovePosition()
    {
        //public float speed = 2;

        /*
         float x = Input.GetAxis("Horizontal");
         Vector2 movement = new Vector2(x, 0);
         transform.Translate(movement * speed * Time.deltaTime);
         */

        //var: generic variable. It will set its type depending on the value
        var differenceInX = Input.GetAxis("Horizontal");
        //newXPos is updated with the current postion + differenceInX
        var newXPos = transform.position.x + differenceInX * Time.deltaTime * speed;

        // clamp the x-postion between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        var differenceInY = Input.GetAxis("Vertical");
        //newYPos is updated with the current postion + differenceInY
        var newYPos = transform.position.y + differenceInY * Time.deltaTime * speed;

        // clamp the y-postion between xMin and xMax
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //update the position of the Player Ship
        transform.position = new Vector2(newXPos, newYPos);

        //set the position
        //transform.position = new Vector2(mov.x * speed * Time.deltaTime, mov.y * speed * Time.deltaTime);
    }

    void boundsSettup()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding + paddingBot;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding - paddingTop;
    }
    
    void routinefire()
    {
        if ((Input.GetButton("Jump") && allowfire))
        {
            //IEnumerator VFire = Fire();
            StartCoroutine(Fire());
            StopCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            allowfire = false;
            GameObject laser = (GameObject)Instantiate(playerLazer, transform.position + lazOffset, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, lSpeed);
            yield return new WaitForSeconds(fRate);
            allowfire = true;
        }
    }
}
