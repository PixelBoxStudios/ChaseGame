using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {
	public static GateScript Instance;
	public Texture2D [] gates;
	public Transform [] fightgates;
	public Transform [] runtriggers;
	public int num = 0;
	public bool give = false;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(give)
		{
			this.transform.renderer.material.mainTexture = gates[num];
			num++;
			give = false;
		}
	}
	public void IncText()
	{
		if(give)
		{
		this.transform.renderer.material.mainTexture = gates[num];
		num++;
			give = false;
		}
	}
	public void GameOver()
	{
		Destroy(this.gameObject);
	}

}
