using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001930 RID: 6448
	public class BlessingCardPackageItem : MonoBehaviour
	{
		// Token: 0x0600FACE RID: 64206 RVA: 0x0044B2E4 File Offset: 0x004496E4
		private void Awake()
		{
			if (this.sellBtn != null)
			{
				this.sellBtn.onClick.RemoveAllListeners();
				this.sellBtn.onClick.AddListener(new UnityAction(this.OnSellBtnClick));
			}
			if (this.itemIconBtn != null)
			{
				this.itemIconBtn.onClick.RemoveAllListeners();
				this.itemIconBtn.onClick.AddListener(new UnityAction(this.OnItemIconBtnClick));
			}
		}

		// Token: 0x0600FACF RID: 64207 RVA: 0x0044B36C File Offset: 0x0044976C
		private void OnDestroy()
		{
			this.monpolyCard = null;
			if (this.sellBtn != null)
			{
				this.sellBtn.onClick.RemoveListener(new UnityAction(this.OnSellBtnClick));
			}
			if (this.itemIconBtn != null)
			{
				this.itemIconBtn.onClick.RemoveListener(new UnityAction(this.OnItemIconBtnClick));
			}
		}

		// Token: 0x0600FAD0 RID: 64208 RVA: 0x0044B3DC File Offset: 0x004497DC
		public void OnItemVisiable(MonpolyCard monpolyCard)
		{
			if (monpolyCard == null)
			{
				return;
			}
			this.monpolyCard = monpolyCard;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)monpolyCard.id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
				if (this.background != null && qualityInfo != null)
				{
					ETCImageLoader.LoadSprite(ref this.background, qualityInfo.Background, true);
				}
				if (this.itemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.itemIcon, tableItem.Icon, true);
				}
			}
			if (this.itemCount != null)
			{
				this.itemCount.text = string.Format("x{0}", monpolyCard.num);
			}
		}

		// Token: 0x0600FAD1 RID: 64209 RVA: 0x0044B4A5 File Offset: 0x004498A5
		private void OnSellBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BlessingCardSellFrame>(FrameLayer.Middle, this.monpolyCard, string.Empty);
		}

		// Token: 0x0600FAD2 RID: 64210 RVA: 0x0044B4C0 File Offset: 0x004498C0
		private void OnItemIconBtnClick()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.monpolyCard.id, 100, 0);
			if (itemData != null)
			{
				itemData.Count = (int)this.monpolyCard.num;
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x04009CB0 RID: 40112
		[SerializeField]
		private Image background;

		// Token: 0x04009CB1 RID: 40113
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04009CB2 RID: 40114
		[SerializeField]
		private Text itemCount;

		// Token: 0x04009CB3 RID: 40115
		[SerializeField]
		private Button sellBtn;

		// Token: 0x04009CB4 RID: 40116
		[SerializeField]
		private Button itemIconBtn;

		// Token: 0x04009CB5 RID: 40117
		private MonpolyCard monpolyCard;
	}
}
