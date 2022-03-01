using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016A5 RID: 5797
	public class CommonItemInfo : MonoBehaviour
	{
		// Token: 0x0600E3AD RID: 58285 RVA: 0x003AAAB7 File Offset: 0x003A8EB7
		private void Awake()
		{
			if (this.mItemBtn != null)
			{
				this.mItemBtn.onClick.RemoveAllListeners();
				this.mItemBtn.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(this.mItemData, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x0600E3AE RID: 58286 RVA: 0x003AAAF8 File Offset: 0x003A8EF8
		public void InitInterface(object data, ItemData equipmentItemData)
		{
			if (data == null || equipmentItemData == null)
			{
				return;
			}
			string path = string.Empty;
			string path2 = string.Empty;
			string text = string.Empty;
			string text2 = string.Empty;
			if (data is PrecBead)
			{
				PrecBead precBead = data as PrecBead;
				this.mItemData = ItemDataManager.CreateItemDataFromTable(precBead.preciousBeadId, 100, 0);
				path = this.mItemData.GetQualityInfo().Background;
				path2 = this.mItemData.Icon;
				text2 = this.mItemData.GetColorName(string.Empty, false);
				text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(precBead.preciousBeadId, false);
				if (precBead.randomBuffId > 0)
				{
					text += string.Format("\n附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(precBead.randomBuffId));
				}
			}
			else if (data is PrecEnchantmentCard)
			{
				PrecEnchantmentCard precEnchantmentCard = data as PrecEnchantmentCard;
				this.mItemData = ItemDataManager.CreateItemDataFromTable(precEnchantmentCard.iEnchantmentCardID, 100, 0);
				path = this.mItemData.GetQualityInfo().Background;
				path2 = this.mItemData.Icon;
				string arg = string.Empty;
				if (precEnchantmentCard.iEnchantmentCardLevel > 0)
				{
					arg = string.Format("+{0}", precEnchantmentCard.iEnchantmentCardLevel);
				}
				text2 = TR.Value("tip_magic_attribute_desc", this.mItemData.GetColorName(string.Empty, false), arg, this.mItemData.GetQualityInfo().ColStr);
				text = equipmentItemData.GetMagicDescs();
			}
			else if (data is InscriptionHoleData)
			{
				InscriptionHoleData inscriptionHoleData = data as InscriptionHoleData;
				this.mItemData = ItemDataManager.CreateItemDataFromTable(inscriptionHoleData.InscriptionId, 100, 0);
				if (this.mItemData == null)
				{
					this.mIcon.CustomActive(false);
					InscriptionHoleSetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionHoleSetTable>(inscriptionHoleData.Type, string.Empty, string.Empty);
					if (tableItem != null)
					{
						path = tableItem.InscriptionHolePicture;
						ETCImageLoader.LoadSprite(ref this.mBackGround, path, true);
					}
					this.mItemName.text = "暂未镶嵌铭文";
					return;
				}
				path = this.mItemData.GetQualityInfo().Background;
				path2 = this.mItemData.Icon;
				text2 = this.mItemData.GetColorName(string.Empty, false);
				text = this.mItemData.GetInscriptionAttrDesc();
			}
			ETCImageLoader.LoadSprite(ref this.mBackGround, path, true);
			ETCImageLoader.LoadSprite(ref this.mIcon, path2, true);
			this.mItemName.text = text2;
			this.mItemType.text = this.GetItemTypeDesc(this.mItemData);
			this.mItemAttr.text = text;
		}

		// Token: 0x0600E3AF RID: 58287 RVA: 0x003AAD84 File Offset: 0x003A9184
		private string GetItemTypeDesc(ItemData item)
		{
			string result = string.Empty;
			if (item.SubType == 54)
			{
				result = "宝珠";
			}
			else if (item.SubType == 25)
			{
				result = "附魔";
			}
			else if (item.SubType == 117)
			{
				result = "铭文";
			}
			return result;
		}

		// Token: 0x0600E3B0 RID: 58288 RVA: 0x003AADDB File Offset: 0x003A91DB
		private void OnDestroy()
		{
			this.mItemData = null;
		}

		// Token: 0x0400889C RID: 34972
		[SerializeField]
		private Image mBackGround;

		// Token: 0x0400889D RID: 34973
		[SerializeField]
		private Image mIcon;

		// Token: 0x0400889E RID: 34974
		[SerializeField]
		private Button mItemBtn;

		// Token: 0x0400889F RID: 34975
		[SerializeField]
		private Text mItemName;

		// Token: 0x040088A0 RID: 34976
		[SerializeField]
		private Text mItemType;

		// Token: 0x040088A1 RID: 34977
		[SerializeField]
		private Text mItemAttr;

		// Token: 0x040088A2 RID: 34978
		private ItemData mItemData;
	}
}
