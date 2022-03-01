using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CC2 RID: 7362
	public class TreasureConversionItem : MonoBehaviour
	{
		// Token: 0x17001DC3 RID: 7619
		// (get) Token: 0x060120F8 RID: 73976 RVA: 0x005486FF File Offset: 0x00546AFF
		// (set) Token: 0x060120F9 RID: 73977 RVA: 0x00548707 File Offset: 0x00546B07
		public ItemData TreasureItemData { get; set; }

		// Token: 0x060120FA RID: 73978 RVA: 0x00548710 File Offset: 0x00546B10
		private void Awake()
		{
			if (this.mIconBtn != null)
			{
				this.mIconBtn.onClick.RemoveAllListeners();
				this.mIconBtn.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(this.TreasureItemData, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x060120FB RID: 73979 RVA: 0x00548750 File Offset: 0x00546B50
		public void OnItemVisiable(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.TreasureItemData = itemData;
			if (this.mBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBackground, itemData.GetQualityInfo().Background, true);
			}
			if (this.mIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, itemData.Icon, true);
			}
			if (this.mCount != null)
			{
				if (itemData.ShowCount > 1)
				{
					this.mCount.text = itemData.ShowCount.ToString();
				}
				else
				{
					this.mCount.text = string.Empty;
				}
			}
			if (this.mName != null)
			{
				this.mName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.mAttr != null)
			{
				this.mAttr.text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(itemData.TableID, false);
			}
			if (this.mNewMark != null)
			{
				if (itemData.IsNew)
				{
					this.mNewMark.gameObject.CustomActive(true);
					DataManager<ItemDataManager>.GetInstance().NotifyItemBeOld(itemData);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
				}
				else
				{
					this.mNewMark.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060120FC RID: 73980 RVA: 0x005488BF File Offset: 0x00546CBF
		public void OnItemChangeDisplay(bool flag)
		{
			if (this.mCheckRoot != null)
			{
				this.mCheckRoot.CustomActive(flag);
			}
		}

		// Token: 0x0400BC3B RID: 48187
		[SerializeField]
		private Image mBackground;

		// Token: 0x0400BC3C RID: 48188
		[SerializeField]
		private Image mIcon;

		// Token: 0x0400BC3D RID: 48189
		[SerializeField]
		private Text mName;

		// Token: 0x0400BC3E RID: 48190
		[SerializeField]
		private Text mAttr;

		// Token: 0x0400BC3F RID: 48191
		[SerializeField]
		private Text mCount;

		// Token: 0x0400BC40 RID: 48192
		[SerializeField]
		private Button mIconBtn;

		// Token: 0x0400BC41 RID: 48193
		[SerializeField]
		private GameObject mCheckRoot;

		// Token: 0x0400BC42 RID: 48194
		[SerializeField]
		private GameObject mNewMark;
	}
}
