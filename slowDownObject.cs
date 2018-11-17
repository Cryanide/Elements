using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDownObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destroyMe", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void destroyMe()
    {
        Destroy(gameObject);
    }
}
