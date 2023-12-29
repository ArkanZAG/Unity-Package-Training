using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}
