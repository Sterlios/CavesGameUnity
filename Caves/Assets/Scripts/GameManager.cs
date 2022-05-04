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
        for(int mapIndex = 0; mapIndex < mapInstances.Length; mapIndex++)
        {
            mapInstances[mapIndex] = Instantiate(mapPrefab) as Map;
            mapInstances[mapIndex].Generate(mapIndex * 10);
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
