using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().HandleDamage(damage);
        }
    }
}
