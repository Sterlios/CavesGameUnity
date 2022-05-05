using UnityEngine;

public static class Directions
{
	public enum Direction
	{
		North,
		East,
		South,
		West
	}

	private static readonly Direction[] opposites = 
	{
		Direction.South,
		Direction.West,
		Direction.North,
		Direction.East
	};

	private static readonly IntVector2[] vectors = 
	{
		new IntVector2(0, 2),
		new IntVector2(2, 0),
		new IntVector2(0, -2),
		new IntVector2(-2, 0)
	}; 

	private static Quaternion[] rotations = 
	{
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};

	public const int Count = 4;

	public static Direction RandomValue => (Direction)Random.Range(0, Count);
	public static IntVector2 ToIntVector2(this Direction direction) => vectors[(int)direction];
	public static Direction GetOpposite(this Direction direction) => opposites[(int)direction];
	public static Quaternion ToRotation(this Direction direction) => rotations[(int)direction];
}
