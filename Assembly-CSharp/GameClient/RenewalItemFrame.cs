using System;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016FA RID: 5882
	internal class RenewalItemFrame : ClientFrame
	{
		// Token: 0x0600E6FF RID: 59135 RVA: 0x003CB6FA File Offset: 0x003C9AFA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/RenewalItem";
		}

		// Token: 0x0600E700 RID: 59136 RVA: 0x003CB704 File Offset: 0x003C9B04
		protected override void _OnOpenFrame()
		{
			this.m_itemData = (this.userData as ItemData);
			if (this.m_itemData == null || !this.m_itemData.CanRenewal())
			{
				return;
			}
			ComItem comItem = base.CreateComItem(this.m_objItemRoot);
			comItem.Setup(this.m_itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.m_labItemName.text = this.m_itemData.GetColorName(string.Empty, false);
			this.m_comItems.Initialize();
			this.m_comItems.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_itemData == null)
				{
					return;
				}
				if (!this.m_itemData.CanRenewal())
				{
					return;
				}
				if (var.m_index >= 0 && var.m_index < this.m_itemData.arrRenewals.Count)
				{
					int nIndex = var.m_index;
					RenewalInfo renewalInfo = this.m_itemData.arrRenewals[nIndex];
					Text componetInChild = Utility.GetComponetInChild<Text>(var.gameObject, "Time");
					if (renewalInfo.nDay <= 0)
					{
						componetInChild.text = TR.Value("item_renewal_forevel");
					}
					else
					{
						componetInChild.text = TR.Value("item_renewal_by_day", renewalInfo.nDay);
					}
					Image componetInChild2 = Utility.GetComponetInChild<Image>(var.gameObject, "Icon");
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(renewalInfo.nCostID);
					ETCImageLoader.LoadSprite(ref componetInChild2, commonItemTableDataByID.Icon, true);
					Text componetInChild3 = Utility.GetComponetInChild<Text>(var.gameObject, "Count");
					componetInChild3.text = renewalInfo.nCostCount.ToString();
					Toggle componetInChild4 = Utility.GetComponetInChild<Toggle>(var.gameObject, "Toggle");
					componetInChild4.onValueChanged.RemoveAllListeners();
					componetInChild4.onValueChanged.AddListener(delegate(bool var2)
					{
						if (var2)
						{
							this.m_nSelectIndex = nIndex;
						}
					});
					if (this.m_nSelectIndex == var.m_index)
					{
						componetInChild4.isOn = true;
					}
					else
					{
						componetInChild4.isOn = false;
					}
				}
			};
			this.m_nSelectIndex = 0;
			this.m_comItems.SetElementAmount(this.m_itemData.arrRenewals.Count);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemRenewalSuccess, new ClientEventSystem.UIEventHandler(this._OnRenewalSuccess));
		}

		// Token: 0x0600E701 RID: 59137 RVA: 0x003CB7EF File Offset: 0x003C9BEF
		protected override void _OnCloseFrame()
		{
			this.m_itemData = null;
			this.m_nSelectIndex = -1;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemRenewalSuccess, new ClientEventSystem.UIEventHandler(this._OnRenewalSuccess));
		}

		// Token: 0x0600E702 RID: 59138 RVA: 0x003CB81A File Offset: 0x003C9C1A
		private void _OnRenewalSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<RenewalItemFrame>(this, false);
		}

		// Token: 0x0600E703 RID: 59139 RVA: 0x003CB82C File Offset: 0x003C9C2C
		[UIEventHandle("Func")]
		private void _OnOkClicked()
		{
			if (this.m_itemData != null && this.m_itemData.CanRenewal() && this.m_nSelectIndex >= 0 && this.m_nSelectIndex < this.m_itemData.arrRenewals.Count)
			{
				int nCostID = this.m_itemData.arrRenewals[this.m_nSelectIndex].nCostID;
				if ((nCostID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || nCostID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				DataManager<ItemDataManager>.GetInstance().RenewalItem(this.m_itemData, (uint)this.m_itemData.arrRenewals[this.m_nSelectIndex].nDay);
			}
		}

		// Token: 0x0600E704 RID: 59140 RVA: 0x003CB8F8 File Offset: 0x003C9CF8
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<RenewalItemFrame>(this, false);
		}

		// Token: 0x04008C01 RID: 35841
		private ItemData m_itemData;

		// Token: 0x04008C02 RID: 35842
		private int m_nSelectIndex = -1;

		// Token: 0x04008C03 RID: 35843
		[UIControl("Group/Items", null, 0)]
		private ComUIListScript m_comItems;

		// Token: 0x04008C04 RID: 35844
		[UIObject("Item")]
		private GameObject m_objItemRoot;

		// Token: 0x04008C05 RID: 35845
		[UIControl("ItemName", null, 0)]
		private Text m_labItemName;
	}
}
