using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Map mapPrefab;
    private Map mapInstance;

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
        mapInstance = Instantiate(mapPrefab) as Map;
        mapInstance.Generate();
    }

    private void RestartGame()
    {
        Destroy(mapInstance.gameObject);
        BeginGame();
    }
}
