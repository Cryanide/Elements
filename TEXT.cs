using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEXT : MonoBehaviour {

    Text cooldownText;
    public float timeLeft2 = 20f;

    public GameObject spawner;
    public attackMagic spawnerValue;

    // Use this for initialization
    void Start () {
        cooldownText = GetComponent<Text>();
        cooldownText.text = "";

        spawnerValue = spawner.GetComponent<attackMagic>();
    }
	
	// Update is called once per frame
	void Update () {

        if (spawner) timeLeft2 = spawnerValue.timeLeft;

        if (attackMagic.cooldown)
        {
            timeLeft2 -= Time.deltaTime;
            cooldownText.text = timeLeft2.ToString();
        }
        if (timeLeft2 <= 0)
        {
            timeLeft2 = 20f;
            cooldownText.text = attackMagic.cooldown.ToString();
        }
        
	}
}
