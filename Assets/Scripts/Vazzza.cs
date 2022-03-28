using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazzza : MonoBehaviour {
    public Animator an;
    void Start() {
        an.speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Warrior") {
            an.speed = 1;
        }
    }
    public void DestroyVaza() {
        Destroy(gameObject);
    }
}
