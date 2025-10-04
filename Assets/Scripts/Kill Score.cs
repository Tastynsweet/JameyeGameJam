using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillScore : MonoBehaviour
{
    public TextMeshProUGUI killText;
    private int kills = 0;

    public void addScore()
    {
        kills++;
        killText.text = "Kills: " + kills; 
    }
}
