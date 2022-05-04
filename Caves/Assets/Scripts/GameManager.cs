using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Map mapPrefab;
    private Map[] mapInstances;

    private void Start()
    {
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        mapInstances = new Map[5];
        mapInstances[0] = Instantiate(mapPrefab) as Map;
        mapInstances[0].Generate(0);
        for (int mapIndex = 1; mapIndex < mapInstances.Length; mapIndex++)
        {
            mapInstances[mapIndex] = Instantiate(mapPrefab) as Map;
            mapInstances[mapIndex].Generate(mapInstances[mapIndex - 1].GetMaxZ() * 2);
        }
    }

    private void RestartGame()
    {
        for (int mapIndex = 0; mapIndex < mapInstances.Length; mapIndex++)
        {
            Destroy(mapInstances[mapIndex].gameObject);
        }
        BeginGame();
    }
}
