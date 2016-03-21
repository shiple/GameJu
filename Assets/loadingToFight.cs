using UnityEngine;
using System.Collections;

public class loadingToFight : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void OnGUI(){

			anim = GetComponent<Animator>();
			AnimatorStateInfo stateInfo = anim .GetCurrentAnimatorStateInfo(0);
			if(stateInfo.IsName("Base Layer.change"))
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
