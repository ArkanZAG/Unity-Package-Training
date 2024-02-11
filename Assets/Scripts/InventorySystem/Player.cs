using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int health;
    public int exp;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI expText;

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        healthText.text = $"HP:{health}";
    }

    public void IncreaseExp(int value)
    {
        exp += value;
        expText.text = $"EXP:{exp}";
    }
}
