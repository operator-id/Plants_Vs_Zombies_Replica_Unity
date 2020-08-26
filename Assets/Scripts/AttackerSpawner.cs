using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] bool enabledProgressiveSpawning = true;




    float timeElapsed;
    public bool Spawn { get; set; } = true;
    public float StartingSpawnDelay { get; set; }
    public float SpawnInterval { get; set; }

    IEnumerator Start()
    {
        float totalLevelTime = FindObjectOfType<LevelTimer>().LevelTime;
        float min = StartingSpawnDelay;
        while (Spawn)
        {
            if (enabledProgressiveSpawning)
            {
                min *= 1 - timeElapsed / totalLevelTime;
             
                yield return new WaitForSeconds(Random.Range(min, min + SpawnInterval));
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(StartingSpawnDelay, SpawnInterval));
            }
                SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
       Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }
}
