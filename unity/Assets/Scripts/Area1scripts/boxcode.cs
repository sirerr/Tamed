using UnityEngine;
using System.Collections;

public class boxcode : MonoBehaviour {

	public area1manager area1;

	void OnCollisionEnter(Collision gothit)
	{
		print("ring got hit");
		if(gothit.gameObject.tag == "Ring")
		{
			if(transform.renderer.material == gothit.gameObject.transform.renderer.material)
			{
				area1.ringcouter ++;
			}
			Destroy(gothit.gameObject);
		}

	}

}
