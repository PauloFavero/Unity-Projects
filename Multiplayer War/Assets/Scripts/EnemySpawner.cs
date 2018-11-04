using UnityEngine.Networking;
using UnityEngine;

public class EnemySpawner : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        var posX = GetComponent<Transform>().position.x;
        var posZ = GetComponent<Transform>().position.z;
        for (int i = 0; i < numberOfEnemies; i++)
        {

            var spawnPosition = new Vector3(posX+ Random.Range(-8.0f, 8.0f), 1f, posZ+ Random.Range(-10.0f, 10.0f));
            Debug.Log(spawnPosition);
        var spawRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

        var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawRotation);

        NetworkServer.Spawn(enemy);
    }
    }
}
