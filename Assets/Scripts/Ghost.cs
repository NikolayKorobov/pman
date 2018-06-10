using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public int speed;              //Скорость
	public int speedLogic;         //Скорость выбора направления
	public GameObject pacman;      //Объект за которым следовать, от которого бежать

    private StateList state;                  //Состояние объекта
    private ActerManager acterManager;         
	private RaycastManager raycastManager;


    enum StateList
	{
		forward,
		back,
		left,
		right,
		inactivity
	}
    
	// Use this for initialization
	void Start () 
	{
		//Утсановка параметров для актера
		acterManager = GetComponent<ActerManager>();
        raycastManager = GetComponent<RaycastManager>();

		acterManager.SetSpeed = speed;
		state = StateList.inactivity;

		StartCoroutine(StateRandom());
	}

    void Update()
	{

		switch(state){

		case StateList.right :
            if (!raycastManager.Detection(new Vector3(0, 0, 1), 0.6f, Color.red))
		       acterManager.MoveRight();
		    break;
		
		case StateList.forward :
		    if(!raycastManager.Detection(new Vector3(-1, 0, 0), 0.6f, Color.red))
		       acterManager.MoveForward();
			break;
        
		case StateList.left :
		    if(!raycastManager.Detection(new Vector3(0, 0, -1), 0.6f, Color.red))
		       acterManager.MoveLeft();
			break;
        
		case StateList.back :
		    if(!raycastManager.Detection(new Vector3(1, 0, 0), 0.6f, Color.red))
		       acterManager.MoveBack();
			break;

		case StateList.inactivity :
		    acterManager.MoveStop();
		break;
		}

		//Пока впереди нет преграды двигатся по направлению
		if (raycastManager.Detection(acterManager.Direction(), 0.6f, Color.blue))
		{
			if (raycastManager.Name == "Block") acterManager.MoveStop();
		}
        
		/*//Убить пакмана при сближений
		if (pacman != null && raycastManager.Detection(pacman.transform.position, 0.6f, Color.blue))
		{
			Destroy(pacman);
		}*/

	}

	void OnTriggerEnter(Collider col)
	{
		Destroy(pacman);
	}

    //Рандомный выбор перемешения
	IEnumerator StateRandom()
    {
        
        int pastRandom = 0;

		while(true)
		{
		int r = Random.Range(0, 5);

		switch (r)
		{
			case 0 :
			    if (pastRandom != 0){
				    state = StateList.inactivity;
					pastRandom = 0;
				}
			    else yield return null;
			break;

			case 1 :
			    if (pastRandom != 1){
				    state = StateList.back;
					pastRandom = 1;
				}
				else yield return null;
			break;

			case 2 :
			    if (pastRandom != 2){
				    state = StateList.forward;
				    pastRandom = 2;
				}
				 else yield return null;
			break;

			case 3 :
			    if (pastRandom != 3){
					state = StateList.left;
					pastRandom = 3;
				}
				else yield return null;
			break;
			
			case 4 :
			    if (pastRandom != 4){
					 state = StateList.right;
					 pastRandom = 4;
				}
				else yield return null;
			break;

		}

		yield return new WaitForSeconds(speedLogic);
		}
	}
}
