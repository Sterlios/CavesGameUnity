
using UnityEngine;

public class Player : MonoBehaviour
{
	public void SetLocation(IntVector2 coordinate)
	{
		transform.localPosition = new Vector3(coordinate.x, 0f, coordinate.z); 
	}
}
