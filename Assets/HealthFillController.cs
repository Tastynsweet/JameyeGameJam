using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFillController : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image healthFill;

    public void setHealth(int health)
    {
        Debug.Log("health fill set to " + health);
        healthSlider.value = health/100f;
    }

    public void setNormalColor()
    {
        healthFill.color = new Color(183, 53, 53);
    }

    public void setSoulColor()
    {
        healthFill.color = new Color(22, 169, 150);
    }
}
