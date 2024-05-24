using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public int damage = 10;
    public float damage_debounce = 1f;
    public Health Health;
    public GameObject Hobject;
    public RectTransform healthTransform;
    public Vector3 change;
    public GameObject Particle;
    private double last_hit_tick = 0;
    public int damageToZombie = 20;
    public int zombieMaxHealth = 40;
    public int zombieCurrentHealth;
    public int scoreValue = 20;
    public GameObject ZombieHitParticle;
    public AudioSource zombieAttack;
    public AudioSource zombieDie;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();


		string sceneName = currentScene.name;
        Hobject = GameObject.FindGameObjectWithTag("Health");
        healthTransform = Hobject.GetComponent<RectTransform>();
        Health = Hobject.GetComponent<Health>();
        change = new Vector3 (0f, 0, 0);
        damageToZombie = 70;
        if (sceneName == "Arena2")
        {
            damage_debounce = 0.5f;
            damage = 15;
            speed = 7f;
            
        }
    }
    
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        float Distance = Vector3.Distance(target.position, transform.position);
        string sceneName = currentScene.name;
        
        if (target != null)
        {

            Vector3 transform_position = transform.position;
            transform_position.y = 0;
            Vector3 target_position = target.position;
            target_position.y = 0;
            if ((target.position - transform.position).magnitude > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            transform.LookAt(target_position);

        }
        if (sceneName == "Arena2")
        {
            if (Distance < 5 && Time.time - last_hit_tick > damage_debounce)
            {
                
                Health.health -= damage;
                healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Health.health * 3);
            

                last_hit_tick = Time.time;
                zombieAttack.Play();
            }
        }
        if (sceneName == "Arena")
        {
            if (Distance < 3 && Time.time - last_hit_tick > damage_debounce)
            {
                Health.health -= damage;
                healthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Health.health * 3);
            

                last_hit_tick = Time.time;
                zombieAttack.Play();
            }
        }
        
        
        

        
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            zombieCurrentHealth -= (damageToZombie + PersistentData.Instance.damageUpgrade);
            ZombieHit();
            if (zombieCurrentHealth <= 0)
            {
                
                ZombieDeath();
            }
        }
    }
    void ZombieDeath()
    {
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(scoreValue);
            GameObject.Find("Game").GetComponent<Spawner>().ZombiesKilled++;
            Destroy(gameObject);
            Instantiate(Particle, transform.position, Quaternion.identity);
            zombieDie.Play();
        }
    }
    void ZombieHit()
    {
        Instantiate(ZombieHitParticle, transform.position, Quaternion.identity);
    }


}
