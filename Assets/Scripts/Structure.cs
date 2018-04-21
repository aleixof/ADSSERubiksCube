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
    //fourth layer covers right side of cube
    private string[,] rightLayer = new string[3, 3];
    //fifth layer covers vertical middle layer
    private string[,] middleRLLayer = new string[3, 3];
    //sixth layer covers the left side of the cube
    private string[,] leftLayer = new string[3, 3];
    //seventh layer covers the front side of the cube
    private string[,] frontLayer = new string[3, 3];
    //eight layer covers the middle between front and back side of the cube
    private string[,] middleFBLayer = new string[3, 3];
    //ninth layer covers the back side of the cube
    private string[,] backLayer = new string[3, 3];
    // Use this for initialization
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

        middleTBLayer[0, 0] = "EdgeRB";
        middleTBLayer[0, 1] = "CenterRed";
        middleTBLayer[0, 2] = "EdgeRG";
        middleTBLayer[1, 0] = "CenterBlue";
        middleTBLayer[1, 1] = "Center";
        middleTBLayer[1, 2] = "CenterGreen";
        middleTBLayer[2, 0] = "EdgeOB";
        middleTBLayer[2, 1] = "CenterOrange";
        middleTBLayer[2, 2] = "EdgeGO";

        bottomLayer[0, 0] = "CornerRBY";
        bottomLayer[0, 1] = "EdgeRY";
        bottomLayer[0, 2] = "CornerRGY";
        bottomLayer[1, 0] = "EdgeBY";
        bottomLayer[1, 1] = "CenterYellow";
        bottomLayer[1, 2] = "EdgeGY";
        bottomLayer[2, 0] = "CornerOBY";
        bottomLayer[2, 1] = "EdgeOY";
        bottomLayer[2, 2] = "CornerGOY";

        rightLayer[0, 0] = "CornerRGW";
        rightLayer[0, 1] = "EdgeRW";
        rightLayer[0, 2] = "CornerRWB";
        rightLayer[1, 0] = "EdgeRG";
        rightLayer[1, 1] = "CenterRed";
        rightLayer[1, 2] = "EdgeRB";
        rightLayer[2, 0] = "CornerRGY";
        rightLayer[2, 1] = "EdgeRY";
        rightLayer[2, 2] = "CornerRBY";

        middleRLLayer[0, 0] = "EdgeGW";
        middleRLLayer[0, 1] = "CenterWhite";
        middleRLLayer[0, 2] = "EdgeBW";
        middleRLLayer[1, 0] = "CenterGreen";
        middleRLLayer[1, 1] = "Center";
        middleRLLayer[1, 2] = "CenterBlue";
        middleRLLayer[2, 0] = "EdgeGY";
        middleRLLayer[2, 1] = "CenterYellow";
        middleRLLayer[2, 2] = "EdgeBY";

        leftLayer[0, 0] = "CornerGWO";
        leftLayer[0, 1] = "EdgeOW";
        leftLayer[0, 2] = "CornerOBW";
        leftLayer[1, 0] = "EdgeGO";
        leftLayer[1, 1] = "CenterOrange";
        leftLayer[1, 2] = "EdgeOB";
        leftLayer[2, 0] = "CornerGOY";
        leftLayer[2, 1] = "EdgeOY";
        leftLayer[2, 2] = "CornerOBY";

        frontLayer[0, 0] = "CornerRWB";
        frontLayer[0, 1] = "EdgeBW";
        frontLayer[0, 2] = "CornerOBW";
        frontLayer[1, 0] = "EdgeRB";
        frontLayer[1, 1] = "CenterBlue";
        frontLayer[1, 2] = "EdgeOB";
        frontLayer[2, 0] = "CornerRBY";
        frontLayer[2, 1] = "EdgeBY";
        frontLayer[2, 2] = "CornerOBY";

        middleFBLayer[0, 0] = "EdgeRW";
        middleFBLayer[0, 1] = "CenterWhite";
        middleFBLayer[0, 2] = "EdgeOW";
        middleFBLayer[1, 0] = "CenterRed";
        middleFBLayer[1, 1] = "Center";
        middleFBLayer[1, 2] = "CenterOrange";
        middleFBLayer[2, 0] = "EdgeRY";
        middleFBLayer[2, 1] = "CenterYellow";
        middleFBLayer[2, 2] = "EdgeOY";

        backLayer[0, 0] = "CornerRGW";
        backLayer[0, 1] = "EdgeGW";
        backLayer[0, 2] = "CornerGWO";
        backLayer[1, 0] = "EdgeRG";
        backLayer[1, 1] = "CenterGreen";
        backLayer[1, 2] = "EdgeGO";
        backLayer[2, 0] = "CornerRGY";
        backLayer[2, 1] = "EdgeGY";
        backLayer[2, 2] = "CornerGOY";
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
            return GetBottomSide();
        }
        else if (side == 2)
        {
            return GetLeftSide();
        }
        else if (side == 3)
        {
            return GetRightSide();
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
        else if (side == 7)
        {
            return GetMiddleRLSide();
        }
        else if (side == 8)
        {
            return GetMiddleFBSide();
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
    public string[,] GetLeftSide()
    {
        return leftLayer;
    }
    public string[,] GetRightSide()
    {
        return rightLayer;
    }
    public string[,] GetFrontSide()
    {
        return frontLayer;
    }
    public string[,] GetBackSide()
    {
        return backLayer;
    }
    public string[,] GetMiddleTBSide()
    {
        return middleTBLayer;
    }
    public string[,] GetMiddleRLSide()
    {
        return middleRLLayer;
    }
    public string[,] GetMiddleFBSide()
    {
        return middleFBLayer;
    }
    private void InitializeArray()
    {

    }

    //This function maps the tag strings to a new position based on a
    //clockwise 90 degrees rotation, based on the input given
    public void Rotate90CW(int side)
    {
        if (side == 0) //top side of the cube
        {
            GameObject top = GameObject.FindGameObjectWithTag("Top");
            GameObject.FindGameObjectWithTag(topLayer[0, 0]).transform.SetParent(top.transform);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
