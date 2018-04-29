using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

    //first layer covers the whole top side
    private string[,] topLayer = new string[3, 3];
    //Second layer is the horizontal middle layer
    private string[,] middleTBLayer = new string[3, 3];
    //Third Layer covers the whole bottom side
    private string[,] bottomLayer = new string[3, 3];

    private string[, ,] rubiks3d = new string[3, 3, 3];

    public Structure()
    {
        StructureCube();
    }
    // Use this for initialization
    public void StructureCube()
    {
        topLayer[0, 0] = "Corner Piece 4";
        topLayer[0, 1] = "Edge Piece 1";
        topLayer[0, 2] = "Corner Piece 1";
        topLayer[1, 0] = "Edge Piece 5";
        topLayer[1, 1] = "Center Piece 1";
        topLayer[1, 2] = "Edge Piece 6";
        topLayer[2, 0] = "Corner Piece 5";
        topLayer[2, 1] = "Edge Piece 9";
        topLayer[2, 2] = "Corner Piece 6";

        middleTBLayer[0, 0] = "Edge Piece 4";   
        middleTBLayer[0, 1] = "Center Piece 6";
        middleTBLayer[0, 2] = "Edge Piece 2";
        middleTBLayer[1, 0] = "Center Piece 4";
        middleTBLayer[1, 1] = "Pivot";
        middleTBLayer[1, 2] = "Center Piece 2";
        middleTBLayer[2, 0] = "Edge Piece 12";
        middleTBLayer[2, 1] = "Center Piece 5";
        middleTBLayer[2, 2] = "Edge Piece 10";

        bottomLayer[0, 0] = "Corner Piece 3";
        bottomLayer[0, 1] = "Edge Piece 3";
        bottomLayer[0, 2] = "Corner Piece 2";
        bottomLayer[1, 0] = "Edge Piece 8";
        bottomLayer[1, 1] = "Center Piece 3";
        bottomLayer[1, 2] = "Edge Piece 7";
        bottomLayer[2, 0] = "Corner Piece 8";
        bottomLayer[2, 1] = "Edge Piece 11";
        bottomLayer[2, 2] = "Corner Piece 7";

        
    }

    public void Printsides()
    {
        for (int row = 0; row < topLayer.GetLength(0); row++)
        {
            for (int column = 0; column < topLayer.GetLength(1); column++)
            {
                Debug.Log("Top: " + row + ", " + column + "  " + topLayer[row,column]);
            }
        }
        for (int row = 0; row < middleTBLayer.GetLength(0); row++)
        {
            for (int column = 0; column < middleTBLayer.GetLength(1); column++)
            {
                Debug.Log("Mid: " + row + ", " + column + "  " + middleTBLayer[row, column]);
            }
        }

        for (int row = 0; row < bottomLayer.GetLength(0); row++)
        {
            for (int column = 0; column < bottomLayer.GetLength(1); column++)
            {
                Debug.Log("Botton: " + row + ", " + column + "  " + bottomLayer[row, column]);
            }
        }
    }

    //the getter functions fetches the string tags of the different sides
    //from a basic "solved" state.
    public string[,] GetSelectedSide(int side)
    {
        if (side == 0)
        {
            return GetTopSide();
        }
        else if (side == 1)
        {
            return GetRightSide();
        }
        else if (side == 2)
        {
            return GetBottomSide();
        }
        else if (side == 3)
        {
            return GetLeftSide();
        }
        else if (side == 4)
        {
            return GetFrontSide();
        }
        else if (side == 5)
        {
            return GetBackSide();
        }
        else if (side == 6)
        {
            return GetMiddleTBSide();
        }
        return null;
    }
    public string[,] GetTopSide()
    {
        return topLayer;
    }
    public string[,] GetBottomSide()
    {
        return bottomLayer;
    }
    public string[,] GetMiddleTBSide()
    {
        return middleTBLayer;
    }
    public string[,] GetRightSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = topLayer[0, 2]; array[0, 1] = middleTBLayer[0, 2]; array[0, 2] = bottomLayer[0, 2];
        array[1, 0] = topLayer[1, 2]; array[1, 1] = middleTBLayer[1, 2]; array[1, 2] = bottomLayer[1, 2];
        array[2, 0] = topLayer[2, 2]; array[2, 1] = middleTBLayer[2, 2]; array[2, 2] = bottomLayer[2, 2];
        return array;
    }
    public string[,] GetLeftSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = bottomLayer[0, 0]; array[0, 1] = middleTBLayer[0, 0]; array[0, 2] = topLayer[0, 0];
        array[1, 0] = bottomLayer[1, 0]; array[1, 1] = middleTBLayer[1, 0]; array[1, 2] = topLayer[1, 0];
        array[2, 0] = bottomLayer[2, 0]; array[2, 1] = middleTBLayer[2, 0]; array[2, 2] = topLayer[2, 0];
        return array;
    }
    public string[,] GetBackSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = bottomLayer[0, 0]; array[0, 1] = bottomLayer[0, 1]; array[0, 2] = bottomLayer[0, 2];
        array[1, 0] = middleTBLayer[0, 0]; array[1, 1] = middleTBLayer[0, 1]; array[1, 2] = middleTBLayer[0, 2];
        array[2, 0] = topLayer[0, 0]; array[2, 1] = topLayer[0, 1]; array[2, 2] = topLayer[0, 2];
        return array;
    }
    public string[,] GetFrontSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = topLayer[2, 2]; array[0, 1] = middleTBLayer[2, 2]; array[0, 2] = bottomLayer[2, 2];
        array[1, 0] = topLayer[2, 1]; array[1, 1] = middleTBLayer[2, 1]; array[1, 2] = bottomLayer[2, 1];
        array[2, 0] = topLayer[2, 0]; array[2, 1] = middleTBLayer[2, 0]; array[2, 2] = bottomLayer[2, 0];
        return array;
    }

    //This function maps the tag strings to a new position based on a
    //clockwise 90 degrees rotation, based on the input given
    public void Rotate(int side)
    {
        if (side == 0) //top side of the cube
        {
            //Rotate the corners
            string temp = topLayer[0, 0];
            topLayer[0, 0] = topLayer[0, 2];
            topLayer[0, 2] = topLayer[2, 2];
            topLayer[2, 2] = topLayer[2, 0];
            topLayer[2, 0] = temp;

            //Rotate the edges
            temp = topLayer[0, 1];
            topLayer[0, 1] = topLayer[1, 2];
            topLayer[1, 2] = topLayer[2, 1];
            topLayer[2, 1] = topLayer[1, 0];
            topLayer[1, 0] = temp;
        }

        if (side == 1) //Right side of the cube
        {
            //Rotate the corners
            string temp = topLayer[0, 2];
            topLayer[0, 2] = bottomLayer[0, 2];
            bottomLayer[0, 2] = bottomLayer[2, 2];
            bottomLayer[2, 2] = topLayer[2, 2];
            topLayer[2, 2] = temp;

            //Rotate the edges
            temp = middleTBLayer[0, 2];
            middleTBLayer[0, 2] = bottomLayer[1, 2];
            bottomLayer[1, 2] = middleTBLayer[2, 2];
            middleTBLayer[2, 2] = topLayer[1, 2];
            topLayer[1, 2] = temp;
        }
        if (side == 2) //Bottom side of the cube
        {
            //Rotate the corners
            string temp = bottomLayer[0, 2];
            bottomLayer[0, 2] = bottomLayer[0, 0]; //upper-left corner -> upper-right corner
            bottomLayer[0, 0] = bottomLayer[2, 0]; //upper-right corner ->  lower-right corner
            bottomLayer[2, 0] = bottomLayer[2, 2]; //lower-right corner -> lower-left corner
            bottomLayer[2, 2] = temp;

            //Rotate the edges
            temp = bottomLayer[0, 1];
            bottomLayer[0, 1] = bottomLayer[1, 0]; // Upper edge piece -> right edge piece
            bottomLayer[1, 0] = bottomLayer[2, 1]; //right edge piece -> lower edge piece
            bottomLayer[2, 1] = bottomLayer[1, 2]; //lower edge piece -> left edge piece
            bottomLayer[1, 2] = temp;
        }
        if (side == 3) //Left side of the cube
        {
            //Rotate the corners
            string temp = bottomLayer[0, 0];
            bottomLayer[0, 0] = topLayer[0, 0];
            topLayer[0, 0] = topLayer[2, 0];
            topLayer[2, 0] = bottomLayer[2, 0];
            bottomLayer[2, 0] = temp;

            //Rotate the edges
            temp = middleTBLayer[0, 0];
            middleTBLayer[0, 0] = topLayer[1, 0];
            topLayer[1, 0] = middleTBLayer[2, 0];
            middleTBLayer[2, 0] = bottomLayer[1, 0];
            bottomLayer[1, 0] = temp;
        }
        if (side == 4) //Front side of the cube
        {
            //Rotate the corners
            string temp = bottomLayer[2, 0];    
            bottomLayer[2, 0] = topLayer[2, 0];
            topLayer[2, 0] = topLayer[2, 2];
            topLayer[2, 2] = bottomLayer[2, 2];
            bottomLayer[2, 2] = temp;

            //Rotate the edges
            temp = middleTBLayer[2, 0];
            middleTBLayer[2, 0] = topLayer[2, 1];
            topLayer[2, 1] = middleTBLayer[2, 2];
            middleTBLayer[2, 2] = bottomLayer[2, 1];
            bottomLayer[2, 1] = temp;
        }
        if (side == 5) //Back side of the cube
        {
            //Rotate the corners
            string temp = bottomLayer[0, 2];
            bottomLayer[0, 2] = topLayer[0, 2];
            topLayer[0, 2] = topLayer[0, 0];
            topLayer[0, 0] = bottomLayer[0, 0];
            bottomLayer[0, 0] = temp;

            //Rotate the edges
            temp = middleTBLayer[0, 2];
            middleTBLayer[0, 2] = topLayer[0, 1];
            topLayer[0, 1] = middleTBLayer[0, 0];
            middleTBLayer[0, 0] = bottomLayer[0, 1];
            bottomLayer[0, 1] = temp;
        }
        Printsides();
    }

    public string[,] RotateMatrixClockwise(string[,] oldMatrix)
    {
        string[,] newMatrix = new string[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newRow, newColumn = oldMatrix.GetLength(1);
        for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
        {
            newRow = oldMatrix.GetLength(0);
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                newRow--;
            }
            newColumn--;
        }
        return newMatrix;
    }

    public string[,] RotateMatrixCounterClockwise(string[,] oldMatrix)
    {
        string[,] newMatrix = new string[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newColumn, newRow = 0;
        for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
        {
            newColumn = 0;
            for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
            {
                newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                newColumn++;
            }
            newRow++;
        }
        return newMatrix;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
