using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public GameObject checkpoint;
    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);

        if (health <= 0)
        {
            this.gameObject.transform.position = checkpoint.transform.position;
            health = maxHealth;
        }
    }
}
