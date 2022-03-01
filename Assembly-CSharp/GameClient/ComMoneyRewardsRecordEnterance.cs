using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020017E0 RID: 6112
	internal class ComMoneyRewardsRecordEnterance : MonoBehaviour
	{
		// Token: 0x0600F0DC RID: 61660 RVA: 0x0040D8F1 File Offset: 0x0040BCF1
		private void Awake()
		{
			this._UpdateStage();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
		}

		// Token: 0x0600F0DD RID: 61661 RVA: 0x0040D914 File Offset: 0x0040BD14
		private void _OnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			this._UpdateStage();
		}

		// Token: 0x0600F0DE RID: 61662 RVA: 0x0040D91C File Offset: 0x0040BD1C
		private void _UpdateStage()
		{
			bool flag = DataManager<MoneyRewardsDataManager>.GetInstance().Status > PremiumLeagueStatus.PLS_PRELIMINAY && this.bIsShow();
			if (flag)
			{
				if (this.onSucceed != null)
				{
					this.onSucceed.Invoke();
				}
			}
			else if (this.onFailed != null)
			{
				this.onFailed.Invoke();
			}
		}

		// Token: 0x0600F0DF RID: 61663 RVA: 0x0040D97A File Offset: 0x0040BD7A
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
		}

		// Token: 0x0600F0E0 RID: 61664 RVA: 0x0040D998 File Offset: 0x0040BD98
		private bool bIsShow()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return true;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SceneSubType != CitySceneTable.eSceneSubType.CrossPk3v3 && tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3;
		}

		// Token: 0x040093E2 RID: 37858
		public UnityEvent onSucceed;

		// Token: 0x040093E3 RID: 37859
		public UnityEvent onFailed;
	}
}
