using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUIManager : MonoBehaviour
{

    [Header("Managers")]
    public InputManager inputManager;
    public CrewManager crewManager;

    [Header("Cursors")]
    public Cursor moveCursor;
    public Cursor attackCursor;

    [Header("Health")]
    public Slider overheadHealthBar;
    Vector3 overheadYOffset = new Vector3(0, 3.0f, 0);
    GameObject overheadTarget;
    Damageable overheadTargetHealthManager;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        //Feed origin and target to cursors
        moveCursor.origin = crewManager.selectedMember.transform.position;
        moveCursor.target = inputManager.cursorPos;

        attackCursor.origin = crewManager.selectedMember.transform.position;
        attackCursor.target = inputManager.cursorPos;

        if(overheadTarget != null){

            overheadHealthBar.transform.position = overheadTarget.transform.position + overheadYOffset;
            //overheadHealthBar.transform.Rotate(new Vector3(0, 90.0f, 0));

            overheadHealthBar.value = (float)overheadTargetHealthManager.hp / (float)overheadTargetHealthManager.maxHP;

        } 

    }

    public void SetOverheadTarget(GameObject target)
    {

        if(target == null) {
            overheadTarget = null;
            overheadTargetHealthManager = null;
            overheadHealthBar.gameObject.SetActive(false);
        } else {
            overheadTargetHealthManager = target.transform.GetComponent<Damageable>();
            overheadTarget = target;
            overheadHealthBar.gameObject.SetActive(true);
        }
        
    }
}
