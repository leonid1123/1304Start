using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazzza : MonoBehaviour {
    public Animator an;
    void Start() {
        an.speed = 0;
    }
    public void Crash() {
        an.speed = 1;
    }
    public void DestroyVaza() {
        Destroy(gameObject);
    }
}
