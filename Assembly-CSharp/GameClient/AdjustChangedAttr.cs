using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200002C RID: 44
	internal class AdjustChangedAttr
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000106 RID: 262 RVA: 0x0000A60C File Offset: 0x00008A0C
		public string ExtraAttr
		{
			get
			{
				return string.Format("{0:F1}", this.iExtraAttr);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000A623 File Offset: 0x00008A23
		public float DeltaValue
		{
			get
			{
				return this.iCurAttr - this.iOrgAttr;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000A634 File Offset: 0x00008A34
		public float fAmount
		{
			get
			{
				float num = 0f;
				if (this.iFullAttr != 0f)
				{
					num = this.iCurAttr * 1f / this.iFullAttr;
					num = Mathf.Clamp01(num);
				}
				return num;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000A674 File Offset: 0x00008A74
		public string Process
		{
			get
			{
				return string.Format("{0}/{1}", string.Format("{0:F1}", (this.iCurAttr <= this.iFullAttr) ? this.iCurAttr : this.iFullAttr), string.Format("{0:F1}", this.iFullAttr));
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000A6D1 File Offset: 0x00008AD1
		public bool IsFull
		{
			get
			{
				return this.iCurQuality >= 100;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000A6E0 File Offset: 0x00008AE0
		public bool IsChanged
		{
			get
			{
				return this.iCurAttr != this.iOrgAttr;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600010C RID: 268 RVA: 0x0000A6F3 File Offset: 0x00008AF3
		public bool IsUp
		{
			get
			{
				return this.iCurAttr > this.iOrgAttr;
			}
		}

		// Token: 0x040000DC RID: 220
		public float iOrgAttr;

		// Token: 0x040000DD RID: 221
		public float iCurAttr;

		// Token: 0x040000DE RID: 222
		public EEquipProp eEEquipProp;

		// Token: 0x040000DF RID: 223
		public int iOrgQuality;

		// Token: 0x040000E0 RID: 224
		public int iCurQuality;

		// Token: 0x040000E1 RID: 225
		public float iFullAttr;

		// Token: 0x040000E2 RID: 226
		public float iExtraAttr;

		// Token: 0x040000E3 RID: 227
		public bool bEffect;
	}
}
