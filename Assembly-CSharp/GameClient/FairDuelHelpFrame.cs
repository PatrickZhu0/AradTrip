using System;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200135F RID: 4959
	public class FairDuelHelpFrame : ClientFrame
	{
		// Token: 0x0600C052 RID: 49234 RVA: 0x002D553B File Offset: 0x002D393B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FairDuel/FairDuelHelpFrame";
		}

		// Token: 0x0600C053 RID: 49235 RVA: 0x002D5542 File Offset: 0x002D3942
		protected override void _bindExUI()
		{
			this.mEquipComUIList = this.mBind.GetCom<ComUIListScript>("EquipItemList");
			this.mFashionComUIList = this.mBind.GetCom<ComUIListScript>("FashionItemList");
		}

		// Token: 0x0600C054 RID: 49236 RVA: 0x002D5570 File Offset: 0x002D3970
		protected override void _unbindExUI()
		{
			if (this.mEquipComUIList != null)
			{
				this.mEquipComUIList = null;
			}
			if (this.mFashionComUIList != null)
			{
				this.mFashionComUIList = null;
			}
		}

		// Token: 0x0600C055 RID: 49237 RVA: 0x002D55A4 File Offset: 0x002D39A4
		protected override void _OnOpenFrame()
		{
			DataManager<FairDuelDataManager>.GetInstance().IintEqualPvPEuqipTableList();
			if (this.mEquipComUIList != null && !this.mEquipComUIList.IsInitialised())
			{
				this.mEquipComUIList.Initialize();
				this.mEquipComUIList.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
				this.mEquipComUIList.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OEquipListVisiable);
			}
			this.mEquipComUIList.SetElementAmount(DataManager<FairDuelDataManager>.GetInstance().EquipIdList.Count);
			if (this.mFashionComUIList != null && !this.mFashionComUIList.IsInitialised())
			{
				this.mFashionComUIList.Initialize();
				this.mFashionComUIList.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
				this.mFashionComUIList.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OFashionListVisiable);
			}
			this.mFashionComUIList.SetElementAmount(DataManager<FairDuelDataManager>.GetInstance().FashioIdList.Count);
		}

		// Token: 0x0600C056 RID: 49238 RVA: 0x002D56A3 File Offset: 0x002D3AA3
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600C057 RID: 49239 RVA: 0x002D56A8 File Offset: 0x002D3AA8
		private void OFashionListVisiable(ComUIListElementScript item)
		{
			ComGridBindItem component = item.GetComponent<ComGridBindItem>();
			if (item.m_index >= 0 && item.m_index < DataManager<FairDuelDataManager>.GetInstance().FashioIdList.Count)
			{
				ComItem comItem = item.gameObjectBindScript as ComItem;
				int num = DataManager<FairDuelDataManager>.GetInstance().FashioIdList[item.m_index];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
				if (itemData != null && DataManager<FairDuelDataManager>.GetInstance().FashionDic.ContainsKey(num))
				{
					itemData.StrengthenLevel = DataManager<FairDuelDataManager>.GetInstance().FashionDic[num].StrengthenLv;
					comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowTips));
				}
			}
		}

		// Token: 0x0600C058 RID: 49240 RVA: 0x002D5758 File Offset: 0x002D3B58
		private void OEquipListVisiable(ComUIListElementScript item)
		{
			ComGridBindItem component = item.GetComponent<ComGridBindItem>();
			if (item.m_index >= 0 && item.m_index < DataManager<FairDuelDataManager>.GetInstance().EquipIdList.Count)
			{
				ComItem comItem = item.gameObjectBindScript as ComItem;
				int num = DataManager<FairDuelDataManager>.GetInstance().EquipIdList[item.m_index];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
				if (itemData != null && DataManager<FairDuelDataManager>.GetInstance().EquipDic.ContainsKey(num))
				{
					itemData.StrengthenLevel = DataManager<FairDuelDataManager>.GetInstance().EquipDic[num].StrengthenLv;
					itemData.SetStrengthenAttr(itemData);
					comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowTips));
				}
			}
		}

		// Token: 0x0600C059 RID: 49241 RVA: 0x002D580F File Offset: 0x002D3C0F
		private void OnShowTips(GameObject obj, ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x04006C99 RID: 27801
		private ComUIListScript mEquipComUIList;

		// Token: 0x04006C9A RID: 27802
		private ComUIListScript mFashionComUIList;
	}
}
