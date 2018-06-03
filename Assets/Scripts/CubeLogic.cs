using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeLogic : MonoBehaviour
{
    //Variable for storing the structure of the cube
    CubeStructure cubeStructure;
    private string[,] side;
    private bool CW = true;

    private Transform[] centerPieces;
    private Transform[] cornerPieces;
    private Transform[] edgePieces;
    private Transform[] middleCubePiece;
    //Variable for selecting which side to rotate
    public int selector;

    int x1 = 1, y1 = 0, z1 = 0;
    int x2 = 0, y2 = 0, z2 = 1;
    int x3 = 0, y3 = 1, z3 = 0;

    public bool startRotation = false;
    // Use this for initialization
    void Start()
    {
        cubeStructure = new CubeStructure();
        InitializePieces();
        ShuffleCube();
        startRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (startRotation == true)
        {
            rotate();
            startRotation = false;
        }
    }
    public void rotate()
    {
        side = cubeStructure.GetSelectedSide(selector);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (selector > 5)
                {
                    Debug.Log(side[i, j]);
                    GameObject.FindWithTag(side[i, j]).transform.parent = middleCubePiece[0];
                }
                else
                {
                    Debug.Log(side[i, j]);
                    GameObject.FindWithTag(side[i, j]).transform.parent = centerPieces[selector];
                }
            }
        }
        if (CW)
        {
            rotateSideCW();
        }
        else if (!CW)
        {
            rotateSideCCW();
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject.FindWithTag(side[i, j]).transform.parent = GameObject.FindWithTag("Main").transform;
            }
        }
        for (int i = 0; i < 90; i++)
        {
            if (selector == 6)
            {
                if (CW)
                {
                    middleCubePiece[0].Rotate(new Vector3(0, 1, 0), Space.Self);
                }
                else
                {
                    middleCubePiece[0].Rotate(new Vector3(0, -1, 0), Space.Self);
                }
            }
            if (selector == 7)
            {
                if (CW)
                {
                    middleCubePiece[0].Rotate(new Vector3(1, 0, 0), Space.Self);
                }
                else
                {
                    middleCubePiece[0].Rotate(new Vector3(-1, 0, 0), Space.Self);
                }
            }
            if (selector == 8)
            {
                if (CW)
                {
                    middleCubePiece[0].Rotate(new Vector3(0, 0, 1), Space.Self);
                }
                else
                {
                    middleCubePiece[0].Rotate(new Vector3(0, 0, -1), Space.Self);
                }
            }
        }
    }
    public void rotateSideCW()
    {
        cubeStructure.RotateCW(selector);
        for (int i = 0; i < 90; i++)
        {
            if (selector == 1 || selector == 3)
            {
                centerPieces[selector].Rotate(new Vector3(x1 * -1, y1 * -1, z1 * -1), Space.Self);
            }
            if (selector == 0 || selector == 2)
            {
                centerPieces[selector].Rotate(new Vector3(x2 * -1, y2 * -1, z2 * -1), Space.Self);
            }
            if (selector == 4 || selector == 5)
            {
                centerPieces[selector].Rotate(new Vector3(x3 * -1, y3 * -1, z3 * -1), Space.Self);
            }
            if (selector == 6)
            {
                middleCubePiece[0].Rotate(new Vector3(0, -1, 0), Space.Self);
            }
            if (selector == 7)
            {
                middleCubePiece[0].Rotate(new Vector3(-1, 0, 0), Space.Self);
            }
            if (selector == 8)
            {
                middleCubePiece[0].Rotate(new Vector3(0, 0, -1), Space.Self);
            }
        }
        if (selector == 6)
        {
            Transform temp = centerPieces[0];
            centerPieces[0] = centerPieces[3];
            centerPieces[3] = centerPieces[2];
            centerPieces[2] = centerPieces[1];
            centerPieces[1] = temp;

            int temp1 = x1; int temp2 = y1; int temp3 = z1;
            x1 = x2; y1 = y2; z1 = z2;
            x2 = temp1; y2 = temp2; z2 = temp3;

        }
        if (selector == 7)
        {
            Transform temp = centerPieces[0];
            centerPieces[0] = centerPieces[5];
            centerPieces[5] = centerPieces[2];
            centerPieces[2] = centerPieces[4];
            centerPieces[4] = temp;

            int temp1 = x2; int temp2 = y2; int temp3 = z2;
            x2 = x3; y2 = y3; z2 = z3;
            x3 = temp1; y3 = temp2; z3 = temp3;

        }
        if (selector == 8)
        {
            Transform temp = centerPieces[5];
            centerPieces[5] = centerPieces[3];
            centerPieces[3] = centerPieces[4];
            centerPieces[4] = centerPieces[1];
            centerPieces[1] = temp;

            int temp1 = x1; int temp2 = y1; int temp3 = z1;
            x1 = x3; y1 = y3; z1 = z3;
            x3 = temp1; y3 = temp2; z3 = temp3;
        }
    }
    public void rotateSideCCW()
    {

        Debug.Log("Center: " + side[1, 1]);
        if (selector < 6)
        {
            Debug.Log("Center Piece: " + centerPieces[selector]);
        }
        cubeStructure.RotateCCW(selector);
        for (int i = 0; i < 90; i++)
        {
            if (selector == 1 || selector == 3)
            {
                centerPieces[selector].Rotate(new Vector3(x1, y1, z1), Space.Self);
            }
            if (selector == 0 || selector == 2)
            {
                centerPieces[selector].Rotate(new Vector3(x2, y2, z2), Space.Self);
            }
            if (selector == 4 || selector == 5)
            {
                centerPieces[selector].Rotate(new Vector3(x3, y3, z3), Space.Self);
            }
            if (selector == 6)
            {
                middleCubePiece[0].Rotate(new Vector3(0, 1, 0), Space.Self);
            }
            if (selector == 7)
            {
                middleCubePiece[0].Rotate(new Vector3(1, 0, 0), Space.Self);
            }
            if (selector == 8)
            {
                middleCubePiece[0].Rotate(new Vector3(0, 0, 1), Space.Self);
            }
        }
        if (selector == 6)
        {
            Transform temp = centerPieces[0];
            centerPieces[0] = centerPieces[1];
            centerPieces[1] = centerPieces[2];
            centerPieces[2] = centerPieces[3];
            centerPieces[3] = temp;

            int temp1 = x1; int temp2 = y1; int temp3 = z1;
            x1 = x2; y1 = y2; z1 = z2;
            x2 = temp1; y2 = temp2; z2 = temp3;

        }
        if (selector == 7)
        {
            Transform temp = centerPieces[0];
            centerPieces[0] = centerPieces[4];
            centerPieces[4] = centerPieces[2];
            centerPieces[2] = centerPieces[5];
            centerPieces[5] = temp;

            int temp1 = x2; int temp2 = y2; int temp3 = z2;
            x2 = x3; y2 = y3; z2 = z3;
            x3 = temp1; y3 = temp2; z3 = temp3;

        }
        if (selector == 8)
        {
            Transform temp = centerPieces[5];
            centerPieces[5] = centerPieces[1];
            centerPieces[1] = centerPieces[4];
            centerPieces[4] = centerPieces[3];
            centerPieces[3] = temp;

            int temp1 = x1; int temp2 = y1; int temp3 = z1;
            x1 = x3; y1 = y3; z1 = z3;
            x3 = temp1; y3 = temp2; z3 = temp3;
        }

        Debug.Log("Done!");
    }
    private void InitializePieces()
    {
        centerPieces = new Transform[6];
        cornerPieces = new Transform[8];
        edgePieces = new Transform[12];
        middleCubePiece = new Transform[1];

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
        middleCubePiece[0] = GameObject.FindWithTag("Pivot").transform;
    }

    public void ShuffleCube()
    {
        int dir = Random.Range(0, 1);
        if (dir == 0)
        {
            changeDirection();
        }

        int index = Random.Range(0, 8);
        if (index == 0)
        {
            RotateFront();
        }
        else if (index == 1)
        {
            RotateRight();
        }
        else if (index == 2)
        {
            RotateBack();
        }
        else if (index == 3)
        {
            RotateLeft();
        }
        else if (index == 4)
        {
            RotateBottom();
        }
        else if (index == 5)
        {
            RotateTop();
        }
        else if (index == 6)
        {
            RotateMiddleTB();
        }
        else if (index == 7)
        {
            RotateMiddleLR();
        }
        else if (index == 8)
        {
            RotateMiddleFB();
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
    public void RotateMiddleTB()
    {
        selector = 6;
        startRotation = true;
    }
    public void RotateMiddleLR()
    {
        selector = 7;
        startRotation = true;
    }
    public void RotateMiddleFB()
    {
        selector = 8;
        startRotation = true;
    }
    public void changeDirection()
    {
        if (CW)
        {
            GameObject.Find("TextCW").GetComponent<Text>().text = "CCW";
            CW = false;
        }
        else if (!CW)
        {
            GameObject.Find("TextCW").GetComponent<Text>().text = "CW";
            CW = true;
        }
    }

    public void ThistlethwaiteSolve()
    {
        
    }
}