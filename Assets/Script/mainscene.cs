using UnityEngine;
using System.Collections;

public class mainscene : MonoBehaviour {


	public GUISkin pause;
	public GUISkin window;
	public Rect windowRect = new Rect(20, 20, 500, 500);//窗口的位置
	public bool windowSwitch = false;
	public int iLeftBlood = 5;//左边玩家的血条
	public int iRightBlood = 5;//右边玩家的血条
	public int huihe = 20;//回合数
	public float r = Vector2.Distance(new Vector2(8.8f,4.8f),new Vector2(7.4f,3.6f));//半径
	int index;
	GameObject CurrentHero;
	bool paused = false;
	protected Vector3 dir;
	Vector3 fir;
	Vector3 sec;

	Vector3 leftpoint = new Vector3(-8,-4,1);//左边的水池的坐标
	Vector3 rightpoint = new Vector3(8,4,1);//右边的水池的坐标
	Vector3 pointR = new Vector3(8.8f,4.8f,0f);
	Vector3 pointL = new Vector3(-8.8f,-4.8f,0f);
	GameObject[] hero;
	bool isExistOne = false;
	int key = 0;
	int step = 0;
	//暂停游戏
	void OnPauseGame()
	{
		paused = true;
	}

	//恢复游戏
	void OnResumeGame()
	{
		paused = false;
	}

	void OnGUI()
	{
		/*GUI.skin = pause;

		if(GUI.Button(new Rect(0,0,100,100),"","button"))
		{
			Debug.Log("asd");
			OnPauseGame();
		}
		if(windowSwitch)
		{
			GUI.skin = window;
			windowRect = GUI.Window(0,windowRect,pausewindow,"myWindow");
		}

		void pausewindow( int windowID)
		{
			if(GUI.startButton("hello"))
			{

			}
		}
*/
	}

	// Use this for initialization
	void Start ()
	{

		hero = new GameObject[3];
		hero[0] = Resources.Load("hero_1")as GameObject;
		hero[1] = Resources.Load("hero_2")as GameObject;
		hero[2] = Resources.Load("hero_3")as GameObject;

	    index = GetRandomCount(0,3);
		CurrentHero = Instantiate(hero[index], rightpoint, Quaternion.identity)as GameObject;
		CurrentHero.GetComponent<Hero>().MyPower = 500;
		if (index == 2)
		{
			CurrentHero.GetComponent<Hero>().MyID = 3;
		}
		isExistOne = true;
		key = 1;//右边
	}
	
	// Update is called once per frame
	void Update ()
	{
		//step = 0;
		if(!paused)//判断游戏是否暂停
		{
			if(!isExistOne)
			{
				if (key == 1)
				{
					index = GetRandomCount(0,3);
					CurrentHero = Instantiate(hero[index], leftpoint, Quaternion.identity)as GameObject;
					if (index == 2)
					{
						CurrentHero.GetComponent<Hero>().MyID = 3;
					}
					key = 0;
					isExistOne = true;
				}
				else if (key == 0)
				{
					index = GetRandomCount(0,3);
					CurrentHero = Instantiate(hero[index], rightpoint, Quaternion.identity)as GameObject;
					if (index == 2)
					{
						CurrentHero.GetComponent<Hero>().MyID = 3;
					}
					key =1;
					isExistOne = true;
				}

			}

			if (Input.GetMouseButtonDown(0))
			{
				Vector3 temp= camera.ScreenToWorldPoint( Input.mousePosition);
				if (key == 1)
				{
					if (Vector3.Distance(temp, pointR) < r )
					{
						step ++;
						fir = Input.mousePosition;
					}
				}
				else if (key == 0)
				{
					if (Vector3.Distance(temp, pointL) < r )
					{
						step ++;
						fir = Input.mousePosition;
					}
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				Vector3 temp= camera.ScreenToWorldPoint( Input.mousePosition);
				if (key == 1)
				{
					if (Vector3.Distance(temp, pointR) > r )
					{
						if (step == 1)
						{
							sec = Input.mousePosition;
							dir = sec - fir;
							CurrentHero.GetComponent<Hero>().MyDirection = dir;
							CurrentHero.GetComponent<Hero>().IsDown = true;
							CurrentHero.GetComponent<Hero>().IsChuQuan = true;
							CurrentHero.gameObject.layer = 12;
							isExistOne = false;
							step = 0;
						}

					}
				}
				else if (key == 0)
				{
					if (Vector3.Distance(temp, pointL) > r )
					{
						if (step == 1)
						{
							sec = Input.mousePosition;
							dir = sec - fir;
							CurrentHero.GetComponent<Hero>().MyDirection = dir;
							CurrentHero.GetComponent<Hero>().IsDown = true;
							CurrentHero.GetComponent<Hero>().IsChuQuan = true;
							CurrentHero.gameObject.layer = 12;
							isExistOne = false;
							step = 0;
						}

					}
				}
			}
		}
			
			if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();

			if(iLeftBlood == 0)
			{
				Debug.Log("左边玩家输了");
			}

			if(iRightBlood == 0)
			{
				Debug.Log("右边玩家输了");
			}

	}
	int GetRandomCount (int from, int to)
	{
		return (int)(Random.Range (from, to) + 0.5);
	}

}