using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodProjectileTargeting : MonoBehaviour
{
    Vector3 targetLocation;

    public void setTargetLocation(Vector3 targetLocation)
    {
        this.targetLocation = targetLocation;
    }
    
    void Update()
    {
        if (gameObject.transform.position != targetLocation)
        {
            print("moving");
            gameObject.transform.position = Vector2.MoveTowards(transform.position, targetLocation, 7f * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
