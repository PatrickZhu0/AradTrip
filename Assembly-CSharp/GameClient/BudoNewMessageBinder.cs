using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000018 RID: 24
	internal class BudoNewMessageBinder : MonoBehaviour
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00007699 File Offset: 0x00005A99
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000076A4 File Offset: 0x00005AA4
		private void Start()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			GlobalEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChangedFinish));
			GlobalEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemChangedFinish));
			this._UpdateStatus();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00007754 File Offset: 0x00005B54
		private void _OnSceneChangedFinish(UIEvent uiEvent)
		{
			this._UpdateStatus();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000775C File Offset: 0x00005B5C
		private void _OnSystemChangedFinish(UIEvent uiEvent)
		{
			this._UpdateStatus();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007764 File Offset: 0x00005B64
		private void _OnActivityUpdated(UIEvent a_event)
		{
			uint num = (uint)a_event.Param1;
			if ((ulong)num == (ulong)((long)BudoManager.ActiveID))
			{
				this._UpdateStatus();
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007790 File Offset: 0x00005B90
		private void _UpdateStatus()
		{
			DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNoticeByTag("BudoActiceAddParty");
			DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNoticeByTag("BudoActiceAcquireAward");
			if (DataManager<BudoManager>.GetInstance().NeedHintAddParty)
			{
				DataManager<NewMessageNoticeManager>.GetInstance().AddNewMessageNoticeWhenNoExist("BudoActiceAddParty", null, delegate(NewMessageNoticeData data)
				{
					DataManager<BudoManager>.GetInstance().TryBeginActive();
					DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNotice(data);
				});
			}
			else if (DataManager<BudoManager>.GetInstance().CanAcqured)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					return;
				}
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
				{
					return;
				}
				DataManager<NewMessageNoticeManager>.GetInstance().AddNewMessageNoticeWhenNoExist("BudoActiceAcquireAward", null, delegate(NewMessageNoticeData data)
				{
					DataManager<BudoManager>.GetInstance().TryBeginActive();
					DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNotice(data);
				});
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007880 File Offset: 0x00005C80
		private void OnBudoInfoChanged()
		{
			this._UpdateStatus();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00007888 File Offset: 0x00005C88
		private void OnDestroy()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			GlobalEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChangedFinish));
			GlobalEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemChangedFinish));
		}
	}
}
