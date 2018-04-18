using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCube : MonoBehaviour {

    public GameObject cubePiece;

    int[,] layers = new int[,] {{ 0,0,0,
                                  0,0,0,
                                  0,0,0 }, 
                                { 1,1,1,
                                  1,1,1,
                                  1,1,1 }, 
                                { 2,2,2,
                                  2,2,2,
                                  2,2,2 },
                                { 3,3,3,
                                  3,3,3,
                                  3,3,3 }, 
                                { 4,4,4,
                                  4,4,4,
                                  4,4,4 }, 
                                { 5,5,5,
                                  5,5,5,
                                  5,5,5 }};

    /*
     Mapping
        U
    L   F   R   B
        U

    Color mapping
        R
    B   W   G   Y
        O

    Odd numbers are edges
    Even numbers are Corners
    */

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Instantiate(cubePiece, new Vector3(i, j , k), new Quaternion(0, 0, 0, 0));
                }

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
