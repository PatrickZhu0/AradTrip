using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000040 RID: 64
	public class ComLegendOpenNotify : MonoBehaviour
	{
		// Token: 0x06000195 RID: 405 RVA: 0x0000ED68 File Offset: 0x0000D168
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._CheckNotify();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000ED70 File Offset: 0x0000D170
		private void _CheckNotify()
		{
			bool flag = false;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<LegendMainTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ComLegendOpenNotify.<_CheckNotify>c__AnonStorey0 <_CheckNotify>c__AnonStorey = new ComLegendOpenNotify.<_CheckNotify>c__AnonStorey0();
				ComLegendOpenNotify.<_CheckNotify>c__AnonStorey0 <_CheckNotify>c__AnonStorey2 = <_CheckNotify>c__AnonStorey;
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				<_CheckNotify>c__AnonStorey2.lengendMainItem = (keyValuePair.Value as LegendMainTable);
				if (!Utility.IsLegendSeriesOver(<_CheckNotify>c__AnonStorey.lengendMainItem.ID))
				{
					bool flag2 = (int)DataManager<PlayerBaseData>.GetInstance().Level >= <_CheckNotify>c__AnonStorey.lengendMainItem.UnLockLevel;
					if (flag2 && DataManager<MissionManager>.GetInstance().DicLegendNotifies.Find((LegendNotifyData x) => x != null && x.iNotifyID == <_CheckNotify>c__AnonStorey.lengendMainItem.ID) == null)
					{
						DataManager<MissionManager>.GetInstance().DicLegendNotifies.Add(new LegendNotifyData
						{
							bNotify = true,
							iNotifyID = <_CheckNotify>c__AnonStorey.lengendMainItem.ID
						});
					}
				}
			}
			for (int i = 0; i < DataManager<MissionManager>.GetInstance().DicLegendNotifies.Count; i++)
			{
				if (DataManager<MissionManager>.GetInstance().DicLegendNotifies[i].bNotify)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this._Notify();
			}
			else
			{
				this._CancelNotify();
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000EEB3 File Offset: 0x0000D2B3
		private void Start()
		{
			this._RemoveListeners();
			this._AddListeners();
			this._CheckNotify();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000EEC7 File Offset: 0x0000D2C7
		private void OnDestroy()
		{
			this._RemoveListeners();
			this.onNotify = null;
			this.onCancelNotify = null;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000EEDD File Offset: 0x0000D2DD
		private void _RemoveListeners()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000EF05 File Offset: 0x0000D305
		private void _AddListeners()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000EF2D File Offset: 0x0000D32D
		public void CancelNotify()
		{
			DataManager<MissionManager>.GetInstance().ClearLegendNotifies();
			this._CancelNotify();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000EF3F File Offset: 0x0000D33F
		private void _CancelNotify()
		{
			if (this.onCancelNotify != null)
			{
				this.onCancelNotify.Invoke();
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000EF57 File Offset: 0x0000D357
		public void Notify()
		{
			this._Notify();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000EF5F File Offset: 0x0000D35F
		private void _Notify()
		{
			if (this.onNotify != null)
			{
				this.onNotify.Invoke();
			}
		}

		// Token: 0x04000187 RID: 391
		public UnityEvent onNotify;

		// Token: 0x04000188 RID: 392
		public UnityEvent onCancelNotify;
	}
}
