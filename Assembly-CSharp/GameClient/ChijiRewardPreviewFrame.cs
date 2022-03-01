using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001114 RID: 4372
	public class ChijiRewardPreviewFrame : ClientFrame
	{
		// Token: 0x0600A5DC RID: 42460 RVA: 0x00225E8E File Offset: 0x0022428E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiRewardPreviewFrame";
		}

		// Token: 0x0600A5DD RID: 42461 RVA: 0x00225E95 File Offset: 0x00224295
		protected sealed override void _OnOpenFrame()
		{
			this._InitInterface();
			this._RefreshRewardItemListCount();
		}

		// Token: 0x0600A5DE RID: 42462 RVA: 0x00225EA3 File Offset: 0x002242A3
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x0600A5DF RID: 42463 RVA: 0x00225EAB File Offset: 0x002242AB
		private void _ClearData()
		{
			this.ItemNum = 0;
		}

		// Token: 0x0600A5E0 RID: 42464 RVA: 0x00225EB4 File Offset: 0x002242B4
		private void _InitInterface()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChijiRewardTable>();
			if (table != null)
			{
				this.ItemNum = table.Count;
			}
			this._InitRewardItemScrollListBind();
		}

		// Token: 0x0600A5E1 RID: 42465 RVA: 0x00225EE4 File Offset: 0x002242E4
		private void _InitRewardItemScrollListBind()
		{
			this.mComScrollViewList.Initialize();
			this.mComScrollViewList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRewardItemScrollListBind(item);
				}
			};
			this.mComScrollViewList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x0600A5E2 RID: 42466 RVA: 0x00225F3C File Offset: 0x0022433C
		private void _UpdateRewardItemScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.ItemNum)
			{
				return;
			}
			ChijiRewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiRewardTable>(item.m_index + 1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("Name");
			GameObject gameObject = component.GetGameObject("IconRoot");
			if (com != null)
			{
				com.text = tableItem.Name;
			}
			if (gameObject != null)
			{
				ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem.RewardBoxID, 100, 0);
				if (itemData == null)
				{
					if (comItem != null)
					{
						comItem.CustomActive(false);
					}
				}
				else
				{
					if (comItem == null)
					{
						comItem = base.CreateComItem(gameObject);
					}
					comItem.CustomActive(true);
					comItem.Setup(itemData, new ComItem.OnItemClicked(this._ShowItemTip));
				}
			}
		}

		// Token: 0x0600A5E3 RID: 42467 RVA: 0x00226047 File Offset: 0x00224447
		private void _ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600A5E4 RID: 42468 RVA: 0x0022605F File Offset: 0x0022445F
		private void _RefreshRewardItemListCount()
		{
			this.mComScrollViewList.SetElementAmount(this.ItemNum);
		}

		// Token: 0x0600A5E5 RID: 42469 RVA: 0x00226074 File Offset: 0x00224474
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mComScrollViewList = this.mBind.GetCom<ComUIListScript>("comScrollViewList");
		}

		// Token: 0x0600A5E6 RID: 42470 RVA: 0x002260C9 File Offset: 0x002244C9
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mComScrollViewList = null;
		}

		// Token: 0x0600A5E7 RID: 42471 RVA: 0x002260F5 File Offset: 0x002244F5
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiRewardPreviewFrame>(this, false);
		}

		// Token: 0x04005CBA RID: 23738
		private int ItemNum;

		// Token: 0x04005CBB RID: 23739
		private Button mBtClose;

		// Token: 0x04005CBC RID: 23740
		private ComUIListScript mComScrollViewList;
	}
}
