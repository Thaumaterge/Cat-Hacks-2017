using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    // member variables
    public GameObject[,] tilesOnScreen;
    public GameObject[] activeUnits;
    public int activeUnitsSize = 0;

	// use this for initialization
	void Start () {
        Debug.Log("Running Map Generation Script...");

        // create a test map
        int[,] testy = new int[5, 5];
        for(int x = 0; x < testy.GetLength(0); x++) {
            for(int y = 0; y < testy.GetLength(1); y++) {
                testy[x, y] = 0;
            }
        }

        // draw the test map
        drawMap(testy);

        // create a unit
        activeUnits = new GameObject[20];
        createUnit(0, 0);

}
	
    void createUnit(int x, int y) {
        GameObject temp = (GameObject)Instantiate(Resources.Load("Unit"));

        temp.transform.localScale = new Vector3(.25f, .25f, 1.0f);

        float tempSize = temp.GetComponent<Renderer>().bounds.size.x;

        float newX = x + tempSize / 2;
        float newY = y + tempSize / 2;

        temp.transform.position = new Vector3(newX, newY, 2);

        activeUnits[activeUnitsSize] = temp;
        activeUnitsSize++;

    }

	// update is called once per frame
	void Update () {
		
	}

    // set the camera to fill the screen
    void setCameraAngle(double tileSize, int xLen, int yLen) {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        float xSize = (float) tileSize * xLen;
        float ySize = (float) tileSize * yLen;

        cam.transform.position = new Vector3(xSize/2, ySize /2 , cam.transform.position.z);
    }

    // draw a given map to the screen
    void drawMap(int[,] transfer) {
        tilesOnScreen = new GameObject[transfer.GetLength(0), transfer.GetLength(1)];
        Map m = new global::Map(transfer);
        double tileSize = 0;

        for (int x = 0; x < m.tileList.GetLength(0); x++) {
            for(int y = 0; y < m.tileList.GetLength(1); y++) {
                if(m.tileList[x, y].id == 0) {
                    //Debug.Log("Drawing Tile at " + x + "," + y);
                    GameObject temp = (GameObject)Instantiate(Resources.Load("Floor1"));

                    double newX = (double)x * temp.GetComponent<Renderer>().bounds.size.x;
                    double newY= (double)y * temp.GetComponent<Renderer>().bounds.size.y;

                    // adjust for first point
                    if(x == 0) {
                        newX += (temp.GetComponent<Renderer>().bounds.size.x) / 2;
                    }
                    if (y == 0) {
                        newY += (temp.GetComponent<Renderer>().bounds.size.y) / 2;
                    }

                    temp.transform.position = new Vector3((float)newX, (float)newY, 1);

                    if(tileSize == 0) {
                        tileSize = temp.GetComponent<Renderer>().bounds.size.x;
                    }
                    //print(temp.GetComponent<Renderer>().bounds.size);

                    tilesOnScreen[x, y] = temp;
                }
            }
        }

        //setCameraAngle(tileSize, m.tileList.GetLength(0), m.tileList.GetLength(1));
    }

}
