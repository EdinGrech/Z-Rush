using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] float padding = 4f;
    [SerializeField] float speed = 100f;
    [SerializeField] float hp = 40f;

    [SerializeField] AudioClip playerPoint;
    [SerializeField][Range(0, 1)] float playerPointVolume = 0.75f;
    [SerializeField] AudioClip playerHit;
    [SerializeField][Range(0, 1)] float playerHitVolume = 0.75f;
    [SerializeField] AudioClip playerDeath;
    [SerializeField][Range(0, 1)] float playerDeathVolume = 0.75f;
    //get effect
    [SerializeField] GameObject effect;

    
    int score = gameSetion.returnScore();
    float xMin, xMax;
    void Start()
    {
        ViewPortToWorldPoint();
    }

    public int returnHP()
    {
        return (int)hp;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        damage localDmg = collision.gameObject.GetComponent<damage>();
        if (localDmg) 
        {
            hp -= localDmg.returnDMG();
            AudioSource.PlayClipAtPoint(playerHit, Camera.main.transform.position, playerHitVolume);
        }
        add2Scor localScor = collision.gameObject.GetComponent<add2Scor>();
        if (localScor)
        {
            score += (int)localScor.returnScor();
            AudioSource.PlayClipAtPoint(playerPoint, Camera.main.transform.position, playerPointVolume);
            gameSetion.setScore(score);
        } 
        Destroy(collision.gameObject);
        print(hp);
        print(score);
        if (hp <= 0)
        {
            //play effect
            GameObject effectIns = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effectIns, 1.1f);
            FindObjectOfType<Level>().LoadGameOver();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(playerDeath, Camera.main.transform.position, playerDeathVolume);    
        }
    }
   
}
