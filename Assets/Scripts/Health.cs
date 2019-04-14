using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth = 5;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Bullet")) {
            currentHealth--;
            Destroy(collision.gameObject);
        }
    }
}
