using UnityEngine;
using System.Collections;

public class ringgen : MonoBehaviour {

	public area1manager a1man;
	public GameObject[] rings;
	public int ringcolorcounter = 0;
	public Playercode playercode1;
	public bool madering = false;


	// Update is called once per frame
	void Update () {
	
		if(a1man.startringgen)
		{
			print ("starting gen");
			a1man.startringgen = false;
			startringgenerator();

		}
	}

	public void startringgenerator()
	{
		GameObject currentring;
		
		print("in ring gen");

		if(a1man.firsttimegen)
		{
			a1man.firsttimegen = false;
			currentring = Instantiate(rings[ringcolorcounter],transform.position,transform.rotation) as GameObject;
		}
		else if	(!playercode1.ringalive)
		{
		
			currentring = Instantiate(rings[ringcolorcounter],transform.position,transform.rotation) as GameObject;

			if(ringcolorcounter == rings.Length-1)
			{
				ringcolorcounter = 0;
			}
			else
			{
				ringcolorcounter++;
			}

		}

		StartCoroutine(waitasec());
	}

	IEnumerator waitasec()
	{
		yield return new WaitForSeconds(.5f);
		startringgenerator();
	}


}
