using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A78 RID: 6776
	public class GoblinShopView : MonoBehaviour
	{
		// Token: 0x06010A0F RID: 68111 RVA: 0x004B4560 File Offset: 0x004B2960
		public void InitShop(GoblinShopData goblinShopData)
		{
			this.activityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData((uint)goblinShopData.activityId);
			this.shopData = DataManager<AccountShopDataManager>.GetInstance().GetAccountShopData(goblinShopData.accountShopItem);
			this.specialItemId = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(501, string.Empty, string.Empty).Value;
			this.accountShopQuery = goblinShopData.accountShopItem;
			if (this.activityData == null || this.shopData == null)
			{
				return;
			}
			if (this.shopData != null)
			{
				this.InitUI(goblinShopData);
				this.InitBtn();
				this.InitShopElementItemList();
			}
		}

		// Token: 0x06010A10 RID: 68112 RVA: 0x004B45FE File Offset: 0x004B29FE
		public void UpdateShopItem(AccountShopQueryIndex accountShopItem)
		{
			this.shopData = DataManager<AccountShopDataManager>.GetInstance().GetAccountShopData(accountShopItem);
			if (this.shopData == null)
			{
				return;
			}
			this.updateShopItem(this.curFirstIndex);
		}

		// Token: 0x06010A11 RID: 68113 RVA: 0x004B462C File Offset: 0x004B2A2C
		public void UpdateSpecialNum(int id)
		{
			if (id == this.specialItemId)
			{
				this.moneyNum.text = DataManager<AccountShopDataManager>.GetInstance().GetSpecialItemNum(this.specialItemId).ToString();
			}
		}

		// Token: 0x06010A12 RID: 68114 RVA: 0x004B4670 File Offset: 0x004B2A70
		private void InitUI(GoblinShopData goblinShopData)
		{
			if (this.activityData != null)
			{
				this.activityTime.SafeSetText(Function.GetTimeWithoutYear((int)this.activityData.startTime, (int)this.activityData.endTime));
				if (this.activityData.parm2 != null && this.activityData.parm2.Length > 2)
				{
					this.clearTime.text = string.Format("{0}清空", Function.GetDateTime((int)this.activityData.parm2[2], false));
					this.clearTime.CustomActive(true);
				}
				else
				{
					this.clearTime.CustomActive(false);
				}
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.specialItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.moneyIcon, tableItem.Icon, true);
				this.moneyNum.text = DataManager<AccountShopDataManager>.GetInstance().GetSpecialItemNum(this.specialItemId).ToString();
			}
			int shopNextTime = DataManager<AccountShopDataManager>.GetInstance().GetShopNextTime(goblinShopData.accountShopItem);
			if (shopNextTime == 0)
			{
				this.nextTime.CustomActive(false);
			}
			else
			{
				this.nextTime.CustomActive(true);
				this.nextTime.text = Function.GetDateTime(shopNextTime, false);
			}
		}

		// Token: 0x06010A13 RID: 68115 RVA: 0x004B47BC File Offset: 0x004B2BBC
		private void InitBtn()
		{
			this.leftBtn.onClick.RemoveAllListeners();
			this.leftBtn.onClick.AddListener(delegate()
			{
				if (this.curFirstIndex > 0)
				{
					this.curFirstIndex--;
					this.updateShopItem(this.curFirstIndex);
				}
			});
			this.rightBtn.onClick.RemoveAllListeners();
			this.rightBtn.onClick.AddListener(delegate()
			{
				if (this.curFirstIndex < this.shopData.Length - 5)
				{
					this.curFirstIndex++;
					this.updateShopItem(this.curFirstIndex);
				}
			});
			this.closeBtn.onClick.RemoveAllListeners();
			this.closeBtn.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GoblinShopFrame>(null, false);
			});
			this.getMoneyBtn.onClick.RemoveAllListeners();
			this.getMoneyBtn.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GoblinPreviewFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x06010A14 RID: 68116 RVA: 0x004B489C File Offset: 0x004B2C9C
		private void InitShopElementItemList()
		{
			if (this.shopData.Length <= 3)
			{
				this.itemLayoutGroup.spacing = 120f;
			}
			else
			{
				this.itemLayoutGroup.spacing = 0f;
			}
			this.shopItemGOList.Clear();
			for (int i = 0; i < 5; i++)
			{
				if (i >= this.shopData.Length)
				{
					break;
				}
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/ShopNew/GoblinShopItem", true, 0U);
				if (gameObject != null)
				{
					Utility.AttachTo(gameObject, this.shopListRoot, false);
				}
				this.shopItemGOList.Add(gameObject);
			}
			this.updateShopItem(0);
		}

		// Token: 0x06010A15 RID: 68117 RVA: 0x004B494C File Offset: 0x004B2D4C
		private void updateShopItem(int curIndex)
		{
			this.updateLeftAndRightBtn(curIndex);
			for (int i = curIndex; i < curIndex + 5; i++)
			{
				if (i >= this.shopData.Length)
				{
					break;
				}
				if (i - curIndex >= this.shopItemGOList.Count)
				{
					break;
				}
				GoblinShopItem component = this.shopItemGOList[i - curIndex].GetComponent<GoblinShopItem>();
				if (component != null)
				{
					component.SetElementItem(this.shopData[i], this.accountShopQuery);
				}
			}
		}

		// Token: 0x06010A16 RID: 68118 RVA: 0x004B49D4 File Offset: 0x004B2DD4
		private void updateLeftAndRightBtn(int curIndex)
		{
			this.leftBtn.CustomActive(true);
			this.rightBtn.CustomActive(true);
			if (this.shopData.Length <= 5)
			{
				this.leftBtn.CustomActive(false);
				this.rightBtn.CustomActive(false);
			}
			else
			{
				if (curIndex == 0)
				{
					this.leftBtn.CustomActive(false);
				}
				if (curIndex == this.shopData.Length - 5)
				{
					this.rightBtn.CustomActive(false);
				}
			}
		}

		// Token: 0x0400A9C4 RID: 43460
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text activityTime;

		// Token: 0x0400A9C5 RID: 43461
		[Space(5f)]
		[Header("Middle")]
		[SerializeField]
		private GameObject shopListRoot;

		// Token: 0x0400A9C6 RID: 43462
		[Space(5f)]
		[Header("Bottom")]
		[SerializeField]
		private Text nextTime;

		// Token: 0x0400A9C7 RID: 43463
		[SerializeField]
		private Image moneyIcon;

		// Token: 0x0400A9C8 RID: 43464
		[SerializeField]
		private Text moneyNum;

		// Token: 0x0400A9C9 RID: 43465
		[SerializeField]
		private Text clearTime;

		// Token: 0x0400A9CA RID: 43466
		[SerializeField]
		private HorizontalLayoutGroup itemLayoutGroup;

		// Token: 0x0400A9CB RID: 43467
		[Space(5f)]
		[Header("Button")]
		[SerializeField]
		private Button getMoneyBtn;

		// Token: 0x0400A9CC RID: 43468
		[SerializeField]
		private Button closeBtn;

		// Token: 0x0400A9CD RID: 43469
		[SerializeField]
		private Button leftBtn;

		// Token: 0x0400A9CE RID: 43470
		[SerializeField]
		private Button rightBtn;

		// Token: 0x0400A9CF RID: 43471
		private const string shopItemPath = "UIFlatten/Prefabs/ShopNew/GoblinShopItem";

		// Token: 0x0400A9D0 RID: 43472
		private int curFirstIndex;

		// Token: 0x0400A9D1 RID: 43473
		private OpActivityData activityData;

		// Token: 0x0400A9D2 RID: 43474
		private AccountShopItemInfo[] shopData;

		// Token: 0x0400A9D3 RID: 43475
		private AccountShopQueryIndex accountShopQuery;

		// Token: 0x0400A9D4 RID: 43476
		private List<GameObject> shopItemGOList = new List<GameObject>();

		// Token: 0x0400A9D5 RID: 43477
		private int specialItemId;
	}
}
