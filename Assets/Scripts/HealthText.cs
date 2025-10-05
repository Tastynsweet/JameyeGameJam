using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject normalHeart;
    [SerializeField] private GameObject soulHeart;

    private void Start()
    {
        setNormalHeart();
    }

    public void setHealth(int health)
    {
        healthText.text = health.ToString();
    }

    public void setNormalHeart()
    {
        normalHeart.SetActive(true);
        soulHeart.SetActive(false);
    }

    public void setSoulHeart()
    {
        soulHeart.SetActive(true);
        normalHeart.SetActive(false);
    }
}
