using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004BE3 RID: 19427
	[ExecuteInEditMode]
	public class UINumber : MonoBehaviour
	{
		// Token: 0x170027E0 RID: 10208
		// (get) Token: 0x0601C7A5 RID: 116645 RVA: 0x0089F994 File Offset: 0x0089DD94
		// (set) Token: 0x0601C7A6 RID: 116646 RVA: 0x0089F99C File Offset: 0x0089DD9C
		public int Value
		{
			get
			{
				return this.iValue;
			}
			set
			{
				this.iValue = value;
				this.m_bDirty = true;
			}
		}

		// Token: 0x0601C7A7 RID: 116647 RVA: 0x0089F9AC File Offset: 0x0089DDAC
		private void Start()
		{
			this.m_bDirty = true;
		}

		// Token: 0x0601C7A8 RID: 116648 RVA: 0x0089F9B8 File Offset: 0x0089DDB8
		private void Update()
		{
			if (!this.m_bDirty)
			{
				return;
			}
			this.m_bDirty = false;
			int num = this.iValue;
			for (int i = 0; i < this.imgPools.Count; i++)
			{
				this.imgPools[this.imgPools.Count - i - 1].CustomActive(i == 0 || num > 0);
				Image image = this.imgPools[this.imgPools.Count - i - 1];
				ETCImageLoader.LoadSprite(ref image, string.Format("{0}{1:D2}", this.preFixed, num % 10), true);
				num /= 10;
			}
		}

		// Token: 0x0601C7A9 RID: 116649 RVA: 0x0089FA69 File Offset: 0x0089DE69
		private void OnDestroy()
		{
			this.imgPools.Clear();
		}

		// Token: 0x04013B16 RID: 80662
		public string preFixed;

		// Token: 0x04013B17 RID: 80663
		public List<Image> imgPools = new List<Image>();

		// Token: 0x04013B18 RID: 80664
		private bool bInitialize;

		// Token: 0x04013B19 RID: 80665
		public int iValue;

		// Token: 0x04013B1A RID: 80666
		private bool m_bDirty = true;
	}
}
