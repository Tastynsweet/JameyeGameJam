using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth.getSoulMode())
        {
            healthText.text = "Soul Health: " + playerHealth.getSoulHealth().ToString();
        } else
        {
            healthText.text = "Health: " + playerHealth.getHealth().ToString();
        }
    }
}
