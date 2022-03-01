using System;
using UnityEngine;

// Token: 0x02000D7E RID: 3454
public class Helper_DrawBox : MonoBehaviour
{
	// Token: 0x06008C06 RID: 35846 RVA: 0x0019E37D File Offset: 0x0019C77D
	public void SetFrameData(BDEntityActionFrameData data, float scale = 1f, float zdimScale = 1f, float scalex = 1f)
	{
		this.frameData = data;
		this.scale = scale;
		this.zdimScale = zdimScale;
		this.scalex = scalex;
	}

	// Token: 0x06008C07 RID: 35847 RVA: 0x0019E39C File Offset: 0x0019C79C
	public void DrawBox(int index)
	{
		if (index == 2 && Helper_DrawBox.hitBox.IsValide())
		{
			Helper_DrawBox.DrawCubeWithGLQUADS(new Vector3(Helper_DrawBox.hitBox._min.fx, Helper_DrawBox.hitBox._min.fy), new Vector3(Helper_DrawBox.hitBox._max.fx, Helper_DrawBox.hitBox._max.fy), new Color(0f, 1f, 0f, 0.5f));
			return;
		}
		if (this.frameData != null)
		{
			BDDBoxData bddboxData = (index != 0) ? this.frameData.pAttackData : this.frameData.pDefenseData;
			if (bddboxData == null)
			{
				return;
			}
			for (int i = 0; i < bddboxData.vBox.Count; i++)
			{
				DBoxImp dboxImp = bddboxData.vBox[i];
				if (index == 0)
				{
					Helper_DrawBox.DrawWireCubeWithGLLINES(new Vector3(dboxImp.vBox._min.fx * this.scale * this.scalex, dboxImp.vBox._min.fy * this.scale), new Vector3(dboxImp.vBox._max.fx * this.scale * this.scalex, dboxImp.vBox._max.fy * this.scale), new Color(0f, 1f, 0f, 0.5f));
				}
				else if (index == 1)
				{
					if (this.zDimMaxX < dboxImp.vBox._max.fx)
					{
						this.zDimMaxX = dboxImp.vBox._max.fx;
					}
					if (this.zDimMinX > dboxImp.vBox._min.fx)
					{
						this.zDimMinX = dboxImp.vBox._min.fx;
					}
					if (DBoxConfig.b2D)
					{
						Helper_DrawBox.DrawWireCubeWithGLLINES(new Vector3(dboxImp.vBox._min.fx * this.scale * this.scalex, dboxImp.vBox._min.fy * this.scale), new Vector3(dboxImp.vBox._max.fx * this.scale * this.scalex, dboxImp.vBox._max.fy * this.scale), new Color(1f, 0f, 0f, 0.5f));
					}
					else
					{
						float num = this.frameData.pAttackData.zDimInt.scalar * Global.Settings.zDimFactor.single * this.zdimScale;
						Helper_DrawBox.DrawWireCubeWithGLLINES(new Vector3(dboxImp.vBox._min.fx, dboxImp.vBox._min.fy, -num), new Vector3(dboxImp.vBox._max.fx, dboxImp.vBox._max.fy, num), new Color(1f, 0f, 0f, 0.5f));
					}
				}
			}
			if (index == 3 && DBoxConfig.b2D && this.zDimMinX <= this.zDimMaxX)
			{
				Vector3 position = base.gameObject.transform.position;
				float num2 = this.frameData.pAttackData.zDimInt.scalar * Global.Settings.zDimFactor.single * this.zdimScale;
				Helper_DrawBox.DrawCubeWithGLQUADS_Y(new Vector3(this.zDimMinX * this.scale * this.scalex, 0.01f - position.y, -num2), new Vector3(this.zDimMaxX * this.scale * this.scalex, 0.01f - position.y, num2), new Color(1f, 0f, 1f, 0.3f));
			}
		}
	}

	// Token: 0x06008C08 RID: 35848 RVA: 0x0019E7A6 File Offset: 0x0019CBA6
	public void Update()
	{
	}

	// Token: 0x06008C09 RID: 35849 RVA: 0x0019E7A8 File Offset: 0x0019CBA8
	private static void CreateLineMaterial()
	{
		if (!Helper_DrawBox.lineMaterial)
		{
			Shader shader = AssetShaderLoader.Find("Hidden/Internal-Colored");
			Helper_DrawBox.lineMaterial = new Material(shader);
			Helper_DrawBox.lineMaterial.hideFlags = 61;
			Helper_DrawBox.lineMaterial.SetInt("_SrcBlend", 5);
			Helper_DrawBox.lineMaterial.SetInt("_DstBlend", 10);
			Helper_DrawBox.lineMaterial.SetInt("_Cull", 0);
			Helper_DrawBox.lineMaterial.SetInt("_ZWrite", 0);
		}
	}

