using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float health = 200f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Laser laser = collider.gameObject.GetComponent<Laser>();
        if (laser)
        {
            health -= laser.GetDamage();
            laser.Hit();
            if (health <= 0) {
                Destroy(gameObject);
            }


        }
    }
}
