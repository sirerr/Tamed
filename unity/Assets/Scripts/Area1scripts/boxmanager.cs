using UnityEngine;
using System.Collections;

public class boxmanager : MonoBehaviour {

	public GameObject[] boxes;
	public float timechange = 0;
	public Material[] boxcolors;

	// Use this for initialization
	void Start () {
	
		quickpoint();
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
