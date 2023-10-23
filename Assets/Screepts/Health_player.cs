using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_player : MonoBehaviour
{
    public float heal = 100;
    private float current_heal;

    void Start()
    {
        current_heal = heal;
    }
    void TakeDamage(float damage_player)
    {
        current_heal -= damage_player;
        if (current_heal <= 0) {
            Die();
        }
    }

    void Die()
    {
       
    }
}
