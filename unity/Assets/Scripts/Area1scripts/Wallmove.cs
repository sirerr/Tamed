using UnityEngine;
using System.Collections;

public class Wallmove : MonoBehaviour {

	public GameObject[] walls;
	public bool startwalls = false;
	public float wallspeed;

	//area1manager
	public area1manager area1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey(KeyCode.F))
		{
			startwalls = true;
		}



		if(startwalls)
		{
			for(int i =0; i<walls.Length;i++)
			{
			walls[i].gameObject.transform.Translate(0,0,wallspeed* Time.deltaTime);
			}
		}

	}
}
