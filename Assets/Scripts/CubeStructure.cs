using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStructure : MonoBehaviour {
    //The logic of the cube structure is stored as 3 layers in 3x3 matrices

    //first layer covers the whole top/white side
    private string[,] topLayer = new string[3, 3];
    //Second layer is the middle layer 
    private string[,] middleLayer = new string[3, 3];
    //Third Layer covers the whole bottom/yellow side
    private string[,] bottomLayer = new string[3, 3];

    public void StructureCube()
    {
        topLayer[0, 0] = "CornerRWB";
        topLayer[0, 1] = "EdgeRW";
        topLayer[0, 2] = "CornerRGW";
        topLayer[1, 0] = "EdgeBW";
        topLayer[1, 1] = "CenterWhite";
        topLayer[1, 2] = "EdgeGW";
        topLayer[2, 0] = "CornerOBW";
        topLayer[2, 1] = "EdgeOW";
        topLayer[2, 2] = "CornerGWO";

        middleLayer[0, 1] = "Center Piece 6";
        middleLayer[0, 0] = "Edge Piece 4";
        middleLayer[0, 2] = "Edge Piece 2";
        middleLayer[1, 0] = "Center Piece 4";
        middleLayer[1, 1] = "Pivot";
        middleLayer[1, 2] = "Center Piece 2";
        middleLayer[2, 0] = "Edge Piece 12";
        middleLayer[2, 1] = "Center Piece 5";
        middleLayer[2, 2] = "Edge Piece 10";

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

    //the getter functions fetches the string tags of the different sides
    //from a basic "solved" state.
    public string[,] GetSelectedSide(int side)
    {
        if (side == 0)
        {
            return GetGreenSide();
        }
        else if (side == 1)
        {
            return GetYellowSide();
        }
        else if (side == 2)
        {
            return GetOrangeSide();
        }
        else if (side == 3)
        {
            return GetBlueSide();
        }
        else if (side == 4)
        {
            return GetWhiteSide();
        }
        else if (side == 5)
        {
            return GetRedSide();
        }
        return null;
    }
    public string[,] GetGreenSide()
    {
        string[,] array = new string[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                array[i, j] = layer1[i, j];
            }
        }
        return array;
    }
    public string[,] GetYellowSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer1[0, 2]; array[0, 1] = layer2[0, 2]; array[0, 2] = layer3[0, 2];
        array[1, 0] = layer1[1, 2]; array[1, 1] = layer2[1, 2]; array[1, 2] = layer3[1, 2];
        array[2, 0] = layer1[2, 2]; array[2, 1] = layer2[2, 2]; array[2, 2] = layer3[2, 2];
        return array;
    }
    public string[,] GetRedSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer3[0, 0]; array[0, 1] = layer3[0, 1]; array[0, 2] = layer3[0, 2];
        array[1, 0] = layer2[0, 0]; array[1, 1] = layer2[0, 1]; array[1, 2] = layer2[0, 2];
        array[2, 0] = layer1[0, 0]; array[2, 1] = layer1[0, 1]; array[2, 2] = layer1[0, 2];
        return array;
    }
    public string[,] GetBlueSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer3[0, 0]; array[0, 1] = layer2[0, 0]; array[0, 2] = layer1[0, 0];
        array[1, 0] = layer3[1, 0]; array[1, 1] = layer2[1, 0]; array[1, 2] = layer1[1, 0];
        array[2, 0] = layer3[2, 0]; array[2, 1] = layer2[2, 0]; array[2, 2] = layer1[2, 0];
        return array;
    }
    public string[,] GetOrangeSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer3[0, 2]; array[0, 1] = layer3[0, 1]; array[0, 2] = layer3[0, 0];
        array[1, 0] = layer3[1, 2]; array[1, 1] = layer3[1, 1]; array[1, 2] = layer3[1, 0];
        array[2, 0] = layer3[2, 2]; array[2, 1] = layer3[2, 1]; array[2, 2] = layer3[2, 0];
        return array;
    }
    public string[,] GetWhiteSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer1[2, 2]; array[0, 1] = layer2[2, 2]; array[0, 2] = layer3[2, 2];
        array[1, 0] = layer1[2, 1]; array[1, 1] = layer2[2, 1]; array[1, 2] = layer3[2, 1];
        array[2, 0] = layer1[2, 0]; array[2, 1] = layer2[2, 0]; array[2, 2] = layer3[2, 0];
        return array;
    }
    private void InitializeArray()
    {

    }


    //This function maps the tag strings to a new position based on a
    //clockwise 90 degrees rotation, based on the input given
    public void Rotate(int side)
    {
        if (side == 0) //green side of the cube
        {
            //Rotate the corners
            string temp = layer1[0, 0];
            layer1[0, 0] = layer1[0, 2];
            layer1[0, 2] = layer1[2, 2];
            layer1[2, 2] = layer1[2, 0];
            layer1[2, 0] = temp;

            //Rotate the edges
            temp = layer1[0, 1];
            layer1[0, 1] = layer1[1, 2];
            layer1[1, 2] = layer1[2, 1];
            layer1[2, 1] = layer1[1, 0];
            layer1[1, 0] = temp;


        }

        if (side == 1) //Yellow side of the cube
        {
            //Rotate the corners
            string temp = layer1[0, 2];
            layer1[0, 2] = layer3[0, 2];
            layer3[0, 2] = layer3[2, 2];
            layer3[2, 2] = layer1[2, 2];
            layer1[0, 2] = temp;

            //Rotate the edges
            temp = layer2[0, 2];
            layer2[0, 2] = layer3[1, 2];
            layer3[1, 2] = layer2[2, 2];
            layer2[2, 2] = layer1[1, 2];
            layer1[1, 2] = temp;
        }
        if (side == 2) //Orange side of the cube
        {
            //Rotate the corners
            string temp = layer3[0, 2];
            layer3[0, 2] = layer3[0, 0]; //upper-left corner -> upper-right corner
            layer3[0, 0] = layer3[2, 0]; //upper-right corner ->  lower-right corner
            layer3[2, 0] = layer3[2, 2]; //lower-right corner -> lower-left corner
            layer1[0, 2] = temp;

            //Rotate the edges
            temp = layer3[0, 1];
            layer3[0, 1] = layer3[1, 0]; // Upper edge piece -> right edge piece
            layer3[1, 0] = layer3[2, 1]; //right edge piece -> lower edge piece
            layer3[2, 1] = layer3[1, 2]; //lower edge piece -> left edge piece
            layer3[1, 2] = temp;
        }
        if (side == 3) //Blue side of the cube
        {
            //Rotate the corners
            string temp = layer3[0, 0];
            layer3[0, 0] = layer1[0, 0];
            layer1[0, 0] = layer1[2, 0];
            layer1[2, 0] = layer3[2, 0];
            layer3[2, 0] = temp;

            //Rotate the edges
            temp = layer2[0, 0];
            layer2[0, 0] = layer1[1, 0];
            layer1[1, 0] = layer2[2, 0];
            layer2[2, 0] = layer3[1, 0];
            layer3[1, 0] = temp;
        }
        if (side == 4) //White side of the cube
        {
            //Rotate the corners
            string temp = layer3[2, 0];
            layer3[2, 0] = layer1[2, 0];
            layer1[2, 0] = layer1[2, 2];
            layer1[2, 2] = layer3[2, 2];
            layer3[2, 2] = temp;

            //Rotate the edges
            temp = layer2[2, 0];
            layer2[2, 0] = layer1[2, 1];
            layer1[2, 1] = layer2[2, 2];
            layer2[2, 2] = layer3[2, 1];
            layer3[2, 1] = temp;
        }
        if (side == 5) //Red side of the cube
        {
            //Rotate the corners
            string temp = layer3[0, 2];
            layer3[0, 2] = layer1[0, 2];
            layer1[0, 2] = layer1[0, 0];
            layer1[0, 0] = layer3[0, 0];
            layer3[0, 0] = temp;

            //Rotate the edges
            temp = layer2[0, 2];
            layer2[0, 2] = layer1[0, 1];
            layer1[0, 1] = layer2[0, 0];
            layer2[0, 0] = layer3[0, 1];
            layer3[0, 1] = temp;
        }

    }
    public CubeStructure()
        {
            StructureCube();
        }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
