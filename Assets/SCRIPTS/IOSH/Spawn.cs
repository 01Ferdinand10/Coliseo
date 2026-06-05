using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using System.Collections.Generic;
public class Spawn : MonoBehaviour
{
    public enum ObjectType {MiniBoss, Enemy}
    public GameObject Door_1;
    public GameObject Door_2;
    public GameObject MarketDoor;
    private bool IsClose = true;
    private GameObject Door;
    public GameObject[] objectPrefabs;
    private int maxEnemies = 5;
    private float  spawnInterval = 2f;
    private bool allEnemiesDead = false;
    private ObjectType currentSpawnType = ObjectType.Enemy;
    private int spawnedEnemies = 0;
    private WorldConfig worldConfig;

    private List<Vector3> validPositions = new List<Vector3>();
    private List<GameObject> spawnObject = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        /*StopAllCoroutines();
        spawnObject.Clear();
        validPositions.Clear();
        isSpawning = false;
        allEnemiesDead = false;
        MarketDoor.SetActive(true);
        ActivarSpawn(5, 1);*/

        worldConfig = FindAnyObjectByType<WorldConfig>();
    }

    public void Iniciar()
    {
        StopAllCoroutines();
        spawnObject.Clear();
        validPositions.Clear();
        isSpawning = false;
        allEnemiesDead = false;
        MarketDoor.SetActive(true);
        ActivarSpawn(5, 1);
    }

    public void ToogleDoor()
    {
        IsClose = !IsClose;
        MarketDoor.SetActive(true);
    }

    void Update()
    {
        if (!isSpawning && ActiveObjectsCount() == 0 && !allEnemiesDead)
        {
            allEnemiesDead = true;
            MarketDoor.SetActive(false);
            worldConfig.LevelSum();
            //ActivarSpawn(1, 0);
        }
    }

    public int ActiveObjectsCount()
    {
        spawnObject.RemoveAll(item => item == null);
        return spawnObject.Count;
    }

    public void ActivarSpawn(int AmountEnemies, int type)
    {
        if (isSpawning) return;
        spawnedEnemies = 0;
        allEnemiesDead = false;
        maxEnemies = AmountEnemies;

        if(type == 1)
        {
            currentSpawnType = ObjectType.Enemy;
        } else
        {
            currentSpawnType = ObjectType.MiniBoss;
        }

        GatherPositions();
        StartCoroutine(SpawnObjectsIfNeeded());
    }

    private IEnumerator SpawnObjectsIfNeeded()
    {
        isSpawning = true;
        while(spawnedEnemies < maxEnemies)
        {
            SpawnObject();
            spawnedEnemies++;
            yield return new WaitForSeconds(spawnInterval);
        }
        isSpawning = false;
    }

    private bool PositionHasObject(Vector3 positionToCheck)
    {
        return spawnObject.Any(obj =>
            obj != null &&
            Vector3.Distance(obj.transform.position, positionToCheck) < 0.5f
        );
    }

    private void SpawnObject()
    {
        if(validPositions.Count == 0) return;
        
        Vector3 spawnPosition = Vector3.zero;
        bool validPositionFound = false;
        while(!validPositionFound && validPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, validPositions.Count);
            Vector3 potentialPosition = validPositions[randomIndex];
            Vector3 leftPosition = potentialPosition + Vector3.left;
            Vector3 rightPosition = potentialPosition + Vector3.right;
            if (!PositionHasObject(potentialPosition))
            {
                spawnPosition = potentialPosition;
                validPositionFound = true;
            }
            //validPositions.RemoveAt(randomIndex);
        }
        if (validPositionFound)
        {
            GameObject gameObject = Instantiate(objectPrefabs[(int)currentSpawnType], spawnPosition, Quaternion.identity);
            spawnObject.Add(gameObject);
        }
        
    }
    
    private void GatherPositions()
    {
        validPositions.Clear();
        for(int i =0; i<maxEnemies; i++)
        {
            int whichDoor = Random.Range(1, 11);

            Vector3 pos = new Vector3();

            Door = (whichDoor <= 5) ? Door_1 : Door_2;
            pos = Door.transform.position; 
            validPositions.Add(pos);
            
        }

        
    }
}
