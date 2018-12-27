using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIManager : MonoBehaviour
{

    [Header("Managers")]
    public InputManager inputManager;
    public CrewManager crewManager;

    [Header("Cursors")]
    public Cursor moveCursor;
    public Cursor attackCursor;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        //Feed origin and target to cursors
        moveCursor.origin = crewManager.members[crewManager.selectedMember].transform.position;
        moveCursor.target = inputManager.cursorPos;


    }
}
