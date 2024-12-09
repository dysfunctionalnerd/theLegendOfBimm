using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObservee : MonoBehaviour
{
    int health = 10;
    int mana = 100;

    public static event Action<int> HealthChanged;

    public delegate void PlayerStats(int health, int mana);
    public event PlayerStats OnStatsChanged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            health--; //shorthand for health = health - 1;
            HealthChanged?.Invoke(health);
            OnStatsChanged?.Invoke(health, mana);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mana--;
            OnStatsChanged(health, mana);
        }
    }
}
