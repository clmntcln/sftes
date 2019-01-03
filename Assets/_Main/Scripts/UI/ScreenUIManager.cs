using System.Collections;
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

    [Header("Portraits")]
    public List<Portrait> crewPortraits = new List<Portrait>();
    int selectedPortraitIndex = 0;

    [Header("Test")]
    public Slider healthSlider;
    public Slider moveSlider;
    public Slider attackSlider;

    //UI Prefab to init for each character

    // Start is called before the first frame update
    void Start()
    {

        SelectedCharacter(selectedPortraitIndex);

    }

    // Update is called once per frame
    void Update()
    {

        healthSlider.value = (float)crewManager.selectedMember.hpManager.hp / (float)crewManager.selectedMember.hpManager.maxHP;

        moveSlider.value = crewManager.selectedMember.abilities[0].currentCharge / crewManager.selectedMember.abilities[0].totalCharge;
        attackSlider.value = crewManager.selectedMember.abilities[1].currentCharge / crewManager.selectedMember.abilities[1].totalCharge;

        // foreach(CrewMember member in crewManager.members)
        // {
        //     //Display abilities recharge in gauges
        //     healthSlider.value = (float)member.hpManager.hp / (float)member.hpManager.maxHP;

        //     moveSlider.value = member.abilities[0].currentCharge / member.abilities[0].totalCharge;
        //     attackSlider.value = member.abilities[1].currentCharge / member.abilities[1].totalCharge;
        // }
        
    }

    public void SelectedCharacter(int index)
    {
        crewPortraits[selectedPortraitIndex].SetSelected(false);
        selectedPortraitIndex = index;
        crewPortraits[selectedPortraitIndex].SetSelected(true);
    }

}
