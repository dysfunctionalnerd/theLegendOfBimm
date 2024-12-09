using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIElements : MonoBehaviour
{
    [SerializeField] PlayerObservee player;
    [SerializeField] TextMeshProUGUI healthUI;
    [SerializeField] TextMeshProUGUI manaUI;

    private void OnEnable()
    {
        //PlayerObservee.HealthChanged += UpdateHealthUI;
        player.OnStatsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        //PlayerObservee.HealthChanged -= UpdateHealthUI;
        player.OnStatsChanged -= UpdateUI;
    }

    void UpdateHealthUI(int _health)
    {
        healthUI.text = "Health: " + _health;
    }

    void UpdateUI(int _health, int _mana)
    {
        healthUI.text = "Health: " + _health;
        manaUI.text = "Mana: " + _mana;
    }
}
