using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{
    public GameObject objetPrefab;
    [SerializeField]
    private float rangeSpawn;
    [SerializeField]
    private float timeSpawn;
    private float timerSpawn;

    private void Update()
    {
        timerSpawn += Time.deltaTime;

        if (timerSpawn > timeSpawn)
        {
            SpawnObject();
            timerSpawn = 0;
        }

    }
    public void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3
                (transform.position.x + Random.Range(-rangeSpawn, rangeSpawn),
                transform.position.y + Random.Range(-rangeSpawn, rangeSpawn),
                0f);
        GameObject obj = Instantiate(objetPrefab, spawnPosition, transform.rotation);
        NetworkServer.Spawn(obj);
    }
}
