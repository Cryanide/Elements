using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthShow : MonoBehaviour {

    public float health;    // health points
    public float maxHealth; // this value never changes in game, could honestly be a static to make my life eaiser, but I like the value in the inspector
                            // in case I want to make a boss

    public GameObject healthBarUI; 
    public Slider slider;

    public GameObject attack; // the attack (magical)
    public GameObject attackHand; // hand to hand 
    public attackDamage attackDamage;

   // private float slowTime = 3f;

    private float Dmg;
    private float ImpactDmg;

    void SetKinematic(bool newValue) // in this script it only enabkes ragdoll on death
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    void Start()
    {
        health = maxHealth; // makes sures health is full
        slider.value = CalculateHealth(); // since the slider only read 0 - 1, this method does the math (literally X / X)
        SetKinematic(true); // disables the ragdoll


    }

    void Update() // called every frame
    {
         /*print(Time.timeScale);
        if (Time.timeScale < 1f) InvokeRepeating("slowDown", 0.4f, 0.4f);
        if (Time.timeScale > 1f) Time.timeScale = 1f;*/

        attack = GameObject.FindGameObjectWithTag("powerHitbox"); // finds a power in the scene
        attackHand = GameObject.FindGameObjectWithTag("punchkicks"); // checks if the hand is enabled in the scene
        if (attack) attackDamage = attack.GetComponent<attackDamage>(); // checks if *attack* returns not null
        if (attackHand) attackDamage = attackHand.GetComponent<attackDamage>(); // checks if *attackHand* returns not null
        Dmg = attackDamage.damage;
        ImpactDmg = attackDamage.OnImpactDamage;

        slider.value = CalculateHealth(); 

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <= 0)
        {
            //Destroy(gameObject);
            SetKinematic(false);
            GetComponent<Animator>().enabled = false;
            healthBarUI.SetActive(false);
            //slowTime -= Time.deltaTime;
            //print(slowTime);
            /*if (slowTime > 0f)
            {
                slowDown();
            }*/
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("powerHitbox")) health = health - Dmg;
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("punchkicks")) health = health - ImpactDmg;
        if (collider.CompareTag("powerHitbox")) health = health - ImpactDmg;
        if (collider.CompareTag("attackKnockback")) health = health - ImpactDmg;
    }

    void slowDown()
    {
        Time.timeScale += 0.1f;
        if (Time.timeScale > 1f) Time.timeScale = 1f;
    }
}
