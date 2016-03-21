using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

	float tim = 0;

	GameObject[] hb;
	int count = 0;
	Vector3 childPos;
	Vector3 targetPos;
	Vector3 currentPos;
	Vector3 newPos;
	// Update is called once per frame
	void Start ()
	{
		hb = new GameObject[10];
		hb[0] = Resources.Load("hb0") as GameObject;
		hb[1] = Resources.Load("hb1") as GameObject;
		hb[2] = Resources.Load("hb2") as GameObject;
		hb[3] = Resources.Load("hb3") as GameObject;
		hb[4] = Resources.Load("hb4") as GameObject;
		hb[5] = Resources.Load("hb5") as GameObject;
		hb[6] = Resources.Load("hb6") as GameObject;
		hb[7] = Resources.Load("hb7") as GameObject;
		hb[8] = Resources.Load("hb8") as GameObject;
		hb[9] = Resources.Load("hb9") as GameObject;
	}
	void Update () {
		tim += Time.deltaTime;
		if (tim >= 1.0f)
		{
			count += 1;
			tim = 0.0f;
		}
		/*if (Input.GetMouseButtonDown(0))
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("jh");
			foreach (GameObject tem in temp)
			{
				//tem.gameObject.activeInHierarchy = false;
				tem.SetActive(true);
				Debug.Log(tem.activeSelf);
			}
			GameObject.Find("hb0").GetComponent<huaban>().IsMove(Count());
		}*/
	}
	Vector3 Count()
	{
		childPos = hb[0].transform.localPosition;
		Debug.Log(childPos.ToString());
		//targetPos = (GameObject.Find("pot1").transform.localPosition - GameObject.Find("point").transform.localPosition) * 3 ;
		targetPos = (childPos - GameObject.Find("point").transform.localPosition) * 5;
		return targetPos;

		//newPos.x = Mathf(currentPos.x, targetPos);


	}
}
