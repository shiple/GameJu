using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {
	public GUISkin pause;
	// Use this for initialization

	void OnGUI()
	{
		GUI.skin = pause;
		if(GUI.Button(new Rect((Screen.width/2)- 26,0,80,80),"","button"))
		{
			Application.LoadLevel(2);
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
