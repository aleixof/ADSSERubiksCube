using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStructure : MonoBehaviour {

    private string[,] layer1 = new string[3,3];
    private string[,] layer2 = new string[3,3];
    private string[,] layer3 = new string[3,3];

    public void StructurCube()
    {
        layer1[0, 0] = "Center Piece 1";
        layer1[0, 1] = "Corner Piece 2";
        layer1[0, 2] = "Corner Piece 2";
        layer1[1, 0] = "Edge piece 1";
        layer1[1, 1] = "Pivot";
        layer1[1, 2] = "Corner piece 3";
        layer1[2, 0] = "Edge piece 2";
        layer1[2, 1] = "Edge piece 3";
        layer1[2, 2] = "Center piece 2";

        layer2[0, 0] = "Center Piece 3";
        layer2[0, 1] = "Corner Piece 4";
        layer2[0, 2] = "Corner Piece 5";
        layer2[1, 0] = "Edge piece 4";
        layer2[1, 1] = "Corner Piece 7";
        layer2[1, 2] = "Corner piece 6";
        layer2[2, 0] = "Edge piece 5";
        layer2[2, 1] = "Edge piece 6";
        layer2[2, 2] = "Center piece 4";

        layer3[0, 0] = "Center Piece 5";
        layer3[0, 1] = "Edge Piece 7";
        layer3[0, 2] = "Edge Piece 8";
        layer3[1, 0] = "Edge piece 10";
        layer3[1, 1] = "Corner Piece 8";
        layer3[1, 2] = "Edge piece 9";
        layer3[2, 0] = "Edge piece 11";
        layer3[2, 1] = "Edge piece 12";
        layer3[2, 2] = "Center piece 6";
    }
    private void InitializeArray()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
