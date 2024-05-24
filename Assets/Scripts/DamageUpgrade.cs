using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DamageUpgrade : MonoBehaviour
{
    
    public GameObject d1Purchased;
    public GameObject d2Purchased;
    public GameObject d3Purchased;
    public GameObject r1Purchased;
    public GameObject r2Purchased;
    public GameObject r3Purchased;
    public Text damage1;
    public bool d1;
    public Text damage2;
    public bool d2;
    public Text damage3;
    public bool d3;
    public Text reload1;
    public bool r1;
    public Text reload2;
    public bool r2;
    public Text reload3;
    public bool r3;

    public int d1Cost;
    public int d2Cost;
    public int d3Cost;
    public int r1Cost;
    public int r2Cost;
    public int r3Cost;
    public int d1CostPercent;
    public int d2CostPercent;
    public int d3CostPercent;
    
    public int r1CostPercent;
    public int r2CostPercent;
    public int r3CostPercent;
    void Start()
    {
        d1Cost = 150;
        d2Cost = 300;
        d3Cost = 450;
        r1Cost = 150;
        r2Cost = 300;
        r3Cost = 450;
        d1Purchased.SetActive(false);
        d2Purchased.SetActive(false);
        d3Purchased.SetActive(false);
        r1Purchased.SetActive(false);
        r2Purchased.SetActive(false);
        r3Purchased.SetActive(false);
        
    }

        


    // Update is called once per frame
    void Update()
    {
        d1Purchased.SetActive(true);


        d2Purchased.SetActive(true);
        

        d3Purchased.SetActive(true);
        

        r1Purchased.SetActive(true);
        

        r2Purchased.SetActive(true);
        

        r3Purchased.SetActive(true);
        damage1.text = d1Cost + " coins";
        damage2.text = d2Cost + " coins";
        damage3.text = d3Cost + " coins";
        reload1.text = r1Cost + " coins";
        reload2.text = r2Cost + " coins";
        reload3.text = r3Cost + " coins";
    }

    // Update is called once per frame

    
    public void UpgradeDamageLevel1()
    {

        if(PersistentData.Instance.coins >= d1Cost)
        {
                PersistentData.Instance.damageUpgrade += 20;
                PersistentData.Instance.coins -= d1Cost;

                d1Cost = (int)(d1Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= d1Cost)
        {
            damage1.text = "Not enough coins!";
        }

    }
    public void UpgradeDamageLevel2()
    {
        if(PersistentData.Instance.coins >= d2Cost)
        {
            PersistentData.Instance.damageUpgrade += 50;
            PersistentData.Instance.coins -= d2Cost;
            d2Cost = (int)(d2Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= d2Cost)
        {
            damage2.text = "Not enough coins!";
        }
    }
    public void UpgradeDamageLevel3()
    {
        if(PersistentData.Instance.coins >= d3Cost)
        {
            PersistentData.Instance.damageUpgrade += 100;
            PersistentData.Instance.coins -= d3Cost;
            d3Cost = (int)(d3Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= d3Cost)
        {
            damage3.text = "Not enough coins!";
        }
    }
    //_________________________________________________________
    //_________________________________________________________
    //_________________________________________________________
    public void UpgradeReloadLevel1()
    {
        if(PersistentData.Instance.coins >= r1Cost)
        {
            PersistentData.Instance.reloadUpgrade += 0.05f;
            PersistentData.Instance.ammoUpgrade += 10;
            PersistentData.Instance.coins -= r1Cost;
            r1Cost = (int)(r1Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= r1Cost)
        {
            reload1.text = "Not enough coins!";
        }

        
    }
    public void UpgradeReloadLevel2()
    {
        if(PersistentData.Instance.coins >= r2Cost)
        {
            PersistentData.Instance.reloadUpgrade += 0.12f;
            PersistentData.Instance.ammoUpgrade += 30;
            PersistentData.Instance.coins -= r2Cost;
            r2Cost = (int)(r2Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= 200)
        {
            reload2.text = "Not enough coins!";
        }
    }
    public void UpgradeReloadLevel3()
    {
        if(PersistentData.Instance.coins >= r3Cost)
        {
            PersistentData.Instance.reloadUpgrade += 0.2f;
            PersistentData.Instance.ammoUpgrade += 50;
            PersistentData.Instance.coins -= r3Cost;
            r3Cost = (int)(r3Cost * 1.2);
        }
        else if (PersistentData.Instance.coins <= r3Cost)
        {
            reload3.text = "Not enough coins!";
        }
    }
    // Start is called before the first frame update

}