using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDamage : MonoBehaviour {

    public float damage; // damage done over time
    public float OnImpactDamage; // damage done on impact
    public bool GetOuttaHereBool = true; // checks if I want gameObject to be removed
    public float GetOuttaHere; // if above is true, this removes gameObject after X seconds
    public bool growUp; // if i want gameObject to expand

    public float growRate; // speed of growing

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(GetOuttaHereBool) Invoke("GetRidOf", GetOuttaHere);
        Expand();
    }   

    void GetRidOf()
    {
        Destroy(gameObject);
    }

    void Expand()
    {
        if(growUp)
        {
            // if (expandX > 20) expandX = 20;
            // if (expandY > 20) expandY = 20;
            // if (expandZ > 20) expandZ = 20;
            //if (expandX >= 20) growUp = false;
            transform.localScale += new Vector3(growRate, growRate, growRate); // for my purposes right now, I only need to increase the object as a whole

        }
    }
}
