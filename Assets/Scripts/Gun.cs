using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public Animator gunAnimator;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    public Text ammoText;
    public AudioSource gunSound;
    
    private void Start()
    {
        maxAmmo = PersistentData.Instance.ammoUpgrade;
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }
    private void Update()
    {
        if (isReloading)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (Time.time - lastAttackTime >= attackCooldown - PersistentData.Instance.reloadUpgrade && currentAmmo > 0)
            {
                gunAnimator.SetTrigger("shoot");
                lastAttackTime = Time.time;
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

                currentAmmo--;
                UpdateAmmoUI();

                gunSound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - lastAttackTime >= attackCooldown && currentAmmo == 0)
            {
                StartCoroutine(Reload());
            }
        }
    }
    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            
            ammoText.text = currentAmmo + " / " + maxAmmo;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        gunAnimator.SetBool("isReloading", true);

        // Play reload animation or sound if needed

        yield return new WaitForSeconds(reloadTime);
        
        gunAnimator.SetBool("isReloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateAmmoUI();
        //make reload animation e
    }
}
// make shooting animation