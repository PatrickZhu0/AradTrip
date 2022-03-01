using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000097 RID: 151
	internal class RoleRecoveryBinder : MonoBehaviour
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00018878 File Offset: 0x00016C78
		private void Start()
		{
			this._CheckRedPoint();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerTimeChanged, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleDeleteOk, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleInfoUpdate, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000188F7 File Offset: 0x00016CF7
		private void _CheckRedPoint(UIEvent uiEvent)
		{
			this._CheckRedPoint();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00018900 File Offset: 0x00016D00
		private void _CheckRedPoint()
		{
			int num = 0;
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (RecoveryRoleCachedObject.OnFilter(roleinfo[i]))
				{
					num++;
				}
			}
			base.gameObject.CustomActive(num > 0);
			if (this.recoveryCount != null)
			{
				this.recoveryCount.text = num.ToString();
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00018978 File Offset: 0x00016D78
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerTimeChanged, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleDeleteOk, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleInfoUpdate, new ClientEventSystem.UIEventHandler(this._CheckRedPoint));
		}

		// Token: 0x04000321 RID: 801
		public Text recoveryCount;
	}
}
