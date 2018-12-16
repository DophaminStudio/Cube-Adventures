using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("road"))
        {
            //Debug.Log(gameObject.name);
            //gameObject.SetActive(false);
            transform.position = new Vector3(transform.position.x + 100f, 0, transform.position.z);

        }
    }
}
