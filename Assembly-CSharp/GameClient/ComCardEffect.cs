using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E7A RID: 3706
	public class ComCardEffect : MonoBehaviour
	{
		// Token: 0x17001902 RID: 6402
		// (get) Token: 0x060092EA RID: 37610 RVA: 0x001B4BB2 File Offset: 0x001B2FB2
		// (set) Token: 0x060092EB RID: 37611 RVA: 0x001B4BBA File Offset: 0x001B2FBA
		public bool bFinished { get; set; }

		// Token: 0x060092EC RID: 37612 RVA: 0x001B4BC3 File Offset: 0x001B2FC3
		private void Awake()
		{
			this.bFinished = true;
		}

		// Token: 0x060092ED RID: 37613 RVA: 0x001B4BCC File Offset: 0x001B2FCC
		public void SetEnable(int a_nFinish)
		{
			this.bFinished = (a_nFinish > 0);
		}
	}
}
