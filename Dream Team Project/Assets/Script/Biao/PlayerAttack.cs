using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float attackDegree = -360f;


    private float rotateRate_Denominator = 15f;
    public float gapTime = 0.001f;
    public float rotateRate;

	// Use this for initialization
	void Start () {
        rotateRate = attackDegree / rotateRate_Denominator;

        //StartCoroutine();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) )
        {
            StartCoroutine(ChangeWeaponRotationTo(rotateRate));
        }
	}



    IEnumerator ChangeWeaponRotationTo(float angleRate)
    {
        for(int i = 0; i < rotateRate_Denominator; i++)
        {
            transform.parent.Rotate(0, 0, angleRate);
            yield return new WaitForSeconds(gapTime);
        }
    }



}
