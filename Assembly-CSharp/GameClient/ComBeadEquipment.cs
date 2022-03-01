using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AD4 RID: 6868
	internal class ComBeadEquipment : MonoBehaviour
	{
		// Token: 0x17001D6E RID: 7534
		// (get) Token: 0x06010DC0 RID: 69056 RVA: 0x004CF43C File Offset: 0x004CD83C
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06010DC1 RID: 69057 RVA: 0x004CF460 File Offset: 0x004CD860
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010DC2 RID: 69058 RVA: 0x004CF46E File Offset: 0x004CD86E
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010DC3 RID: 69059 RVA: 0x004CF488 File Offset: 0x004CD888
		public void OnItemVisible(ItemData itemData)
		{
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			Text text = this.beadName;
			string colorName = itemData.GetColorName(string.Empty, false);
			this.Name.text = colorName;
			text.text = colorName;
			Text text2 = this.checkBeadName;
			colorName = itemData.GetColorName(string.Empty, false);
			this.checkName.text = colorName;
			text2.text = colorName;
			if (itemData != null)
			{
				PrecBead precBead = null;
				for (int i = 0; i < itemData.PreciousBeadMountHole.Length; i++)
				{
					PrecBead precBead2 = itemData.PreciousBeadMountHole[i];
					if (precBead2 != null)
					{
						precBead = precBead2;
						break;
					}
				}
				if (precBead != null)
				{
					this.mCanBeSetRoot.CustomActive(false);
					this.mHasBeenSetRoot.CustomActive(false);
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(precBead.preciousBeadId, 100, 0);
					if (itemData2 != null)
					{
						if (this.beadCardComItem == null)
						{
							this.beadCardComItem = ComItemManager.Create(this.mBeadCardParent);
						}
						ComItem comItem = this.beadCardComItem;
						ItemData item = itemData2;
						if (ComBeadEquipment.<>f__mg$cache0 == null)
						{
							ComBeadEquipment.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem.Setup(item, ComBeadEquipment.<>f__mg$cache0);
						string attributesDesc = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(precBead.preciousBeadId, false);
						int count = Regex.Matches(attributesDesc, "\n").Count;
						if (count > 2)
						{
							this.mBeadCardAttr.alignment = 0;
						}
						else
						{
							this.mBeadCardAttr.alignment = 3;
						}
						if (this.mBeadCardAttr != null)
						{
							this.mBeadCardAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(precBead.preciousBeadId, false);
							if (precBead.randomBuffId > 0)
							{
								Text text3 = this.mBeadCardAttr;
								text3.text += string.Format("\n附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(precBead.randomBuffId));
							}
						}
						this.mHasBeenSetRoot.CustomActive(true);
					}
					else
					{
						this.mCanBeSetRoot.CustomActive(true);
					}
				}
			}
			this.equiptedMark.CustomActive(itemData.PackageType == EPackageType.WearEquip);
			base.gameObject.name = itemData.TableID.ToString();
			if (itemData.PackageType == EPackageType.WearEquip)
			{
				this.comFunctionBinder.ClearCheckFunctions();
				this.comFunctionBinder.SpecialItem = itemData;
				this.comFunctionBinder.AddCheckFunction(SmithFunctionRedBinder.SmithFunctionType.SFT_PEARLINLAY);
				ETCImageLoader.LoadSprite(ref this.redHintText, TR.Value("SMITH_CAN_ADDMAGIC"), true);
			}
			else
			{
				this.comFunctionBinder.SpecialItem = null;
				this.comFunctionBinder.ClearCheckFunctions();
			}
			if (itemData.Type == ItemTable.eType.FUCKTITTLE)
			{
				bool enabled = itemData.Packing || itemData.iMaxPackTime > 0;
				this.mGrayRoot.enabled = enabled;
			}
			else
			{
				this.mGrayRoot.enabled = false;
			}
		}

		// Token: 0x06010DC4 RID: 69060 RVA: 0x004CF780 File Offset: 0x004CDB80
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0400AD14 RID: 44308
		public static ItemData ms_selected;

		// Token: 0x0400AD15 RID: 44309
		public ComCommonBind mBind;

		// Token: 0x0400AD16 RID: 44310
		public Text Name;

		// Token: 0x0400AD17 RID: 44311
		public Text beadName;

		// Token: 0x0400AD18 RID: 44312
		public Text checkName;

		// Token: 0x0400AD19 RID: 44313
		public Text checkBeadName;

		// Token: 0x0400AD1A RID: 44314
		public GameObject equiptedMark;

		// Token: 0x0400AD1B RID: 44315
		public GameObject goItemParent;

		// Token: 0x0400AD1C RID: 44316
		public GameObject goCheckMark;

		// Token: 0x0400AD1D RID: 44317
		public Image redHintText;

		// Token: 0x0400AD1E RID: 44318
		public Image imageItemBack;

		// Token: 0x0400AD1F RID: 44319
		public Text mAttrDesc;

		// Token: 0x0400AD20 RID: 44320
		[SerializeField]
		private UIGray mGrayRoot;

		// Token: 0x0400AD21 RID: 44321
		[SerializeField]
		private GameObject mCanBeSetRoot;

		// Token: 0x0400AD22 RID: 44322
		[SerializeField]
		private GameObject mHasBeenSetRoot;

		// Token: 0x0400AD23 RID: 44323
		[SerializeField]
		private GameObject mBeadCardParent;

		// Token: 0x0400AD24 RID: 44324
		[SerializeField]
		private Text mBeadCardAttr;

		// Token: 0x0400AD25 RID: 44325
		private ComItem comItem;

		// Token: 0x0400AD26 RID: 44326
		public SmithFunctionRedBinder comFunctionBinder;

		// Token: 0x0400AD27 RID: 44327
		private ComItem beadCardComItem;

		// Token: 0x0400AD28 RID: 44328
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