	// Token: 0x06008C0A RID: 35850 RVA: 0x0019E828 File Offset: 0x0019CC28
	public static void DrawWireCubeWithGLLINES(Vector3 min, Vector3 max, Color color)
	{
		GL.Color(color);
		if (min.z == max.z)
		{
			GL.Vertex3(min.x, min.y, min.z);
			GL.Vertex3(min.x, max.y, min.z);
			GL.Vertex3(min.x, max.y, min.z);
			GL.Vertex3(max.x, max.y, min.z);
			GL.Vertex3(max.x, max.y, min.z);
			GL.Vertex3(max.x, min.y, min.z);
			GL.Vertex3(max.x, min.y, min.z);
			GL.Vertex3(min.x, min.y, min.z);
		}
		else
		{
			GL.Vertex3(min.x, max.y, min.z);
			GL.Vertex3(max.x, max.y, min.z);
			GL.Vertex3(max.x, max.y, min.z);
			GL.Vertex3(max.x, max.y, max.z);
			GL.Vertex3(max.x, max.y, max.z);
			GL.Vertex3(min.x, max.y, max.z);
			GL.Vertex3(min.x, max.y, max.z);
			GL.Vertex3(min.x, max.y, min.z);
			GL.Vertex3(min.x, min.y, min.z);
			GL.Vertex3(max.x, min.y, min.z);
			GL.Vertex3(max.x, min.y, min.z);
			GL.Vertex3(max.x, min.y, max.z);
			GL.Vertex3(max.x, min.y, max.z);
			GL.Vertex3(min.x, min.y, max.z);
			GL.Vertex3(min.x, min.y, max.z);
			GL.Vertex3(min.x, min.y, min.z);
			GL.Vertex3(min.x, min.y, min.z);
			GL.Vertex3(min.x, max.y, min.z);
			GL.Vertex3(max.x, min.y, max.z);
			GL.Vertex3(max.x, max.y, max.z);
			GL.Vertex3(max.x, min.y, min.z);
			GL.Vertex3(max.x, max.y, min.z);
			GL.Vertex3(min.x, min.y, max.z);
			GL.Vertex3(min.x, max.y, max.z);
		}
	}

	// Token: 0x06008C0B RID: 35851 RVA: 0x0019EB94 File Offset: 0x0019CF94
	public static void DrawCubeWithGLQUADS(Vector3 min, Vector3 max, Color color)
	{
		GL.Color(color);
		GL.Vertex3(min.x, min.y, min.z);
		GL.Vertex3(min.x, max.y, min.z);
		GL.Vertex3(max.x, max.y, min.z);
		GL.Vertex3(max.x, min.y, min.z);
	}

	// Token: 0x06008C0C RID: 35852 RVA: 0x0019EC10 File Offset: 0x0019D010
	public static void DrawCubeWithGLQUADS_Y(Vector3 min, Vector3 max, Color color)
	{
		GL.Color(color);
		GL.Vertex3(min.x, min.y, min.z);
		GL.Vertex3(min.x, min.y, max.z);
		GL.Vertex3(max.x, min.y, max.z);
		GL.Vertex3(max.x, min.y, min.z);
	}

	// Token: 0x06008C0D RID: 35853 RVA: 0x0019EC8C File Offset: 0x0019D08C
	public void OnRenderObject()
	{
		this.zDimMinX = float.MaxValue;
		this.zDimMaxX = float.MinValue;
		Helper_DrawBox.CreateLineMaterial();
		Helper_DrawBox.lineMaterial.SetPass(0);
		GL.PushMatrix();
		GL.MultMatrix(base.transform.localToWorldMatrix);
		GL.Begin(1);
		this.DrawBox(0);
		GL.End();
		GL.Begin(1);
		this.DrawBox(1);
		GL.End();
		GL.Begin(7);
		this.DrawBox(3);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x0400454B RID: 17739
	public BDEntityActionFrameData frameData;

	// Token: 0x0400454C RID: 17740
	public static DBox hitBox;

	// Token: 0x0400454D RID: 17741
	private float scale = 1f;

	// Token: 0x0400454E RID: 17742
	private float zdimScale = 1f;

	// Token: 0x0400454F RID: 17743
	private float scalex = 1f;

	// Token: 0x04004550 RID: 17744
	private float zDimMinX = float.MaxValue;

	// Token: 0x04004551 RID: 17745
	private float zDimMaxX = float.MinValue;

	// Token: 0x04004552 RID: 17746
	private static Material lineMaterial;
}
