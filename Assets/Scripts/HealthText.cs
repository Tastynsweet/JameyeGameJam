using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth healthCount;
    private int currentHealth;

    void Update()
    {
        currentHealth = healthCount.GetHealth();
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
