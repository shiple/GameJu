using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

	float len = 0.6f;
	float timer = 0.0f;
	public AudioClip[]  list;
	void Start ()
	{
		//list = new AudioClip[8];
		audio.PlayOneShot(list[GetRandomCount(0,8)]);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > len )
		{
			Destroy(this.gameObject);
		}
	}
	int GetRandomCount (int from, int to)
	{
		return (int)(Random.Range (from, to) + 0.5);
	}
}
