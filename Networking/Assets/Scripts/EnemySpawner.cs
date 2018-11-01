using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject prefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var SpawnPosition = new Vector3(8, 8, 0);
            var SpawnRotation = new Quaternion(8, 8, 0, 1);
        }
    }
}
