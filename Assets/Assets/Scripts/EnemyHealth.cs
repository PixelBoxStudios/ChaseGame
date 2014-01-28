using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	 int health = 100;
	public ParticleEmitter hurt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
		{
			Application.LoadLevel(1);
			print("You Win");
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "rock")
		{
			health = health -20;
		    hurt.particleEmitter.Emit();

		}


	}

}
