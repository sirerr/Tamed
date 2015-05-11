using UnityEngine;
using System.Collections;

public class thanksman : MonoBehaviour {

	public float waittime = 0;

	// Use this for initialization
	void Start () {
	
		StartCoroutine(exitinggame());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator exitinggame()
	{
		yield return new WaitForSeconds(waittime);
		OVRPluginEvent.Issue(RenderEventType.PlatformUIConfirmQuit);
		 
	}
}
