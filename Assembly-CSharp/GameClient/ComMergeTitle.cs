using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CB0 RID: 7344
	internal class ComMergeTitle : MonoBehaviour
	{
		// Token: 0x17001DBC RID: 7612
		// (get) Token: 0x06012050 RID: 73808 RVA: 0x0054450F File Offset: 0x0054290F
		public TitleMergeData Value
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x06012051 RID: 73809 RVA: 0x00544517 File Offset: 0x00542917
		private void _OnSelectedMergeTitleChanged(UIEvent uiEvent)
		{
			if (this.Value != null)
			{
				this.OnItemVisible(this.data);
			}
		}

		// Token: 0x06012052 RID: 73810 RVA: 0x00544530 File Offset: 0x00542930
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectedMergeTitleChanged, new ClientEventSystem.UIEventHandler(this._OnSelectedMergeTitleChanged));
		}

		// Token: 0x06012053 RID: 73811 RVA: 0x0054454D File Offset: 0x0054294D
		public static void Clear()
		{
			ComMergeTitle.Selected = null;
		}

		// Token: 0x17001DBD RID: 7613
		// (get) Token: 0x06012054 RID: 73812 RVA: 0x00544555 File Offset: 0x00542955
		// (set) Token: 0x06012055 RID: 73813 RVA: 0x0054455C File Offset: 0x0054295C
		public static TitleMergeData Selected
		{
			get
			{
				return ComMergeTitle.ms_selected;
			}
			set
			{
				ComMergeTitle.ms_selected = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectedMergeTitleChanged, null, null, null, null);
			}
		}

		// Token: 0x06012056 RID: 73814 RVA: 0x00544578 File Offset: 0x00542978
		public void OnItemVisible(TitleMergeData value)
		{
			this.data = value;
			bool flag = ComMergeTitle.checkMaterialEnough(value, false);
			if (null != this.comState)
			{
				if (flag)
				{
					this.comState.Key = "can_make";
				}
				else
				{
					this.comState.Key = "need_material";
				}
			}
			if (null == this.comItem)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			if (null != this.comItem && this.data != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.data.item.ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = 1;
				}
				this.comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				});
			}
			bool bActive = false;
			if (this.data != null && this.data.item != null)
			{
				bActive = DataManager<TittleBookManager>.GetInstance().HasTitle(this.data.item.ID);
			}
			this.ownedMark.CustomActive(bActive);
			this.goCheckMark.CustomActive(ComMergeTitle.ms_selected != null && this.Value.forgeItem == ComMergeTitle.ms_selected.forgeItem);
			if (null != this.comItem && null != this.Name && this.comItem.ItemData != null)
			{
				this.Name.text = this.comItem.ItemData.Name;
			}
			if (null != this.gray)
			{
				this.gray.enabled = true;
			}
		}

		// Token: 0x06012057 RID: 73815 RVA: 0x00544744 File Offset: 0x00542B44
		public static bool checkMoneyEnough(TitleMergeData data)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(data.getMoneyId(), true);
			return ownedItemCount >= data.getMoneyCount();
		}

		// Token: 0x06012058 RID: 73816 RVA: 0x00544774 File Offset: 0x00542B74
		public static bool checkMaterialEnough(TitleMergeData data, bool bNeedLink = false)
		{
			if (data != null)
			{
				for (int i = 0; i < data.materials.Count; i++)
				{
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(data.materials[i].id, true);
					if (ownedItemCount < data.materials[i].count)
					{
						if (bNeedLink)
						{
							ItemComeLink.OnLink(data.materials[i].id, data.materials[i].count, true, null, false, false, false, null, string.Empty);
						}
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06012059 RID: 73817 RVA: 0x00544814 File Offset: 0x00542C14
		public void OnDestroy()
		{
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectedMergeTitleChanged, new ClientEventSystem.UIEventHandler(this._OnSelectedMergeTitleChanged));
		}

		// Token: 0x0400BBD6 RID: 48086
		public StateController comState;

		// Token: 0x0400BBD7 RID: 48087
		public GameObject ownedMark;

		// Token: 0x0400BBD8 RID: 48088
		public GameObject goItemParent;

		// Token: 0x0400BBD9 RID: 48089
		public GameObject goCheckMark;

		// Token: 0x0400BBDA RID: 48090
		public Text Name;

		// Token: 0x0400BBDB RID: 48091
		public UIGray gray;

		// Token: 0x0400BBDC RID: 48092
		private ComItem comItem;

		// Token: 0x0400BBDD RID: 48093
		private TitleMergeData data;

		// Token: 0x0400BBDE RID: 48094
		private static TitleMergeData ms_selected;
	}
}
