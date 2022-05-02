using UnityEngine;

public enum Direction
{
	North,
	East,
	South,
	West
}

public static class Directions
{
	public const int Count = 4;


	public static Direction RandomValue
	{
		get
		{
			return (Direction)Random.Range(0, Count);
		}
	}

	private static IntVector2[] vectors = {
		new IntVector2(0, 1),
		new IntVector2(1, 0),
		new IntVector2(0, -1),
		new IntVector2(-1, 0)
	};

	public static IntVector2 ToIntVector2(this Direction direction)
	{
		return vectors[(int)direction];
	}
}
