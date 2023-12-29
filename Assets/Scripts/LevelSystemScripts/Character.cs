using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private Button button;

    [SerializeField] private PlayerData currentData = new();

    public PlayerData Data => currentData;

    
}
