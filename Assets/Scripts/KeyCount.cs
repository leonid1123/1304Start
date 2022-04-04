using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    private int keys = 0;
    private int coins = 0;
    public TMP_Text text;
     public TMP_Text coinText;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = "Количество ключей: "+keys.ToString();
        coinText.text = "Количество монеток: "+ coins.ToString();
    }
    public void AddCoin(){
        coins++;
    }
    public void RemoveCoin(){
        coins--;
    }
    public int GetCoins() {
        return coins;
    }
    public void AddKey()
    {
        keys++;
    }
    public void RemoveKey() {
        keys--;
    }
    public int GetKeysCount() {
        return keys;
    }
}
