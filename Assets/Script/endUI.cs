using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class endUI : MonoBehaviour {

	float timer = 0;
	bool once = false;
	public Transform anmb;
	public Transform anmbPos;
	public Transform againPos;
	public Transform exitPos;
	public Texture2D again;
	public Texture2D exit;
	GUISkin Myskin;

	Rect rc;
	int index;
	public AudioClip doorclosr;
	public AudioClip doorslide;
	public AudioClip doorhit;

	void Start ()
	{
		//again = GameObject.Find ("zlyc")as Texture2D;
		//Myskin.button.onActive.background = exit;
		//Myskin.button.onNormal.background = again;
		//Myskin.button.name = "again";
		audio.PlayOneShot(doorslide);
	}
	void Update ()
	{

		timer += Time.deltaTime;
		if (timer > 1.3f && !once)
		{
			once = true;
			GameObject.Instantiate(anmb, anmbPos.position, Quaternion.identity);
			audio.PlayOneShot(doorhit);
		}
	}
	void OnGUI ()
	{
		if (once)
		{
			GUI.skin = Myskin;

			//{}
		}
	}
	void DoDownMethodName()
	{
		//Debug.Log("down.down");
	}
}
