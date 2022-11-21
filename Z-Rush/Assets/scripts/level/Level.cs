using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 3f;
    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level");

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quitting");
        //works only when running EXE game
        Application.Quit();
    }
}
