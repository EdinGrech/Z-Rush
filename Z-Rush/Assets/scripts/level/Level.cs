using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 1f;
    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        gameSetion gameSetion = FindObjectOfType<gameSetion>();
        gameSetion.resetScore();
        SceneManager.LoadScene("Level");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        gameSetion gameSetion = FindObjectOfType<gameSetion>();
        gameSetion.resetScore();
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        print("Quitting");
        //works only when running EXE game
        Application.Quit();
    }
}
