using UnityEngine;
using System.Collections;

public class boxcode : MonoBehaviour {

	public area1manager area1;
	public Playercode playercode1;

	void OnCollisionEnter(Collision gothit)
	{
	//	print("ring got hit");
		if(gothit.gameObject.tag == "Ring")
		{
			if(transform.renderer.material.color == gothit.gameObject.transform.renderer.material.color)
			{
				area1.ringcouter ++;
			}
			Destroy(gothit.gameObject);
			playercode1.holdingring = 0;
		}

	}

}
