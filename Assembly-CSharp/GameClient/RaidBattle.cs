using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020045C4 RID: 17860
	public class RaidBattle : PVEBattle
	{
		// Token: 0x06019115 RID: 102677 RVA: 0x007E8A94 File Offset: 0x007E6E94
		public RaidBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
			if (base.dungeonManager == null || base.dungeonManager.GetDungeonDataManager() == null || base.dungeonManager.GetDungeonDataManager().table == null)
			{
				return;
			}
			this.mMaxRebornCount = base.dungeonManager.GetDungeonDataManager().table.TotalRebornCount;
			this.mCurRebornCount = this.mMaxRebornCount;
			this.mAddRbornNotify = TR.Value("raid_battle_add_reborn_count");
		}

		// Token: 0x06019116 RID: 102678 RVA: 0x007E8B40 File Offset: 0x007E6F40
		public override bool IsRebornCountLimit()
		{
			return this.mMaxRebornCount > 0;
		}

		// Token: 0x06019117 RID: 102679 RVA: 0x007E8B4B File Offset: 0x007E6F4B
		public override int GetLeftRebornCount()
		{
			return this.mCurRebornCount;
		}

		// Token: 0x06019118 RID: 102680 RVA: 0x007E8B53 File Offset: 0x007E6F53
		public override int GetMaxRebornCount()
		{
			return this.mMaxRebornCount;
		}

		// Token: 0x06019119 RID: 102681 RVA: 0x007E8B5C File Offset: 0x007E6F5C
		public override void AddMaxRebornCount(int count)
		{
			this.mMaxRebornCount += count;
			this.mCurRebornCount += count;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AddRerbornCount, null, null, null, null);
			SystemNotifyManager.SysDungeonSkillTip(string.Format(this.mAddRbornNotify, count), 9f, true);
		}

		// Token: 0x0601911A RID: 102682 RVA: 0x007E8BB5 File Offset: 0x007E6FB5
		protected override void _onReborn(BattlePlayer player)
		{
			this.mCurRebornCount--;
		}

		// Token: 0x0601911B RID: 102683 RVA: 0x007E8BC8 File Offset: 0x007E6FC8
		protected override void _onSceneDungeonRaceEndRes(SceneDungeonRaceEndRes res)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(3091343170U);
			}
			if (res.result == 0U)
			{
				this._finishProcess((DungeonScore)res.score);
			}
			else
			{
				Logger.LogErrorCode(res.result);
			}
		}

		// Token: 0x0601911C RID: 102684 RVA: 0x007E8C34 File Offset: 0x007E7034
		private void _finishProcess(DungeonScore score)
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (!this.mIsTeamWin)
			{
				if (score != DungeonScore.C)
				{
					string msgContent = TR.Value("team_battle_result_succ");
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					string msgContent2 = TR.Value("team_battle_result_failed");
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent2, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonMenuFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonMenuFrame>(FrameLayer.Middle, null, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRewardFinish, null, null, null, null);
		}

		// Token: 0x0601911D RID: 102685 RVA: 0x007E8CBC File Offset: 0x007E70BC
		protected override void _onTeamCopyRaceEnd()
		{
			if (this.mDungeonManager != null && !this.mDungeonManager.IsFinishFight())
			{
				this.mIsTeamWin = true;
				base.FrameRandom.Range100();
				this.m_CanFinishFight = true;
				base._sendDungeonRaceEndFail(DungeonScore.A);
				if (this.mDungeonManager.GetBeScene() != null)
				{
					this.mDungeonManager.GetBeScene().ClearAllMonsters();
				}
			}
		}

		// Token: 0x0601911E RID: 102686 RVA: 0x007E8D28 File Offset: 0x007E7128
		public int GetDungeonRecoverProcess(int dungeonId)
		{
			int result;
			if (this.mDungeonRecoverProcess.TryGetValue(dungeonId, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x0601911F RID: 102687 RVA: 0x007E8D4B File Offset: 0x007E714B
		public void SetDungeonRecoverProcess(int dungeonId, int process)
		{
			if (this.mDungeonRecoverProcess.ContainsKey(dungeonId))
			{
				this.mDungeonRecoverProcess[dungeonId] = process;
			}
			else
			{
				this.mDungeonRecoverProcess.Add(dungeonId, process);
			}
		}

		// Token: 0x06019120 RID: 102688 RVA: 0x007E8D80 File Offset: 0x007E7180
		public void DungeonDestroyNotify(int dungeonId)
		{
			Logger.LogErrorFormat("收到团本关卡被歼灭的消息,关卡ID:{0}", new object[]
			{
				dungeonId
			});
			if (dungeonId == 8000700)
			{
				this.ServerNotifyArr[3] = true;
			}
			else if (dungeonId == 8000800)
			{
				this.ServerNotifyArr[2] = true;
			}
			else if (dungeonId == 8000400)
			{
				this.ServerNotifyArr[1] = true;
			}
			else if (dungeonId == 8001700)
			{
				this.ServerNotifyArr[6] = true;
			}
			else if (dungeonId == 8001800)
			{
				this.ServerNotifyArr[5] = true;
			}
			else if (dungeonId == 8001400)
			{
				this.ServerNotifyArr[4] = true;
			}
			else if (!this.ServerNotifyList.Contains(dungeonId))
			{
				this.ServerNotifyList.Add(dungeonId);
			}
		}

		// Token: 0x06019121 RID: 102689 RVA: 0x007E8E59 File Offset: 0x007E7259
		public bool CheckServerNotify(int id)
		{
			if (id <= 0)
			{
				return false;
			}
			if (id >= this.ServerNotifyArr.Length)
			{
				Logger.LogErrorFormat("消息ID错误:{0}", new object[]
				{
					id
				});
				return false;
			}
			return this.ServerNotifyArr[id];
		}

		// Token: 0x06019122 RID: 102690 RVA: 0x007E8E95 File Offset: 0x007E7295
		public bool CheckServerNotifyEx(int dungeonID)
		{
			return this.ServerNotifyList.Contains(dungeonID);
		}

		// Token: 0x06019123 RID: 102691 RVA: 0x007E8EA3 File Offset: 0x007E72A3
		public override void BeforeExecFrameCommand(byte seat, IFrameCommand cmd)
		{
		}

		// Token: 0x06019124 RID: 102692 RVA: 0x007E8EA8 File Offset: 0x007E72A8
		public override void AfterExecFrameCommand(byte seat, IFrameCommand cmd)
		{
			base.AfterExecFrameCommand(seat, cmd);
			FrameCommandID id = cmd.GetID();
			if (id == FrameCommandID.TeamCopyRaceEnd)
			{
				this._onTeamCopyRaceEnd();
				if (this.mDungeonManager != null)
				{
					this.mDungeonManager.FinishFight();
				}
				if (!Singleton<ReplayServer>.GetInstance().IsLiveShow())
				{
					FrameSync.instance.SetDungeonMode(eDungeonMode.LocalFrame);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleFrameSyncEnd, null, null, null, null);
			}
		}

		// Token: 0x04011FBD RID: 73661
		private int mCurRebornCount;

		// Token: 0x04011FBE RID: 73662
		private int mMaxRebornCount;

		// Token: 0x04011FBF RID: 73663
		private bool mIsTeamWin;

		// Token: 0x04011FC0 RID: 73664
		protected bool[] ServerNotifyArr = new bool[10];

		// Token: 0x04011FC1 RID: 73665
		private List<int> ServerNotifyList = new List<int>();

		// Token: 0x04011FC2 RID: 73666
		protected Dictionary<int, int> mDungeonRecoverProcess = new Dictionary<int, int>();

		// Token: 0x04011FC3 RID: 73667
		protected string mAddRbornNotify = string.Empty;
	}
}
