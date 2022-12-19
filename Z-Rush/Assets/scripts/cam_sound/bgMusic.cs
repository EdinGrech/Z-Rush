using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{

    [SerializeField] AudioClip Music;
    [SerializeField][Range(0, 1)] float MusicVolume = 0.75f;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(playMusic());
        }
        while (true);
    }

    IEnumerator playMusic()
    {
        AudioSource.PlayClipAtPoint(Music, Camera.main.transform.position, MusicVolume);
        DontDestroyOnLoad(GameObject.Find("One shot audio"));
        yield return new WaitForSeconds(Music.length);
        //yield return new WaitForSeconds(0.2f);
    }

    void SetupSingolton()
    {
        if (FindObjectsOfType<bgMusic>().Length > 1)
        {
            print("destroy");
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SetupSingolton();
    }

}
