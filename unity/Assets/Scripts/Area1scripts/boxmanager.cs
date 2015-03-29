using UnityEngine;
using System.Collections;

public class boxmanager : MonoBehaviour {

	public GameObject[] boxes;
	public float timechange = 0;
	public Material[] boxcolors;

	//connection to game manager
	public area1manager area1;

	// Use this for initialization
	void Start () {
	
		quickpoint();
	}


	void Update () {

		if(area1.task1start)
		{
			print("task1 complete");
			for(int i = 0; i<boxes.Length; i++)
			{
				boxes[i].rigidbody.isKinematic = false;
				boxes[i].rigidbody.useGravity = true;
			}
		}


	}

	public void quickpoint()
	{
		int temp = Random.Range(0,boxcolors.Length-1);
	
		for(int i = 0; i<boxes.Length; i++)
		{
			boxes[i].gameObject.renderer.material = boxcolors[temp];

			if(temp == boxcolors.Length-1)
			{
				temp = 0;
			}
			else
			{
				temp++;
			}

		}
		StartCoroutine(changingcolor());

	}
	IEnumerator changingcolor()
	{
		yield return new WaitForSeconds(timechange);
		quickpoint();
	}
}
