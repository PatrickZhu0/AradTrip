using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B08 RID: 6920
	public class EpicTransformationConverterFrame : ClientFrame
	{
		// Token: 0x06010FD8 RID: 69592 RVA: 0x004DC29C File Offset: 0x004DA69C
		protected sealed override void _bindExUI()
		{
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
		}

		// Token: 0x06010FD9 RID: 69593 RVA: 0x004DC2B4 File Offset: 0x004DA6B4
		protected sealed override void _unbindExUI()
		{
			this.mUIList = null;
		}

		// Token: 0x06010FDA RID: 69594 RVA: 0x004DC2BD File Offset: 0x004DA6BD
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EquipUpgrade/EpicTransformationConverterFrame";
		}

		// Token: 0x06010FDB RID: 69595 RVA: 0x004DC2C4 File Offset: 0x004DA6C4
		protected sealed override void _OnOpenFrame()
		{
			this.InitEquipmentUIListScript();
			this.mEpicTransformationConverterDataModel = (this.userData as EpicTransformationConverterDataModel);
			if (this.mEpicTransformationConverterDataModel == null)
			{
				return;
			}
			this.mConverterList = this.mEpicTransformationConverterDataModel.converterList;
			this.mUIList.SetElementAmount(this.mConverterList.Count);
		}

		// Token: 0x06010FDC RID: 69596 RVA: 0x004DC31B File Offset: 0x004DA71B
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitEquipmentUIListScript();
			this.mConverterList.Clear();
		}

		// Token: 0x06010FDD RID: 69597 RVA: 0x004DC330 File Offset: 0x004DA730
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

		// Token: 0x06010FDE RID: 69598 RVA: 0x004DC3D0 File Offset: 0x004DA7D0
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

		// Token: 0x06010FDF RID: 69599 RVA: 0x004DC463 File Offset: 0x004DA863
		private GrowthExpendItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<GrowthExpendItem>();
		}

		// Token: 0x06010FE0 RID: 69600 RVA: 0x004DC46C File Offset: 0x004DA86C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
			if (growthExpendItem != null && item.m_index >= 0 && item.m_index < this.mConverterList.Count)
			{
				growthExpendItem.OnItemVisiable(this.mConverterList[item.m_index]);
			}
		}

		// Token: 0x06010FE1 RID: 69601 RVA: 0x004DC4CC File Offset: 0x004DA8CC
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
			if (growthExpendItem != null && this.mEpicTransformationConverterDataModel != null && this.mEpicTransformationConverterDataModel.onConverterClick != null)
			{
				this.mEpicTransformationConverterDataModel.onConverterClick(growthExpendItem.ItemData);
				base.Close(false);
			}
		}

		// Token: 0x0400AED9 RID: 44761
		private ComUIListScript mUIList;

		// Token: 0x0400AEDA RID: 44762
		private List<ItemData> mConverterList = new List<ItemData>();

		// Token: 0x0400AEDB RID: 44763
		private EpicTransformationConverterDataModel mEpicTransformationConverterDataModel;
	}
}
