using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016B2 RID: 5810
	internal class EquipMasterFrame : ClientFrame
	{
		// Token: 0x0600E3DD RID: 58333 RVA: 0x003ADD3F File Offset: 0x003AC13F
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/EquipMaster/EquipMaster";
		}

		// Token: 0x0600E3DE RID: 58334 RVA: 0x003ADD48 File Offset: 0x003AC148
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			EquipProp equipProp = new EquipProp();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					EquipProp equipMasterProp = DataManager<EquipMasterDataManager>.GetInstance().GetEquipMasterProp(DataManager<PlayerBaseData>.GetInstance().JobTableID, item);
					if (equipMasterProp != null)
					{
						EquipMasterFrame.Part part = this._GetPart((ItemTable.eSubType)item.SubType);
						if (part != null)
						{
							part.SetActive(true);
						}
						equipProp += equipMasterProp;
					}
				}
			}
			List<string> propsFormatStr = equipProp.GetPropsFormatStr();
			for (int j = 0; j < propsFormatStr.Count; j++)
			{
				if (j < 0 || j >= this.m_arrValues.Count)
				{
					break;
				}
				this.m_arrValues[j].text = propsFormatStr[j];
			}
		}

		// Token: 0x0600E3DF RID: 58335 RVA: 0x003ADE48 File Offset: 0x003AC248
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
		}

		// Token: 0x0600E3E0 RID: 58336 RVA: 0x003ADE50 File Offset: 0x003AC250
		private void _InitUI()
		{
			this.m_arrParts.Add(new EquipMasterFrame.Part(ItemTable.eSubType.HEAD, this.frame));
			this.m_arrParts.Add(new EquipMasterFrame.Part(ItemTable.eSubType.CHEST, this.frame));
			this.m_arrParts.Add(new EquipMasterFrame.Part(ItemTable.eSubType.BELT, this.frame));
			this.m_arrParts.Add(new EquipMasterFrame.Part(ItemTable.eSubType.LEG, this.frame));
			this.m_arrParts.Add(new EquipMasterFrame.Part(ItemTable.eSubType.BOOT, this.frame));
			for (int i = 0; i < 6; i++)
			{
				Text componetInChild = Utility.GetComponetInChild<Text>(this.frame, string.Format("Content/Attr/BG/Value{0}", i));
				if (componetInChild != null)
				{
					componetInChild.text = string.Empty;
					this.m_arrValues.Add(componetInChild);
				}
			}
		}

		// Token: 0x0600E3E1 RID: 58337 RVA: 0x003ADF21 File Offset: 0x003AC321
		private void _ClearUI()
		{
			this.m_arrParts.Clear();
			this.m_arrValues.Clear();
		}

		// Token: 0x0600E3E2 RID: 58338 RVA: 0x003ADF3C File Offset: 0x003AC33C
		private EquipMasterFrame.Part _GetPart(ItemTable.eSubType a_part)
		{
			for (int i = 0; i < this.m_arrParts.Count; i++)
			{
				if (this.m_arrParts[i].part == a_part)
				{
					return this.m_arrParts[i];
				}
			}
			return null;
		}

		// Token: 0x0600E3E3 RID: 58339 RVA: 0x003ADF8A File Offset: 0x003AC38A
		[UIEventHandle("Black")]
		private void _OnBackCLicked()
		{
			this.frameMgr.CloseFrame<EquipMasterFrame>(this, false);
		}

		// Token: 0x040088DA RID: 35034
		[UIControl("Content/Title/Text", null, 0)]
		private Text m_labTitle;

		// Token: 0x040088DB RID: 35035
		[UIControl("Content/Desc/Desc1", null, 0)]
		private Text m_labMasterDesc1;

		// Token: 0x040088DC RID: 35036
		[UIControl("Content/Desc/Desc2", null, 0)]
		private Text m_labMasterDesc2;

		// Token: 0x040088DD RID: 35037
		private List<EquipMasterFrame.Part> m_arrParts = new List<EquipMasterFrame.Part>();

		// Token: 0x040088DE RID: 35038
		private List<Text> m_arrValues = new List<Text>();

		// Token: 0x020016B3 RID: 5811
		private class Part
		{
			// Token: 0x0600E3E4 RID: 58340 RVA: 0x003ADF9C File Offset: 0x003AC39C
			public Part(ItemTable.eSubType a_part, GameObject a_frame)
			{
				this.part = a_part;
				this.m_imgBG1 = Utility.GetComponetInChild<Image>(a_frame, string.Format("Content/State/Part{0}/BG1", (int)a_part));
				this.m_comIcon = Utility.GetComponetInChild<UIGray>(a_frame, string.Format("Content/State/Part{0}/Icon", (int)a_part));
				this.m_objLine = Utility.FindGameObject(a_frame, string.Format("Content/State/Part{0}/Line", (int)a_part), true);
				this.m_bActive = true;
				this.SetActive(false);
				this.m_labName = Utility.GetComponetInChild<Text>(a_frame, string.Format("Content/State/Part{0}/Name", (int)a_part));
				this.m_labName.text = TR.Value(((EEquipWearSlotType)a_part).GetDescription(true));
			}

			// Token: 0x0600E3E5 RID: 58341 RVA: 0x003AE054 File Offset: 0x003AC454
			public void SetActive(bool a_bActive)
			{
				if (this.m_bActive != a_bActive)
				{
					this.m_bActive = a_bActive;
					if (this.m_imgBG1 != null)
					{
						if (this.m_bActive)
						{
							ETCImageLoader.LoadSprite(ref this.m_imgBG1, "UIPacked/p-Armor.png:Armor_icon_jt", true);
							this.m_imgBG1.SetNativeSize();
						}
						else
						{
							ETCImageLoader.LoadSprite(ref this.m_imgBG1, "UIPacked/p-Armor.png:Armor_icon_N", true);
							this.m_imgBG1.SetNativeSize();
						}
					}
					if (this.m_comIcon != null)
					{
						this.m_comIcon.enabled = !this.m_bActive;
					}
					if (this.m_objLine != null)
					{
						this.m_objLine.SetActive(this.m_bActive);
					}
				}
			}

			// Token: 0x040088DF RID: 35039
			private bool m_bActive;

			// Token: 0x040088E0 RID: 35040
			private Image m_imgBG1;

			// Token: 0x040088E1 RID: 35041
			private UIGray m_comIcon;

			// Token: 0x040088E2 RID: 35042
			private GameObject m_objLine;

			// Token: 0x040088E3 RID: 35043
			private Text m_labName;

			// Token: 0x040088E4 RID: 35044
			public ItemTable.eSubType part;
		}
	}
}
