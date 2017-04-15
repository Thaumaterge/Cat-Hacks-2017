using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    // member variables
    public Tile[,] tileList;
    public int width;
    public int height;

    public Map (int[,] ids) {
        width = ids.GetLength(0);
        height = ids.GetLength(1);
        tileList = new Tile[width, height];

        convertId2Tile(ids);
    }

    public void convertId2Tile(int[,] map) {
        for(int x = 0; x < map.GetLength(0); x++) {
            for(int y = 0; y < map.GetLength(1); y++) {
                tileList[x, y] = new global::Tile(0);
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
