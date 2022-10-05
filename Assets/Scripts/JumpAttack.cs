using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float bounceForce = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks to see if object you are jumping on has breakable tag
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.GetComponent<Breakable>().HandleDamage(damage);
            this.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
            
        }

        //this code does the exact same thing as above but checks to see if is an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //-- the below line of code would be what it would look like if you're enemy used the same health logic as we have set up so far ----
            //collision.gameObject.GetComponent<EnemyHealth>().HandleDamage(damage);

            //-- below code would make it so your character bounces off them ----
            //this.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }
        
}
