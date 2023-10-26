using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour{
    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 12;
    public int nbrOfTiles = 3;
    public int totalNumOfTiles = 6;

    public float zSpawn = 0;

    Transform player;

    int previousIndex;

    void Start(){
    	player = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        for (int i = 0; i < nbrOfTiles; i++){
            if(i==0)
                SpawnTile();
            else
                SpawnTile(Random.Range(1, totalNumOfTiles));
        }

    }
    void LateUpdate(){
        if(player.position.z - 18 >= zSpawn - (nbrOfTiles * tileLength)){
            int index = Random.Range(1, totalNumOfTiles);
            int n = 0;
            while(index == previousIndex && n < 10){
            	index = Random.Range(1, totalNumOfTiles);
            	n++;
            }

            DeleteTile();
            SpawnTile(index);
        }
    }

    public void SpawnTile(int index = 0){
        GameObject tile = Instantiate(tilePrefabs[index], Vector3.forward * zSpawn, Quaternion.identity);
        activeTiles.Add(tile);
        zSpawn += tileLength;
        previousIndex = index;
    }

    private void DeleteTile(){
        PlayerManager.score += 1; 
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
