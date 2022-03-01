using System;
using UnityEngine;

// Token: 0x020048D6 RID: 18646
public class SphereMirror : MonoBehaviour
{
	// Token: 0x0601AD4E RID: 109902 RVA: 0x00840C24 File Offset: 0x0083F024
	private void Start()
	{
		Vector2[] uv = base.transform.GetComponent<MeshFilter>().mesh.uv;
		for (int i = 0; i < uv.Length; i++)
		{
			uv[i] = new Vector2(1f - uv[i].x, uv[i].y);
		}
		base.transform.GetComponent<MeshFilter>().mesh.uv = uv;
	}

	// Token: 0x0601AD4F RID: 109903 RVA: 0x00840CA0 File Offset: 0x0083F0A0
	private void Update()
	{
	}
}
