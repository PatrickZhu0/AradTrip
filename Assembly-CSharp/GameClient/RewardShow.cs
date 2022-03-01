using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001918 RID: 6424
	internal class RewardShow : ClientFrame
	{
		// Token: 0x0600FA0F RID: 64015 RVA: 0x00447129 File Offset: 0x00445529
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/RewardShow";
		}

		// Token: 0x0600FA10 RID: 64016 RVA: 0x00447130 File Offset: 0x00445530
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				Logger.LogErrorFormat("需要传入一个奖品链表", new object[0]);
				return;
			}
			this.tableID = (int)this.userData;
			this.InitData();
		}

		// Token: 0x0600FA11 RID: 64017 RVA: 0x00447165 File Offset: 0x00445565
		private void InitData()
		{
			this.rewardID.Clear();
			this.importantRewardID.Clear();
			this.rewardNum.Clear();
			this.importantRewardNum.Clear();
			this.InitIcon();
		}

		// Token: 0x0600FA12 RID: 64018 RVA: 0x0044719C File Offset: 0x0044559C
		private void InitIcon()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<RewardPoolTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				RewardPoolTable rewardPoolTable = keyValuePair.Value as RewardPoolTable;
				if (rewardPoolTable.DrawPrizeTableID == this.tableID && rewardPoolTable.IsImportant != 1)
				{
					this.rewardID.Add(rewardPoolTable.ItemID);
					this.rewardNum.Add(rewardPoolTable.ItemNum);
				}
				else if (rewardPoolTable.DrawPrizeTableID == this.tableID && rewardPoolTable.IsImportant == 1)
				{
					this.importantRewardID.Add(rewardPoolTable.ItemID);
					this.importantRewardNum.Add(rewardPoolTable.ItemNum);
				}
			}
			if (this.rewardID.Count == 0 && this.importantRewardID.Count == 0)
			{
				Logger.LogErrorFormat("id为{0}的奖池表为空", new object[]
				{
					this.tableID
				});
			}
			else
			{
				this.mItemRoot.CustomActive(false);
				this.mImportantItemRoot.CustomActive(false);
				for (int i = 0; i < this.rewardID.Count; i++)
				{
					this.mItemRoot.CustomActive(true);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.rewardID[i], 100, 0);
					if (itemData != null)
					{
						GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimelAwardIcon", true, 0U);
						if (gameObject == null)
						{
							return;
						}
						Utility.AttachTo(gameObject, this.mItemRoot, false);
						itemData.Count = this.rewardNum[i];
						ComItem comItem = base.CreateComItem(gameObject);
						int result = this.rewardID[i];
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
				for (int j = 0; j < this.importantRewardID.Count; j++)
				{
					this.mImportantItemRoot.CustomActive(true);
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(this.importantRewardID[j], 100, 0);
					if (itemData2 != null)
					{
						GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimelAwardIcon", true, 0U);
						if (gameObject2 == null)
						{
							return;
						}
						Utility.AttachTo(gameObject2, this.mImportantItemRoot, false);
						itemData2.Count = this.importantRewardNum[j];
						ComItem comItem2 = base.CreateComItem(gameObject2);
						int result = this.importantRewardID[j];
						comItem2.Setup(itemData2, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
			}
			base.StartCoroutine(this.DonateResult());
		}

		// Token: 0x0600FA13 RID: 64019 RVA: 0x00447478 File Offset: 0x00445878
		private IEnumerator DonateResult()
		{
			yield return null;
			this.mScrollView.verticalNormalizedPosition = 1f;
			yield break;
		}

		// Token: 0x0600FA14 RID: 64020 RVA: 0x00447494 File Offset: 0x00445894
		private void OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600FA15 RID: 64021 RVA: 0x004474BB File Offset: 0x004458BB
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600FA16 RID: 64022 RVA: 0x004474C4 File Offset: 0x004458C4
		private void ClearData()
		{
			this.tableID = -1;
			this.rewardID.Clear();
			this.importantRewardID.Clear();
			this.rewardNum.Clear();
			this.importantRewardNum.Clear();
			base.StopCoroutine(this.DonateResult());
		}

		// Token: 0x0600FA17 RID: 64023 RVA: 0x00447510 File Offset: 0x00445910
		protected override void _bindExUI()
		{
			this.mScrollView = this.mBind.GetCom<ScrollRect>("ScrollView");
			this.mImportantItemRoot = this.mBind.GetGameObject("importantItemRoot");
			this.mItemRoot = this.mBind.GetGameObject("itemRoot");
		}

		// Token: 0x0600FA18 RID: 64024 RVA: 0x0044755F File Offset: 0x0044595F
		protected override void _unbindExUI()
		{
			this.mScrollView = null;
			this.mImportantItemRoot = null;
			this.mItemRoot = null;
		}

		// Token: 0x04009C27 RID: 39975
		private int tableID = -1;

		// Token: 0x04009C28 RID: 39976
		private List<int> rewardID = new List<int>();

		// Token: 0x04009C29 RID: 39977
		private List<int> importantRewardID = new List<int>();

		// Token: 0x04009C2A RID: 39978
		private List<int> rewardNum = new List<int>();

		// Token: 0x04009C2B RID: 39979
		private List<int> importantRewardNum = new List<int>();

		// Token: 0x04009C2C RID: 39980
		private const string rewardIconRewardPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimelAwardIcon";

		// Token: 0x04009C2D RID: 39981
		private ScrollRect mScrollView;

		// Token: 0x04009C2E RID: 39982
		private GameObject mImportantItemRoot;

		// Token: 0x04009C2F RID: 39983
		private GameObject mItemRoot;
	}
}
