using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Map mapPrefab;
    private Map[] mapInstances;
    private Player playerInstance;
    [SerializeField] private Player player;

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
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        mapInstances = new Map[1];
        for (int mapIndex = 0; mapIndex < mapInstances.Length; mapIndex++)
        {
            mapInstances[mapIndex] = Instantiate(mapPrefab) as Map;
            mapInstances[mapIndex].Generate(mapIndex * 10);
        }
        playerInstance = Instantiate(player) as Player;
        playerInstance.SetLocation(mapInstances[0].GetCellCoordinate(mapInstances[0].RandomCell()));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    }

    private void RestartGame()
    {
        for (int mapIndex = 0; mapIndex < mapInstances.Length; mapIndex++)
        {
            Destroy(mapInstances[mapIndex].gameObject);
        }
        Destroy(playerInstance.gameObject);
        BeginGame();
    }
}
