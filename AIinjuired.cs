using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIinjuired : MonoBehaviour {
    public Animator anim;


    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        SetKinematic(true);
    }
	
	// Update is called once per frame
	void Update () {
        //print(health);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.name == "hitbox") anim.SetTrigger("hurt");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "punchkicks") anim.SetTrigger("hurt");
        if (other.tag == "attackKnockback") anim.SetTrigger("knockback");
    }
};
