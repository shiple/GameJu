using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour 
{
	public AudioClip[] list;
	int m_blood;
	public int MyBlood
	{
		set { m_blood = value; }
		get { return m_blood; }
	}

	GameObject[] bloodPic;
	GameObject currentPic;
	// Use this for initialization
	void Start () 
	{
		m_blood = 10;
		bloodPic = new GameObject[11];
		bloodPic[0] = Resources.Load("11")as GameObject;
		bloodPic[1] = Resources.Load("10")as GameObject;
		bloodPic[2] = Resources.Load("09")as GameObject;
		bloodPic[3] = Resources.Load("08")as GameObject;
		bloodPic[4] = Resources.Load("07")as GameObject;
		bloodPic[5] = Resources.Load("06")as GameObject;
		bloodPic[6] = Resources.Load("05")as GameObject;
		bloodPic[7] = Resources.Load("04")as GameObject;
		bloodPic[8] = Resources.Load("03")as GameObject;
		bloodPic[9] = Resources.Load("02")as GameObject;
		bloodPic[10] = Resources.Load("01")as GameObject;

		 currentPic = Instantiate(bloodPic[10],this.transform.position,Quaternion.identity)as GameObject;

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void RemoveBlood()
	{
		//audio.volume = 10000;
		audio.PlayOneShot(list[GetRandomCount(0,6)]);

		if (m_blood > 0) 
		{
			m_blood -= 1;
			GameObject temp = Instantiate(bloodPic[m_blood],this.transform.position,Quaternion.identity)as GameObject;
			Destroy (currentPic);
			currentPic = temp;
			Debug.Log (m_blood);
		}
		else if (m_blood == 0)
		{
			GameObject temp = Instantiate(bloodPic[0],this.transform.position,Quaternion.identity)as GameObject;
			Application.LoadLevel("end");
		}


	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log (m_blood);
		if (collision.gameObject.tag == "FeiZao")
		{
			RemoveBlood();
		}
			
	}
	int GetRandomCount (int from, int to)
	{
		return (int)(Random.Range (from, to) + 0.5);
	}

}

