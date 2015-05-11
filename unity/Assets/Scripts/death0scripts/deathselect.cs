using UnityEngine;
using System.Collections;

public class deathselect : MonoBehaviour {

	//button currently selected
	public GameObject buttonselected;
	//ray distance
	public float raydis = 0;

	//wait time to restarting
	public float restarttime = 0;

	public AudioClip deathspeech;
	public float deathspeechtime = 0;
	public bool okaytochoose = false;


	// Use this for initialization
	void Start () {
	
		StartCoroutine(deathspeechcor());

	}

	IEnumerator deathspeechcor()
	{
		audio.PlayOneShot(deathspeech);
		yield return new WaitForSeconds(deathspeechtime);
		okaytochoose = true;

	}

	public void raycastbutton()
	{
		RaycastHit lookatbutton;

		if(Physics.Raycast(transform.position,transform.forward,out lookatbutton,raydis))
		{
			if(lookatbutton.transform.gameObject.tag == "buttons")
			{

				if(lookatbutton.transform.gameObject.name == "restarter")
				{
					StartCoroutine(waitarea1());
				}
				else
				{
					StartCoroutine(waitarea0());
				}

			}

		}

	}
	// Update is called once per frame
	void Update () {
	

		if(okaytochoose)
			{
				raycastbutton();
			}
	}

	IEnumerator waitarea0()
	{
		yield return new WaitForSeconds(restarttime);
		Application.LoadLevel("area0");
	}

	IEnumerator waitarea1()
	{
		yield return new WaitForSeconds(restarttime);
		Application.LoadLevel("area1");
	}

}
