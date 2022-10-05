using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Health
{
    [SerializeField] private Sprite crackedSprite; // the sprite you want displayed when object damaged
    public GameObject brokenFX;
    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);

        //this line of code swaps the sprite out every time the player damages the breakable object
        this.gameObject.GetComponent<SpriteRenderer>().sprite = crackedSprite;

        //if the breakable object runs out of health below handles its destruction
        if (health <= 0)
        {
            Instantiate(brokenFX, gameObject.transform.localPosition, Quaternion.identity); // instantiates vfx smoke poof
            Destroy(gameObject); // destroys the actual object
        }

    }
}
