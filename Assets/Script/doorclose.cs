using UnityEngine;
using System.Collections;

public class doorclose : MonoBehaviour {
	//AudioClip doorclose;
	float timer = 0;
	public AudioClip doorClose;
	bool isPlay ;
	// Use this for initialization
	void Start () {
		isPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >=0.58f && !isPlay)
		{
			audio.PlayOneShot(doorClose);
			timer = 0;
			isPlay = true;
		}
	}
}
