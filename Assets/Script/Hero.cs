using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	int power;
	float drag;
	Vector3 direction;
	bool isDown;
	Transform [] icon;
	public Transform hero_1;
	public Transform hero_2;
	public Transform hero_3;
	public Transform myBoom;
	//public int testPower = 8000;
	public int myID;
	Animator anim ;
	public bool isPeng = false;
	bool isChuQuan = false;
	public bool IsChuQuan
	{
		set { isChuQuan = value; }
		get { return isChuQuan; }
	}
	public enum MyState 
	{
		idle,
		dianji,
		move,
		pengzhuan,
	}
	public MyState currentState = MyState.idle;
	public int MyPower
	{
		set { power = value; }
		get { return power; }
	}
	public Vector3 MyDirection
	{
		set { direction = value; }
		get { return direction; }
	}
	public bool IsDown
	{
		set { isDown = value; }
		get { return isDown; }
	}
	public float MyDrag
	{
		set { drag = value; }
		get { return drag; }
	}
	public int MyID 
	{
		set { myID = value; }
		get { return myID; }
	}
	void Start () 
	{
		//Instantiate(hero, Vector3.zero,Quaternion.identity);
		MyPower = 5000;
		MyDrag = 0.3f;
		IsDown = false;
		IsChuQuan = false;
		myID = 1;
		icon = new Transform[3];
		icon[0] = hero_1;
		icon[1] = hero_2;
		icon[2] = hero_3;
		//	this.rigidbody2D.AddForce(Vector3.right * 300);
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		if (isDown)
		{
			this.rigidbody2D.drag = drag;
			this.rigidbody2D.AddForce(direction.normalized * power);
			isDown = false;
		}
		switch (myID)
		{
		case 1:
			if (anim)
			{
				//AnimationInfo info = anim.GetCurrentAnimatorStateInfo(0);
				switch (currentState)
				{
				case MyState.idle:
					anim.SetBool("idle",true);
					break;
				case MyState.dianji:
					anim.SetBool("touch", true);
					break;
				case MyState.move:
					anim.SetBool("move", true);
					break;
				case MyState.pengzhuan:
					anim.SetBool("peng", true);	
					break;
				}
			}
			break;
		case 2:
			break;
		case 3:
			break;
		}
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "FeiZao")
		{
			isPeng = true;
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			//dir = this.transform.position - coll.transform.position;
			//int power = GetComponent<Hero> ().MyPower;
			this.rigidbody2D.drag = 5.0f;
			GameObject boom = GameObject.Instantiate(myBoom, this.transform.position, Quaternion.identity) as GameObject;
			currentState = MyState.pengzhuan;
		}
		if (coll.gameObject.tag == "Hero")
		{
			if (coll.gameObject.GetComponent<Hero>().IsChuQuan)
			{
				if (this.gameObject.name == "hero_3(Clone)")
				{
					GameObject boom = GameObject.Instantiate(myBoom, this.transform.position, Quaternion.identity) as GameObject;
					currentState = MyState.pengzhuan;
					Destroy(coll.gameObject);
					Destroy(this.gameObject);
				}
			}


		}
	}
	int GetRandomCount (int from, int to)
	{
		return (int)(Random.Range (from, to) + 0.5);
	}
	public void SetMyState (int index)
	{
		switch(index)
		{
		case 0 :
			currentState = MyState.idle;
			break;
		case 1:
			currentState =MyState.dianji;
			break;
		case 2:
			currentState =MyState.move;
			break;
		case 3:
			currentState =MyState.pengzhuan;
			break;
		}
	}
}
