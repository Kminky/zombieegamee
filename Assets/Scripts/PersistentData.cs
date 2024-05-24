using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData
{
    public int coins = 0;
    public int damageUpgrade = 0;
    public float reloadUpgrade = 0f;

    public int ammoUpgrade = 10;
    public Text coinText;
    
    private static PersistentData _instance = null;
    public static PersistentData Instance => _instance ?? (_instance = new PersistentData());
    
}
