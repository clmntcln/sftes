using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{

    //List of current crew characters
    List<GameObject> members = new List<GameObject>();

    //Functions to kick crew member
    int selectedMember = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectMember(int index){

        //If current member is using an ability, cancel it
        selectedMember = index;

        //Change camera target

    }

    void DispatchPlayerInput(){

    }
}
