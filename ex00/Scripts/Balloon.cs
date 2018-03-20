using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
	public	float	breath = 10.0f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (transform.localScale.x <= 0.5f || transform.localScale.x >= 7.0f)
			explode ();
		if (Input.GetKeyDown ("space") && breath >= 1) {
			transform.localScale *= 1.2f;
			breath -= 1;
		}
		else {
			transform.localScale *= 0.9f;
			if (breath < 5)
				breath += 0.5f;
		}
	}

	void explode () {
		GameObject.Destroy(this);
		Debug.Log ("Balloon life time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s\n");
	}
}