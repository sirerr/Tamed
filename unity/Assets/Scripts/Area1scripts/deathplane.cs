﻿using UnityEngine;
using System.Collections;

public class deathplane : MonoBehaviour {

	public void OnCollisionEnter(Collision fallingobj)
	{
		Destroy(fallingobj.gameObject);

	}

}
