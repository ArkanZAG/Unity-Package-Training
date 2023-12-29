using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int expAmount = 100;

    private void Collected()
    {
        ExperienceManager.instance.AddExperience(expAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collected();

        if (other.TryGetComponent(out Character character))
        {
            character.Data.AddXp(expAmount);
        }
    }
}
