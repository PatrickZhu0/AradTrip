using System;
using UnityEngine;

// Token: 0x02000D03 RID: 3331
public class GeSpecialSceneManager
{
	// Token: 0x06008817 RID: 34839 RVA: 0x00183168 File Offset: 0x00181568
	public void LoadMagicScene(string _scenePath, int _time, int _reversTime, float maxValue, GeSceneEx scene)
	{
		this.geScene = scene;
		this.scenePath = _scenePath;
		this.time = _time;
		this.reversTime = _reversTime;
		this.maxValue = maxValue;
		this.LoadMagicScene();
	}

	// Token: 0x06008818 RID: 34840 RVA: 0x00183198 File Offset: 0x00181598
	private void LoadMagicScene()
	{
		this.scenePrefab = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.scenePath, true, 0U);
		if (this.scenePrefab != null && this.geScene != null)
		{
			Utility.AttachTo(this.scenePrefab, this.geScene.GetSceneRoot(), false);
			this.renders = this.scenePrefab.GetComponentsInChildren<MeshRenderer>();
		}
	}

	// Token: 0x06008819 RID: 34841 RVA: 0x00183204 File Offset: 0x00181604
	public void Update(int deltaTime)
	{
		if (this.renders == null || this.scenePrefab == null || this.geScene == null)
		{
			return;
		}
		if (this.reverse)
		{
			this.curReversTime += deltaTime;
			if (this.curReversTime > this.reversTime)
			{
				this.DestroyScene();
			}
			else
			{
				this.TransformScenePrefab(true);
			}
		}
		else if (this.timer < this.time)
		{
			this.timer += deltaTime;
			this.TransformScenePrefab(false);
			this.reversStartValue = this.mainValue;
		}
	}

	// Token: 0x0600881A RID: 34842 RVA: 0x001832AC File Offset: 0x001816AC
	private void TransformScenePrefab(bool revers = false)
	{
		if (this.renders != null)
		{
			for (int i = 0; i < this.renders.Length; i++)
			{
				MeshRenderer meshRenderer = this.renders[i];
				if (revers)
				{
					this.mainValue = this.reversStartValue + (1.3f - this.reversStartValue) * ((float)this.curReversTime / (float)this.reversTime);
				}
				else
				{
					this.mainValue = this.maxValue - this.maxValue * ((float)this.timer / (float)this.time);
				}
				this.mainValue = Mathf.Clamp(this.mainValue, 0f, this.maxValue);
				meshRenderer.sharedMaterial.SetFloat("_MainValue", this.mainValue);
			}
		}
	}

	// Token: 0x0600881B RID: 34843 RVA: 0x0018336F File Offset: 0x0018176F
	public void DestroyScene()
	{
		if (this.scenePrefab != null)
		{
			Object.Destroy(this.scenePrefab);
			this.scenePrefab = null;
			this.renders = null;
		}
	}

	// Token: 0x0600881C RID: 34844 RVA: 0x0018339B File Offset: 0x0018179B
	public void ReverseScene()
	{
		this.reverse = true;
	}

	// Token: 0x0600881D RID: 34845 RVA: 0x001833A4 File Offset: 0x001817A4
	public void Deinit()
	{
		this.DestroyScene();
	}

	// Token: 0x040041E8 RID: 16872
	private string scenePath = string.Empty;

	// Token: 0x040041E9 RID: 16873
	private int time;

	// Token: 0x040041EA RID: 16874
	private int reversTime;

	// Token: 0x040041EB RID: 16875
	private int curReversTime;

	// Token: 0x040041EC RID: 16876
	private GameObject scenePrefab;

	// Token: 0x040041ED RID: 16877
	private MeshRenderer[] renders;

	// Token: 0x040041EE RID: 16878
	private bool reverse;

	// Token: 0x040041EF RID: 16879
	private float maxValue;

	// Token: 0x040041F0 RID: 16880
	private GeSceneEx geScene;

	// Token: 0x040041F1 RID: 16881
	private int timer;

	// Token: 0x040041F2 RID: 16882
	private float mainValue;

	// Token: 0x040041F3 RID: 16883
	private float reversStartValue;
}
