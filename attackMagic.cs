using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackMagic : MonoBehaviour
{
    int selection;

    public Transform[] spawnLocations;
    public GameObject[] whatToSpawn;
    public GameObject[] whatToSpawnClone;
    public static bool cooldown = false;
    public float timeLeft = 20f;
    public Text cooldownText;


    void spawnAttack()
    {
        whatToSpawnClone[selection] = Instantiate(whatToSpawn[selection], spawnLocations[selection].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }


    IEnumerator destroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(whatToSpawnClone[selection]);
        //cooldown = true;
    }

    void warmedUp()
    {
        cooldown = false;
        timeLeft = 20f;
    }
    void cooled()
    {
        cooldown = true;
    }

    IEnumerator cooleder(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        cooldown = true;
        timeLeft = cooldownTime;
    }

    void Update()
    {

        if (cooldown)
        {
            timeLeft -= Time.deltaTime;
            //print(timeLeft);
            if (timeLeft <= 0) warmedUp();
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && !cooldown)
        {
            selection = 2;
            Invoke("spawnAttack", 0.5f);
            StartCoroutine(cooleder(1f));

        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && !cooldown)
        {

            selection = 0;
            Invoke("spawnAttack", 0.5f);
            Invoke("cooled", 0.2f);


        }
        if (Input.GetKeyDown(KeyCode.Keypad9) && !cooldown)
        {
            selection = 1;
            Invoke("spawnAttack", 1f);
            Invoke("cooled", 0.2f);
        }
    }
}
