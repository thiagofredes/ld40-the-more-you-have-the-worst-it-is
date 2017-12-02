using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagnetic
{

	void Attract (Vector3 direction, float strength);

	void ResetSpeed ();
}
