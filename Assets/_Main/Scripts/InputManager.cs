using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public enum EInput { CONFIRM, CANCEL };

    [Header("Managers")]
    public WorldUIManager worldUIManager;
    public CrewManager crewManager;
    public CameraBehavior cameraBehavior;

    enum EAbilities { MOVE, ATTACK, SPECIAL };

    bool trackCursor = false;

    public Vector3 cursorPos = new Vector3(0, 0, 0);


    int groundLayer;

    // Start is called before the first frame update
    void Start()
    {

        groundLayer = LayerMask.GetMask("Ground");
        
    }

    // Update is called once per frame
    void Update()
    {

        if(trackCursor)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.blue);

                cursorPos = hit.point;
            }
        }

        CheckAbilitiesInput();

    }

    void SetCursorTracking(bool state)
    {

        trackCursor = state;

    }

    void ToggleCursorTracking()
    {

        trackCursor = !trackCursor;

    }

    void CheckAbilitiesInput()
    {

        if (Input.GetKeyDown(KeyCode.C)){
            cameraBehavior.ChangeTarget(CameraBehavior.ECamTarget.CREW1);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            cameraBehavior.ChangeTarget(CameraBehavior.ECamTarget.CREW2);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            cameraBehavior.ChangeTarget(CameraBehavior.ECamTarget.CURSOR);
        }

        //Check if player wants to launch ability
        //Communicates info to crew manager 
        //Crew manager dispatches info to current crew member selected

        //Also check for cancel input

        if (Input.GetMouseButtonDown(0))
        {
            InputInfo inputInfo = new InputInfo(EInput.CONFIRM, cursorPos);
            crewManager.DispatchInput(inputInfo);
        }

        //1
        //Toggle move ability
        if(Input.GetKeyDown(KeyCode.Tab)){
            worldUIManager.moveCursor.ToggleCursorVisibility();
            ToggleCursorTracking();
            crewManager.ToggleMoveAbility();
        }

    }

    public class InputInfo{
        
        public EInput action;
        public Vector3 targetPoint;
        public GameObject targetObject;

        public InputInfo(EInput actionName, Vector3 targetPoint = new Vector3(), GameObject targetObject = null){

            this.action = actionName;
            this.targetPoint = targetPoint;
            this.targetObject = targetObject;

        }
    }
}