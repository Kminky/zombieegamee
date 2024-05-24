using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float health;
    public Text healthText;
    public Button RestartButton;
    public GameObject Restart;
    public bool restart = false;
    private GameObject player;
    private CinemachineVirtualCamera playerCam;
    private CinemachineVirtualCamera deathCam;
    private float timer = -5f;
    public float healAmount = 10f; // Amount of healing per tick
    public float tickRate = 1f;
    public ScoreManager Score;
    public GameObject afterDeath;
    // Start is called before the first frame update
    void Start()
    {
        afterDeath.SetActive(false);
        restart = false;
        health = 200;
        Restart.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerCam = GameObject.FindGameObjectWithTag("PlayerCam").GetComponent<CinemachineVirtualCamera>();
        deathCam = GameObject.FindGameObjectWithTag("DeathCam").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            if (!afterDeath.activeSelf)
            {
                Score.AddCoins(Score.score);
            }
            afterDeath.SetActive(true);
            foreach (MonoBehaviour behaviour in player.GetComponents<MonoBehaviour>())
            {
                behaviour.enabled = false;
            }
            playerCam.enabled = false;
            deathCam.enabled = true;
            player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        }
        if (health < 100)
        {
            timer += Time.deltaTime;
            if (timer >= tickRate)
            {
                health += healAmount;
                timer = -3;
                health = Mathf.Min(health, 200f);
            }
        }
    }
    public void DiedMenu()
    {
        SceneManager.LoadScene(0);

    }

}
