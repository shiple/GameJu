using UnityEngine;
using System.Collections;

public class huaban : MonoBehaviour {
	bool isMove = false;
	Vector3 targetPos;
	Vector3 newPos;
	Vector3 current;
	public Transform target;

	// Use this for initialization
	void Start () {
		current = transform.InverseTransformPoint(transform.position);
		Debug.Log (current);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMove)
		{

			current =  transform.position;
			newPos.x = Mathf.Lerp(current.x, targetPos.x, 0.95f*Time.deltaTime);
			newPos.y = Mathf.Lerp(current.y, targetPos.x, 0.95f*Time.deltaTime);
			transform.localPosition = newPos;
			if (current == targetPos)
				isMove = false;
		}
	}
	public void IsMove(Vector3 tgtPos)
	{
		animation.Play("hb");
		isMove = true;
		targetPos = tgtPos;
		Debug.Log(targetPos);
	}
}
