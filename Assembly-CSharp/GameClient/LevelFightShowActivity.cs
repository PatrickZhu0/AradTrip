using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200184A RID: 6218
	public sealed class LevelFightShowActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F41F RID: 62495 RVA: 0x0041EF54 File Offset: 0x0041D354
		public override void Init(uint activityId)
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LevelFightShowActivityDataModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null, null);
			}
		}

		// Token: 0x0600F420 RID: 62496 RVA: 0x0041EF8C File Offset: 0x0041D38C
		public override void Show(Transform root)
		{
			base.Show(root);
			if (this.mView != null)
			{
				LevelFightActivityView levelFightActivityView = this.mView as LevelFightActivityView;
				if (levelFightActivityView != null)
				{
					if (this.mDataModel != null && this.mDataModel.TaskDatas != null)
					{
						levelFightActivityView.ShowResultText(this.mDataModel.TaskDatas.Count);
					}
					levelFightActivityView.OnButtonClick = new UnityAction(this._OnGoToRank);
					levelFightActivityView.ShowPlayerName(false);
					this._UpdateRankList();
				}
			}
		}

		// Token: 0x0600F421 RID: 62497 RVA: 0x0041F014 File Offset: 0x0041D414
		public override void UpdateData()
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(this.mDataModel.Id);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LevelFightShowActivityDataModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null, null);
				this._UpdateRankList();
			}
		}

		// Token: 0x0600F422 RID: 62498 RVA: 0x0041F059 File Offset: 0x0041D459
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LevelFightActivity";
		}

		// Token: 0x0600F423 RID: 62499 RVA: 0x0041F060 File Offset: 0x0041D460
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/LevelFightShowItem";
		}

		// Token: 0x0600F424 RID: 62500 RVA: 0x0041F068 File Offset: 0x0041D468
		private void _UpdateRankList()
		{
			WorldSortListReq cmd = new WorldSortListReq
			{
				type = 5,
				num = 100
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList baseSortList = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				if (baseSortList != null && baseSortList.selfEntry != null)
				{
					if (this.mDataModel is LevelFightShowActivityDataModel)
					{
						((LevelFightShowActivityDataModel)this.mDataModel).UpdateRecords(baseSortList);
					}
					LevelFightActivityView levelFightActivityView = this.mView as LevelFightActivityView;
					if (levelFightActivityView != null)
					{
						this.mView.UpdateData(this.mDataModel);
						levelFightActivityView.SetRank((int)baseSortList.selfEntry.ranking);
					}
				}
			}, true, 15f, null);
		}

		// Token: 0x0600F425 RID: 62501 RVA: 0x0041F0BE File Offset: 0x0041D4BE
		private void _OnGoToRank()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RanklistFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<RanklistFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
		}

		// Token: 0x04009608 RID: 38408
		private const int SHOW_RANK_MAX_COUNT = 100;
	}
}
