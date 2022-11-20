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
        yield return new WaitForSeconds(Music.length - 0.22f);
    }

}
