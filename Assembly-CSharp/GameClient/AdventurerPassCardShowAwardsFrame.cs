using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001432 RID: 5170
	public class AdventurerPassCardShowAwardsFrame : ClientFrame
	{
		// Token: 0x0600C8BB RID: 51387 RVA: 0x0030CC5A File Offset: 0x0030B05A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventurerPassCard/AdventurerPassCardShowAwards";
		}

		// Token: 0x0600C8BC RID: 51388 RVA: 0x0030CC64 File Offset: 0x0030B064
		protected override void _OnOpenFrame()
		{
			this.awardItemDataListNoraml = null;
			this.awardItemDataListKing = null;
			this.InitAwardItemsNormal();
			this.UpdateAwardItemsNormal();
			this.InitAwardItemsKing();
			this.UpdateAwardItemsKing();
			this.mBtBuy.SafeSetGray(DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType != AdventurerPassCardDataManager.PassCardType.Normal, true);
			this.BindUIEvent();
		}

		// Token: 0x0600C8BD RID: 51389 RVA: 0x0030CCB9 File Offset: 0x0030B0B9
		protected override void _OnCloseFrame()
		{
			this.awardItemDataListNoraml = null;
			this.awardItemDataListKing = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600C8BE RID: 51390 RVA: 0x0030CCD0 File Offset: 0x0030B0D0
		protected override void _bindExUI()
		{
			this.mBtBuy = this.mBind.GetCom<Button>("btBuy");
			this.mBtBuy.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardBuyKingLevelFrame>(FrameLayer.Middle, null, string.Empty);
				this.frameMgr.CloseFrame<AdventurerPassCardShowAwardsFrame>(this, false);
			});
			this.mAwardShowNormal = this.mBind.GetCom<ComUIListScript>("awardShowNormal");
			this.mAwardShowKing = this.mBind.GetCom<ComUIListScript>("awardShowKing");
		}

		// Token: 0x0600C8BF RID: 51391 RVA: 0x0030CD36 File Offset: 0x0030B136
		protected override void _unbindExUI()
		{
			this.mBtBuy = null;
			this.mAwardShowNormal = null;
			this.mAwardShowKing = null;
		}

		// Token: 0x0600C8C0 RID: 51392 RVA: 0x0030CD4D File Offset: 0x0030B14D
		private void BindUIEvent()
		{
		}

		// Token: 0x0600C8C1 RID: 51393 RVA: 0x0030CD4F File Offset: 0x0030B14F
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600C8C2 RID: 51394 RVA: 0x0030CD51 File Offset: 0x0030B151
		private void UpdateUI()
		{
		}

		// Token: 0x0600C8C3 RID: 51395 RVA: 0x0030CD54 File Offset: 0x0030B154
		private void InitAwardItemsNormal()
		{
			if (this.mAwardShowNormal == null)
			{
				return;
			}
			this.mAwardShowNormal.Initialize();
			this.mAwardShowNormal.onBindItem = delegate(GameObject go)
			{
				PayRewardItem result = null;
				if (go)
				{
					result = go.GetComponent<PayRewardItem>();
				}
				return result;
			};
			this.mAwardShowNormal.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && this.awardItemDataListNoraml != null && index < this.awardItemDataListNoraml.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataListNoraml[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("AdventurerPassCardShowAwardsFrame Can not find item id in item table!!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataListNoraml[index].ID
						});
						return;
					}
					ItemData itemData2 = itemData;
					if (itemData2.TableData != null && itemData2.TableData.ExpireTime > 0)
					{
						itemData2.DeadTimestamp = itemData2.TableData.ExpireTime;
					}
					itemData.Count = this.awardItemDataListNoraml[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
		}

		// Token: 0x0600C8C4 RID: 51396 RVA: 0x0030CDC0 File Offset: 0x0030B1C0
		private List<AwardItemData> GetAwardItems(string awardText)
		{
			if (awardText == null)
			{
				return null;
			}
			List<AwardItemData> list = new List<AwardItemData>();
			if (list == null)
			{
				return null;
			}
			string[] array = awardText.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2.Length >= 2)
				{
					int id = 0;
					int.TryParse(array2[0], out id);
					int num = 0;
					int.TryParse(array2[1], out num);
					AwardItemData awardItemData = new AwardItemData();
					if (awardItemData != null)
					{
						awardItemData.ID = id;
						awardItemData.Num = num;
						list.Add(awardItemData);
					}
				}
			}
			return list;
		}

		// Token: 0x0600C8C5 RID: 51397 RVA: 0x0030CE6C File Offset: 0x0030B26C
		private void CalAwardItemListNormal()
		{
			this.awardItemDataListNoraml = new List<AwardItemData>();
			if (this.awardItemDataListNoraml == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyRewardTable adventurePassBuyRewardTable = keyValuePair.Value as AdventurePassBuyRewardTable;
					if (adventurePassBuyRewardTable != null)
					{
						if ((long)adventurePassBuyRewardTable.Season == (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID))
						{
							this.awardItemDataListNoraml.AddRange(this.GetAwardItems(adventurePassBuyRewardTable.Normal));
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600C8C6 RID: 51398 RVA: 0x0030CF0C File Offset: 0x0030B30C
		private void UpdateAwardItemsNormal()
		{
			if (this.mAwardShowNormal == null)
			{
				return;
			}
			this.CalAwardItemListNormal();
			if (this.awardItemDataListNoraml != null)
			{
				this.mAwardShowNormal.SetElementAmount(this.awardItemDataListNoraml.Count);
			}
		}

		// Token: 0x0600C8C7 RID: 51399 RVA: 0x0030CF48 File Offset: 0x0030B348
		private void InitAwardItemsKing()
		{
			if (this.mAwardShowKing == null)
			{
				return;
			}
			this.mAwardShowKing.Initialize();
			this.mAwardShowKing.onBindItem = delegate(GameObject go)
			{
				PayRewardItem result = null;
				if (go)
				{
					result = go.GetComponent<PayRewardItem>();
				}
				return result;
			};
			this.mAwardShowKing.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && this.awardItemDataListKing != null && index < this.awardItemDataListKing.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataListKing[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("AdventurerPassCardShowAwardsFrame Can not find item id in item table!!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataListKing[index].ID
						});
						return;
					}
					ItemData itemData2 = itemData;
					if (itemData2.TableData != null && itemData2.TableData.ExpireTime > 0)
					{
						itemData2.DeadTimestamp = itemData2.TableData.ExpireTime;
					}
					itemData.Count = this.awardItemDataListKing[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
		}

		// Token: 0x0600C8C8 RID: 51400 RVA: 0x0030CFB4 File Offset: 0x0030B3B4
		private void CalAwardItemListKing()
		{
			this.awardItemDataListKing = new List<AwardItemData>();
			if (this.awardItemDataListKing == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyRewardTable adventurePassBuyRewardTable = keyValuePair.Value as AdventurePassBuyRewardTable;
					if (adventurePassBuyRewardTable != null)
					{
						if ((long)adventurePassBuyRewardTable.Season == (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID))
						{
							this.awardItemDataListKing.AddRange(this.GetAwardItems(adventurePassBuyRewardTable.High));
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600C8C9 RID: 51401 RVA: 0x0030D054 File Offset: 0x0030B454
		private void UpdateAwardItemsKing()
		{
			if (this.mAwardShowKing == null)
			{
				return;
			}
			this.CalAwardItemListKing();
			if (this.awardItemDataListKing != null)
			{
				this.mAwardShowKing.SetElementAmount(this.awardItemDataListKing.Count);
			}
		}

		// Token: 0x0600C8CA RID: 51402 RVA: 0x0030D08F File Offset: 0x0030B48F
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
		}

		// Token: 0x040073C8 RID: 29640
		private List<AwardItemData> awardItemDataListNoraml;

		// Token: 0x040073C9 RID: 29641
		private List<AwardItemData> awardItemDataListKing;

		// Token: 0x040073CA RID: 29642
		private Button mBtBuy;

		// Token: 0x040073CB RID: 29643
		private ComUIListScript mAwardShowNormal;

		// Token: 0x040073CC RID: 29644
		private ComUIListScript mAwardShowKing;
	}
}
