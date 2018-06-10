using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour {

	private bool isDetected;
	private string name;

	public string Name
	{
		get { return name; name = ""; }
	}
    
	// Update is called once per frame
	public bool Detection (Vector3 direction, float size, Color color) {

		RaycastHit hit;
		Ray ray = new Ray(transform.position, direction);

		if (Physics.Raycast(ray, out hit, size))
		{
			Debug.DrawLine(transform.position, hit.point, color);
			name = hit.collider.tag;
			return true;
		}

		else return false;
		
	}
}
