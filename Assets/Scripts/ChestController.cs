using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {
    public Animator animator;
    public GameObject txtObject;
    public GameObject Coin;
    private bool open = false;

    private void Start() {
        animator.speed = 0;

    }
    public void OpenSelf() {
        open = true;
        animator.speed = 1;

    }
    void Update() {

        Collider2D[] x = Physics2D.OverlapCircleAll(transform.position, 0.2f);

        foreach (Collider2D a in x) {
            if (a.name == "Warrior" && !open) {
                txtObject.GetComponent<MeshRenderer>().enabled = true;
            } else {
                txtObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    public void CoinSpawn() {
        Instantiate(Coin, transform.position, transform.rotation);
    }

}
