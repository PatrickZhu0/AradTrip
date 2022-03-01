using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200000C RID: 12
	internal class ActiveStatusControl : MonoBehaviour
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00005E20 File Offset: 0x00004220
		private void Start()
		{
			this._CheckStatus();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005EA8 File Offset: 0x000042A8
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005F28 File Offset: 0x00004328
		private void _CheckStatus()
		{
			bool bActive = false;
			List<ActiveMainTable> type2Templates = DataManager<ActiveManager>.GetInstance().GetType2Templates(this.iActiveConfigID);
			int num = 0;
			while (type2Templates != null && num < type2Templates.Count)
			{
				if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(type2Templates[num].ID))
				{
					ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[type2Templates[num].ID];
					if (activeData != null)
					{
						if (activeData.mainInfo != null && activeData.mainInfo.state != 0)
						{
							bActive = true;
							break;
						}
					}
				}
				num++;
			}
			base.gameObject.CustomActive(bActive);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005FDF File Offset: 0x000043DF
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005FFD File Offset: 0x000043FD
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000601B File Offset: 0x0000441B
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x04000024 RID: 36
		public int iActiveConfigID;
	}
}
