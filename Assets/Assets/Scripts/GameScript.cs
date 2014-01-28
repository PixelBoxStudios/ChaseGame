using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	private PlayerScript player;
	private bool isPlaying = false;




	public Transform playerT;

	void Start () {
		player = playerT.GetComponent<PlayerScript>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 temp = player.transform.position;
		if(player.transform.position != temp)
		{
			isPlaying = true;
		}
	}
}
