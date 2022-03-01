using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020019CE RID: 6606
	public class ComRanomTreasureItemBind : MonoBehaviour
	{
		// Token: 0x060102CE RID: 66254 RVA: 0x00482998 File Offset: 0x00480D98
		private void Awake()
		{
			if (this.mInfo != null)
			{
				this.mInfo.onTitleBtnClick = delegate()
				{
					this.OnTryGetBtnClick();
				};
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTresureItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnChange));
		}

		// Token: 0x060102CF RID: 66255 RVA: 0x004829E8 File Offset: 0x00480DE8
		private void Start()
		{
			if (this.mItemType == DigType.DIG_GLOD)
			{
				this.mItemId = DataManager<RandomTreasureDataManager>.GetInstance().Gold_Treasure_Item_Id;
			}
			else if (this.mItemType == DigType.DIG_SILVER)
			{
				this.mItemId = DataManager<RandomTreasureDataManager>.GetInstance().Silver_Treasure_Item_Id;
			}
			if (this.mInfo != null)
			{
				string ownedItemIconPath = DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.mItemId);
				this.mInfo.SetInfoTitleImg(ownedItemIconPath);
			}
			this.SetInfoContent();
		}

		// Token: 0x060102D0 RID: 66256 RVA: 0x00482A66 File Offset: 0x00480E66
		private void Update()
		{
		}

		// Token: 0x060102D1 RID: 66257 RVA: 0x00482A68 File Offset: 0x00480E68
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTresureItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnChange));
		}

		// Token: 0x060102D2 RID: 66258 RVA: 0x00482A88 File Offset: 0x00480E88
		private void OnTryGetBtnClick()
		{
			if (this.mItemId == 0)
			{
				return;
			}
			ItemComeLink.OnLink(this.mItemId, 0, false, null, false, false, false, null, string.Empty);
		}

		// Token: 0x060102D3 RID: 66259 RVA: 0x00482AB8 File Offset: 0x00480EB8
		private void OnChange(UIEvent uiEvent)
		{
			this.SetInfoContent();
		}

		// Token: 0x060102D4 RID: 66260 RVA: 0x00482AC0 File Offset: 0x00480EC0
		private void SetInfoContent()
		{
			if (this.mInfo != null)
			{
				this.mInfo.SetInfoContent(Utility.ToThousandsSeparator((ulong)((long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mItemId, false))));
			}
		}

		// Token: 0x0400A38E RID: 41870
		[SerializeField]
		private DigType mItemType;

		// Token: 0x0400A38F RID: 41871
		public RandomTreasureInfo mInfo;

		// Token: 0x0400A390 RID: 41872
		private int mItemId;
	}
}
