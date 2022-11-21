using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeeter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] List<GameObject> foodProjectile;
    [SerializeField] AudioClip yeetSound;
    [SerializeField][Range(0, 1)] float yeetSoundVolume = 0.75f;
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
            AudioSource.PlayClipAtPoint(yeetSound, Camera.main.transform.position, yeetSoundVolume);
            GameObject foodProjInstance = Instantiate(foodProjectile[Random.Range(0,foodProjectile.Count)], gameObject.transform.position, Quaternion.identity);
            foodProjInstance.GetComponent<foodProjectileTargeting>().setTargetLocation(playerPos);
            foodProjInstance.GetComponent<damage>().setFixedDamageOverwrite(1);
        }
    }   
}
