using UnityEngine;
using System.Collections;

public class FeiZao : MonoBehaviour {

	Vector3 dir = Vector3.zero;
	//public int power = 1500;

	void Start ()
	{
		//this.rigidbody2D.AddForce(Vector3.right * 500);
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Hero")
		{
			bool temp = coll.gameObject.GetComponent<Hero>().isPeng;
			{
				if (!temp)
				{
					this.rigidbody2D.drag = 0.0f;
					//coll.gameObject.SendMessage("ApplyDamage", 10);
					dir = this.transform.position - coll.transform.position;
					int power =coll.gameObject.GetComponent<Hero> ().MyPower;
					//Debug.Log(power);
					this.rigidbody2D.AddForce(dir * power);
				}
			}


		}
	}
}	
