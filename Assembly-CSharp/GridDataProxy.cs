using System;
using UnityEngine;

// Token: 0x02004B9A RID: 19354
public class GridDataProxy : MonoBehaviour
{
	// Token: 0x0601C750 RID: 116560 RVA: 0x0089EB8F File Offset: 0x0089CF8F
	private void Start()
	{
	}

	// Token: 0x0601C751 RID: 116561 RVA: 0x0089EB91 File Offset: 0x0089CF91
	private void Update()
	{
	}

	// Token: 0x0601C752 RID: 116562 RVA: 0x0089EB94 File Offset: 0x0089CF94
	public void AllocBlockData()
	{
		int num = this.m_Width * this.m_Height;
		if (num > 0)
		{
			byte[] blockData = this.m_BlockData;
			this.m_BlockData = new byte[num];
			int num2 = (this.m_Width <= this.m_OldWidth) ? this.m_OldWidth : this.m_Width;
			int num3 = (this.m_Height <= this.m_OldHeight) ? this.m_OldHeight : this.m_Height;
			int num4 = ((this.m_OldWidth & 1) == 0) ? 1 : 0;
			int num5 = ((this.m_Width & 1) == 0) ? 1 : 0;
			int num6 = ((this.m_OldHeight & 1) == 0) ? 1 : 0;
			int num7 = ((this.m_Height & 1) == 0) ? 1 : 0;
			int num8 = (this.m_OldWidth + num4) / 2 - (this.m_Width + num5) / 2;
			int num9 = (this.m_OldHeight + num6) / 2 - (this.m_Height + num7) / 2;
			int num10 = (this.m_Width + num5) / 2 - (this.m_OldWidth + num4) / 2;
			int num11 = (this.m_Height + num7) / 2 - (this.m_OldHeight + num6) / 2;
			for (int i = 0; i < this.m_Height; i++)
			{
				for (int j = 0; j < this.m_Width; j++)
				{
					int num12 = j + i * this.m_Width;
					if (j < num10 || i < num11)
					{
						this.m_BlockData[num12] = 0;
					}
					else if (j < this.m_OldWidth + num10 && i < this.m_OldHeight + num11)
					{
						int num13 = j + num8 + (i + num9) * this.m_OldWidth;
						this.m_BlockData[num12] = blockData[num13];
					}
					else
					{
						this.m_BlockData[num12] = 0;
					}
				}
			}
			this.m_OldWidth = this.m_Width;
			this.m_OldHeight = this.m_Height;
		}
		else
		{
			Debug.LogWarning("Block size must be positive value!");
		}
	}

	// Token: 0x0601C753 RID: 116563 RVA: 0x0089EDAD File Offset: 0x0089D1AD
	public byte[] GetBlockData()
	{
		return this.m_BlockData;
	}

	// Token: 0x04013913 RID: 80147
	public int m_Width = 4;

	// Token: 0x04013914 RID: 80148
	public int m_Height = 4;

	// Token: 0x04013915 RID: 80149
	public Vector3 m_Min = Vector3.zero;

	// Token: 0x04013916 RID: 80150
	public Vector3 m_Max = Vector3.zero;

	// Token: 0x04013917 RID: 80151
	public bool m_DrawBlock;

	// Token: 0x04013918 RID: 80152
	public bool m_DrawBBox;

	// Token: 0x04013919 RID: 80153
	private int m_OldWidth;

	// Token: 0x0401391A RID: 80154
	private int m_OldHeight;

	// Token: 0x0401391B RID: 80155
	private byte[] m_BlockData;
}
