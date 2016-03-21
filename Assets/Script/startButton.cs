using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {
	public GUISkin mySkin;
	public GameObject myParticle;
	public AudioClip biubiu;
	Animator anim;
	// Use this for initialization
	void OnGUI(){
		GUI.skin = mySkin;
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2-50,200,200),"","button"))
		{
			audio.PlayOneShot(biubiu);
			Debug.Log("dianji");
			Destroy(myParticle);
			anim = GetComponent<Animator>();
			anim.SetBool("isBegin", true);
			/*AnimatorStateInfo stateInfo = anim .GetCurrentAnimatorStateInfo(0);
            if(stateInfo.IsName("Base Layer.empty"))
			{
				Application.LoadLevel(1);
			}*/
			//isDown = true;
				//Application.LoadLevel(1);
		}	
			AnimatorStateInfo stateInfo = anim .GetCurrentAnimatorStateInfo(0);
            if(stateInfo.IsName("Base Layer.empty"))
			{
				Application.LoadLevel(1);
			}
	}
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
		
}
