using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016E9 RID: 5865
	public class ItemTipModelAvatarEnumerationController : MonoBehaviour
	{
		// Token: 0x0600E5B9 RID: 58809 RVA: 0x003BDE73 File Offset: 0x003BC273
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600E5BA RID: 58810 RVA: 0x003BDE7B File Offset: 0x003BC27B
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600E5BB RID: 58811 RVA: 0x003BDE8C File Offset: 0x003BC28C
		private void BindUiEvents()
		{
			if (this.enumerationItemListEx != null)
			{
				this.enumerationItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.enumerationItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.enumerationItemListEx;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.enumerationItemListEx;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600E5BC RID: 58812 RVA: 0x003BDF2C File Offset: 0x003BC32C
		private void UnBindUiEvents()
		{
			if (this.enumerationItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.enumerationItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.enumerationItemListEx;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.enumerationItemListEx;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600E5BD RID: 58813 RVA: 0x003BDFBF File Offset: 0x003BC3BF
		private void ClearData()
		{
			this._onItemTipModelAvatarEnumerationItemClick = null;
			if (this._enumerationDataModelList != null)
			{
				this._enumerationDataModelList.Clear();
				this._enumerationDataModelList = null;
			}
			this._selectedIndex = 0;
			this._maxItemNumber = 0;
		}

		// Token: 0x0600E5BE RID: 58814 RVA: 0x003BDFF4 File Offset: 0x003BC3F4
		public void InitController(List<int> professionIdList, int selectIndex, OnItemTipModelAvatarEnumerationItemClick onItemTipModelAvatarEnumerationItemClick)
		{
			if (professionIdList == null || professionIdList.Count <= 0)
			{
				return;
			}
			this._selectedIndex = selectIndex;
			this._onItemTipModelAvatarEnumerationItemClick = onItemTipModelAvatarEnumerationItemClick;
			this._maxItemNumber = professionIdList.Count;
			if (this._enumerationDataModelList == null)
			{
				this._enumerationDataModelList = new List<ItemTipModelAvatarEnumerationDataModel>();
			}
			this._enumerationDataModelList.Clear();
			for (int i = 0; i < professionIdList.Count; i++)
			{
				int professionId = professionIdList[i];
				int num = i + 1;
				bool isSelectedFlag = this._selectedIndex == num;
				ItemTipModelAvatarEnumerationDataModel item = new ItemTipModelAvatarEnumerationDataModel
				{
					Index = num,
					IsSelectedFlag = isSelectedFlag,
					IsPlayerProfessionType = true,
					ProfessionId = professionId
				};
				this._enumerationDataModelList.Add(item);
			}
			this.InitView();
		}

		// Token: 0x0600E5BF RID: 58815 RVA: 0x003BE0C4 File Offset: 0x003BC4C4
		public void InitController(List<ItemTable> giftPackItemTableList, int selectItemTableIndex, OnItemTipModelAvatarEnumerationItemClick onItemTipModelAvatarEnumerationItemClick)
		{
			if (giftPackItemTableList == null || giftPackItemTableList.Count <= 0)
			{
				return;
			}
			this._selectedIndex = selectItemTableIndex;
			this._onItemTipModelAvatarEnumerationItemClick = onItemTipModelAvatarEnumerationItemClick;
			this._maxItemNumber = giftPackItemTableList.Count;
			if (this._enumerationDataModelList == null)
			{
				this._enumerationDataModelList = new List<ItemTipModelAvatarEnumerationDataModel>();
			}
			this._enumerationDataModelList.Clear();
			for (int i = 0; i < giftPackItemTableList.Count; i++)
			{
				ItemTable itemTable = giftPackItemTableList[i];
				int num = i + 1;
				bool isSelectedFlag = selectItemTableIndex == num;
				ItemTipModelAvatarEnumerationDataModel item = new ItemTipModelAvatarEnumerationDataModel
				{
					Index = num,
					ItemTable = itemTable,
					IsSelectedFlag = isSelectedFlag
				};
				this._enumerationDataModelList.Add(item);
			}
			this.InitView();
		}

		// Token: 0x0600E5C0 RID: 58816 RVA: 0x003BE188 File Offset: 0x003BC588
		private void InitView()
		{
			int elementAmount = 0;
			if (this._enumerationDataModelList != null)
			{
				elementAmount = this._enumerationDataModelList.Count;
			}
			if (this.enumerationItemListEx != null)
			{
				this.enumerationItemListEx.SetElementAmount(elementAmount);
			}
			this.UpdateEnumerationItemListPosition();
			this.InitPageController();
		}

		// Token: 0x0600E5C1 RID: 58817 RVA: 0x003BE1D7 File Offset: 0x003BC5D7
		public void OnEnableController(int selectedIndex)
		{
			this._selectedIndex = selectedIndex;
			this.UpdateEnumerationItemList();
			this.UpdatePageController();
		}

		// Token: 0x0600E5C2 RID: 58818 RVA: 0x003BE1EC File Offset: 0x003BC5EC
		private void InitPageController()
		{
			if (this.comPageChangeController != null)
			{
				this.comPageChangeController.InitPageChangeController(this._selectedIndex, this._maxItemNumber, new OnPageChangeAction(this.OnItemPageChangeAction));
			}
		}

		// Token: 0x0600E5C3 RID: 58819 RVA: 0x003BE222 File Offset: 0x003BC622
		private void UpdatePageController()
		{
			if (this.comPageChangeController != null)
			{
				this.comPageChangeController.UpdatePageChangeController(this._selectedIndex);
			}
		}

		// Token: 0x0600E5C4 RID: 58820 RVA: 0x003BE246 File Offset: 0x003BC646
		private void OnItemPageChangeAction(int selectedIndex)
		{
			this._selectedIndex = selectedIndex;
			this.UpdateEnumerationItemList();
			if (this._onItemTipModelAvatarEnumerationItemClick != null)
			{
				this._onItemTipModelAvatarEnumerationItemClick(selectedIndex);
			}
		}

		// Token: 0x0600E5C5 RID: 58821 RVA: 0x003BE26C File Offset: 0x003BC66C
		public void UpdateEnumerationItemList()
		{
			if (this._enumerationDataModelList == null || this._enumerationDataModelList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._enumerationDataModelList.Count; i++)
			{
				ItemTipModelAvatarEnumerationDataModel itemTipModelAvatarEnumerationDataModel = this._enumerationDataModelList[i];
				if (itemTipModelAvatarEnumerationDataModel != null)
				{
					if (itemTipModelAvatarEnumerationDataModel.Index == this._selectedIndex)
					{
						itemTipModelAvatarEnumerationDataModel.IsSelectedFlag = true;
					}
					else
					{
						itemTipModelAvatarEnumerationDataModel.IsSelectedFlag = false;
					}
				}
			}
			if (this.enumerationItemListEx != null)
			{
				this.enumerationItemListEx.UpdateElement();
			}
		}

		// Token: 0x0600E5C6 RID: 58822 RVA: 0x003BE30A File Offset: 0x003BC70A
		private void OnItemClickAction(int selectedIndex)
		{
			this._selectedIndex = selectedIndex;
			this.UpdateEnumerationItemList();
			this.UpdatePageController();
			if (this._onItemTipModelAvatarEnumerationItemClick != null)
			{
				this._onItemTipModelAvatarEnumerationItemClick(selectedIndex);
			}
		}

		// Token: 0x0600E5C7 RID: 58823 RVA: 0x003BE338 File Offset: 0x003BC738
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.enumerationItemListEx == null)
			{
				return;
			}
			if (this._enumerationDataModelList == null || this._enumerationDataModelList.Count <= 0)
			{
				return;
			}
			ItemTipModelAvatarEnumerationDataModel itemTipModelAvatarEnumerationDataModel = this._enumerationDataModelList[item.m_index];
			ItemTipModelAvatarEnumerationItem component = item.GetComponent<ItemTipModelAvatarEnumerationItem>();
			if (component != null && itemTipModelAvatarEnumerationDataModel != null)
			{
				component.InitItem(itemTipModelAvatarEnumerationDataModel, new OnItemTipModelAvatarEnumerationItemClick(this.OnItemClickAction));
			}
		}

		// Token: 0x0600E5C8 RID: 58824 RVA: 0x003BE3C0 File Offset: 0x003BC7C0
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ItemTipModelAvatarEnumerationItem component = item.GetComponent<ItemTipModelAvatarEnumerationItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600E5C9 RID: 58825 RVA: 0x003BE3F4 File Offset: 0x003BC7F4
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ItemTipModelAvatarEnumerationItem component = item.GetComponent<ItemTipModelAvatarEnumerationItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600E5CA RID: 58826 RVA: 0x003BE428 File Offset: 0x003BC828
		private void UpdateEnumerationItemListPosition()
		{
			if (this._maxItemNumber >= 6)
			{
				return;
			}
			if (this.itemListRoot == null)
			{
				return;
			}
			Vector3 localPosition = this.itemListRoot.transform.localPosition;
			float x = localPosition.x;
			if (this._maxItemNumber == 1)
			{
				if (this.itemOnePositionGo != null)
				{
					x = this.itemOnePositionGo.transform.localPosition.x;
				}
			}
			else if (this._maxItemNumber == 2)
			{
				if (this.itemTwoPositionGo != null)
				{
					x = this.itemTwoPositionGo.transform.localPosition.x;
				}
			}
			else if (this._maxItemNumber == 3)
			{
				if (this.itemThreePositionGo != null)
				{
					x = this.itemThreePositionGo.transform.localPosition.x;
				}
			}
			else if (this._maxItemNumber == 4)
			{
				if (this.itemFourPositionGo != null)
				{
					x = this.itemFourPositionGo.transform.localPosition.x;
				}
			}
			else if (this._maxItemNumber == 5 && this.itemFivePositionGo != null)
			{
				x = this.itemFivePositionGo.transform.localPosition.x;
			}
			this.itemListRoot.transform.localPosition = new Vector3(x, localPosition.y, localPosition.z);
		}

		// Token: 0x04008B15 RID: 35605
		private int _selectedIndex;

		// Token: 0x04008B16 RID: 35606
		private int _maxItemNumber;

		// Token: 0x04008B17 RID: 35607
		private List<ItemTipModelAvatarEnumerationDataModel> _enumerationDataModelList;

		// Token: 0x04008B18 RID: 35608
		private OnItemTipModelAvatarEnumerationItemClick _onItemTipModelAvatarEnumerationItemClick;

		// Token: 0x04008B19 RID: 35609
		[Space(10f)]
		[Header("ComPageChangeController")]
		[Space(10f)]
		[SerializeField]
		private ComPageChangeController comPageChangeController;

		// Token: 0x04008B1A RID: 35610
		[Space(10f)]
		[Header("ItemListScriptEx")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx enumerationItemListEx;

		// Token: 0x04008B1B RID: 35611
		[Space(10f)]
		[Header("ItemPosition")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemListRoot;

		// Token: 0x04008B1C RID: 35612
		[SerializeField]
		private GameObject itemOnePositionGo;

		// Token: 0x04008B1D RID: 35613
		[SerializeField]
		private GameObject itemTwoPositionGo;

		// Token: 0x04008B1E RID: 35614
		[SerializeField]
		private GameObject itemThreePositionGo;

		// Token: 0x04008B1F RID: 35615
		[SerializeField]
		private GameObject itemFourPositionGo;

		// Token: 0x04008B20 RID: 35616
		[SerializeField]
		private GameObject itemFivePositionGo;
	}
}
