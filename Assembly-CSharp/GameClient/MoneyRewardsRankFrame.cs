using System;
using System.Collections.Generic;
using Network;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020017ED RID: 6125
	internal class MoneyRewardsRankFrame : ClientFrame
	{
		// Token: 0x0600F160 RID: 61792 RVA: 0x00410685 File Offset: 0x0040EA85
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsRankFrame";
		}

		// Token: 0x0600F161 RID: 61793 RVA: 0x0041068C File Offset: 0x0040EA8C
		public static void CommandOpen(object argv)
		{
			MoneyRewardsRankFrame._RequestRanklist(35, 0, 20, true, null);
		}

		// Token: 0x0600F162 RID: 61794 RVA: 0x0041069C File Offset: 0x0040EA9C
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<MoneyRewardsRankFrame>(this, false);
			});
			if (null != this.scripts)
			{
				this.scripts.Initialize();
				this.scripts.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComMoneyRewaradsRankItem>();
					}
					return null;
				};
				this.scripts.onItemVisiable = delegate(ComUIListElementScript item)
				{
					MoneyRewaradsRankItemData[] rankItems = DataManager<MoneyRewardsDataManager>.GetInstance().RankItems;
					int getValidRankCount = DataManager<MoneyRewardsDataManager>.GetInstance().getValidRankCount;
					if (null != item && item.m_index >= 0 && item.m_index < rankItems.Length && item.m_index < getValidRankCount)
					{
						ComMoneyRewaradsRankItem comMoneyRewaradsRankItem = item.gameObjectBindScript as ComMoneyRewaradsRankItem;
						if (null != comMoneyRewaradsRankItem)
						{
							comMoneyRewaradsRankItem.OnItemVisible(rankItems[item.m_index]);
							if (item.m_index == getValidRankCount - 1 && getValidRankCount < 100 && !this.m_searched_list.Contains(getValidRankCount))
							{
								this.m_searched_list.Add(getValidRankCount);
								MoneyRewardsRankFrame._RequestRanklist(35, getValidRankCount, 20, true, null);
							}
						}
					}
				};
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsRankListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRankListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
			this._UpdateRankItems();
			this._UpdateSelfRankItem();
		}

		// Token: 0x0600F163 RID: 61795 RVA: 0x00410760 File Offset: 0x0040EB60
		public static void _RequestRanklist(int a_type, int a_startIndex, int a_count, bool bOpenRankFrame = true, UnityAction callback = null)
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = (byte)a_type;
			worldSortListReq.start = (ushort)a_startIndex;
			worldSortListReq.num = (ushort)a_count;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList baseSortList = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				for (int i = 0; i < baseSortList.entries.Count; i++)
				{
					MoneyRewardsSortListEntry moneyRewardsSortListEntry = baseSortList.entries[i] as MoneyRewardsSortListEntry;
					if (moneyRewardsSortListEntry != null && moneyRewardsSortListEntry.ranking >= 1 && (int)moneyRewardsSortListEntry.ranking <= DataManager<MoneyRewardsDataManager>.GetInstance().RankItems.Length)
					{
						if (DataManager<MoneyRewardsDataManager>.GetInstance().RankItems[(int)(moneyRewardsSortListEntry.ranking - 1)] == null)
						{
							DataManager<MoneyRewardsDataManager>.GetInstance().RankItems[(int)(moneyRewardsSortListEntry.ranking - 1)] = new MoneyRewaradsRankItemData();
						}
						MoneyRewaradsRankItemData moneyRewaradsRankItemData = DataManager<MoneyRewardsDataManager>.GetInstance().RankItems[(int)(moneyRewardsSortListEntry.ranking - 1)];
						if (moneyRewaradsRankItemData != null)
						{
							moneyRewaradsRankItemData.name = moneyRewardsSortListEntry.name;
							moneyRewaradsRankItemData.rank = (int)moneyRewardsSortListEntry.ranking;
							moneyRewaradsRankItemData.score = (int)moneyRewardsSortListEntry.score;
							moneyRewaradsRankItemData.maxScore = (int)moneyRewardsSortListEntry.maxScore;
						}
					}
				}
				MoneyRewaradsRankItemData moneyRewaradsRankItemData2 = DataManager<MoneyRewardsDataManager>.GetInstance().RankItemSelf;
				if (moneyRewaradsRankItemData2 != null)
				{
					moneyRewaradsRankItemData2.name = DataManager<PlayerBaseData>.GetInstance().Name;
					if (baseSortList.selfEntry != null)
					{
						moneyRewaradsRankItemData2.rank = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).ranking;
						DataManager<MoneyRewardsDataManager>.GetInstance().Rank = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).ranking;
						moneyRewaradsRankItemData2.score = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).score;
						DataManager<MoneyRewardsDataManager>.GetInstance().Score = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).score;
						moneyRewaradsRankItemData2.maxScore = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).maxScore;
						DataManager<MoneyRewardsDataManager>.GetInstance().MaxScore = (int)(baseSortList.selfEntry as MoneyRewardsSortListEntry).maxScore;
					}
					else
					{
						moneyRewaradsRankItemData2.rank = 999;
						DataManager<MoneyRewardsDataManager>.GetInstance().Rank = 999;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsSelfResultChanged, null, null, null, null);
				if (bOpenRankFrame)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsRankFrame>(null))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsRankListChanged, null, null, null, null);
					}
					else
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsRankFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
				if (callback != null)
				{
					callback.Invoke();
				}
			}, true, 15f, null);
		}

		// Token: 0x0600F164 RID: 61796 RVA: 0x004107D4 File Offset: 0x0040EBD4
		private void _UpdateRankItems()
		{
			if (null != this.scripts)
			{
				MoneyRewaradsRankItemData[] rankItems = DataManager<MoneyRewardsDataManager>.GetInstance().RankItems;
				int getValidRankCount = DataManager<MoneyRewardsDataManager>.GetInstance().getValidRankCount;
				this.scripts.SetElementAmount(getValidRankCount);
			}
		}

		// Token: 0x0600F165 RID: 61797 RVA: 0x00410814 File Offset: 0x0040EC14
		private void _UpdateSelfRankItem()
		{
			if (null != this.rankItemSelf)
			{
				this.rankItemSelf.OnItemVisible(DataManager<MoneyRewardsDataManager>.GetInstance().RankItemSelf);
			}
		}

		// Token: 0x0600F166 RID: 61798 RVA: 0x0041083C File Offset: 0x0040EC3C
		protected override void _OnCloseFrame()
		{
			if (null != this.scripts)
			{
				this.scripts.onBindItem = null;
				this.scripts.onItemVisiable = null;
				this.scripts = null;
			}
			this.m_searched_list.Clear();
			DataManager<MoneyRewardsDataManager>.GetInstance().ClearRankItems();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsRankListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRankListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
		}

		// Token: 0x0600F167 RID: 61799 RVA: 0x004108C4 File Offset: 0x0040ECC4
		private void _OnMoneyRewardsRankListChanged(UIEvent uiEvent)
		{
			this._UpdateRankItems();
		}

		// Token: 0x0600F168 RID: 61800 RVA: 0x004108CC File Offset: 0x0040ECCC
		private void _OnMoneyRewardsSelfResultChanged(UIEvent uiEvent)
		{
			this._UpdateSelfRankItem();
		}

		// Token: 0x04009452 RID: 37970
		[UIControl("ScrollView", typeof(ComUIListScript), 0)]
		private ComUIListScript scripts;

		// Token: 0x04009453 RID: 37971
		[UIControl("RankItemFixed", typeof(ComMoneyRewaradsRankItem), 0)]
		private ComMoneyRewaradsRankItem rankItemSelf;

		// Token: 0x04009454 RID: 37972
		private List<int> m_searched_list = new List<int>();
	}
}
