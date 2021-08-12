using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenScenes : MonoBehaviour
{

    public Animator transition;

    public float transitionTime;

    public void GoToScene(int scene)
    {
        StartCoroutine(loadSceneAsync(scene));
        //UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {
        endGame();
    }

    IEnumerator endGame()
    {
        //transition.SetTrigger("Start");

        //yield return new WaitForSeconds(transitionTime);
        
        Application.Quit();
        return null;
    }

    IEnumerator loadSceneAsync(int scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
