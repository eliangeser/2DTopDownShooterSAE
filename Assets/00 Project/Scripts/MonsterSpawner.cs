using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] Transform player;

    private void Start()
    {
        GameObject spawnedMonster = Instantiate(monster, transform.position, Quaternion.identity);

        EnemyManager enemyManager = spawnedMonster.GetComponent<EnemyManager>();
        enemyManager.player = player;
    }
}
