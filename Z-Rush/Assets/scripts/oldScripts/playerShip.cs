using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShip : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigBod;
    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
 
        rigBod.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
