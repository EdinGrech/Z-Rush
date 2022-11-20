using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeeter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] GameObject foodProjectile;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(yeet());
        
        IEnumerator yeet()
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            print("spawn time");
            Vector3 playerPos = GameObject.Find("player").transform.position;
            playerPos.y -= 2f;
            playerPos.z = 0f;
            GameObject foodProjInstance = Instantiate(foodProjectile, gameObject.transform.position, Quaternion.identity);
            foodProjInstance.GetComponent<foodProjectileTargeting>().setTargetLocation(playerPos);
            foodProjInstance.GetComponent<damage>().setFixedDamageOverwrite(1);
        }
    }   
}
