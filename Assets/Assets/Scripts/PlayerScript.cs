using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	

		// check the poistion

	}
	void OnCollisionEnter(Collision other)
	{
	
		if(other.gameObject.tag == "fight")
		{
			print ("you lose");
			Application.LoadLevel(2);
		}
	}
}
