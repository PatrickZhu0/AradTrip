using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C97 RID: 7319
	public class TeamDuplicationFightVotePlayerItem : TeamDuplicationBasePlayerItem
	{
		// Token: 0x06011F2B RID: 73515 RVA: 0x0053F6A4 File Offset: 0x0053DAA4
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStartVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStartVoteAgreeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteAgreeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteRefuseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteRefuseMessage));
		}

		// Token: 0x06011F2C RID: 73516 RVA: 0x0053F704 File Offset: 0x0053DB04
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStartVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStartVoteAgreeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteAgreeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteRefuseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteRefuseMessage));
		}

		// Token: 0x06011F2D RID: 73517 RVA: 0x0053F764 File Offset: 0x0053DB64
		public void InitVotePlayerItem(TeamDuplicationPlayerDataModel playerDataModel, TeamDuplicationFightVoteType fightVoteType = TeamDuplicationFightVoteType.FightStartVote)
		{
			this._fightVoteType = fightVoteType;
			base.Init(playerDataModel);
			if (playerDataModel == null)
			{
				return;
			}
			ulong guid = playerDataModel.Guid;
			if (this._fightVoteType == TeamDuplicationFightVoteType.FightEndVote)
			{
				bool flag = TeamDuplicationUtility.IsPlayerAlreadyAgreeFightEndVote(guid);
				bool flag2 = TeamDuplicationUtility.IsPlayerAlreadyRefuseFightEndVote(guid);
				if (!flag && !flag2)
				{
					this.UpdateHeadGray(false);
					CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, true);
					if (flag)
					{
						CommonUtility.UpdateGameObjectVisible(this.agreeRoot, true);
						CommonUtility.UpdateGameObjectVisible(this.refuseRoot, false);
					}
					else
					{
						CommonUtility.UpdateGameObjectVisible(this.agreeRoot, false);
						CommonUtility.UpdateGameObjectVisible(this.refuseRoot, true);
					}
				}
			}
			else
			{
				bool flag3 = TeamDuplicationUtility.IsPlayerAlreadyAgreeFightStartVote(guid);
				this.UpdateHeadGray(flag3);
				CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, false);
			}
		}

		// Token: 0x06011F2E RID: 73518 RVA: 0x0053F834 File Offset: 0x0053DC34
		private void OnReceiveTeamDuplicationFightStartVoteAgreeMessage(UIEvent uiEvent)
		{
			if (this._fightVoteType == TeamDuplicationFightVoteType.FightEndVote)
			{
				return;
			}
			if (this.PlayerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this.PlayerDataModel.Guid)
			{
				return;
			}
			this.UpdateHeadGray(true);
			CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, false);
		}

		// Token: 0x06011F2F RID: 73519 RVA: 0x0053F8A0 File Offset: 0x0053DCA0
		private void OnReceiveTeamDuplicationFightEndVoteAgreeMessage(UIEvent uiEvent)
		{
			if (this._fightVoteType != TeamDuplicationFightVoteType.FightEndVote)
			{
				return;
			}
			if (this.PlayerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this.PlayerDataModel.Guid)
			{
				return;
			}
			this.UpdateHeadGray(true);
			CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.agreeRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.refuseRoot, false);
		}

		// Token: 0x06011F30 RID: 73520 RVA: 0x0053F924 File Offset: 0x0053DD24
		private void OnReceiveTeamDuplicationFightEndVoteRefuseMessage(UIEvent uiEvent)
		{
			if (this._fightVoteType != TeamDuplicationFightVoteType.FightEndVote)
			{
				return;
			}
			if (this.PlayerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this.PlayerDataModel.Guid)
			{
				return;
			}
			this.UpdateHeadGray(true);
			CommonUtility.UpdateGameObjectVisible(this.voteResultRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.agreeRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.refuseRoot, true);
		}

		// Token: 0x06011F31 RID: 73521 RVA: 0x0053F9A8 File Offset: 0x0053DDA8
		private void UpdateVotePlayerItem(UIEvent uiEvent)
		{
			if (this.PlayerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this.PlayerDataModel.Guid)
			{
				return;
			}
			this.UpdateHeadGray(true);
		}

		// Token: 0x06011F32 RID: 73522 RVA: 0x0053F9F8 File Offset: 0x0053DDF8
		public void UpdateHeadGray(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.headGrayCover, !flag);
		}

		// Token: 0x06011F33 RID: 73523 RVA: 0x0053FA09 File Offset: 0x0053DE09
		public void Reset()
		{
			this.PlayerDataModel = null;
			this._fightVoteType = TeamDuplicationFightVoteType.None;
		}

		// Token: 0x0400BB17 RID: 47895
		private TeamDuplicationFightVoteType _fightVoteType;

		// Token: 0x0400BB18 RID: 47896
		[SerializeField]
		private GameObject headGrayCover;

		// Token: 0x0400BB19 RID: 47897
		[Space(10f)]
		[Header("VoteResult")]
		[Space(10f)]
		[SerializeField]
		private GameObject voteResultRoot;

		// Token: 0x0400BB1A RID: 47898
		[SerializeField]
		private GameObject agreeRoot;

		// Token: 0x0400BB1B RID: 47899
		[SerializeField]
		private GameObject refuseRoot;
	}
}
