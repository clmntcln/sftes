﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUIManager : MonoBehaviour
{

    [Header("Managers")]
    public CrewManager crewManager;

    [Header("Prefabs")]
    public GameObject crewMemberPortrait;
    public GameObject crewMemberUI;

    [Header("Test")]
    public Slider healthSlider;
    public Slider moveSlider;
    public Slider attackSlider;

    //UI Prefab to init for each character

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach(CrewMember member in crewManager.members)
        {
            //Display abilities recharge in gauges
            healthSlider.value = (float)member.hpManager.hp / (float)member.hpManager.maxHP;

            moveSlider.value = member.abilities[0].currentCharge / member.abilities[0].totalCharge;
            attackSlider.value = member.abilities[1].currentCharge / member.abilities[1].totalCharge;
        }
        
    }
}