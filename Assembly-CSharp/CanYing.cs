using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CC0 RID: 3264
public class CanYing : MonoBehaviour
{
	// Token: 0x06008670 RID: 34416 RVA: 0x00177911 File Offset: 0x00175D11
	private void Start()
	{
		this.meshFilters = base.gameObject.GetComponentsInChildren<MeshFilter>();
		this.skinedMeshRenderers = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
	}

	// Token: 0x06008671 RID: 34417 RVA: 0x00177938 File Offset: 0x00175D38
	private void OnDisable()
	{
		foreach (GameObject gameObject in this.objs)
		{
			Object.DestroyImmediate(gameObject);
		}
		this.objs.Clear();
		this.objs = null;
	}

	// Token: 0x06008672 RID: 34418 RVA: 0x001779A8 File Offset: 0x00175DA8
	private void Update()
	{
		if (Time.time - this.lastCombinedTime > this.interval && Time.time > this.startGhostTime && Time.time < this.endGhostTime)
		{
			this.lastCombinedTime = Time.time;
			int num = 0;
			while (this.skinedMeshRenderers != null && num < this.skinedMeshRenderers.Length)
			{
				Mesh mesh = new Mesh();
				this.skinedMeshRenderers[num].BakeMesh(mesh);
				GameObject gameObject = new GameObject();
				gameObject.hideFlags = 61;
				MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
				meshFilter.mesh = mesh;
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				meshRenderer.material = this.skinedMeshRenderers[num].material;
				this.InitFadeInObj(gameObject, this.skinedMeshRenderers[num].transform.position, this.skinedMeshRenderers[num].transform.rotation, this.life);
				num++;
			}
			int num2 = 0;
			while (this.meshFilters != null && num2 < this.meshFilters.Length)
			{
				GameObject go = Object.Instantiate<GameObject>(this.meshFilters[num2].gameObject);
				this.InitFadeInObj(go, this.meshFilters[num2].transform.position, this.meshFilters[num2].transform.rotation, this.life);
				num2++;
			}
		}
	}

	// Token: 0x06008673 RID: 34419 RVA: 0x00177B0C File Offset: 0x00175F0C
	private void InitFadeInObj(GameObject go, Vector3 position, Quaternion rotation, float life)
	{
		go.hideFlags = 61;
		go.transform.position = position;
		go.transform.rotation = rotation;
		FadInOut fadInOut = go.AddComponent<FadInOut>();
		fadInOut.life = life;
		this.objs.Add(go);
	}

	// Token: 0x04004054 RID: 16468
	public float interval = 0.3f;

	// Token: 0x04004055 RID: 16469
	public float life = 1f;

	// Token: 0x04004056 RID: 16470
	public float startGhostTime;

	// Token: 0x04004057 RID: 16471
	public float endGhostTime = 2f;

	// Token: 0x04004058 RID: 16472
	private float lastCombinedTime;

	// Token: 0x04004059 RID: 16473
	private MeshFilter[] meshFilters;

	// Token: 0x0400405A RID: 16474
	private SkinnedMeshRenderer[] skinedMeshRenderers;

	// Token: 0x0400405B RID: 16475
	private List<GameObject> objs = new List<GameObject>();
}
