using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200188F RID: 6287
	public class FashionTicketBuyActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F605 RID: 62981 RVA: 0x00425F52 File Offset: 0x00424352
		public void SetBuyCallBack(FashionTicketBuyActivityView.BuyCallBack callback)
		{
			this.mBuyCallBack = callback;
		}

		// Token: 0x0600F606 RID: 62982 RVA: 0x00425F5C File Offset: 0x0042435C
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this.mNote.Init(model, true, base.GetComponent<ComCommonBind>());
			for (int i = 0; i < model.ParamArray.Length; i++)
			{
				int mallItemTableID = (int)model.ParamArray[i];
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(mallItemTableID, string.Empty, string.Empty);
				ItemTable.eSubType moneytype = (ItemTable.eSubType)tableItem.moneytype;
				if (tableItem != null && this.mItemPath != null)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mItemPath, true, 0U);
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					if (component != null)
					{
						GameObject gameObject2 = component.GetGameObject("ItemRoot");
						Image com = component.GetCom<Image>("PriceImage");
						Text com2 = component.GetCom<Text>("Price");
						Button com3 = component.GetCom<Button>("Buy");
						Text com4 = component.GetCom<Text>("Name");
						string text = tableItem.giftpackitems.Split(new char[]
						{
							'|'
						})[0];
						string[] array = text.Split(new char[]
						{
							':'
						});
						if (array.Length != 2)
						{
							goto IL_2B0;
						}
						int num = -1;
						int count = -1;
						int.TryParse(array[0], out num);
						int.TryParse(array[1], out count);
						if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty) == null)
						{
							return;
						}
						ComItem comItem = gameObject2.GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							ComItem comItem2 = ComItemManager.Create(gameObject2);
							comItem = comItem2;
							this.mComItems.Add(comItem);
						}
						ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
						if (ItemDetailData == null)
						{
							return;
						}
						ItemDetailData.Count = count;
						comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
						{
							this._OnShowTips(ItemDetailData);
						});
						com3.onClick.RemoveAllListeners();
						com3.onClick.AddListener(delegate()
						{
							if (this.mBuyCallBack != null)
							{
								this.mBuyCallBack((uint)mallItemTableID);
							}
						});
						com4.text = tableItem.giftpackname;
						com2.text = tableItem.price.ToString();
						int id = -1;
						if (moneytype == ItemTable.eSubType.BindPOINT)
						{
							id = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
						}
						else if (moneytype == ItemTable.eSubType.POINT)
						{
							id = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
						}
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref com, tableItem2.Icon, true);
						}
					}
					Utility.AttachTo(gameObject, this.mBuyItemRoot, false);
				}
				IL_2B0:;
			}
		}

		// Token: 0x0600F607 RID: 62983 RVA: 0x0042622C File Offset: 0x0042462C
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F608 RID: 62984 RVA: 0x00426284 File Offset: 0x00424684
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x040096DD RID: 38621
		[SerializeField]
		private GameObject mBuyItemRoot;

		// Token: 0x040096DE RID: 38622
		[SerializeField]
		private string mItemPath;

		// Token: 0x040096DF RID: 38623
		private FashionTicketBuyActivityView.BuyCallBack mBuyCallBack;

		// Token: 0x040096E0 RID: 38624
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x02001890 RID: 6288
		// (Invoke) Token: 0x0600F60A RID: 62986
		public delegate void BuyCallBack(uint mallItemId);
	}
}
