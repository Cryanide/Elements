using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{
    public Animator anim;
    private float attackReadyTime;
    private bool attackReadyBool;
    //private float attackReady;

    private float timeLeft;

    private bool fisticuffs;

    public GameObject rightHand;
    public GameObject magicAttacks;

    public GameObject playerTeleport;
    public GameObject[] tpLoc;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //attackReadyTime = 2.0f;
        attackReadyBool = false;
        fisticuffs = false;
        timeLeft = 1.8f;
        rightHand = GameObject.Find("rightFist");
        //if (rightHand) rightHand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //print(anim.GetCurrentAnimatorStateInfo(0).IsName("01_Frank_Moves_Idle_(In-place)"));

        
        magicAttacks = GameObject.FindGameObjectWithTag("power");
        tpLoc = GameObject.FindGameObjectsWithTag("behindTarget");
        

        if (magicAttacks)
        {
            anim.ResetTrigger("BoomBoom");
            anim.ResetTrigger("DeathRay");
            anim.ResetTrigger("teleport");
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && !attackMagic.cooldown) anim.SetTrigger("teleport");
        else if (Input.GetKeyDown(KeyCode.Keypad0) && attackMagic.cooldown) anim.SetTrigger("failedAttack");

        if (Input.GetKeyDown(KeyCode.Keypad3) && !attackMagic.cooldown) anim.SetTrigger("BoomBoom");
        else if (Input.GetKeyDown(KeyCode.Keypad3) && attackMagic.cooldown) anim.SetTrigger("failedAttack");

        if (Input.GetKeyDown(KeyCode.Keypad9) && !attackMagic.cooldown) anim.SetTrigger("DeathRay");
        else if (Input.GetKeyDown(KeyCode.Keypad9) && attackMagic.cooldown) anim.SetTrigger("failedAttack");


        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Invoke("teleport", 4f);
        }


        if (attackReadyBool) timeLeft -= Time.deltaTime;
        if (!attackReadyBool) timeLeft = 1.8f;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attackReady", true);
            attackReadyBool = true;
            
            //attackReady += 2f;

        }
        if (Input.GetMouseButtonDown(0) && timeLeft > 0f && anim.GetCurrentAnimatorStateInfo(0).IsName("01_Frank_Moves_Idle_(In-place)"))
        {
            anim.SetBool("attack", true);
            Invoke("stopAttackReady", 1f);
            fisticuffs = true;
            Invoke("resetCombo", 1.2f);
        }

        if (timeLeft <= 0f)
        {
            anim.SetBool("attackReady", false);
            //attackReady = 2;
            attackReadyBool = false;
            fisticuffs = false;
            //resetCombo();
        }


        if (fisticuffs)
        {
            rightHand.SetActive(true);
        }
        if (!fisticuffs)
        {
            rightHand.SetActive(false);
        }
        //print();

    }


    //I dont know how to Invoke something that isnt a method so... here this is
    void stopAttackReady()
    {
        anim.SetBool("attackReady", false);
        Invoke("startAttackReady", 0.2f);
        Invoke("stopAttackReadyAGAIN", 2f);
    }

    // so i had this idea where you'd go back in the fight idle pose, but for reasons i dont want to type into a comment
    // I'll just say this was a good idea, future me (or anyone else) if you want to see why this would be needed, just comment out
    // "anim.SetBool("attackReady", false);" and dont do a combo with exit time *on*, you'll see
    void startAttackReady()
    {
        anim.SetBool("attackReady", true);
    }

    //THATS RIGHT I NEED 3 METHODS TO DO THIS, LEAVE ME ALONE IM NEW TO C# AND IF IT AINT BROKE DONT FIX IT
    // ITS ALSO 1:10AM 
    void stopAttackReadyAGAIN()
    {
        anim.SetBool("attackReady", false);
    }

    void teleport()
    {
        playerTeleport.transform.position = tpLoc[Random.Range(0, tpLoc.Length)].transform.position;
        playerTeleport.transform.rotation = tpLoc[Random.Range(0, tpLoc.Length)].transform.rotation;
    }

    void resetCombo()
    {
        anim.SetBool("attack", false);
        //attackReady = attackReadyTime;
        attackReadyBool = false;
        fisticuffs = false;
    }
}