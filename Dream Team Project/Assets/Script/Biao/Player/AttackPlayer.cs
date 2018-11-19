using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

    public AssignProperties_Inter objectProperties;
    private bool IDoDamages = false;
    //private bool IDoHeal = false;
    private float MyDamage;
    //private float MyHeal;

	void Start () {
        IDoDamages = objectProperties.DoesDamage;
        MyDamage = objectProperties.Damage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D otherCollider = collision.collider;
        if (IDoDamages &&  otherCollider.tag == "Player")
        {
            //Debug.Log("I attacked player");
            otherCollider.GetComponentInChildren<PlayerConditions_Manager>().DecreasePlayerHealthBy(MyDamage);
        }
    }
}
