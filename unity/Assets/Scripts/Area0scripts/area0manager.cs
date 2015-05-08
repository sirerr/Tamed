using UnityEngine;
using System.Collections;

public class area0manager : MonoBehaviour {

	public float part1time = 0;
	public float timeuntilstart = 0;
	public ParticleSystem sparkps;
	public GameObject sparkobj;

	//eye quad
	public GameObject floatingeye;
	public float maincolorlow = 0;
	public float maincolorhigh =0;

	// Use this for initialization
	void Start () {
		StartCoroutine(talkthenstart());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator talkthenstart()
	{
		yield return new WaitForSeconds(part1time);
		sparkobj.SetActive(true);
		floatingeye.SetActive(true);

		sparkps.Play();
		yield return new WaitForSeconds(1f);
		floatingeye.SetActive(false);
		yield return new WaitForSeconds(2f);
		//particle system
		sparkobj.SetActive(true);
		sparkps.Play();
		floatingeye.SetActive(true);
		yield return new WaitForSeconds(timeuntilstart);
		Application.LoadLevel("area1");

	}
}
