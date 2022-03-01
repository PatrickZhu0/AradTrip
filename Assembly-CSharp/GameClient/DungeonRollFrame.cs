using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;

namespace GameClient
{
	// Token: 0x020010B7 RID: 4279
	public class DungeonRollFrame : ClientFrame
	{
		// Token: 0x0600A199 RID: 41369 RVA: 0x0020E1E7 File Offset: 0x0020C5E7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Reward/RollItemFrame";
		}

		// Token: 0x0600A19A RID: 41370 RVA: 0x0020E1EE File Offset: 0x0020C5EE
		protected override void _bindExUI()
		{
			this.mRollItems = this.mBind.GetCom<ComUIListScript>("RollItemList");
		}

		// Token: 0x0600A19B RID: 41371 RVA: 0x0020E208 File Offset: 0x0020C608
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.maxTime < 0f)
			{
				Logger.LogError("等待时间超长了");
				return;
			}
			this.maxTime -= timeElapsed;
			if (this.maxTime < 0f)
			{
				base.Close(false);
				return;
			}
			if (this.curTime < 0f)
			{
				return;
			}
			this.curTime -= timeElapsed;
			if (this.curTime <= 0f)
			{
				this.CheckItemStat();
				if (this.mRollItems != null)
				{
					this.mRollItems.UpdateElement();
				}
			}
		}

		// Token: 0x0600A19C RID: 41372 RVA: 0x0020E2A8 File Offset: 0x0020C6A8
		private void CheckItemStat()
		{
			foreach (DungeonRollFrame.RollItemInfo rollItemInfo in this.mRollItemDetailList)
			{
				if (rollItemInfo != null && rollItemInfo.stat == DungeonRollFrame.ROLLITEM_STAT.NONE)
				{
					this.SetHum(rollItemInfo);
				}
			}
		}

		// Token: 0x0600A19D RID: 41373 RVA: 0x0020E2F4 File Offset: 0x0020C6F4
		private void SetHum(DungeonRollFrame.RollItemInfo item)
		{
			if (item != null && item.itemData != null)
			{
				WorldDungeonRollItemReq cmd = new WorldDungeonRollItemReq
				{
					dropIndex = item.itemData.rollIndex,
					opType = 2
				};
				MonoSingleton<NetManager>.instance.SendCommand<WorldDungeonRollItemReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600A19E RID: 41374 RVA: 0x0020E33F File Offset: 0x0020C73F
		protected override void _unbindExUI()
		{
			this.mRollItems = null;
		}

		// Token: 0x0600A19F RID: 41375 RVA: 0x0020E348 File Offset: 0x0020C748
		private int SortItemData(DungeonRollFrame.RollItemInfo a, DungeonRollFrame.RollItemInfo b)
		{
			if (a == null || b == null || a.item == null || b.item == null)
			{
				return 0;
			}
			if (a.item.Quality > b.item.Quality)
			{
				return 1;
			}
			if (a.item.Quality != b.item.Quality)
			{
				return -1;
			}
			if (a.item.TableID < b.item.TableID)
			{
				return 1;
			}
			if (a.item.TableID > b.item.TableID)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600A1A0 RID: 41376 RVA: 0x0020E3F0 File Offset: 0x0020C7F0
		private void TestInit()
		{
			int[] array = new int[]
			{
				110210001,
				120510001,
				131210001,
				131510001,
				151810001,
				163510001,
				176132001,
				145460001
			};
			int[] array2 = new int[]
			{
				115210001,
				120510001,
				120610001,
				135410004,
				151210001,
				151810001,
				165410002,
				142540002
			};
			int[] array3 = new int[]
			{
				134744003,
				135444002,
				135444003,
				135444004,
				151444001,
				142541002,
				142542002,
				142043002
			};
			for (int i = 0; i < array3.Length; i++)
			{
				this.mRollItemDetailList.Add(new DungeonRollFrame.RollItemInfo
				{
					item = ItemDataManager.CreateItemDataFromTable(array3[i], 100, 0)
				});
			}
		}

		// Token: 0x0600A1A1 RID: 41377 RVA: 0x0020E470 File Offset: 0x0020C870
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(631, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.tableTime = Convert.ToSingle(tableItem.Value);
				this.curTime = this.tableTime;
			}
			this.mRollItemDetailList.Clear();
			Protocol.RollItemInfo[] rollRewardItem = DataManager<BattleDataManager>.GetInstance().rollRewardItem;
			if (rollRewardItem != null)
			{
				for (int i = 0; i < rollRewardItem.Length; i++)
				{
					Protocol.RollItemInfo rollItemInfo = rollRewardItem[i];
					if (rollItemInfo != null && rollItemInfo.dropItem != null)
					{
						this.mRollItemDetailList.Add(new DungeonRollFrame.RollItemInfo
						{
							item = ItemDataManager.CreateItemDataFromTable((int)rollItemInfo.dropItem.itemId, 100, 0),
							itemData = rollItemInfo
						});
					}
					else
					{
						Logger.LogErrorFormat("session id {0} rollitem {1} is invalid", new object[]
						{
							(ClientApplication.playerinfo == null) ? 0UL : ClientApplication.playerinfo.session,
							i
						});
					}
				}
			}
			this.mRollItemDetailList.Sort(new Comparison<DungeonRollFrame.RollItemInfo>(this.SortItemData));
			this._InitUI();
		}

		// Token: 0x0600A1A2 RID: 41378 RVA: 0x0020E59C File Offset: 0x0020C99C
		private void OnItemData(ComUIListElementScript item)
		{
			if (item.m_index >= 0 && item.m_index < this.mRollItemDetailList.Count)
			{
				ComRollItem component = item.GetComponent<ComRollItem>();
				if (component != null)
				{
					DungeonRollFrame.RollItemInfo curData = this.mRollItemDetailList[this.mRollItemDetailList.Count - item.m_index - 1];
					if (curData == null)
					{
						return;
					}
					component.Init(curData.item, this.curTime, this.tableTime, curData.score, curData.stat);
					if (curData.stat == DungeonRollFrame.ROLLITEM_STAT.NONE)
					{
						if (component.btnHum != null)
						{
							component.btnHum.enabled = true;
							component.btnHum.onClick.RemoveAllListeners();
							if (this.curTime > 0f)
							{
								component.btnHum.onClick.AddListener(delegate()
								{
									SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("humility_rollitem_msg_box"), null, delegate()
									{
										this.SetHum(curData);
									}, 0f, false, null);
								});
							}
						}
						if (component.btnRoll != null && this.curTime > 0f)
						{
							component.btnRoll.enabled = true;
							component.btnRoll.onClick.RemoveAllListeners();
							component.btnRoll.onClick.AddListener(delegate()
							{
								if (curData != null && curData.itemData != null)
								{
									WorldDungeonRollItemReq cmd = new WorldDungeonRollItemReq
									{
										dropIndex = curData.itemData.rollIndex,
										opType = 1
									};
									MonoSingleton<NetManager>.instance.SendCommand<WorldDungeonRollItemReq>(ServerType.GATE_SERVER, cmd);
								}
							});
						}
					}
				}
			}
		}

		// Token: 0x0600A1A3 RID: 41379 RVA: 0x0020E711 File Offset: 0x0020CB11
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A1A4 RID: 41380 RVA: 0x0020E714 File Offset: 0x0020CB14
		private void _InitUI()
		{
			if (this.mRollItems == null)
			{
				return;
			}
			this.mRollItems.Initialize();
			this.mRollItems.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OnItemData);
			this.mRollItems.SetElementAmount(this.mRollItemDetailList.Count);
			this.mRollItems.OnItemUpdate = new ComUIListScript.OnItemUpdateDelegate(this.OnItemData);
		}

		// Token: 0x0600A1A5 RID: 41381 RVA: 0x0020E782 File Offset: 0x0020CB82
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			if (DataManager<ItemTipManager>.GetInstance() != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600A1A6 RID: 41382 RVA: 0x0020E79E File Offset: 0x0020CB9E
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpateRollItem, new ClientEventSystem.UIEventHandler(this._OnUpdateRollItem));
		}

		// Token: 0x0600A1A7 RID: 41383 RVA: 0x0020E7BB File Offset: 0x0020CBBB
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpateRollItem, new ClientEventSystem.UIEventHandler(this._OnUpdateRollItem));
		}

		// Token: 0x0600A1A8 RID: 41384 RVA: 0x0020E7D8 File Offset: 0x0020CBD8
		private void _OnUpdateRollItem(UIEvent uiEvent)
		{
			WorldDungeonRollItemRes worldDungeonRollItemRes = uiEvent.Param1 as WorldDungeonRollItemRes;
			if (worldDungeonRollItemRes != null)
			{
				foreach (DungeonRollFrame.RollItemInfo rollItemInfo in this.mRollItemDetailList)
				{
					if (rollItemInfo.itemData != null && rollItemInfo.itemData.rollIndex == worldDungeonRollItemRes.dropIndex)
					{
						if (worldDungeonRollItemRes.opType == 2)
						{
							rollItemInfo.stat = DungeonRollFrame.ROLLITEM_STAT.HUM;
						}
						else if (worldDungeonRollItemRes.opType == 1)
						{
							rollItemInfo.stat = DungeonRollFrame.ROLLITEM_STAT.SCORE;
						}
						rollItemInfo.score = (int)worldDungeonRollItemRes.point;
						if (this.mRollItems != null)
						{
							this.mRollItems.UpdateElement();
						}
						return;
					}
				}
			}
		}

		// Token: 0x04005A22 RID: 23074
		private ComUIListScript mRollItems;

		// Token: 0x04005A23 RID: 23075
		private List<DungeonRollFrame.RollItemInfo> mRollItemDetailList = new List<DungeonRollFrame.RollItemInfo>();

		// Token: 0x04005A24 RID: 23076
		private float curTime = 10f;

		// Token: 0x04005A25 RID: 23077
		private float tableTime = 10f;

		// Token: 0x04005A26 RID: 23078
		private float maxTime = 100f;

		// Token: 0x020010B8 RID: 4280
		public enum ROLLITEM_STAT
		{
			// Token: 0x04005A28 RID: 23080
			NONE,
			// Token: 0x04005A29 RID: 23081
			HUM,
			// Token: 0x04005A2A RID: 23082
			SCORE
		}

		// Token: 0x020010B9 RID: 4281
		private class RollItemInfo
		{
			// Token: 0x04005A2B RID: 23083
			public ItemData item;

			// Token: 0x04005A2C RID: 23084
			public DungeonRollFrame.ROLLITEM_STAT stat;

			// Token: 0x04005A2D RID: 23085
			public Protocol.RollItemInfo itemData;

			// Token: 0x04005A2E RID: 23086
			public int score;
		}
	}
}
