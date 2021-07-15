using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner/Human Spawner")]
public class HumanSpawnerSO : ScriptableObject
{
    public Transform[] spawnPoints;
    public GameObject[] humanTypes;
    public int numberOfHumanToSpawn;
    public HumanSettingsSO settings;

}
