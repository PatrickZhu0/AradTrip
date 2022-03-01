using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA0 RID: 7328
	public class TeamDuplicationTeamRoomItem : MonoBehaviour
	{
		// Token: 0x06011F98 RID: 73624 RVA: 0x00541395 File Offset: 0x0053F795
		private void OnDestroy()
		{
			this._captainDataModel = null;
			this._isOtherTeam = false;
			this._teamCopyType = TeamCopyType.TC_TYPE_ONE;
			this._captainIndexLabelGray = null;
		}

		// Token: 0x06011F99 RID: 73625 RVA: 0x005413B3 File Offset: 0x0053F7B3
		public void Init(TeamDuplicationCaptainDataModel captainDataModel, bool isOtherTeam = false, TeamCopyType teamCopyType = TeamCopyType.TC_TYPE_ONE)
		{
			this._captainDataModel = captainDataModel;
			this._isOtherTeam = isOtherTeam;
			this._teamCopyType = teamCopyType;
			if (this._captainDataModel == null)
			{
				Logger.LogErrorFormat("TeamDuplicationTroopTotalItem Init troopDataModel is null", new object[0]);
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F9A RID: 73626 RVA: 0x005413EC File Offset: 0x0053F7EC
		private void InitItem()
		{
			bool flag = this._teamCopyType == TeamCopyType.TC_TYPE_TWO && this._captainDataModel.CaptainId > DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumberWith65Level;
			if (this.troopIndexTitle != null)
			{
				if (flag)
				{
					string text = TR.Value("Team_Duplication_Seat_Empty_Label_Not_Sit");
					this.troopIndexTitle.text = text;
					if (this._captainIndexLabelGray == null)
					{
						this._captainIndexLabelGray = this.troopIndexTitle.gameObject.AddComponent<UIGray>();
					}
				}
				else
				{
					string text2 = TR.Value("team_duplication_troop_room_team_title", this._captainDataModel.CaptainId);
					this.troopIndexTitle.text = text2;
				}
			}
			int num = (this._captainDataModel.CaptainId - 1) * 3;
			int playerSeatId = num + 1;
			int playerSeatId2 = num + 2;
			int playerSeatId3 = num + 3;
			if (this.firstPlayerItem != null)
			{
				TeamDuplicationPlayerDataModel playerDataModel = null;
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 0)
				{
					playerDataModel = this._captainDataModel.PlayerList[0];
				}
				this.firstPlayerItem.InitItem(playerDataModel, this._isOtherTeam, playerSeatId, flag);
			}
			if (this.secondPlayerItem != null)
			{
				TeamDuplicationPlayerDataModel playerDataModel2 = null;
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 1)
				{
					playerDataModel2 = this._captainDataModel.PlayerList[1];
				}
				this.secondPlayerItem.InitItem(playerDataModel2, this._isOtherTeam, playerSeatId2, flag);
			}
			if (this.thirdPlayerItem != null)
			{
				TeamDuplicationPlayerDataModel playerDataModel3 = null;
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 2)
				{
					playerDataModel3 = this._captainDataModel.PlayerList[2];
				}
				this.thirdPlayerItem.InitItem(playerDataModel3, this._isOtherTeam, playerSeatId3, flag);
			}
		}

		// Token: 0x0400BB5E RID: 47966
		private TeamDuplicationCaptainDataModel _captainDataModel;

		// Token: 0x0400BB5F RID: 47967
		private bool _isOtherTeam;

		// Token: 0x0400BB60 RID: 47968
		private TeamCopyType _teamCopyType;

		// Token: 0x0400BB61 RID: 47969
		private UIGray _captainIndexLabelGray;

		// Token: 0x0400BB62 RID: 47970
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text troopIndexTitle;

		// Token: 0x0400BB63 RID: 47971
		[Space(10f)]
		[Header("TroopRoomPlayerItem")]
		[Space(5f)]
		[SerializeField]
		private TeamDuplicationTeamRoomPlayerItem firstPlayerItem;

		// Token: 0x0400BB64 RID: 47972
		[SerializeField]
		private TeamDuplicationTeamRoomPlayerItem secondPlayerItem;

		// Token: 0x0400BB65 RID: 47973
		[SerializeField]
		private TeamDuplicationTeamRoomPlayerItem thirdPlayerItem;
	}
}
