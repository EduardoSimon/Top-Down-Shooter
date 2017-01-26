using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Transform tilePrefab;
    public Vector2 mapSize;

    [Range(0,1)]
    public float outlinePercent;

    public void GenerateMap()
    {
        string holderName = "Generated Map";

        if(transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                //posicion del centro de la tile
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + x + 0.5f, 0, -mapSize.y / 2 + y + 0.5f);

                //hay que rotarla noventa grados en el eje x
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;

                //Distancia entre tiles
                newTile.localScale = Vector3.one * (1 - outlinePercent);
            }
        }
    }

	// Use this for initialization
	void Start () {
        GenerateMap();
	}
}
