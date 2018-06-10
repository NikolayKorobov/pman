using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActerManager : MonoBehaviour {

	private int healt;
	private float speed;
	
    private stateCharacterList state;
    private float angleRotate;
	private Vector3 vectorMovement;
	private Vector3 vectorRotation;

    //Список состояния персонажа
    enum stateCharacterList
	{
		forward,
		back,
		left,
		right,
		inactivity
	};

    //Установка параметров
    public float SetSpeed
	{
		set { speed = value; }
	}

	public Vector3 Position
	{
		get { return transform.position; }
	}

	void Start()
	{
		state = stateCharacterList.inactivity;
		angleRotate = 90f;
	}

    void Update()
	{
		if (state != stateCharacterList.inactivity)
		{
			//Врашение куба
			float deltaAngle = speed * Time.deltaTime * Mathf.Rad2Deg;
		    transform.RotateAround(transform.position, vectorRotation, deltaAngle);

            //Перемешение куба
		    transform.position += vectorMovement * (deltaAngle / 90f);

			if (angleRotate < 90f) angleRotate += deltaAngle;
		    else angleRotate = 0;
	    }
	}

	//Движение вниз
	public void MoveBack()
	{
		if(angleRotate >= 85f && state != stateCharacterList.back)
		{
		    vectorRotation = new Vector3(0, 0, -1);
		    vectorMovement = new Vector3(1, 0, 0);
		    state = stateCharacterList.back;
			angleRotate = 0;

			//Округления позиций
			transform.rotation = Quaternion.Euler(RoundVectorTo(new Vector3(
				transform.rotation.x,
				 transform.rotation.y,
				  transform.rotation.z), 90f));
			transform.position = RoundVectorTo(transform.position, 1f, new Vector3(0.5f, 0.5f, 0.5f));
		}
	}
	//Движение Верх
	public void MoveForward()
	{
		if(angleRotate >= 85f && state != stateCharacterList.forward)
		{
		    vectorRotation = new Vector3(0, 0, 1);
		    vectorMovement = new Vector3(-1, 0, 0);
		    state = stateCharacterList.forward;
			angleRotate = 0;

			//Округления позиций
			transform.rotation = Quaternion.Euler(RoundVectorTo(new Vector3(
				transform.rotation.x,
				 transform.rotation.y,
				  transform.rotation.z), 90f));
			transform.position = RoundVectorTo(transform.position, 1f, new Vector3(0.5f, 0.5f, 0.5f));
		}
	}
    //Движение Влево
	public void MoveLeft()
	{
		if(angleRotate >= 85f && state != stateCharacterList.left)
		{
		    vectorRotation = new Vector3(-1, 0, 0);
		    vectorMovement = new Vector3(0, 0, -1);
		    state = stateCharacterList.left;
			angleRotate = 0;

			//Округления позиций
			transform.rotation = Quaternion.Euler(RoundVectorTo(new Vector3(
				transform.rotation.x,
				 transform.rotation.y,
				  transform.rotation.z), 90f));
			transform.position = RoundVectorTo(transform.position, 1f, new Vector3(0.5f, 0.5f, 0.5f));
		}
	}
	 //Движение Вправо
	public void MoveRight()
	{
		if(angleRotate >= 85f && state != stateCharacterList.right)
		{
		    vectorRotation = new Vector3(1, 0, 0);
		    vectorMovement = new Vector3(0, 0, 1);
		    state = stateCharacterList.right;
			angleRotate = 0;

			//Округления позиций
			transform.rotation = Quaternion.Euler(RoundVectorTo(new Vector3(
				transform.rotation.x,
				 transform.rotation.y,
				  transform.rotation.z), 90f));
			transform.position = RoundVectorTo(transform.position, 1f, new Vector3(0.5f, 0.5f, 0.5f));
		}
	}

	public void MoveStop()
	{
		state = stateCharacterList.inactivity;
		angleRotate = 90f;

		//Округления позиций
			transform.rotation = Quaternion.Euler(RoundVectorTo(new Vector3(
				transform.rotation.x,
				 transform.rotation.y,
				  transform.rotation.z), 90f));
			transform.position = RoundVectorTo(transform.position, 1f, new Vector3(0.5f, 0.5f, 0.5f));
	}

    public Vector3 Direction()
	{
		if (state == stateCharacterList.forward) return new Vector3(-1, 0, 0);
		if (state == stateCharacterList.back) return new Vector3(1, 0, 0);
		if (state == stateCharacterList.left) return new Vector3(0, 0, -1);
		if (state == stateCharacterList.right) return new Vector3(0, 0, 1);

		return Vector3.zero;
	}
	 //Для округления позиций
	private Vector3 RoundVectorTo(Vector3 vector, float approximation, Vector3 offset = default(Vector3)) 
    { 
        vector -= offset; 
        vector /= approximation; 
        float[] coords = new float[] { vector.x, vector.y, vector.z }; 

        for (int i = 0; i < coords.Length; i++) 
            coords[i] = Mathf.Round(coords[i]); 
        return new Vector3(coords[0], coords[1], coords[2]) * approximation + offset; 
    }


}
