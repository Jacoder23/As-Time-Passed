using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveFromStage : MonoBehaviour
{
    public bool canLeave = false;
    public float distance = 7.65f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canLeave)
        {
            if (transform.position.x > distance)
            {
                GameObject.Find("SceneTransitions").GetComponent<MoveBetweenScenes>().GoToScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (transform.position.x < -8.7f)
            {
                GameObject.Find("SceneTransitions").GetComponent<MoveBetweenScenes>().GoToScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
