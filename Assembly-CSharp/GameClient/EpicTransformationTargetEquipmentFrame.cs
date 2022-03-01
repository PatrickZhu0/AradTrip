using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B0A RID: 6922
	public class EpicTransformationTargetEquipmentFrame : ClientFrame
	{
		// Token: 0x06010FE4 RID: 69604 RVA: 0x004DC544 File Offset: 0x004DA944
		protected sealed override void _bindExUI()
		{
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
		}

		// Token: 0x06010FE5 RID: 69605 RVA: 0x004DC55C File Offset: 0x004DA95C
		protected sealed override void _unbindExUI()
		{
			this.mUIList = null;
		}

		// Token: 0x06010FE6 RID: 69606 RVA: 0x004DC565 File Offset: 0x004DA965
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EquipUpgrade/EpicTransformationTargetEquipmentFrame";
		}

		// Token: 0x06010FE7 RID: 69607 RVA: 0x004DC56C File Offset: 0x004DA96C
		protected sealed override void _OnOpenFrame()
		{
			this.InitEquipmentUIListScript();
			this.mEpicEquipmentData = (this.userData as EpicEquipmentTransformationTargetDataModle);
			if (this.mEpicEquipmentData == null)
			{
				return;
			}
			if (this.mEpicEquipmentData.type == EpicEquipmentTransformationType.SetOfConversion)
			{
				this.mTargetEquipmentList = DataManager<EpicEquipmentTransformationDataManager>.GetInstance().GetTargetEquipmentList(this.mEpicEquipmentData.equipmentItem);
			}
			else if (this.mEpicEquipmentData.type == EpicEquipmentTransformationType.AcrossaSetOfConversion)
			{
				this.mTargetEquipmentList = DataManager<EpicEquipmentTransformationDataManager>.GetInstance().GetCrossTargetEquipmentList(this.mEpicEquipmentData.equipmentItem);
			}
			this.mUIList.SetElementAmount(this.mTargetEquipmentList.Count);
		}

		// Token: 0x06010FE8 RID: 69608 RVA: 0x004DC60F File Offset: 0x004DAA0F
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitEquipmentUIListScript();
			this.mTargetEquipmentList.Clear();
		}

		// Token: 0x06010FE9 RID: 69609 RVA: 0x004DC624 File Offset: 0x004DAA24
		private void InitEquipmentUIListScript()
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
			}
		}

		// Token: 0x06010FEA RID: 69610 RVA: 0x004DC6C4 File Offset: 0x004DAAC4
		private void UnInitEquipmentUIListScript()
		{
			if (this.mUIList != null)
			{
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
			}
		}

		// Token: 0x06010FEB RID: 69611 RVA: 0x004DC757 File Offset: 0x004DAB57
		private EpicTransformationTargetEquipmentItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EpicTransformationTargetEquipmentItem>();
		}

		// Token: 0x06010FEC RID: 69612 RVA: 0x004DC760 File Offset: 0x004DAB60
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EpicTransformationTargetEquipmentItem epicTransformationTargetEquipmentItem = item.gameObjectBindScript as EpicTransformationTargetEquipmentItem;
			if (epicTransformationTargetEquipmentItem != null && item.m_index >= 0 && item.m_index < this.mTargetEquipmentList.Count)
			{
				epicTransformationTargetEquipmentItem.OnItemVisiable(this.mTargetEquipmentList[item.m_index]);
			}
		}

		// Token: 0x06010FED RID: 69613 RVA: 0x004DC7C0 File Offset: 0x004DABC0
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EpicTransformationTargetEquipmentItem epicTransformationTargetEquipmentItem = item.gameObjectBindScript as EpicTransformationTargetEquipmentItem;
			if (epicTransformationTargetEquipmentItem != null && this.mEpicEquipmentData != null && this.mEpicEquipmentData.onTargetEquipmentClick != null)
			{
				this.mEpicEquipmentData.onTargetEquipmentClick(epicTransformationTargetEquipmentItem.EquipmentItemData);
				base.Close(false);
			}
		}

		// Token: 0x0400AEDF RID: 44767
		private ComUIListScript mUIList;

		// Token: 0x0400AEE0 RID: 44768
		private List<ItemData> mTargetEquipmentList = new List<ItemData>();

		// Token: 0x0400AEE1 RID: 44769
		private EpicEquipmentTransformationTargetDataModle mEpicEquipmentData;
	}
}
