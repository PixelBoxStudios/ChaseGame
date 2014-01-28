
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour
{
	private float rotSpeed = 200f;
	private float runSpeed = 300f;
	private float maxPitch = -.2f;
	private float minPitch = -.53f;
	private float speedMultiplier = 1f;

	private float minYaw = -0.1f;
	private float maxYaw = 0.1f;
	private GameObject[] camArray;

	private GameObject rClaw;
	public GameObject lClaw;

	public bool canThrust;
	public GameObject smallRock;
	public GameObject largeRock;
	public GameObject rockPile;

	private GameObject rock;
	private GameObject rock2;

	private GameObject cubePointL;
	private GameObject cubePointR;

	private bool isGrabbing;
	private bool hasRock;

	private bool isGrabbing2;
	private bool hasRock2;

	private bool hasThrown;
	private bool hasThrown2;

	void Start()
	{

		Reset ();

	}

	void Reset()
	{
		canThrust = false;
		camArray = GameObject.FindGameObjectsWithTag("MainCamera");
		rClaw = GameObject.Find ("claw_close_R");
		lClaw = GameObject.Find ("claw_close_L");
		cubePointL = GameObject.Find ("Cube_Claw_L");
		cubePointR = GameObject.Find ("Cube_Claw_R");

		isGrabbing = false;
		hasRock = false;
		isGrabbing2 = false;
		hasRock2 = false;
		hasThrown = false;
		hasThrown2 = false;


	}
	
	void Update()
	{
		if (canThrust)
		{
			UseThrusters();
		}

		else
		{
			JoystickMove();
			Buttons();
		}
	}

	void Buttons()
	{
		if(SixenseInput.Controllers[0].Trigger >= .5)
		{
//			print ("Left Grippy");
//			hasThrown = false;
//
//			if(!isGrabbing)
//			{
//				if(!hasRock)
//				{
//					if(rock)
//					{
//						Destroy(rock);
//					}
//					rock = (GameObject)Instantiate(smallRock, cubePointL.transform.position, cubePointL.transform.rotation);
//					hasRock = true;
//				}
//
//				isGrabbing = true;
//			}
//
//			if(hasRock)
//			{
//				Vector3 temp = cubePointL.transform.position;
//				rock.gameObject.transform.position = temp;
//				rock.AddComponent("Rigidbody");
//			}
//		}
//
//		else
//		{
//			isGrabbing = false;
//			hasRock = false;
//
//			if(!hasThrown && rock != null)
//			{
//				rock.rigidbody.AddForce (cubePointL.transform.forward * runSpeed * 2);
//				rock.rigidbody.AddForce (cubePointL.transform.up * 100);
//
//				hasThrown = true;
//			}
		}

		if(SixenseInput.Controllers[1].Trigger >= .5)
		{
			//print ("Right Grippy");
			hasThrown2 = false;

			if(!isGrabbing2)
			{
				//print("YARP");
				if(!hasRock2)
				{
					if(rock2)
					{
						Destroy(rock2);
					}
					
					rock2 = (GameObject)Instantiate(largeRock, cubePointR.transform.position, cubePointR.transform.rotation);
					hasRock2 = true;
				}
				
				isGrabbing2 = true;
			}
			
			if(hasRock2)
			{
				Vector3 temp2 = cubePointR.transform.position;
				rock2.gameObject.transform.position = temp2;
				rock2.AddComponent("Rigidbody");
				//rock2.rigidbody.velocity = this.gameObject.transform.forward * 100 * SixenseInput.Controllers [0].JoystickX;
				rock2.rigidbody.AddForce(cubePointR.transform.forward * 30, ForceMode.Impulse);
			}
		}

		else
		{
			isGrabbing2 = false;
			hasRock2 = false;
		}
	}

	void JoystickMove() // THE FIRST JOYSTICK YOU MOVE IS BOUND TO [0]!!! I'M TOO LAZY TO FIX IT NOW, JUST A FOREWARNING!!!
	{
		transform.Translate (Vector3.right * SixenseInput.Controllers [0].JoystickX * runSpeed * Time.deltaTime);
		transform.Translate (Vector3.forward * SixenseInput.Controllers [0].JoystickY * runSpeed * Time.deltaTime);

		transform.RotateAround (transform.position, Vector3.up, rotSpeed * SixenseInput.Controllers [1].JoystickX * Time.deltaTime);
	}

	void UseThrusters()
	{
		if (canThrust)
		{
			if (SixenseInput.Controllers [0].Rotation.x >= maxPitch && SixenseInput.Controllers [1].Rotation.x <= minPitch) 
			{
				//Turn Clockwise Fast
				//print ("CW Fast");
				transform.RotateAround (transform.position, Vector3.up, rotSpeed * speedMultiplier * Time.deltaTime);
			}

			else if (SixenseInput.Controllers [0].Rotation.x <= minPitch && SixenseInput.Controllers [1].Rotation.x >= maxPitch) 
			{
				//Turn CCW Fast
				//print ("CCW Fast");
				transform.RotateAround(transform.position, Vector3.up , -rotSpeed * speedMultiplier * Time.deltaTime);
			}

			else if (SixenseInput.Controllers [0].Rotation.x >= maxPitch && SixenseInput.Controllers [1].Rotation.x >= maxPitch) 
			{
				//Go Forward
				//print ("Forward");
				transform.Translate(Vector3.forward * runSpeed * speedMultiplier * Time.deltaTime);
			}

			else if (SixenseInput.Controllers [0].Rotation.x <= minPitch && SixenseInput.Controllers [1].Rotation.x <= minPitch) 
			{
				//Reverse
				//print ("Reverse");
				transform.Translate(Vector3.forward * -runSpeed * Time.deltaTime);		
			}

			else if (SixenseInput.Controllers [0].Rotation.x >= maxPitch || SixenseInput.Controllers [1].Rotation.x <= minPitch)
			{
				//Turn CCW slow
				//print ("CW Slow");
				transform.RotateAround(transform.position, Vector3.up , rotSpeed * Time.deltaTime);
				transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
			}
			
			else if (SixenseInput.Controllers [0].Rotation.x <= minPitch || SixenseInput.Controllers [1].Rotation.x >= maxPitch)
			{
				//Turn Clockwise Slow
				//print ("CCW Slow");
				transform.RotateAround (transform.position, Vector3.up, -rotSpeed * Time.deltaTime);
				transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
			}

			//Strafing
			if(SixenseInput.Controllers [0].Rotation.z + SixenseInput.Controllers [0].Rotation.y >= maxYaw && SixenseInput.Controllers [1].Rotation.z + SixenseInput.Controllers [1].Rotation.y >= maxYaw)
			{
				//print ("Strafe Left");
				transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
			}

			if(SixenseInput.Controllers [0].Rotation.z + SixenseInput.Controllers [0].Rotation.y <= minYaw && SixenseInput.Controllers [1].Rotation.z + SixenseInput.Controllers [1].Rotation.y <= minYaw)
			{
				//print ("Strafe Right");
				transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
			}
		}
	} //End UseThrusters()
} //END OF LINE
