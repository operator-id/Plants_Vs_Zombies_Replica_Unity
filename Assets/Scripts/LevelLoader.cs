using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene index" + currentSceneIndex);
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        
    }
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void LoadLevelLoseScreen()
    {
        FindObjectOfType<LevelController>().HandleLoseCondition();
    }

    public void RestartScene()
    {
        Debug.Log("Try Again Pressed");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        
    }
    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Menu");
    }
    public void QuitGame()
    {
       
           // UnityEditor.EditorApplication.isPlaying = false;
       
             Application.Quit();

    }
}   

