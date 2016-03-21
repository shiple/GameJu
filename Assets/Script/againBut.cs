using UnityEngine;
using System.Collections;

public class againBut : MonoBehaviour {

	public Texture2D a;
	public Texture2D b;
	public Transform pos;
	bool isDown;
	public AudioClip doo;
	void Start ()
	{
		this.guiTexture.texture = a;
		//this.guiTexture.pixelInset = 
	}
	void OnMouseEnter()
	{
		this.guiTexture.texture = b;
		audio.PlayOneShot(doo);
	}
	void OnMouseExit ()
	{
		this.guiTexture.texture = a;
		isDown = false;
	}


	IEnumerator OnMouseDown(){
		isDown = true;
		
		yield return new WaitForSeconds(0.35f);
		if (isDown)
		{
			guiTexture.texture = b;
			Application.LoadLevel("mainScene");
		}
			
	}
}
