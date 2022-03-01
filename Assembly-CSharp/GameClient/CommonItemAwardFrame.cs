using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E19 RID: 3609
	public class CommonItemAwardFrame : ClientFrame
	{
		// Token: 0x06009079 RID: 36985 RVA: 0x001AB32F File Offset: 0x001A972F
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600907A RID: 36986 RVA: 0x001AB331 File Offset: 0x001A9731
		protected override void _OnCloseFrame()
		{
			this.TimeFlag = 0f;
		}

		// Token: 0x0600907B RID: 36987 RVA: 0x001AB33E File Offset: 0x001A973E
		public override string GetPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x0600907C RID: 36988 RVA: 0x001AB348 File Offset: 0x001A9748
		public void SetAwardItems(List<AwardItemData> ItemsData)
		{
			if (ItemsData.Count <= 0)
			{
				return;
			}
			int num = ItemsData.Count % 2;
			int num2;
			RectTransform[] array;
			Text[] array2;
			if (num == 1)
			{
				num2 = 9;
				array = this.Oddpos;
				array2 = this.OddName;
			}
			else
			{
				num2 = 8;
				array = this.Evenpos;
				array2 = this.EvenName;
			}
			int num3 = 0;
			while (num3 < ItemsData.Count && num3 < num2)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(ItemsData[num3].ID, 100, 0);
				if (itemData != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(ItemsData[num3].ID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ComItem comItem = base.CreateComItem(array[num3].gameObject);
						itemData.Count = ItemsData[num3].Num;
						comItem.Setup(itemData, null);
						array2[num3].text = tableItem.Name;
					}
				}
				num3++;
			}
		}

		// Token: 0x0600907D RID: 36989 RVA: 0x001AB44E File Offset: 0x001A984E
		public void SetTitle(string titlePath)
		{
			if (titlePath != string.Empty || titlePath != "-")
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.title, titlePath, true);
		}

		// Token: 0x0600907E RID: 36990 RVA: 0x001AB47F File Offset: 0x001A987F
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600907F RID: 36991 RVA: 0x001AB482 File Offset: 0x001A9882
		protected override void _OnUpdate(float timeElapsed)
		{
			this.TimeFlag += timeElapsed;
			if (this.TimeFlag > 2f)
			{
				this.frameMgr.CloseFrame<CommonItemAwardFrame>(this, false);
				return;
			}
		}

		// Token: 0x040047C8 RID: 18376
		private const int OddNum = 9;

		// Token: 0x040047C9 RID: 18377
		private const int EvenNum = 8;

		// Token: 0x040047CA RID: 18378
		private float TimeFlag;

		// Token: 0x040047CB RID: 18379
		[UIControl("Dotween/title", null, 0)]
		protected Image title;

		// Token: 0x040047CC RID: 18380
		[UIControl("Dotween/OddPos/pos{0}", typeof(RectTransform), 1)]
		protected RectTransform[] Oddpos = new RectTransform[9];

		// Token: 0x040047CD RID: 18381
		[UIControl("Dotween/OddPos/pos{0}/name", typeof(Text), 1)]
		protected Text[] OddName = new Text[9];

		// Token: 0x040047CE RID: 18382
		[UIControl("Dotween/EvenPos/pos{0}", typeof(RectTransform), 1)]
		protected RectTransform[] Evenpos = new RectTransform[8];

		// Token: 0x040047CF RID: 18383
		[UIControl("Dotween/EvenPos/pos{0}/name", typeof(Text), 1)]
		protected Text[] EvenName = new Text[8];
	}
}
