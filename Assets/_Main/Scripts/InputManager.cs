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
    public CameraManager cameraManager;

    enum EAbilities { MOVE, ATTACK, SPECIAL };

    bool trackCursor = false;

    public Vector3 cursorPos = new Vector3(0, 0, 0);

    GameObject targetObj;

    int groundLayer;
    int damageableLayer;

    // Start is called before the first frame update
    void Start()
    {

        groundLayer = LayerMask.GetMask("Ground");
        damageableLayer = LayerMask.GetMask("Damageable");
        
    }

    // Update is called once per frame
    void Update()
    {

        // if(trackCursor)
        // {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);

            cursorPos = hit.point;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, damageableLayer))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            targetObj = hit.collider.gameObject;
            worldUIManager.SetOverheadTarget(hit.collider.gameObject);
            
        } else {
            targetObj = null;
            worldUIManager.SetOverheadTarget(null);
        }
        //}

        CheckAbilitiesInput();

    }

    public void SetCursorTracking(bool state)
    {

        trackCursor = state;

    }

    public void ToggleCursorTracking()
    {

        trackCursor = !trackCursor;

    }

    void CheckAbilitiesInput()
    {

        //Camera focus on character
        if (Input.GetKeyDown(KeyCode.C)){
            crewManager.SelectMember(0);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            crewManager.SelectMember(1);
        }

        //Check if player wants to launch ability
        //Communicates info to crew manager 
        //Crew manager dispatches info to current crew member selected

        if (Input.GetMouseButtonDown(0) && crewManager.selectedMember.isHoldingAbility)
        {

            InputInfo inputInfo = new InputInfo(cursorPos, targetObj);

            crewManager.selectedMember.UseAbility(crewManager.selectedMember.abilityInUse, inputInfo);

        }

        //1
        //Toggle move ability
        if(Input.GetKeyDown(KeyCode.A)){

            crewManager.ToggleMemberAbility(0);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            crewManager.ToggleMemberAbility(1);

        }

    }

    public class InputInfo{
        
        public Vector3 targetPoint;
        public GameObject targetObject;

        public InputInfo(Vector3 targetPoint = new Vector3(), GameObject targetObject = null){

            this.targetPoint = targetPoint;
            this.targetObject = targetObject;

        }
    }
}