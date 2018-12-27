using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{

    //List of current crew characters
    public List<CrewMember> members = new List<CrewMember>();

    //Functions to kick crew member
    public int selectedMember = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectMember(int index)
    {

        //If current member is using an ability, cancel it
        selectedMember = index;

        //Change camera target

    }

    public void DispatchInput(InputManager.InputInfo inputInfo)
    {
        
        if(members[selectedMember].holdMove && inputInfo.action == InputManager.EInput.CONFIRM)
        {
            members[selectedMember].Move(inputInfo.targetPoint);
        }
        

    }

    public void ToggleMoveAbility()
    {
        members[selectedMember].holdMove = !members[selectedMember].holdMove;
    }
}
