using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) 
	{
		if (coll.gameObject.tag == "FeiZao")
			coll.gameObject.GetComponent<Rigidbody2D>().drag = 0.5f;
		if (coll.gameObject.tag == "Hero")
			coll.gameObject.GetComponent<Rigidbody2D>().drag = 2.0f;
	}
}
