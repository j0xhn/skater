using UnityEngine;
using System.Collections;

public class DebugUtil : MonoBehaviour 
{
	public static void Assert(bool condition)
	{
		if (!condition) 
		{
			UnityException exception = new UnityException();
			Debug.LogException(exception);
		}
	}
}