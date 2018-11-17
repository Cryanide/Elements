using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Animator anim;
    public Rigidbody rb;
    private bool run;

    private float inputH;
    private float inputV;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1"))
        {
            //anim.Play("<name of animation>, layer animation is located, how far in the animation starts)
            //base layer (a.k.a default) is -1
            //start of animation: 0f; end of animation: 1f
            int n = Random.Range(1, 5);
            if(n == 1) anim.Play("WAIT01", -1, 0f);
            else if(n == 2) anim.Play("WAIT02", -1, 0f);
            else if(n == 3) anim.Play("WAIT03", -1, 0f);
            else if(n == 4) anim.Play("WAIT04", -1, 0f);
        }
        if(Input.GetMouseButtonDown(0))
        {
           // anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
           // anim.Play("DAMAGED01", -1, 0f);
        }
        //RUNNING
        if (Input.GetKey(KeyCode.LeftShift)) {
            run = false;
        }
        else {
            run = true;
        }
        //END RUNNING
        // JUMPING
        if (Input.GetKey(KeyCode.Space)) anim.SetBool("jump", true);
        else anim.SetBool("jump", false);
        // END JUMPING
        // SLIDING
        if (Input.GetKey(KeyCode.LeftControl)) anim.SetBool("slid", true);
        else anim.SetBool("slid", false);



        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");


        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if(moveZ <= 0f)
        {
            moveX = 0f;
        }
        else if (run)
        {
            moveX *= 4f;
            moveZ *= 4f;
        } 

        rb.velocity = new Vector3(moveX, 0, moveZ);
	}
}
