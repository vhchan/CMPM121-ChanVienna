using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Terrain terrain;
    public GameObject mushroom;
    private int mushCount = 100;

    // Start is called before the first frame update
    void Start() //instantiate mushrooms
    {
        float placeX, placeZ, placeY;
        for (int i = 0; i < mushCount; i++)
        {
            placeX = Random.Range(0f, 500.0f);
            placeZ = Random.Range(0f, 500.0f);
            placeY = terrain.terrainData.GetHeight(Mathf.RoundToInt(placeX), Mathf.RoundToInt(placeZ));
            Vector3 pos = new Vector3(placeX, placeY + 3.0f, placeZ);
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            Instantiate(mushroom, pos, rot);
        }
    }

}
