using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    public SpriteRenderer sp;
    public Collider2D coll;
    bool visible = false;
    void Start() {
        coll.enabled = false;
        sp.color = new Vector4(0, 0, 0, 0);
    }
    public void Apper() {
        coll.enabled = true;
        visible=true;
    }
    private void Update() {
        if (visible) {
            sp.color+= new Color(255,255,255,Time.deltaTime);
        }
    }
}
