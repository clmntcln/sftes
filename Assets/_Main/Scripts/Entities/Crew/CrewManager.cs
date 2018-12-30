using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{

    [Header("Managers")]
    public CameraManager cameraManager;
    public InputManager inputManager;
    public WorldUIManager worldUIManager;

    //List of current crew characters
    public List<CrewMember> members = new List<CrewMember>();

    //Functions to kick crew member
    public int selectedMemberIndex = 0;
    public CrewMember selectedMember;

    // Start is called before the first frame update
    void Start()
    {
        selectedMember = members[selectedMemberIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMember(int index)
    {

        //TODO: If current member is using an ability, cancel it

        selectedMemberIndex = index;
        selectedMember = members[selectedMemberIndex];

        //Change camera target
        cameraManager.ChangeTarget(selectedMember.transform.gameObject);

    }

    public void ToggleMemberAbility(int abilityId)
    {

        selectedMember.ToggleAbility(abilityId);

    }

}
