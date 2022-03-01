using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A8 RID: 5288
	internal class BoduInfoFrame : ClientFrame
	{
		// Token: 0x0600CCF5 RID: 52469 RVA: 0x003259AC File Offset: 0x00323DAC
		public static void Open(int jarID = 1)
		{
			BoduData boduData = new BoduData();
			boduData.jarId = jarID;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BoduInfoFrame>(FrameLayer.Middle, boduData, string.Empty);
		}

		// Token: 0x0600CCF6 RID: 52470 RVA: 0x003259D8 File Offset: 0x00323DD8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Budo/BoduInfoFrame";
		}

		// Token: 0x0600CCF7 RID: 52471 RVA: 0x003259E0 File Offset: 0x00323DE0
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as BoduData);
			this.m_kCostPre = Utility.FindComponent<Text>(this.frame, "PreCost", true);
			this.goAwardParent = Utility.FindChild(this.frame, "Jars");
			this.goAwardPrefab = Utility.FindChild(this.frame, "Jars/ItemParent");
			this.goAwardPrefab.CustomActive(false);
			this.btnAddParty = Utility.FindComponent<Button>(this.frame, "BtnAddParty", true);
			this.btnAddParty.onClick.RemoveAllListeners();
			this.btnAddParty.onClick.AddListener(new UnityAction(this._OnAddParty));
			this.grayParty = Utility.FindComponent<UIGray>(this.frame, "BtnAddParty", true);
			this._SetData();
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			BudoManager instance4 = DataManager<BudoManager>.GetInstance();
			instance4.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance4.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._OnBudoInfoChanged));
		}

		// Token: 0x0600CCF8 RID: 52472 RVA: 0x00325B45 File Offset: 0x00323F45
		private void OnAddNewItem(List<Item> items)
		{
			this._UpdateBoduInfo();
		}

		// Token: 0x0600CCF9 RID: 52473 RVA: 0x00325B4D File Offset: 0x00323F4D
		private void OnRemoveItem(ItemData data)
		{
			this._UpdateBoduInfo();
		}

		// Token: 0x0600CCFA RID: 52474 RVA: 0x00325B55 File Offset: 0x00323F55
		private void OnUpdateItem(List<Item> items)
		{
			this._UpdateBoduInfo();
		}

		// Token: 0x0600CCFB RID: 52475 RVA: 0x00325B5D File Offset: 0x00323F5D
		private void _OnBudoInfoChanged()
		{
			this._UpdateBoduInfo();
		}

		// Token: 0x0600CCFC RID: 52476 RVA: 0x00325B68 File Offset: 0x00323F68
		private void _OnAddParty()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("budo_need_stop_match"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (DataManager<BudoManager>.GetInstance().CanParty)
			{
				if (!DataManager<BudoManager>.GetInstance().IsLevelFit)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("budo_need_lv"), DataManager<BudoManager>.GetInstance().NeedLv), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(BudoManager.TicketID, true);
				if (ownedItemCount <= 0 && DataManager<BudoManager>.GetInstance().TotalTimes > 0)
				{
					ItemComeLink.OnLink(BudoManager.TicketID, 1, true, delegate
					{
						DataManager<BudoManager>.GetInstance().SendAddParty();
						this.frameMgr.CloseFrame<BoduInfoFrame>(this, true);
					}, false, false, false, null, string.Empty);
					return;
				}
				DataManager<BudoManager>.GetInstance().SendAddParty();
			}
			else
			{
				DataManager<BudoManager>.GetInstance().GotoPvpBudo();
			}
			DataManager<ActivityDungeonDataManager>.GetInstance().mIsLimitActivityRedPoint = false;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			this.frameMgr.CloseFrame<BoduInfoFrame>(this, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshLimitTimeState, null, null, null, null);
		}

		// Token: 0x0600CCFD RID: 52477 RVA: 0x00325C94 File Offset: 0x00324094
		protected override void _OnCloseFrame()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			BudoManager instance4 = DataManager<BudoManager>.GetInstance();
			instance4.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance4.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._OnBudoInfoChanged));
			if (this.btnAddParty != null)
			{
				this.btnAddParty.onClick.RemoveAllListeners();
				this.btnAddParty = null;
			}
		}

		// Token: 0x0600CCFE RID: 52478 RVA: 0x00325D61 File Offset: 0x00324161
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600CCFF RID: 52479 RVA: 0x00325D7C File Offset: 0x0032417C
		private void _SetData()
		{
			if (this.m_kData != null)
			{
				List<BudoAwardTable> budoJars = DataManager<BudoManager>.GetInstance().BudoJars;
				int num = 0;
				while (budoJars != null && num < 5 && num < budoJars.Count)
				{
					BudoAwardTable budoAwardTable = budoJars[num];
					GameObject gameObject = Object.Instantiate<GameObject>(this.goAwardPrefab);
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.goAwardParent, false);
					ComItem comItem = base.CreateComItem(gameObject);
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(budoAwardTable.ID);
					comItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.OnItemClicked));
					Text text = Utility.FindComponent<Text>(gameObject, "Hint", true);
					text.text = budoAwardTable.desc;
					Text text2 = Utility.FindComponent<Text>(gameObject, "Name", true);
					if (commonItemTableDataByID != null)
					{
						text2.text = commonItemTableDataByID.GetColorName(string.Empty, false);
					}
					num++;
				}
				this._UpdateBoduInfo();
			}
		}

		// Token: 0x0600CD00 RID: 52480 RVA: 0x00325E68 File Offset: 0x00324268
		private void _UpdateBoduInfo()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(BudoManager.TicketID, true);
			if (ownedItemCount > 0)
			{
				this.m_kCostPre.text = string.Format(TR.Value("budo_ticket_hint_ok"), ownedItemCount);
			}
			else
			{
				this.m_kCostPre.text = string.Format(TR.Value("budo_ticket_hint_failed"), ownedItemCount);
			}
			if (DataManager<BudoManager>.GetInstance().TotalTimes <= 0)
			{
				this.m_kCostPre.text = string.Format(TR.Value("budo_free_hint"), ownedItemCount);
			}
			bool isOpen = DataManager<BudoManager>.GetInstance().IsOpen;
			this.grayParty.enabled = !isOpen;
			this.btnAddParty.enabled = isOpen;
		}

		// Token: 0x0600CD01 RID: 52481 RVA: 0x00325F28 File Offset: 0x00324328
		[UIEventHandle("Close")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<BoduInfoFrame>(this, false);
		}

		// Token: 0x04007763 RID: 30563
		private BoduData m_kData;

		// Token: 0x04007764 RID: 30564
		private Text m_kCostPre;

		// Token: 0x04007765 RID: 30565
		private GameObject goAwardParent;

		// Token: 0x04007766 RID: 30566
		private GameObject goAwardPrefab;

		// Token: 0x04007767 RID: 30567
		private Button btnAddParty;

		// Token: 0x04007768 RID: 30568
		private UIGray grayParty;
	}
}
