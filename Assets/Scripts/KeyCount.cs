using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    private int keys = 0;
    public TMP_Text text;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = "Количество ключей: "+keys.ToString();
    }
    public void AddKey()
    {
        keys++;
    }
}
