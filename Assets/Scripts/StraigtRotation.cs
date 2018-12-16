using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraigtRotation : MonoBehaviour {

    private Vector3 axisForward = new Vector3(0, 0, 1);
    private Vector3 axisRight   = new Vector3(1, 0, 0);

	void Start () {
        // сбросим к глобальным координатам
        transform.rotation = Quaternion.identity;
	}

    public void rotAroundZ(float input) {
        transform.Rotate(-input * axisForward, 90f, Space.World);
    }

    public void rotAroundX(float input) {
        transform.Rotate(input * axisRight, 90f, Space.World);
    }

    public Quaternion getSlaveRotation() {
        return transform.rotation;
    }
}
