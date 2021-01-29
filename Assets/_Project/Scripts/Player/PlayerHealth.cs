﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] int _maxHealth = 120;


    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }

        set
        {
            _maxHealth = Mathf.Clamp(value, 0, 200);
        }
    }

    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = Mathf.Clamp(value,0,MaxHealth);
        }
    }

    private void OnValidate()
    {
        Health = _health;
        MaxHealth = _maxHealth;
    }
}