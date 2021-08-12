using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSAM
{
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        /// Button used to toggle the pause menu, incompatible with Unity's new input manager
        /// </summary>
        [Tooltip("Button used to toggle the pause menu, incompatible with Unity's new input manager")]
        [SerializeField]
        KeyCode toggleButton = KeyCode.Escape;

        Canvas pauseMenu;

        float previousPosition;

        // Start is called before the first frame update
        void Awake()
        {
            pauseMenu = GameObject.Find("pauseMenu").GetComponent<Canvas>();
            pauseMenu.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            //previousPosition += Time.deltaTime;
            if (Input.GetKeyDown(toggleButton))
            {
                pauseMenu.enabled = !pauseMenu.enabled;
                if (pauseMenu.enabled)
                {
                    Time.timeScale = 0;
                    AudioManager.CrossfadeMusic(Music.PauseMenu, 0.5f);
                    GetComponent<Animator>().SetBool("Paused?", true);
                }
                else
                {
                    //AudioManager.SetMusicPlaybackPosition(previousPosition);
                    Time.timeScale = 1;
                    AudioManager.CrossfadeMusic(Music.YukariTheme, 0.5f);
                    GetComponent<Animator>().SetBool("Paused?", false);
                }
            }

            if (pauseMenu.enabled)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Time.timeScale = 0;
                    // Sometimes the user has custom cursor locking code
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}