using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject Prefab;
    public float RoundDelay = 10;
    public float DelayBetweenZombieSpawns = 5;
    public float ZombieSpawnsDelayMultiplier = 0.95f;
    private int _waveCount = 1;
    public int WaveCount { get => _waveCount; }
    public int ZombiesKilled;
    private int ZombiesSpawned = 0;
    private int ZombiesPerWave = 10;

    public int ZombieHealthIncreasePerWave = 30;
    public int ZombieHealth = 30;

    public int ZombieSpeedIncreasePerWave = 2;
    public int ZombieSpeed = 5;

    public int ZombieDamageIncreasePerWave = 5;
    public int ZombieDamage = 10;

    public int ZombieScoreIncreasePerWave = 15;
    public int ZombieScore = 15;

    public AudioSource ZombieAttackAudio;
    public AudioSource ZombieDieAudio;

    private GameObject[] SpawnLocations;


    //Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");

	    string sceneName = currentScene.name;

        InvokeRepeating(nameof(SpawnPrefab), RoundDelay, DelayBetweenZombieSpawns);
    }

    void Update()
    {
        if (ZombiesKilled >= ZombiesPerWave) {
            _waveCount++;
            ZombiesKilled = 0;
            ZombiesSpawned = 0;
            ZombiesPerWave += 5;
            
            ZombieHealth += ZombieHealthIncreasePerWave;
            
            ZombieSpeed += ZombieSpeedIncreasePerWave;
            ZombieDamage += ZombieDamageIncreasePerWave;
            ZombieScore += ZombieScoreIncreasePerWave;
            
            CancelInvoke(nameof(SpawnPrefab));

            InvokeRepeating(nameof(SpawnPrefab), RoundDelay, DelayBetweenZombieSpawns);
            DelayBetweenZombieSpawns *= ZombieSpawnsDelayMultiplier;
        }
    }
    
    void SpawnPrefab()
    {
        if (ZombiesSpawned < ZombiesPerWave) {
            var spawn = SpawnLocations[Random.Range(0, SpawnLocations.Length)];
            GameObject Zombie = Instantiate(Prefab, spawn.transform);
            ZombieAI ai = Zombie.GetComponent<ZombieAI>();
            ai.target = player.transform;
            ai.zombieMaxHealth = ZombieHealth;
            ai.zombieCurrentHealth = ZombieHealth;
            ai.speed = ZombieSpeed;
            ai.damage = ZombieDamage;
            ai.scoreValue = ZombieScore;
            ai.zombieAttack = ZombieAttackAudio;
            ai.zombieDie = ZombieDieAudio;
            ZombiesSpawned++;
        }
    }
    
}