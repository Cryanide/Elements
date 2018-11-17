using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeYourself : MonoBehaviour
{

    public float removeTime;

    // Use this for initialization
    void Start()
    {
        Invoke("YeetusDeletus", removeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void YeetusDeletus()
    {
        Destroy(gameObject);
    }
}
