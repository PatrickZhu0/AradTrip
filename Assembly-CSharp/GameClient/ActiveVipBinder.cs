using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000012 RID: 18
	internal class ActiveVipBinder : MonoBehaviour
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00006DFF File Offset: 0x000051FF
		private void Start()
		{
			this._Update();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this._OnVipLvChanged));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00006E22 File Offset: 0x00005222
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this._OnVipLvChanged));
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006E3F File Offset: 0x0000523F
		private void _OnVipLvChanged(UIEvent uiEvent)
		{
			this._Update();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006E48 File Offset: 0x00005248
		private void _Update()
		{
			bool flag = DataManager<PlayerBaseData>.GetInstance().VipLevel >= this.iVipLv;
			for (int i = 0; i < this.vipVisible.Length; i++)
			{
				this.vipVisible[i].CustomActive(flag);
			}
			for (int j = 0; j < this.unvipVisible.Length; j++)
			{
				this.unvipVisible[j].CustomActive(!flag);
			}
		}

		// Token: 0x04000044 RID: 68
		public GameObject[] vipVisible = new GameObject[0];

		// Token: 0x04000045 RID: 69
		public GameObject[] unvipVisible = new GameObject[0];

		// Token: 0x04000046 RID: 70
		public int iVipLv;
	}
}
