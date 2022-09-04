using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Replay();
        }
    }
    public void Replay()
    {
        canvas.enabled = !canvas.enabled;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;

            if (Time.timeScale == 0)
            {
                paused.TransitionTo(0.05f);
            }
            else
            {
                unpaused.TransitionTo(0.05f);
            }
    }
    public void Refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Exitmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

}
