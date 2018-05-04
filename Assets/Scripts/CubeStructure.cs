using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStructure : MonoBehaviour {
    //The logic of the cube structure is stored as 3 layers in 3x3 matrices

    //first layer covers the whole top/white side
    private string[,] layer1 = new string[3, 3];
    //Second layer is the middle layer 
    private string[,] layer2 = new string[3, 3];
    //Third Layer covers the whole bottom/yellow side
    private string[,] layer3 = new string[3, 3];

    public void StructureCube()
    {
        layer1[0, 0] = "Corner Piece 4";
        layer1[0, 1] = "Edge Piece 1";
        layer1[0, 2] = "Corner Piece 1";
        layer1[1, 0] = "Edge Piece 5";
        layer1[1, 1] = "Center Piece 1";
        layer1[1, 2] = "Edge Piece 6";
        layer1[2, 0] = "Corner Piece 5";
        layer1[2, 1] = "Edge Piece 9";
        layer1[2, 2] = "Corner Piece 6";

        layer2[0, 0] = "Edge Piece 4";
        layer2[0, 1] = "Center Piece 6";
        layer2[0, 2] = "Edge Piece 2";
        layer2[1, 0] = "Center Piece 4";
        layer2[1, 1] = "Pivot";
        layer2[1, 2] = "Center Piece 2";
        layer2[2, 0] = "Edge Piece 12";
        layer2[2, 1] = "Center Piece 5";
        layer2[2, 2] = "Edge Piece 10";

        layer3[0, 0] = "Corner Piece 3";
        layer3[0, 1] = "Edge Piece 3";
        layer3[0, 2] = "Corner Piece 2";
        layer3[1, 0] = "Edge Piece 8";
        layer3[1, 1] = "Center Piece 3";
        layer3[1, 2] = "Edge Piece 7";
        layer3[2, 0] = "Corner Piece 8";
        layer3[2, 1] = "Edge Piece 11";
        layer3[2, 2] = "Corner Piece 7";
    }

    //the getter functions fetches the string tags of the different sides
    //from a basic "solved" state.
    public string[,] GetSelectedSide(int side)
    {
        Debug.Log("SIDE:  " + side);
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
        else if (side == 6)
        {
            return GetMiddleTB();
        }
        else if (side == 7)
        {
            return GetMiddleLR();
        }
        else if (side == 8)
        {
            Debug.Log("SELECTEDDDDDD");
            return GetMiddleFB();
        }
        return null;
    }
    public string[,] GetGreenSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer1[0, 2]; array[0, 1] = layer1[0, 1]; array[0, 2] = layer1[0, 0];
        array[1, 0] = layer1[1, 2]; array[1, 1] = layer1[1, 1]; array[1, 2] = layer1[1, 0];
        array[2, 0] = layer1[2, 2]; array[2, 1] = layer1[2, 1]; array[2, 2] = layer1[2, 0];
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
    public string[,] GetRedSide()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer3[0, 0]; array[0, 1] = layer3[0, 1]; array[0, 2] = layer3[0, 2];
        array[1, 0] = layer2[0, 0]; array[1, 1] = layer2[0, 1]; array[1, 2] = layer2[0, 2];
        array[2, 0] = layer1[0, 0]; array[2, 1] = layer1[0, 1]; array[2, 2] = layer1[0, 2];
        return array;
    }
    public string[,] GetMiddleTB()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer3[1, 0]; array[0, 1] = layer3[1, 1]; array[0, 2] = layer3[1, 2];
        array[1, 0] = layer2[1, 0]; array[1, 1] = layer2[1, 1]; array[1, 2] = layer2[1, 2];
        array[2, 0] = layer1[1, 0]; array[2, 1] = layer1[1, 1]; array[2, 2] = layer1[1, 2];
        return array;
    }
    public string[,] GetMiddleLR()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer1[0, 1]; array[0, 1] = layer2[0, 1]; array[0, 2] = layer3[0, 1];
        array[1, 0] = layer1[1, 1]; array[1, 1] = layer2[1, 1]; array[1, 2] = layer3[1, 1];
        array[2, 0] = layer1[2, 1]; array[2, 1] = layer2[2, 1]; array[2, 2] = layer3[2, 1];
        return array;
    }
    public string[,] GetMiddleFB()
    {
        string[,] array = new string[3, 3];
        array[0, 0] = layer2[0, 2]; array[0, 1] = layer2[0, 1]; array[0, 2] = layer2[0, 0];
        array[1, 0] = layer2[1, 2]; array[1, 1] = layer2[1, 1]; array[1, 2] = layer2[1, 0];
        array[2, 0] = layer2[2, 2]; array[2, 1] = layer2[2, 1]; array[2, 2] = layer2[2, 0];
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
            layer1[2, 2] = temp;

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
            layer3[2, 2] = temp;

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
        if(side == 6)//Middle between top bottom
        {
            //rotate corners
            string temp = layer1[1, 0];
            layer1[1, 0] = layer1[1, 2];
            layer1[1, 2] = layer3[1, 2];
            layer3[1, 2] = layer3[1, 0];
            layer3[1, 0] = temp;

            //rotate edges
            temp = layer1[1, 1];
            layer1[1, 1] = layer2[1, 2];
            layer2[1, 2] = layer3[1, 1];
            layer3[1, 1] = layer2[1, 0];
            layer2[1, 0] = temp;
        }
        if (side  == 7)//Middle between left and right
        {
            //rotate corners
            string temp = layer1[0, 1];
            layer1[0, 1] = layer1[2, 1];
            layer1[2, 1] = layer3[2, 1];
            layer3[2, 1] = layer3[0, 1];
            layer3[0, 1] = temp;

            //rotate edges
            temp = layer1[1, 1];
            layer1[1, 1] = layer2[2, 1];
            layer2[2, 1] = layer3[1, 1];
            layer3[1, 1] = layer2[0, 1];
            layer2[0, 1] = temp;
        }
        if (side == 8)//Middle between front and back
        {
            //Rotate the corners
            string temp = layer2[0, 0];
            layer2[0, 0] = layer2[0, 2];
            layer2[0, 2] = layer2[2, 2];
            layer2[2, 2] = layer2[2, 0];
            layer2[2, 0] = temp;

            //Rotate the edges
            temp = layer2[0, 1];
            layer2[0, 1] = layer2[1, 2];
            layer2[1, 2] = layer2[2, 1];
            layer2[2, 1] = layer2[1, 0];
            layer2[1, 0] = temp;
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
