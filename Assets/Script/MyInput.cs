using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour {

	private float firstPointX;
	private float firstPointY;
	private float secondPointX;
	private float secondPointY;
	private float angle;
	protected float dir;
	Vector3 fir;
	Vector3 sec;
	GameObject hero;
	void Start ()
	{
		hero = GameObject.FindGameObjectWithTag("Hero");
	}
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			firstPointX = Input.mousePosition.x;
			firstPointY = Input.mousePosition.y;
			fir = Input.mousePosition;
			hero.GetComponent<Hero>().currentState = Hero.MyState.dianji;
		}
		if (Input.GetMouseButtonUp (0))
		{
			secondPointX = Input.mousePosition.x;
			secondPointY = Input.mousePosition.y;
			sec = Input.mousePosition;

			hero.GetComponent<Hero>().MyDirection = sec - fir;
			hero.GetComponent<Hero>().MyPower = 5000;
			hero.GetComponent<Hero>().IsDown = true;
			hero.GetComponent<Hero>().currentState = Hero.MyState.move;
		}
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
	private Vector3 CalculateAngle (float firX, float firY, float secX, float secY)
	{
		return (sec - fir);
		angle = Mathf.Atan ( (secY-firY) / (secX-firX) ) * Mathf.Rad2Deg ;
		//Debug.Log (angle+180);
		/*
		if (angle <= 90.0f  && angle >= 0.0f)
		{
			if ( (secX-firX) > 0)
				//return angle;
			if ( (secX-firX) < 0)
				//return (angle + 180);
		

		}
		if (angle >= -90.0f && angle <= -0.0f )
		{
			if ( (secY-firY) >0)
				//return (180 + angle);
			if ( (secY-firY) <0)
				//return (360 + angle);
		}

		return 0;
		*/
	}
}
