using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E5 RID: 5605
	public class CheckEmblemCanLvUp : MonoBehaviour
	{
		// Token: 0x0600DB6F RID: 56175 RVA: 0x00374CF0 File Offset: 0x003730F0
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateGuildEmblemLvUpRedPoint, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB70 RID: 56176 RVA: 0x00374DAC File Offset: 0x003731AC
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateGuildEmblemLvUpRedPoint, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x0600DB71 RID: 56177 RVA: 0x00374E61 File Offset: 0x00373261
		private void Update()
		{
		}

		// Token: 0x0600DB72 RID: 56178 RVA: 0x00374E63 File Offset: 0x00373263
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB73 RID: 56179 RVA: 0x00374E6C File Offset: 0x0037326C
		private void _OnAddNewItem(List<Item> items)
		{
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB74 RID: 56180 RVA: 0x00374E75 File Offset: 0x00373275
		private void OnUpdateItem(List<Item> items)
		{
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB75 RID: 56181 RVA: 0x00374E80 File Offset: 0x00373280
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			bool flag = (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit() && DataManager<GuildDataManager>.GetInstance().myGuild != null && DataManager<GuildDataManager>.GetInstance().myGuild.nLevel >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit() && DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR) >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpHonourLvLimit();
			int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
			int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR);
			int emblemNeedHonourLv = DataManager<GuildDataManager>.GetInstance().GetEmblemNeedHonourLv(emblemLv + 1);
			List<int> list = null;
			bool flag2 = buildingLevel >= emblemNeedHonourLv && DataManager<GuildDataManager>.GetInstance().IsCostEnoughToLvUpEmblem(ref list);
			bool bActive = flag && flag2;
			this.goShow.CustomActive(bActive);
		}

		// Token: 0x04008158 RID: 33112
		[SerializeField]
		private GameObject goShow;
	}
}
