using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015B1 RID: 5553
	internal class EnchantResultFrame : ClientFrame
	{
		// Token: 0x0600D921 RID: 55585 RVA: 0x00366404 File Offset: 0x00364804
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EnchantResultFrame";
		}

		// Token: 0x0600D922 RID: 55586 RVA: 0x0036640C File Offset: 0x0036480C
		protected sealed override void _OnOpenFrame()
		{
			this.m_goParent = Utility.FindChild(this.frame, "ok/common_black/ItemParent");
			this.m_kComItem = base.CreateComItem(this.m_goParent);
			if (this.userData is EnchantResultFrame.EnchantResultFrameData)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(12);
				this.SetData(this.userData as EnchantResultFrame.EnchantResultFrameData);
			}
			else if (this.userData is EquipmentClearChangeActivationResultData)
			{
				EquipmentClearChangeActivationResultData equipmentClearChangeActivationResultData = this.userData as EquipmentClearChangeActivationResultData;
				string text = string.Empty;
				string text2 = string.Empty;
				if (equipmentClearChangeActivationResultData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Clear)
				{
					text = TR.Value("equipment_clear_success");
				}
				else if (equipmentClearChangeActivationResultData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Activate)
				{
					text = TR.Value("equipment_activation_success");
					text2 = TR.Value("growth_attr_des", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(equipmentClearChangeActivationResultData.mEquipItemData.GrowthAttrType), equipmentClearChangeActivationResultData.mEquipItemData.GrowthAttrNum);
				}
				else if (equipmentClearChangeActivationResultData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Change)
				{
					text = TR.Value("equipment_changed_success");
					text2 = TR.Value("growth_attr_des", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(equipmentClearChangeActivationResultData.mEquipItemData.GrowthAttrType), equipmentClearChangeActivationResultData.mEquipItemData.GrowthAttrNum);
				}
				this.m_kTitle.text = text;
				this.m_kComItem.Setup(equipmentClearChangeActivationResultData.mEquipItemData, new ComItem.OnItemClicked(this.OnItemClicked));
				if (equipmentClearChangeActivationResultData.mEquipItemData != null)
				{
					this.m_kName.text = equipmentClearChangeActivationResultData.mEquipItemData.GetColorName(string.Empty, false);
				}
				this.m_kAttributes.text = text2;
			}
			else if (this.userData is MaterialsSynthesisResultData)
			{
				MaterialsSynthesisResultData materialsSynthesisResultData = this.userData as MaterialsSynthesisResultData;
				this.m_kTitle.text = "合成成功";
				this.m_kAttributes.text = string.Empty;
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(materialsSynthesisResultData.itemId, 100, 0);
				if (itemData != null)
				{
					itemData.Count = materialsSynthesisResultData.itemNumber;
				}
				this.m_kComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.m_kName.text = itemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x0600D923 RID: 55587 RVA: 0x0036663D File Offset: 0x00364A3D
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
		}

		// Token: 0x0600D924 RID: 55588 RVA: 0x00366646 File Offset: 0x00364A46
		[UIEventHandle("OK")]
		private void OnFunction()
		{
			this.frameMgr.CloseFrame<EnchantResultFrame>(this, false);
		}

		// Token: 0x0600D925 RID: 55589 RVA: 0x00366655 File Offset: 0x00364A55
		private void _OnClickCard(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600D926 RID: 55590 RVA: 0x00366667 File Offset: 0x00364A67
		private void _OnClickItem(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600D927 RID: 55591 RVA: 0x0036667C File Offset: 0x00364A7C
		public void SetData(EnchantResultFrame.EnchantResultFrameData data)
		{
			this.m_kData = data;
			this.m_kComItem.Setup(this.m_kData.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			if (this.m_kData.itemData != null)
			{
				this.m_kName.text = this.m_kData.itemData.GetColorName(string.Empty, false);
			}
			else
			{
				this.m_kName.text = "none";
			}
			if (this.m_kData.bMerge)
			{
				this.m_kAttributes.text = DataManager<EnchantmentsCardManager>.GetInstance().GetCondition(data.itemData.TableID);
				Text kAttributes = this.m_kAttributes;
				kAttributes.text += "\n";
				Text kAttributes2 = this.m_kAttributes;
				kAttributes2.text += DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(data.itemData.TableID, data.iCardLevel, false);
				this.m_kTitle.text = TR.Value("magic_merge_ok");
			}
			else
			{
				this.m_kAttributes.text = string.Format("<color={0}>附魔属性:</color>", "#0FCF6Aff");
				Text kAttributes3 = this.m_kAttributes;
				kAttributes3.text += DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.m_kData.iCardTableID, this.m_kData.iCardLevel, false);
				this.m_kTitle.text = TR.Value("magic_ok");
			}
		}

		// Token: 0x0600D928 RID: 55592 RVA: 0x003667F5 File Offset: 0x00364BF5
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x04007F96 RID: 32662
		private EnchantResultFrame.EnchantResultFrameData m_kData;

		// Token: 0x04007F97 RID: 32663
		private GameObject m_goParent;

		// Token: 0x04007F98 RID: 32664
		private ComItem m_kComItem;

		// Token: 0x04007F99 RID: 32665
		[UIControl("ok/common_black/itemname", null, 0)]
		private Text m_kName;

		// Token: 0x04007F9A RID: 32666
		[UIControl("ScrollView/Viewport/content/Text", null, 0)]
		private Text m_kAttributes;

		// Token: 0x04007F9B RID: 32667
		[UIControl("ok/common_black/Title", null, 0)]
		private Text m_kTitle;

		// Token: 0x020015B2 RID: 5554
		public class EnchantResultFrameData
		{
			// Token: 0x04007F9C RID: 32668
			public bool bMerge;

			// Token: 0x04007F9D RID: 32669
			public ItemData itemData;

			// Token: 0x04007F9E RID: 32670
			public int iCardTableID;

			// Token: 0x04007F9F RID: 32671
			public int iCardLevel;
		}
	}
}
