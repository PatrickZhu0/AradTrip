using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AEA RID: 6890
	internal class ComSealEquipment : MonoBehaviour
	{
		// Token: 0x17001D7A RID: 7546
		// (get) Token: 0x06010EA3 RID: 69283 RVA: 0x004D4891 File Offset: 0x004D2C91
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06010EA4 RID: 69284 RVA: 0x004D48B5 File Offset: 0x004D2CB5
		public static bool CheckCanSeal(ItemData x)
		{
			return x.iMaxPackTime > 0 && !x.Packing && x.RePackTime > 0 && !x.isInSidePack;
		}

		// Token: 0x06010EA5 RID: 69285 RVA: 0x004D48E6 File Offset: 0x004D2CE6
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010EA6 RID: 69286 RVA: 0x004D48F4 File Offset: 0x004D2CF4
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010EA7 RID: 69287 RVA: 0x004D490C File Offset: 0x004D2D0C
		public void OnItemVisible(ItemData itemData, SmithShopNewTabType eFunctionType, bool isShowIncriptionHolInfo = false)
		{
			this.eFunctionType = eFunctionType;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.checkName.text = itemData.GetColorName(string.Empty, false);
			this.equiptedMark.CustomActive(itemData.PackageType == EPackageType.WearEquip);
			base.gameObject.name = itemData.TableID.ToString();
			if (eFunctionType == SmithShopNewTabType.SSNTT_ADJUST && itemData.PackageType == EPackageType.WearEquip)
			{
				this.comFunctionBinder.ClearCheckFunctions();
				this.comFunctionBinder.SpecialItem = itemData;
				this.comFunctionBinder.AddCheckFunction(SmithFunctionRedBinder.SmithFunctionType.SFT_ADJUST);
				ETCImageLoader.LoadSprite(ref this.redPointHint, TR.Value("SMITH_CAN_ADJUST_QUALITY"), true);
			}
			else
			{
				this.comFunctionBinder.SpecialItem = null;
				this.comFunctionBinder.ClearCheckFunctions();
			}
			if (isShowIncriptionHolInfo)
			{
				if (this.mGoInscriptionHoles != null && this.mGoInscriptionHoles.Count > 0)
				{
					for (int i = 0; i < this.mGoInscriptionHoles.Count; i++)
					{
						this.mGoInscriptionHoles[i].CustomActive(false);
					}
				}
				bool flag = false;
				if (itemData.InscriptionHoles != null)
				{
					for (int j = 0; j < itemData.InscriptionHoles.Count; j++)
					{
						InscriptionHoleData inscriptionHoleData = itemData.InscriptionHoles[j];
						if (inscriptionHoleData != null)
						{
							if (inscriptionHoleData.InscriptionId > 0)
							{
								flag = true;
								if (j < this.mGoInscriptionHoles.Count)
								{
									this.mGoInscriptionHoles[j].CustomActive(true);
									EquipmentInscriptionHole component = this.mGoInscriptionHoles[j].GetComponent<EquipmentInscriptionHole>();
									if (component != null)
									{
										component.OnItemVisiable(itemData.InscriptionHoles[j]);
									}
								}
								else
								{
									GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mEquipmentInscriptionHolePath, true, 0U);
									if (gameObject != null)
									{
										Utility.AttachTo(gameObject, this.goInscriptionHoleRoot, false);
										EquipmentInscriptionHole component2 = gameObject.GetComponent<EquipmentInscriptionHole>();
										if (component2 != null)
										{
											component2.OnItemVisiable(itemData.InscriptionHoles[j]);
										}
										this.mGoInscriptionHoles.Add(gameObject);
									}
								}
							}
						}
					}
					if (flag)
					{
						this.Name.rectTransform.anchoredPosition = new Vector2(this.Name.rectTransform.anchoredPosition.x, 60f);
					}
					else
					{
						this.Name.rectTransform.anchoredPosition = new Vector2(this.Name.rectTransform.anchoredPosition.x, 0f);
					}
				}
			}
		}

		// Token: 0x06010EA8 RID: 69288 RVA: 0x004D4BFC File Offset: 0x004D2FFC
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0400ADC8 RID: 44488
		public static ItemData ms_selected;

		// Token: 0x0400ADC9 RID: 44489
		public Text Name;

		// Token: 0x0400ADCA RID: 44490
		public Text checkName;

		// Token: 0x0400ADCB RID: 44491
		public GameObject equiptedMark;

		// Token: 0x0400ADCC RID: 44492
		public GameObject goItemParent;

		// Token: 0x0400ADCD RID: 44493
		public GameObject goCheckMark;

		// Token: 0x0400ADCE RID: 44494
		public GameObject goInscriptionHoleRoot;

		// Token: 0x0400ADCF RID: 44495
		public Image redPointHint;

		// Token: 0x0400ADD0 RID: 44496
		public Image imageItemBack;

		// Token: 0x0400ADD1 RID: 44497
		public string mEquipmentInscriptionHolePath = "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionHole";

		// Token: 0x0400ADD2 RID: 44498
		private ComItem comItem;

		// Token: 0x0400ADD3 RID: 44499
		public SmithFunctionRedBinder comFunctionBinder;

		// Token: 0x0400ADD4 RID: 44500
		private SmithShopNewTabType eFunctionType = SmithShopNewTabType.SSNTT_ADJUST;

		// Token: 0x0400ADD5 RID: 44501
		private List<GameObject> mGoInscriptionHoles = new List<GameObject>();
	}
}
