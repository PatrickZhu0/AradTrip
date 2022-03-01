using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B22 RID: 6946
	internal class ComFashionMergeItemNew : MonoBehaviour
	{
		// Token: 0x17001D95 RID: 7573
		// (get) Token: 0x06011103 RID: 69891 RVA: 0x004E3F23 File Offset: 0x004E2323
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06011104 RID: 69892 RVA: 0x004E3F47 File Offset: 0x004E2347
		public void OnCreate(ClientFrame frame)
		{
			this.clientFrame = (frame as FashionMergeNewFrame);
			if (frame != null)
			{
				this.comItem = frame.CreateComItem(this.goItemParent);
				this.comItem.imgBackGround.enabled = false;
			}
		}

		// Token: 0x06011105 RID: 69893 RVA: 0x004E3F7E File Offset: 0x004E237E
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(false);
		}

		// Token: 0x06011106 RID: 69894 RVA: 0x004E3F8C File Offset: 0x004E238C
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06011107 RID: 69895 RVA: 0x004E3FA4 File Offset: 0x004E23A4
		public static FashionMergeType GetFashionMergeType(ItemData itemData)
		{
			FashionMergeType result = FashionMergeType.MT_COUNT;
			if (itemData != null)
			{
				switch (itemData.FashionWearSlotType)
				{
				case EFashionWearSlotType.Head:
					result = FashionMergeType.FMT_HEAD;
					break;
				case EFashionWearSlotType.Waist:
					result = FashionMergeType.FMT_WAIST;
					break;
				case EFashionWearSlotType.UpperBody:
					result = FashionMergeType.FMT_UPPER_BODY;
					break;
				case EFashionWearSlotType.LowerBody:
					result = FashionMergeType.FMT_LOWER_BODY;
					break;
				case EFashionWearSlotType.Chest:
					result = FashionMergeType.FMT_CHEST;
					break;
				default:
					result = FashionMergeType.MT_COUNT;
					break;
				}
			}
			return result;
		}

		// Token: 0x06011108 RID: 69896 RVA: 0x004E400C File Offset: 0x004E240C
		public void OnItemVisible(ItemData itemData)
		{
			this.eFashionMergeType = ComFashionMergeItemNew.GetFashionMergeType(itemData);
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.Atrribute.text = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(itemData.FashionAttributeID, "fashion_attribute_color", string.Empty);
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			base.gameObject.name = itemData.TableID.ToString();
		}

		// Token: 0x06011109 RID: 69897 RVA: 0x004E4098 File Offset: 0x004E2498
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem.imgBackGround.enabled = true;
				this.comItem = null;
			}
			this.clientFrame = null;
		}

		// Token: 0x0400AFBC RID: 44988
		public static ItemData ms_selected_left;

		// Token: 0x0400AFBD RID: 44989
		public static ItemData ms_selected_right;

		// Token: 0x0400AFBE RID: 44990
		public GameObject goItemParent;

		// Token: 0x0400AFBF RID: 44991
		public Text Name;

		// Token: 0x0400AFC0 RID: 44992
		public Text Atrribute;

		// Token: 0x0400AFC1 RID: 44993
		public GameObject goCheckMark;

		// Token: 0x0400AFC2 RID: 44994
		public Image imageItemBack;

		// Token: 0x0400AFC3 RID: 44995
		private ComItem comItem;

		// Token: 0x0400AFC4 RID: 44996
		private FashionMergeNewFrame clientFrame;

		// Token: 0x0400AFC5 RID: 44997
		private FashionMergeType eFashionMergeType = FashionMergeType.MT_COUNT;
	}
}
