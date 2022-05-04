using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    private int _level = 0;
    [SerializeField] private Cell cellPrefab;
    private IDictionary<IntVector2,Cell> cells = new Dictionary<IntVector2, Cell>();
    [SerializeField] private IntVector2 size;
    private int Square => size.x * size.z;
    private int MinCellCount => (int)((float)Square * (0.75f));
    private int MaxCellCount => (int)((float)Square * (0.9f));
    private int cellIndex = 0;

    public void Generate(int level)
    {
        _level = level;
        int cellCount = Random.Range(MinCellCount, MaxCellCount);
        Cell target = GetNextCell(new IntVector2(0,0));
        while (cellIndex < cellCount)
        {
            IntVector2 newDirection = Directions.ToIntVector2(Directions.RandomValue);
            target = GetNextCell(target.coordinate + newDirection);
        }
    }

    public int GetMaxZ()
    {
        int maxZ = 0;
        ICollection<Cell> cellsForMaxZ = cells.Values;
        foreach(Cell cell in cellsForMaxZ)
        {
            maxZ = cell.coordinate.z > maxZ ? cell.coordinate.z : maxZ;
        }
        return maxZ;
    }

    private Cell GetNextCell(IntVector2 coordinate) => cells.ContainsKey(coordinate) ? cells[coordinate] : CreateCell(coordinate);

    private Cell CreateCell(IntVector2 coordinate)
    {
        Cell newCell = Instantiate(cellPrefab) as Cell;
        newCell.coordinate = coordinate;
        newCell.name = "Cell" + coordinate;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinate.x, 0f, coordinate.z + _level);
        UpdateWalls(newCell);
        cells.Add(coordinate,newCell);
        cellIndex++;
        return newCell;
    }

    private void UpdateWalls(Cell target)
    {
        for (Directions.Direction direction = 0; (int)direction < Directions.Count; direction++)
        {
            if (cells.ContainsKey(target.coordinate + Directions.ToIntVector2(direction)))
            {
                target.DestroyWall(direction);
                cells[target.coordinate + Directions.ToIntVector2(direction)].DestroyWall(Directions.GetOpposite(direction));
            }
            else
            {
                target.BuildingWall(direction);
            }
        }
    }
}
