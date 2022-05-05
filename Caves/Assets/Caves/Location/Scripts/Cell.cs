using UnityEngine;
using System.Collections.Generic;

public class Cell : MonoBehaviour
{
    public IntVector2 coordinate;
    [SerializeField] private Wall wallPrefab;
    private IDictionary<Directions.Direction, Wall> walls = new Dictionary<Directions.Direction, Wall>();

    public void BuildingWall(Directions.Direction direction)
    {
        if (!walls.ContainsKey(direction))
        {
            walls.Add(direction, CreateWall(direction));
        }
    }

    public void DestroyWall(Directions.Direction direction)
    {
        if (walls.ContainsKey(direction))
        {
            Destroy(walls[direction].gameObject);
        }
    }

    private Wall CreateWall(Directions.Direction direction)
    {
        Wall newWall = Instantiate(wallPrefab) as Wall;
        newWall.coordinate = coordinate;
        newWall.name = "Wall " + coordinate;
        newWall.transform.parent = transform;
        newWall.transform.rotation = Directions.ToRotation(direction);
        newWall.transform.localPosition = new Vector3(0f, 0f, 0f);
        return newWall;
    }
}
