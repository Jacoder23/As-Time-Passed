using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JSAM;

public class CutsceneManager : MonoBehaviour
{
    float timer;
    int attempts;
    public GameObject KosuzuPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < -5.2f || attempts != 0)
        {
            if (attempts == 3)
            {
                // Play and wait for end of animation where she dresses up and then burns to a crisp and looks scared
                GameObject temp = Instantiate(KosuzuPrefab);
                temp.SetActive(true);
                GetComponent<Animator>().Play("title_akyuu_sleeping");
                attempts += 1;
            }
            else if (attempts >= 3)
            {
                return;
            }
            else if (Input.anyKey & timer < 0f)
            {
                timer = 0.5f;
                attempts += 1;
                GetComponent<Animator>().Play("title_stirring");
                JSAM.AudioManager.PlaySound(Sounds.PlayerBulletSpawn);
            }

            //if(transform.position.x > 8)
            //{
            //    SceneManager.LoadScene("SampleScene");
            //}
        }
        timer -= Time.deltaTime;
    }
}
