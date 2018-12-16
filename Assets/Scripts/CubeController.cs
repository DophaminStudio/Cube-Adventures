using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public StraigtRotation strRot;

    public GameObject cube;
    private Transform cubeTransform;

    private float inpX;
    private float inpZ;
    private float inpJump;

    public float rotateSpd = 5f;
    public float jumpHeight = 1f;
    public float jumpSpd = 0.15f;
    public float fallSpd = 0.08f;

    private bool isRotating = false;
    private bool isJumping  = false;
    private bool isFalling  = false;
    private float maxJumpHeight;
    private float groundHeight;


    void Start () {
        cubeTransform = cube.transform;
        groundHeight = transform.position.y;
        maxJumpHeight = transform.position.y + jumpHeight;
    }
	
	// get input
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            inpX = -1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            inpX = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            inpZ = 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            inpZ = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            inpJump = 1;
        }
    }

    // logic
    private void FixedUpdate()
    {
        // второе условие запрещает одновременный поворот в 2ух осях
        if ((inpX != 0 || inpZ != 0) && !(inpX != 0 && inpZ != 0)) {
            if (inpX != 0) {
                strRot.rotAroundZ(inpX);
            }
            if (inpZ != 0) {
                strRot.rotAroundX(inpZ);
            }
        }

        /* 
         * считаем поворот куба как суперпозицию поворота родительского объекта
         * с поворотом объекта, показывающего вращение в глобальной системе координат
         */
        cubeTransform.rotation = Quaternion.Lerp(
            cubeTransform.rotation,
            transform.rotation * strRot.getSlaveRotation(), 
            Time.deltaTime * rotateSpd);

        resetInput();
    }

    private void resetInput() {
        inpX    = 0;
        inpZ    = 0;
        inpJump = 0;
    }
}
