using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C96 RID: 7318
	public class TeamDuplicationFightVoteItem : MonoBehaviour
	{
		// Token: 0x06011F21 RID: 73505 RVA: 0x0053F2D6 File Offset: 0x0053D6D6
		private void Awake()
		{
		}

		// Token: 0x06011F22 RID: 73506 RVA: 0x0053F2D8 File Offset: 0x0053D6D8
		private void OnEnable()
		{
		}

		// Token: 0x06011F23 RID: 73507 RVA: 0x0053F2DA File Offset: 0x0053D6DA
		private void OnDisable()
		{
		}

		// Token: 0x06011F24 RID: 73508 RVA: 0x0053F2DC File Offset: 0x0053D6DC
		private void OnDestroy()
		{
			this._captainDataModel = null;
			this._fightVoteType = TeamDuplicationFightVoteType.None;
		}

		// Token: 0x06011F25 RID: 73509 RVA: 0x0053F2EC File Offset: 0x0053D6EC
		public void Init(TeamDuplicationCaptainDataModel captainDataModel, TeamDuplicationFightVoteType fightVoteType = TeamDuplicationFightVoteType.FightStartVote)
		{
			this._captainDataModel = captainDataModel;
			this._fightVoteType = fightVoteType;
			if (this._captainDataModel == null)
			{
				Logger.LogErrorFormat("TeamDuplicationTroopTotalItem Init troopDataModel is null", new object[0]);
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F26 RID: 73510 RVA: 0x0053F31E File Offset: 0x0053D71E
		private void InitItem()
		{
			this.InitCaptainLabel();
			this.InitVotePlayerItem();
		}

		// Token: 0x06011F27 RID: 73511 RVA: 0x0053F32C File Offset: 0x0053D72C
		private void InitCaptainLabel()
		{
			if (this.troopIndexTitle != null)
			{
				this.troopIndexTitle.text = this._captainDataModel.CaptainId.ToString();
			}
		}

		// Token: 0x06011F28 RID: 73512 RVA: 0x0053F360 File Offset: 0x0053D760
		private void InitVotePlayerItem()
		{
			if (this.firstPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 0)
				{
					this.firstPlayerItem.InitVotePlayerItem(this._captainDataModel.PlayerList[0], this._fightVoteType);
				}
				else
				{
					this.firstPlayerItem.InitVotePlayerItem(null, this._fightVoteType);
				}
			}
			if (this.secondPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 1)
				{
					this.secondPlayerItem.InitVotePlayerItem(this._captainDataModel.PlayerList[1], this._fightVoteType);
				}
				else
				{
					this.secondPlayerItem.InitVotePlayerItem(null, this._fightVoteType);
				}
			}
			if (this.thirdPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 2)
				{
					this.thirdPlayerItem.InitVotePlayerItem(this._captainDataModel.PlayerList[2], this._fightVoteType);
				}
				else
				{
					this.thirdPlayerItem.InitVotePlayerItem(null, this._fightVoteType);
				}
			}
		}

		// Token: 0x06011F29 RID: 73513 RVA: 0x0053F4C0 File Offset: 0x0053D8C0
		public void Reset()
		{
			if (this.firstPlayerItem != null)
			{
				this.firstPlayerItem.Reset();
			}
			if (this.secondPlayerItem != null)
			{
				this.secondPlayerItem.Reset();
			}
			if (this.thirdPlayerItem != null)
			{
				this.thirdPlayerItem.Reset();
			}
		}

		// Token: 0x0400BB11 RID: 47889
		private TeamDuplicationCaptainDataModel _captainDataModel;

		// Token: 0x0400BB12 RID: 47890
		private TeamDuplicationFightVoteType _fightVoteType;

		// Token: 0x0400BB13 RID: 47891
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text troopIndexTitle;

		// Token: 0x0400BB14 RID: 47892
		[Space(10f)]
		[Header("FightVotePlayer")]
		[Space(5f)]
		[SerializeField]
		private TeamDuplicationFightVotePlayerItem firstPlayerItem;

		// Token: 0x0400BB15 RID: 47893
		[SerializeField]
		private TeamDuplicationFightVotePlayerItem secondPlayerItem;

		// Token: 0x0400BB16 RID: 47894
		[SerializeField]
		private TeamDuplicationFightVotePlayerItem thirdPlayerItem;
	}
}
