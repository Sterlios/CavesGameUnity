using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    private IDictionary<IntVector2,Cell> cells = new Dictionary<IntVector2, Cell>();
    [SerializeField] private IntVector2 size;
    private int Square => size.x * size.z;
    private int MinCellCount => (int)((float)Square * (0.75f));
    private int MaxCellCount => (int)((float)Square * (0.9f));
    private int cellCount;
    private int cellIndex = 0;

    public void Generate()
    {
        cellCount = Random.Range(MinCellCount, MaxCellCount);
        Cell target = GetNextCell(new IntVector2(0,0));
        while (cellIndex < cellCount)
        {
            IntVector2 newDirection = Directions.ToIntVector2(Directions.RandomValue);
            target = GetNextCell(target.coordinate + newDirection);
        }
    }

    private Cell GetNextCell(IntVector2 coordinate)
    {
        Cell next = cells.ContainsKey(coordinate) ? cells[coordinate] : CreateCell(coordinate);
        return next;
    }

    private Cell CreateCell(IntVector2 coordinate)
    {
        Cell newCell = Instantiate(cellPrefab) as Cell;
        newCell.coordinate = coordinate;
        newCell.name = "Cell" + coordinate;
        newCell.transform.parent = transform;
        newCell.transform.localPosition =
            new Vector3(coordinate.x, 0f, coordinate.z);
        cells.Add(coordinate,newCell);
        cellIndex++;
        return newCell;
    }
}
