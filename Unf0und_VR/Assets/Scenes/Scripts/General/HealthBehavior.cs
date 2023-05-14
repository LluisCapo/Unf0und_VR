using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float health;
    public float maxHealth;

    public UnityEvent<float, float> OnHurt;
    public UnityEvent HasNoLife;

	public void Hurt(float damage)
	{
        health -= damage;

        if (health <= 0)
            HasNoLife.Invoke();

        OnHurt.Invoke(health, maxHealth);
    }

    public float GetHealth()
	{
        return health;
	}

    public void SetHealth(float a)
	{
        if (a <= maxHealth)
            health = a;
	}

    public void AddHealth(float a)
	{
        health += a;
        if (health > maxHealth)
            health = maxHealth;
    }

    public void ResetLife()
    {
        health = maxHealth;
    }
}
