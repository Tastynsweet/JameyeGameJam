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
        healthSlider.value = health/100f;
    }

    public void setNormalColor()
    {
        healthFill.color = new Color32(183, 53, 53, 255);
    }

    public void setSoulColor()
    {
        healthFill.color = new Color32(250, 0, 250, 255);
    }
}
