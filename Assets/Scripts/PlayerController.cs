using System.Threading;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
	
	// Camera field of view = 49.3
	
	public float speed = 6f;
	public float rotationSpeed = 15f;

	private Vector3 movement;
	private Vector3 rotation;
//	private Quaternion rotation;
	private Transform playerTransform;
	private Animator animator;

	private void Awake () {
		animator = GetComponent<Animator>();
		playerTransform = GetComponentInChildren <Transform>();  //GetComponent<Transform>();
	}

	private void Update() {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		Move(h, v);

		float toAngleX = 0f;
		float toAngleY = 0f;
		float toAngleZ = 0f;

		bool isTurning = false;
		
		if (Input.GetButtonDown("Rotation Y"))
		{
			toAngleY = playerTransform.eulerAngles.y + 90;
			
//			Quaternion target = Quaternion.Euler(toAngleX, toAngleY, toAngleZ);
//			playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, target, 1); //Time.deltaTime * rotationSpeed);

			playerTransform.rotation = Quaternion.Euler(toAngleX, toAngleY, toAngleZ);
			
			isTurning = true;
		}

		Animate(isTurning);

//		int rotX = (int) Input.GetAxisRaw("Rotation X");
//		int rotY = (int) Input.GetAxisRaw("Rotation Y");
//		int rotZ = (int) Input.GetAxisRaw("Rotation Z");
//
//		Rotate(rotX, rotY, rotZ);
	}

	
	private void Move(float h, float v) {
		movement = new Vector3(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerTransform.position += movement;
	}

	private void Rotate(int rotX, int rotY, int rotZ) {
//		playerTransform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
		
		rotation = new Vector3(
			rotX != 0 ? 30 : 0, 
			rotY != 0 ? 30 : 0, 
			rotZ != 0 ? 30 : 0);

		playerTransform.eulerAngles += rotation;
	}
	
	private void Animate(bool isTurning)
	{
		animator.SetBool("isMoving", isTurning);
	}
}
