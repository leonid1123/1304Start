using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite lever2;
    public void LeverChange() {
        sr.sprite = lever2;
        GameObject.Find("Block").GetComponent<BlockController>().Apper();
    }
}
