using System;
using UnityEngine;

// Token: 0x0200023D RID: 573
public class FrameMaterials : MonoBehaviour
{
	// Token: 0x060012F9 RID: 4857 RVA: 0x00064E20 File Offset: 0x00063220
	public void Start()
	{
		this.index = this.StartFrame;
		this.UpdateTime = 1f / (float)this.FPS;
		this.UseMaterial = base.GetComponent<Renderer>().material;
		this.XTiling = 1f / (float)this.TileX;
		this.YTiling = 1f / (float)this.TileY;
		this.TimeFlg = Time.time + this.StartTime;
		this.UseMaterial.SetTextureScale("_MainTex", new Vector2(this.XTiling, this.YTiling));
		this.XOffset = 0f;
		this.YOffset = (float)(this.TileY - 1) * this.YTiling;
		this.UseMaterial.SetTextureOffset("_MainTex", new Vector2(this.XOffset, this.YOffset));
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x00064EF8 File Offset: 0x000632F8
	private void Update()
	{
		if (Time.time - this.TimeFlg > this.UpdateTime)
		{
			this.index++;
			if (this.index >= this.TileX * this.TileY)
			{
				if (this.Loop)
				{
					this.index = 0;
				}
				else
				{
					this.index = this.TileX * this.TileY - 1;
				}
			}
			this.XOffset = (float)(this.index % this.TileX) * this.XTiling;
			this.YOffset = (float)(this.TileY - 1 - this.index / this.TileX) * this.YTiling;
			this.TimeFlg = Time.time;
			this.UseMaterial.SetTextureOffset("_MainTex", new Vector2(this.XOffset, this.YOffset));
		}
	}

	// Token: 0x060012FB RID: 4859 RVA: 0x00064FDC File Offset: 0x000633DC
	public float Duration()
	{
		this.UpdateTime = 1f / (float)this.FPS;
		return this.StartTime + (float)(this.TileX * this.TileY) * this.UpdateTime;
	}

	// Token: 0x060012FC RID: 4860 RVA: 0x0006501C File Offset: 0x0006341C
	public void Sampler(float time)
	{
		if (this.UseMaterial == null)
		{
			this.UpdateTime = 1f / (float)this.FPS;
			this.UseMaterial = base.GetComponent<Renderer>().sharedMaterial;
			this.XTiling = 1f / (float)this.TileX;
			this.YTiling = 1f / (float)this.TileY;
			if (this.UseMaterial)
			{
				this.UseMaterial.SetTextureScale("_MainTex", new Vector2(this.XTiling, this.YTiling));
			}
		}
		if (this.UseMaterial)
		{
			if (time <= this.StartTime)
			{
				this.index = this.StartFrame;
				this.XOffset = 0f;
				this.YOffset = (float)(this.TileY - 1) * this.YTiling;
			}
			else
			{
				float num = time - this.StartTime;
				num /= this.UpdateTime;
				this.index = Mathf.FloorToInt(num);
				if (this.index >= this.TileX * this.TileY)
				{
					if (this.Loop)
					{
						this.index = 0;
					}
					else
					{
						this.index = this.TileX * this.TileY - 1;
					}
				}
				this.XOffset = (float)(this.index % this.TileX) * this.XTiling;
				this.YOffset = (float)(this.TileY - 1 - this.index / this.TileX) * this.YTiling;
				this.TimeFlg = time;
				this.UseMaterial.SetTextureOffset("_MainTex", new Vector2(this.XOffset, this.YOffset));
			}
		}
	}

	// Token: 0x04000C8C RID: 3212
	public float StartTime;

	// Token: 0x04000C8D RID: 3213
	public int TileX = 1;

	// Token: 0x04000C8E RID: 3214
	public int TileY = 1;

	// Token: 0x04000C8F RID: 3215
	public int FPS = 12;

	// Token: 0x04000C90 RID: 3216
	public int StartFrame;

	// Token: 0x04000C91 RID: 3217
	public bool Loop = true;

	// Token: 0x04000C92 RID: 3218
	private float XTiling;

	// Token: 0x04000C93 RID: 3219
	private float YTiling;

	// Token: 0x04000C94 RID: 3220
	private float XOffset;

	// Token: 0x04000C95 RID: 3221
	private float YOffset;

	// Token: 0x04000C96 RID: 3222
	private float UpdateTime;

	// Token: 0x04000C97 RID: 3223
	private float TimeFlg;

	// Token: 0x04000C98 RID: 3224
	private int index;

	// Token: 0x04000C99 RID: 3225
	private Material UseMaterial;
}
