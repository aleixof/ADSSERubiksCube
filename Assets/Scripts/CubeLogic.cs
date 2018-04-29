﻿using System.Collections;
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
        if(side != null)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject.FindWithTag(side[i, j]).transform.parent = GameObject.FindWithTag("Pivot").transform;
                }
            }
        }
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
            if (selector == 1 || selector == 3)
            {
                centerPieces[selector].Rotate(new Vector3(1, 0, 0), Space.Self);
            }
            if (selector == 0 || selector == 2)
            {
                centerPieces[selector].Rotate(new Vector3(0, 0, 1), Space.Self);
            }
            if (selector == 4 || selector == 5)
            {
                centerPieces[selector].Rotate(new Vector3(0, 1, 0), Space.Self);
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

    public void RotateFront()
    {
        selector = 0;
        startRotation = true;
    }

    public void RotateRight()
    {
        selector = 1;
        startRotation = true;
    }
    public void RotateBack()
    {
        selector = 2;
        startRotation = true;
    }
    public void RotateLeft()
    {
        selector = 3;
        startRotation = true;
    }
    public void RotateBottom()
    {
        selector = 4;
        startRotation = true;
    }
    public void RotateTop()
    {
        selector = 5;
        startRotation = true;
    }
}
