﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform HeadTransform;
	public GameObject Projectile;

	// Use this for initialization
	void Start () {

		HeadTransform = transform.FindChild ("Head");
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 forward = new Vector3 (HeadTransform.forward.x, 0f, HeadTransform.forward.z);
		forward.Normalize ();
		transform.position += HeadTransform.forward * Time.deltaTime * 20.0f;

	//if it's x or z values are greater or less than set values, reset location

		if (transform.position.x >= 148f) {
			transform.position = new Vector3(-148f, 0f,transform.position.z);
		}else if (transform.position.x <= -148f) {
			transform.position = new Vector3(148f, 0f,transform.position.z);
		}else if (transform.position.z >= 148f) {
			transform.position = new Vector3(transform.position.x, 0f,-148f);
		}else if (transform.position.z <= -148f) {
			transform.position = new Vector3(transform.position.x, 0f,148f);
	}
}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Asteroid") {
			Destroy (collision.gameObject);
		}
	}

	public void Shoot(){
		Vector3 forward = new Vector3 (HeadTransform.forward.x, 0f, HeadTransform.forward.z);
		forward.Normalize ();
		Ray ray = new Ray (HeadTransform.position, forward);
		Instantiate(Projectile, ray.GetPoint(6), Quaternion.LookRotation (forward));
		Debug.Log("Shooting");
	}

}