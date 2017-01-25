using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;

    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float dmg, RaycastHit hit)
    {
        //AQUI SE PUEDE DETECTAR DONDE SE DA EL PUNTO Y SE PUEDE INSTANCIAR UN PARTICLE SYSTEM
        TakeDamage(dmg);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0 && !dead)
            Die();
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
            OnDeath();
        Destroy(gameObject);
    }
}
