using UnityEngine;
using System.Collections;

public class ringgen : MonoBehaviour {

	public area1manager a1man;
	public GameObject[] rings;
	public int ringcolorcounter = 0;
	public Playercode playercode1;

	//test code
	public int ringcreatestate = 10;
	
	//test code

	// Update is called once per frame
	void Update () {
	
		if(a1man.startringgen)
		{
			print ("starting gen");
			a1man.startringgen = false;
			//startringgenerator();
			print (a1man.startringgen);
			//test code
			ringcreatestate = 0;
			//test code
		}
		
		switch (ringcreatestate)
		{
			case 0:
				startmakingrings();
				break;
			case 1:
				if	(playercode1.holdingring == 0)
					{	
				print (a1man.startringgen);
						a1man.startringgen = true;
					}
				break;
		case 2:
				if(playercode1.holdingring == 1)
			{
				ringcreatestate = 1;
			}
			break;
		}		
	}
	
	//use this function to create rings
	public void startmakingrings()
	{
		Instantiate(rings[ringcolorcounter],transform.position,transform.rotation);
		ringcreatestate = 2;
		if(ringcolorcounter == rings.Length-1)
			{
				ringcolorcounter = 0;
			}
			else
			{
				ringcolorcounter++;
			}
	}

}
        