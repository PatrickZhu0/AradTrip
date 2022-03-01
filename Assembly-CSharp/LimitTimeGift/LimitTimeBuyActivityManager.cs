using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace LimitTimeGift
{
	// Token: 0x0200172F RID: 5935
	public class LimitTimeBuyActivityManager : Singleton<LimitTimeBuyActivityManager>
	{
		// Token: 0x17001CC5 RID: 7365
		// (get) Token: 0x0600E94F RID: 59727 RVA: 0x003DC8D1 File Offset: 0x003DACD1
		// (set) Token: 0x0600E950 RID: 59728 RVA: 0x003DC8D9 File Offset: 0x003DACD9
		public bool mIsHaveSummerGift { get; private set; }

		// Token: 0x17001CC6 RID: 7366
		// (get) Token: 0x0600E951 RID: 59729 RVA: 0x003DC8E2 File Offset: 0x003DACE2
		// (set) Token: 0x0600E952 RID: 59730 RVA: 0x003DC8EA File Offset: 0x003DACEA
		public bool mIsHaveOtherGift { get; private set; }

		// Token: 0x0600E953 RID: 59731 RVA: 0x003DC8F3 File Offset: 0x003DACF3
		public override void Init()
		{
			this.mIsHaveSummerGift = false;
			this.mIsHaveOtherGift = false;
		}

		// Token: 0x0600E954 RID: 59732 RVA: 0x003DC903 File Offset: 0x003DAD03
		public override void UnInit()
		{
			this.mIsHaveSummerGift = false;
			this.mIsHaveOtherGift = false;
		}

		// Token: 0x0600E955 RID: 59733 RVA: 0x003DC913 File Offset: 0x003DAD13
		public LimitTimeGiftData GetCurrActivityData()
		{
			return this.currShowActivityData;
		}

		// Token: 0x0600E956 RID: 59734 RVA: 0x003DC91C File Offset: 0x003DAD1C
		public void SyncLimitTimeActivityData(List<LimitTimeGiftData> data)
		{
			this.mIsHaveSummerGift = false;
			this.mIsHaveOtherGift = false;
			if (data != null)
			{
				for (int i = 0; i < data.Count; i++)
				{
					if (data[i].GiftId == 79000U || data[i].GiftId == 79001U)
					{
						this.mIsHaveSummerGift = true;
					}
					else
					{
						this.mIsHaveOtherGift = true;
					}
					if (this.mIsHaveSummerGift && this.mIsHaveOtherGift)
					{
						break;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.InitLimitTimeActivityView, this.currShowActivityData, data, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshLimitTimeActivityIcon, null, null, null, null);
			}
		}

		// Token: 0x0600E957 RID: 59735 RVA: 0x003DC9DC File Offset: 0x003DADDC
		public void UpdateLimitTimeActIcon(Image icon, Text text)
		{
			if (!this.NeedRefreshIcon)
			{
				return;
			}
			if (icon == null || text == null)
			{
				return;
			}
			if (this.currShowActivityData != null)
			{
				MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)this.currShowActivityData.GiftId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string iconPath = tableItem.IconPath;
					if (!string.IsNullOrEmpty(iconPath))
					{
						try
						{
							ETCImageLoader.LoadSprite(ref icon, iconPath, true);
							icon.SetNativeSize();
							RectTransform component = icon.GetComponent<RectTransform>();
							if (component)
							{
								component.anchoredPosition = new Vector2((float)tableItem.IconPosX, (float)tableItem.IconPosY);
							}
							text.text = tableItem.Name;
							this.NeedRefreshIcon = false;
						}
						catch (Exception ex)
						{
						}
					}
				}
			}
		}

		// Token: 0x04008D6C RID: 36204
		private LimitTimeGiftData currShowActivityData;

		// Token: 0x04008D6F RID: 36207
		public bool NeedRefreshIcon;
	}
}
