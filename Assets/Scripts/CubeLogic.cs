using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour {
    //Variable for storing the structure of the cube
    Structure  cubeStructure;
    private string[,] side;

    private Transform[] centerPieces;
    private Transform[] cornerPieces;
    private Transform[] edgePieces;
    //Variable for selecting which side to rotate
    public int selector;

    public bool startRotation = false;
	// Use this for initialization
	void Start () {
        cubeStructure = new Structure();
        InitializePieces();
        rotateSide();

    }
	
	// Update is called once per frame
	void Update () {
        if (startRotation == true)
        {
            rotateSide();
            startRotation = false;
        }
        //rotateSide();
    }
    public void rotateSide()
    {
        Debug.Log("Rotating " + selector);
        side = cubeStructure.GetSelectedSide(selector);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log(side[i, j]);
                GameObject.FindWithTag(side[i, j]).transform.parent = centerPieces[selector];
                
            }
        }
        cubeStructure.Rotate(selector);
        for (int i = 0; i < 90; i++)
        {
           centerPieces[selector].Rotate(new Vector3(0, 1, 0), Space.Self);
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (side[i, j].Contains("Center"))
                {
                    GameObject.FindWithTag(side[i, j]).transform.parent = centerPieces[selector];
                }
                else
                {
                    GameObject.FindWithTag(side[i, j]).transform.parent = GameObject.FindGameObjectWithTag("Main").transform;
                }
            }
        }
        InitializePieces();
        Debug.Log("Done!");
    }
    private void InitializePieces()
    {
        centerPieces = new Transform[6];
        cornerPieces = new Transform[8];
        edgePieces = new Transform[12];

        for (int i = 0; i < 6; i++)
        {
            centerPieces[i] = GameObject.FindGameObjectWithTag("Center Piece " + (i + 1)).transform;          
        }
        for (int i = 0; i < 8; i++)
        {
            cornerPieces[i] = GameObject.FindGameObjectWithTag("Corner Piece " + (i + 1)).transform;
        }
        for (int i = 0; i < 12; i++)
        {
            edgePieces[i] = GameObject.FindGameObjectWithTag("Edge Piece " + (i + 1)).transform;
        }
    }
}
