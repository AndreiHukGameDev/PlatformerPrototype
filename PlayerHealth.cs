using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    //public AudioSource TakeDamageSound;
    public AudioSource AddHealthSound;

    public HealthUI HealthUI;
    //public DamageScreen DamageScreen;
    //public Blink Blink;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.SetUo(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    private bool _invulnerable = false;
    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvureble", 1.0f);
            //TakeDamageSound.Play();
            HealthUI.DisplayHealth(Health);
            //DamageScreen.StartEffect();
            //Blink.StartBlink();
            
            EventOnTakeDamage.Invoke();
        }
    }

    private void StopInvureble()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        AddHealthSound.Play();
        Health += healthValue;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        HealthUI.DisplayHealth(Health);
    }
    private void Die()
    {
        
    }
}
