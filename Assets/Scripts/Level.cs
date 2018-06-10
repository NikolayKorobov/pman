using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public GameObject pacman;
	public GameObject coins;

	// Update is called once per frame
	void Update () {

		if(pacman == null)
		{
			SceneManager.LoadScene("Level");
		}

		if (coins.transform.childCount == 0)
		{
			SceneManager.LoadScene("Level");
		}
		
	}
}
