using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Waves : MonoBehaviour
{
    public GameObject objectToDisappear;
    public Text waveText;
    bool isPaused = false;
    private GameObject player;
    public GameObject crosshair;
    bool Paused = false;
    [SerializeField] GameObject pauseMenu = null;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(true);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + GameObject.Find("Game").GetComponent<Spawner>().WaveCount;
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle pause state
            isPaused = !isPaused;
            

            // Pause or resume the game based on the pause state
            if (isPaused)
            {
                crosshair.SetActive(false);
                pauseMenu.SetActive(true);
                Pause();
                player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
                Paused = true;
                
            }
            else
            {
                crosshair.SetActive(true);
                pauseMenu.SetActive(false);
                Resume();
                player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = true;
                Paused = false;
            }
        }
    }

    private object GameObjectFindGameObjectWithTag(string v)
    {
        throw new NotImplementedException();
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;
    }

    
    
    

}
