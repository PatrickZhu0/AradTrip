using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001849 RID: 6217
	public sealed class LevelFightActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F41A RID: 62490 RVA: 0x0041EDE8 File Offset: 0x0041D1E8
		public override void Show(Transform root)
		{
			base.Show(root);
			if (this.mView != null)
			{
				LevelFightActivityView view = this.mView as LevelFightActivityView;
				if (view != null)
				{
					view.SetEndTime((int)this.mDataModel.EndTime);
					view.OnButtonClick = new UnityAction(this._OnGoToRank);
					view.ShowPlayerName(false);
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
							view.SetRank((int)baseSortList.selfEntry.ranking);
						}
					}, true, 15f, null);
				}
			}
		}

		// Token: 0x0600F41B RID: 62491 RVA: 0x0041EEB1 File Offset: 0x0041D2B1
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LevelFightActivity";
		}

		// Token: 0x0600F41C RID: 62492 RVA: 0x0041EEB8 File Offset: 0x0041D2B8
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/LevelFightItem";
		}

		// Token: 0x0600F41D RID: 62493 RVA: 0x0041EEBF File Offset: 0x0041D2BF
		private void _OnGoToRank()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RanklistFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<RanklistFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
		}

		// Token: 0x04009607 RID: 38407
		private const int SHOW_RANK_MAX_COUNT = 100;
	}
}
