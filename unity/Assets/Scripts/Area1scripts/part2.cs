using UnityEngine;
using System.Collections;

public class part2 : MonoBehaviour {

	public bool  startringshower = false;
	
	public GameObject[] showerpoints;
	//ring array to use 
	public GameObject[] ringsforshower;
	//counter to figure out when to create the green ring
	public int greenringcounter = 0;
	public int greenringrequired = 0;

	public GameObject greenringobj;

	//values for smallpause
	public float lowsmallpause = 0;
	public float highsmallpause = 0;

	//value for ring mass
	public float ringmass = 0;
	//value for ring drag
	public float ringdrag = 0;
	
	void Start()
	{
		
	}
	
	void OnEnable()
	{
		//print("we're in");
		if(startringshower)
		{
			startshower();
		}
	}
	
public void startshower()
	{
		//print("start shower");
		for(int i =0; i<showerpoints.Length; i++)
		{
			GameObject aring;
			int ringcolor;
			ringcolor = Random.Range(0,ringsforshower.Length-1);
				
				if(greenringcounter == greenringrequired)
			{
				//create green ring
				aring = Instantiate(greenringobj,showerpoints[i].transform.position,showerpoints[i].transform.rotation)as GameObject;
				aring.gameObject.rigidbody.useGravity = true;
				aring.gameObject.rigidbody.drag = ringdrag;
				aring.gameObject.rigidbody.mass = ringmass;
				greenringcounter = 0;
			}
			else
			{
				//create color ring based on the random 
				aring = Instantiate(ringsforshower[ringcolor],showerpoints[i].transform.position,showerpoints[i].transform.rotation)as GameObject;
				aring.gameObject.rigidbody.useGravity = true;
				aring.gameObject.rigidbody.mass = ringmass;
				aring.gameObject.rigidbody.drag = ringdrag;
				greenringcounter++;
			}
			
		
		}
		StartCoroutine(smallpause());
	}
	
	
	IEnumerator smallpause()	
	{
		float quicktime;
		quicktime = Random.Range(lowsmallpause,highsmallpause);
		yield return new WaitForSeconds(quicktime);
		OnEnable();
	}


}
