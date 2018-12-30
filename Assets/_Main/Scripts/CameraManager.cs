using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    public enum ECamTargetType { GAMEOBJECT, CURSOR };

    [Header("Managers")]
    public InputManager inputManager;
    public CrewManager crewManager;

    [Header("Position")]
    public Vector3 offset = new Vector3(0, 10, -10);
    [Range(0, 3)]
    public float inertia = 0.5f;

    [Header("Targets")]
    public List<GameObject> crew = new List<GameObject>();

    ECamTargetType currentTargetType = ECamTargetType.GAMEOBJECT;
    GameObject currentTarget;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = crewManager.selectedMember.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateTargetPos();

        transform.position = Vector3.Lerp(transform.position, targetPos, inertia) + offset;

    } 

    public void ChangeTarget(GameObject newTarget)
    {

        currentTarget = newTarget;

    }

    public void ChangeTargetType(ECamTargetType newTargetType)
    {

        currentTargetType = newTargetType;

    }

    void UpdateTargetPos()
    {
        
        switch(currentTargetType){
            case ECamTargetType.GAMEOBJECT:
                targetPos = currentTarget.transform.position;
                break;

            case ECamTargetType.CURSOR:
                targetPos = inputManager.cursorPos;
                break;
        }
    }

}
