using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacman : MonoBehaviour {
	
    public float speed;   //Скорость
	public int healt;     //Здоровье
	private int coins;    //Очки
    
    private ActerManager acterManager;
	private RaycastManager raycastManager;

    public Text textCoins;

	void Start()
	{
		acterManager = GetComponent<ActerManager>();
	    raycastManager = GetComponent<RaycastManager>();

		acterManager.SetSpeed = speed;
		coins = 0;
	}

	// Update is called once per frame
	void Update ()
	{

        //вниз
		if (Input.GetKey(KeyCode.S)){
			if (!raycastManager.Detection(acterManager.Direction(), 0.6f, Color.white)){
			    acterManager.MoveBack();
		    }
		    
		}

        //Верх
		if (Input.GetKey(KeyCode.W)){
			if (!raycastManager.Detection(acterManager.Direction(), 0.6f, Color.white)){
			    acterManager.MoveForward();
		    }
			
		}

        //Вправо
		if (Input.GetKey(KeyCode.A)){
			   if (!raycastManager.Detection(acterManager.Direction(), 0.6f, Color.white)){
			       acterManager.MoveLeft();
		    }
			
		}

        //Влево
		if (Input.GetKey(KeyCode.D)){
			if (!raycastManager.Detection(acterManager.Direction(), 0.6f, Color.white)){
			    acterManager.MoveRight();
		    }
		}

        //Пока впереди нет преграды двигатся по направлению
		if (raycastManager.Detection(acterManager.Direction(), 0.6f, Color.blue))
		{
			if (raycastManager.Name == "Block"){
				acterManager.MoveStop();
			}
		}

        //Остановится
		if (Input.GetKey(KeyCode.Space)){
			acterManager.MoveStop();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Coins"){
			coins += 1;
			textCoins.text = "Coins: " + coins;
		}

	}
}
