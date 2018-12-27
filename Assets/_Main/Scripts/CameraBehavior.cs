using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECamTarget { CREW1, CREW2, CURSOR };

public class CameraBehavior : MonoBehaviour
{

    [Header("Managers")]
    public InputManager inputManager;

    [Header("Position")]
    public Vector3 offset = new Vector3(0, 10, -10);
    [Range(0, 3)]
    public float inertia = 0.5f;

    [Header("Targets")]
    public List<GameObject> crew = new List<GameObject>();

    [SerializeField]
    ECamTarget currentTarget = ECamTarget.CREW1;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateTargetPos();

        transform.position = Vector3.Lerp(transform.position, targetPos, inertia) + offset;

    }

    void ChangeTarget(ECamTarget newTarget)
    {

        currentTarget = newTarget;

    }

    void UpdateTargetPos()
    {
        
        switch(currentTarget){
            case ECamTarget.CREW1:
                targetPos = crew[0].transform.position;
                break;

            case ECamTarget.CREW2:
                targetPos = crew[1].transform.position;
                break;

            case ECamTarget.CURSOR:
                targetPos = inputManager.cursorPos;
                break;
        }
    }

}
