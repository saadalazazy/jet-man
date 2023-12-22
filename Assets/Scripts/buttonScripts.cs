using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadGameOver()
    {
        StartCoroutine(deleyBeforGameOver());
    }
    public void loadwin()
    {
        StartCoroutine(deleyBeforwin());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator deleyBeforGameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
    IEnumerator deleyBeforwin()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

}
