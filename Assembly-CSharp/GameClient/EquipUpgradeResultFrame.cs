using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B0E RID: 6926
	public class EquipUpgradeResultFrame : ClientFrame
	{
		// Token: 0x06011000 RID: 69632 RVA: 0x004DCD98 File Offset: 0x004DB198
		protected sealed override void _bindExUI()
		{
			this.mItemParent = this.mBind.GetGameObject("ItemParent");
			this.mItemname = this.mBind.GetCom<Text>("itemname");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mArrt = this.mBind.GetCom<Text>("Arrt");
			this.mTitle = this.mBind.GetCom<Text>("title");
			this.mHint = this.mBind.GetGameObject("Hint");
			this.mInscriptionFail = this.mBind.GetGameObject("InscriptionFail");
		}

		// Token: 0x06011001 RID: 69633 RVA: 0x004DCE6C File Offset: 0x004DB26C
		protected sealed override void _unbindExUI()
		{
			this.mItemParent = null;
			this.mItemname = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mArrt = null;
			this.mTitle = null;
			this.mHint = null;
			this.mInscriptionFail = null;
		}

		// Token: 0x06011002 RID: 69634 RVA: 0x004DCED7 File Offset: 0x004DB2D7
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipUpgradeResultFrame>(this, false);
		}

		// Token: 0x06011003 RID: 69635 RVA: 0x004DCEE6 File Offset: 0x004DB2E6
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EquipUpgrade/EquipUpgradeResultFrame";
		}

		// Token: 0x06011004 RID: 69636 RVA: 0x004DCEF0 File Offset: 0x004DB2F0
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData is ItemData)
			{
				ItemData itemData = this.userData as ItemData;
				if (itemData != null)
				{
					ComItem comItem = ComItemManager.Create(this.mItemParent);
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (EquipUpgradeResultFrame.<>f__mg$cache0 == null)
					{
						EquipUpgradeResultFrame.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, EquipUpgradeResultFrame.<>f__mg$cache0);
					this.mItemname.text = itemData.GetColorName(string.Empty, false);
				}
			}
			else if (this.userData is EnchantmentCardUpgradeSuccessData)
			{
				EnchantmentCardUpgradeSuccessData enchantmentCardUpgradeSuccessData = this.userData as EnchantmentCardUpgradeSuccessData;
				if (enchantmentCardUpgradeSuccessData != null)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(enchantmentCardUpgradeSuccessData.mEnchantmentCardID, 100, 0);
					ComItem comItem3 = ComItemManager.Create(this.mItemParent);
					ComItem comItem4 = comItem3;
					ItemData item2 = itemData2;
					if (EquipUpgradeResultFrame.<>f__mg$cache1 == null)
					{
						EquipUpgradeResultFrame.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem4.Setup(item2, EquipUpgradeResultFrame.<>f__mg$cache1);
					if (enchantmentCardUpgradeSuccessData.mEnchantmentCardLevel > 0)
					{
						this.mItemname.text = string.Format("{0}+{1}", itemData2.GetColorName(string.Empty, false), enchantmentCardUpgradeSuccessData.mEnchantmentCardLevel);
					}
					else
					{
						this.mItemname.text = string.Format("{0}", itemData2.GetColorName(string.Empty, false));
					}
					if (enchantmentCardUpgradeSuccessData.isSuccess)
					{
						this.mArrt.text = string.Format("<color={0}>附魔卡属性:</color>", "#0FCF6Aff");
						Text text = this.mArrt;
						text.text += DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(enchantmentCardUpgradeSuccessData.mEnchantmentCardID, enchantmentCardUpgradeSuccessData.mEnchantmentCardLevel, false);
					}
					else
					{
						this.mTitle.text = "升级失败";
						this.mTitle.color = Color.red;
					}
					this.mHint.CustomActive(enchantmentCardUpgradeSuccessData.isSuccess);
				}
			}
			else if (this.userData is InscriptionMosaicSuccessData)
			{
				InscriptionMosaicSuccessData inscriptionMosaicSuccessData = this.userData as InscriptionMosaicSuccessData;
				if (inscriptionMosaicSuccessData != null)
				{
					this.mTitle.text = "镶嵌成功";
					ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(inscriptionMosaicSuccessData.guid);
					if (item3 != null)
					{
						ComItem comItem5 = ComItemManager.Create(this.mItemParent);
						ComItem comItem6 = comItem5;
						ItemData item4 = item3;
						if (EquipUpgradeResultFrame.<>f__mg$cache2 == null)
						{
							EquipUpgradeResultFrame.<>f__mg$cache2 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem6.Setup(item4, EquipUpgradeResultFrame.<>f__mg$cache2);
						this.mItemname.text = item3.GetColorName(string.Empty, false);
					}
					this.mArrt.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(inscriptionMosaicSuccessData.inscriptionId, true);
					this.mHint.CustomActive(true);
				}
			}
			else if (this.userData is InscriptionExtractResultData)
			{
				InscriptionExtractResultData inscriptionExtractResultData = this.userData as InscriptionExtractResultData;
				if (inscriptionExtractResultData != null)
				{
					if (inscriptionExtractResultData.IsSuccessed)
					{
						this.mTitle.text = "摘取成功";
						ItemData inscriptionItemData = inscriptionExtractResultData.InscriptionItemData;
						if (inscriptionItemData != null)
						{
							ComItem comItem7 = ComItemManager.Create(this.mItemParent);
							ComItem comItem8 = comItem7;
							ItemData item5 = inscriptionItemData;
							if (EquipUpgradeResultFrame.<>f__mg$cache3 == null)
							{
								EquipUpgradeResultFrame.<>f__mg$cache3 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem8.Setup(item5, EquipUpgradeResultFrame.<>f__mg$cache3);
							this.mItemname.text = inscriptionItemData.GetColorName(string.Empty, false);
							this.mArrt.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(inscriptionItemData.TableID, true);
						}
					}
					else
					{
						this.mTitle.text = "摘取失败";
						this.mTitle.color = Color.red;
						this.mInscriptionFail.CustomActive(true);
					}
					this.mHint.CustomActive(inscriptionExtractResultData.IsSuccessed);
				}
			}
			else if (this.userData is InscriptionFracturnResultData)
			{
				InscriptionFracturnResultData inscriptionFracturnResultData = this.userData as InscriptionFracturnResultData;
				if (inscriptionFracturnResultData != null)
				{
					if (inscriptionFracturnResultData.IsSuccessed)
					{
						this.mTitle.text = "碎裂成功";
						this.mInscriptionFail.CustomActive(true);
					}
					this.mHint.CustomActive(false);
				}
			}
			else if (this.userData is EpicEquipmentTransformationSuccessData)
			{
				EpicEquipmentTransformationSuccessData epicEquipmentTransformationSuccessData = this.userData as EpicEquipmentTransformationSuccessData;
				if (epicEquipmentTransformationSuccessData != null && epicEquipmentTransformationSuccessData.itemData != null)
				{
					this.mTitle.text = "转化成功";
					ComItem comItem9 = ComItemManager.Create(this.mItemParent);
					ComItem comItem10 = comItem9;
					ItemData itemData3 = epicEquipmentTransformationSuccessData.itemData;
					if (EquipUpgradeResultFrame.<>f__mg$cache4 == null)
					{
						EquipUpgradeResultFrame.<>f__mg$cache4 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem10.Setup(itemData3, EquipUpgradeResultFrame.<>f__mg$cache4);
					this.mItemname.text = epicEquipmentTransformationSuccessData.itemData.GetColorName(string.Empty, false);
				}
			}
		}

		// Token: 0x06011005 RID: 69637 RVA: 0x004DD375 File Offset: 0x004DB775
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0400AEFA RID: 44794
		private GameObject mItemParent;

		// Token: 0x0400AEFB RID: 44795
		private Text mItemname;

		// Token: 0x0400AEFC RID: 44796
		private Button mClose;

		// Token: 0x0400AEFD RID: 44797
		private Text mArrt;

		// Token: 0x0400AEFE RID: 44798
		private Text mTitle;

		// Token: 0x0400AEFF RID: 44799
		private GameObject mHint;

		// Token: 0x0400AF00 RID: 44800
		private GameObject mInscriptionFail;

		// Token: 0x0400AF01 RID: 44801
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AF02 RID: 44802
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;

		// Token: 0x0400AF03 RID: 44803
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache2;

		// Token: 0x0400AF04 RID: 44804
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache3;

		// Token: 0x0400AF05 RID: 44805
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache4;
	}
}
