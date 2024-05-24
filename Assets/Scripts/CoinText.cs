using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "Coins: " + PersistentData.Instance.coins;
    }
}