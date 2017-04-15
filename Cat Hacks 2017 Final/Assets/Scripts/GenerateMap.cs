using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    // member variables
    GameObject[,] tilesOnScreen;

	// use this for initialization
	void Start () {
        Debug.Log("Running Map Generation Script...");

        // create a test map
        int[,] testy = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        // draw the test map
        drawMap(testy);
}
	
	// update is called once per frame
	void Update () {
		
	}

    // draw a given map to the screen
    void drawMap(int[,] transfer) {
        tilesOnScreen = new GameObject[transfer.GetLength(0), transfer.GetLength(1)];
        Map m = new global::Map(transfer);

        for (int x = 0; x < m.tileList.GetLength(0); x++) {
            for(int y = 0; y < m.tileList.GetLength(1); y++) {
                if(m.tileList[x, y].id == 0) {
                    //Debug.Log("Drawing Tile at " + x + "," + y);
                    GameObject temp = (GameObject)Instantiate(Resources.Load("Floor1"));

                    double newX = (double)x * temp.GetComponent<Renderer>().bounds.size.x;
                    double newY= (double)y * temp.GetComponent<Renderer>().bounds.size.y;
                    temp.transform.position = new Vector3((float)newX, (float)newY, 1);

                    //print(temp.GetComponent<Renderer>().bounds.size);

                    tilesOnScreen[x, y] = temp;
                }
            }
        }
    }

}
