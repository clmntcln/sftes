using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Abilities;

public class CrewMember : MonoBehaviour
{

    [Header("Cursors")]
    public Cursor moveCursor;
    public Cursor attackCursor;

    [Range(1, 10)]
    public float speed = 1.0f;

    public List<Ability> abilities = new List<Ability>();

    public bool isHoldingAbility = false;
    public int abilityInUse = 0;

    public Damageable hpManager;

    // Start is called before the first frame update
    void Start()
    {

        hpManager = transform.GetComponent<Damageable>();

        abilities.Add(new Abilities.Move(transform.gameObject, 10.0f, 0.01f, moveCursor));
        abilities.Add(new Abilities.Shoot(10.0f, 0.01f, attackCursor));

    }

    // Update is called once per frame
    void Update()
    {

        //Foreach abilty, check recharge
        foreach(Ability ability in abilities){
            if (ability.recharging) 
            {
                ability.Recharge();
            }
        }
        
    }

    public void ToggleAbility(int index)
    {

        if(isHoldingAbility){

            //Toggle the current one
            abilities[abilityInUse].ToggleHold();

            //If same ability, set abilityInUse to false. Else, also toggle the new one.
            if(abilityInUse.Equals(index)){
                isHoldingAbility = false;
            } else {
                abilityInUse = index;
                abilities[abilityInUse].ToggleHold();
            }
            
        } else {
            Debug.Log("New ability in use: " + abilities[index].name);
            abilityInUse = index;
            abilities[abilityInUse].ToggleHold();
            isHoldingAbility = true;
        }

    }

    public void UseAbility(int index){

        abilities[index].Use();

        ToggleAbility(index);

    }

    public void UseAbility(int index, InputManager.InputInfo parameters)
    {

        if(parameters.targetObject != null){
            abilities[index].Use(parameters.targetObject);
        } else {
            abilities[index].Use(parameters.targetPoint);
        }
        

        ToggleAbility(index);

    }

    //Refactor to singleton
    public void Shoot()
    {
        //Rotate in good direction
        //Trigger animation
        //Communicate damage taken to target
    }
}
