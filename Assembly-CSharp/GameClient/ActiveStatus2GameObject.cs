using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200000B RID: 11
	public class ActiveStatus2GameObject : MonoBehaviour
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00005B8C File Offset: 0x00003F8C
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00005B94 File Offset: 0x00003F94
		public int ActiveConfigID
		{
			get
			{
				return this.iActiveConfigID;
			}
			set
			{
				this.iActiveConfigID = value;
				this._CheckStatus();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005BA4 File Offset: 0x00003FA4
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

		// Token: 0x0600003D RID: 61 RVA: 0x00005C2C File Offset: 0x0000402C
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005CAC File Offset: 0x000040AC
		private void _CheckStatus()
		{
			int num = 0;
			if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(this.iActiveConfigID))
			{
				num = (int)DataManager<ActiveManager>.GetInstance().ActiveDictionary[this.iActiveConfigID].mainInfo.state;
			}
			for (int i = 0; i < this.status.Length; i++)
			{
				if (this.status[i].eStatus != (TaskStatus)num)
				{
					Array.ForEach<GameObject>(this.status[i].targets, delegate(GameObject x)
					{
						x.CustomActive(false);
					});
				}
			}
			for (int j = 0; j < this.status.Length; j++)
			{
				if (this.status[j].eStatus == (TaskStatus)num)
				{
					Array.ForEach<GameObject>(this.status[j].targets, delegate(GameObject x)
					{
						x.CustomActive(true);
					});
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005DAB File Offset: 0x000041AB
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005DC9 File Offset: 0x000041C9
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005DE7 File Offset: 0x000041E7
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x04000020 RID: 32
		public int iActiveConfigID = 7100;

		// Token: 0x04000021 RID: 33
		public Status[] status;
	}
}
