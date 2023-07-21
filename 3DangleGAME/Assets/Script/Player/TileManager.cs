using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn=0;
    public float tileLength=30.0f;
    public int  numberOfTiles=5;
    private List<GameObject> activeTiles=new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0,tilePrefabs.Length));
            
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //update for ımaging design 
        if(playerTransform.position.z - 35>zSpawn-(numberOfTiles*tileLength)){
           SpawnTile(Random.Range(0,tilePrefabs.Length));
           DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex){

        GameObject go= Instantiate(tilePrefabs[tileIndex],transform.forward*zSpawn,transform.rotation);
        for (int i = 0; i < tilePrefabs[tileIndex].transform.childCount; i++)
        {
            if (tilePrefabs[tileIndex].transform.GetChild(i).gameObject.name == "Obstacle")
            {
                tilePrefabs[tileIndex].transform.GetChild(i).gameObject.tag = "obstacle";
            }
        }
        activeTiles.Add(go);
        //Instantiate(tilePrefabs[tileIndex],transform.forward*zSpawn,transform.rotation);
        zSpawn+=tileLength;
    }

    // after game bug design traffic block 
    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
