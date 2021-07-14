using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Base
{
    private Transform _transform;
    private Vector3 _spawnPoint;

    private int _arraySize;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _spawnPoint = new Vector3(_transform.position.x, _transform.position.y + 0.6f, _transform.position.z);
    }
    public List<GameObject> SpawnEnemy(int amount, GameObject _enemyPrefab, Vector3 target)
    {
        List<GameObject> enemies = new List<GameObject>();
        _arraySize = amount;
        for (int i = 0; i < amount; i++)
        {
            GameObject currentEnemy = Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);
            enemies.Add(currentEnemy);
            enemies[i].GetComponent<Enemy>().SetTarget(target);
        }
        
        StartCoroutine(StartMoving(enemies));
        return enemies;
    }

    private IEnumerator StartMoving(List<GameObject> enemies)
    {
        for (int i = 0; i < _arraySize; i++)
        {
            yield return new WaitForSeconds(1);

            for (int j = 0; j < enemies.Count; j++)
            {
                if(enemies[j].GetComponent<Enemy>().GetSpeed() == 0f)
                {
                    enemies[j].GetComponent<Enemy>().SetSpeed();
                    break;
                }
            }
        }
    }
}
