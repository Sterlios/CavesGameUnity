using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    private IDictionary<IntVector2,Cell> cells = new Dictionary<IntVector2, Cell>();
    private IDictionary<IntVector2, Cell> activeCells = new Dictionary<IntVector2, Cell>();
    private int side = 20;
    private int size => Random.Range((int)Mathf.Pow(side,2)*(3/4), (int)Mathf.Pow(side, 2));
    private int cellIndex = 0;

    public void Generate()
    {
        Cell target = GetNextCell(new IntVector2(0,0));
        while (activeCells.Count != 0)
        {
            IntVector2 newDirection = Directions.ToIntVector2(Directions.RandomValue);
            target = GetNextCell(target.coordinate + newDirection);
            if (cellIndex == size)
            {
                activeCells.Clear();
            }
        }
    }

    private Cell GetNextCell(IntVector2 coordinate)
    {
        Cell next = cells.ContainsKey(coordinate) ? cells[coordinate] : CreateCell(coordinate);
        if (activeCells.ContainsKey(coordinate))
        {
            if (activeCells.ContainsKey(coordinate + Directions.ToIntVector2(Direction.East)) &&
                activeCells.ContainsKey(coordinate + Directions.ToIntVector2(Direction.West)) &&
                activeCells.ContainsKey(coordinate + Directions.ToIntVector2(Direction.North)) &&
                activeCells.ContainsKey(coordinate + Directions.ToIntVector2(Direction.South)))
            {
                activeCells.Remove(coordinate);
            }
        }
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
        activeCells.Add(coordinate, newCell);
        cellIndex++;
        return newCell;
    }
}
