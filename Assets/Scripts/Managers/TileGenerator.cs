using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public Transform tileObj;
    public Vector2 startPoint;
    public Vector2 endPoint;

	// Use this for initialization
	void Start ()
    {
        for (int i = (int)startPoint.x; i < endPoint.x; i++)
        {
            for(int j = (int)startPoint.y; j < endPoint.y; j++)
            {
                Instantiate(tileObj, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
