using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200007A RID: 122
	internal class LayoutSortOrder : MonoBehaviour
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600029D RID: 669 RVA: 0x0001411A File Offset: 0x0001251A
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00014122 File Offset: 0x00012522
		public int SortID
		{
			get
			{
				return this.iOrder;
			}
			set
			{
				this.iOrder = value;
			}
		}

		// Token: 0x0400028A RID: 650
		public int iOrder;
	}
}
