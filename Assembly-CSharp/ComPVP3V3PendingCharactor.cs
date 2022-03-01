using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200004B RID: 75
public class ComPVP3V3PendingCharactor : MonoBehaviour
{
	// Token: 0x060001C1 RID: 449 RVA: 0x0000F760 File Offset: 0x0000DB60
	private void Awake()
	{
		this._bindExUI();
		this._bindEvent();
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000F76E File Offset: 0x0000DB6E
	private void OnDestroy()
	{
		this._unbindExUI();
		this._unbindEvent();
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000F77C File Offset: 0x0000DB7C
	private void _bindEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3StartRedyFightCount, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0000F7B4 File Offset: 0x0000DBB4
	private void _unbindEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3StartRedyFightCount, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000F7EC File Offset: 0x0000DBEC
	private void _onPK3V3VoteForFightStatusChanged(UIEvent ui)
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return;
		}
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
		{
			return;
		}
		if (mainPlayer.teamType != playerBySeat.teamType)
		{
			return;
		}
		this._updateFightFlag();
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000F850 File Offset: 0x0000DC50
	protected void _bindExUI()
	{
		this.mBg = this.mBind.GetCom<RectTransform>("bg");
		this.mIcon = this.mBind.GetCom<Image>("icon");
		this.mIconRoot = this.mBind.GetGameObject("iconRoot");
		this.mName = this.mBind.GetCom<Text>("name");
		this.mDeadFlag = this.mBind.GetGameObject("deadFlag");
		this.mTeamFlag = this.mBind.GetCom<Outline>("teamFlag");
		this.mLocalPlayerFlag = this.mBind.GetGameObject("localPlayerFlag");
		this.mRedtipapplybattle = this.mBind.GetGameObject("redtipapplybattle");
		this.mRedtipnextround = this.mBind.GetGameObject("redtipnextround");
		this.mRedtiproot = this.mBind.GetGameObject("redtiproot");
		this.mRedtriangle = this.mBind.GetGameObject("redtriangle");
		this.mFightFlag = this.mBind.GetGameObject("fightFlag");
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000F968 File Offset: 0x0000DD68
	protected void _unbindExUI()
	{
		this.mBg = null;
		this.mIcon = null;
		this.mIconRoot = null;
		this.mName = null;
		this.mDeadFlag = null;
		this.mTeamFlag = null;
		this.mLocalPlayerFlag = null;
		this.mRedtipapplybattle = null;
		this.mRedtipnextround = null;
		this.mRedtiproot = null;
		this.mRedtriangle = null;
		this.mFightFlag = null;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000F9CC File Offset: 0x0000DDCC
	public void InitWithSeat(byte seat)
	{
		if (this.mSeat == seat)
		{
			return;
		}
		this.mSeat = seat;
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(seat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return;
		}
		if (null != this.mName)
		{
			this.mName.text = playerBySeat.GetPlayerName();
		}
		if (null != this.mTeamFlag)
		{
		}
		if (null != this.mRedtiproot)
		{
			this.mRedtiproot.CustomActive(true);
		}
		if (null != this.mIcon)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)playerBySeat.playerInfo.occupation, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref this.mIcon, tableItem2.IconPath, true);
				}
			}
		}
		if (null != this.mIconRoot)
		{
			if (playerBySeat.IsTeamRed())
			{
				this.mIconRoot.transform.SetAsFirstSibling();
			}
			else
			{
				this.mIconRoot.transform.SetAsLastSibling();
			}
		}
		if (null != this.mLocalPlayerFlag)
		{
			this.mLocalPlayerFlag.CustomActive(playerBySeat.IsLocalPlayer());
			this.mLocalPlayerFlag.transform.SetAsLastSibling();
		}
		if (null != this.mBg)
		{
			this.mBg.transform.SetAsFirstSibling();
			if (playerBySeat.IsTeamRed())
			{
				this.mBg.rectTransform().localScale = Vector3.one;
			}
			else
			{
				this.mBg.rectTransform().localScale = new Vector3(-1f, 1f, 1f);
			}
		}
		if (null != this.mRedtipnextround)
		{
			if (playerBySeat.IsTeamRed())
			{
				this.mRedtipnextround.transform.localScale = Vector3.one;
			}
			else
			{
				this.mRedtipnextround.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}
		if (null != this.mRedtipapplybattle)
		{
			if (playerBySeat.IsTeamRed())
			{
				this.mRedtipapplybattle.transform.localScale = Vector3.one;
			}
			else
			{
				this.mRedtipapplybattle.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000FC58 File Offset: 0x0000E058
	public void UpdateInfo()
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return;
		}
		this._updateFightFlag();
		if (null != this.mDeadFlag)
		{
			this.mDeadFlag.CustomActive(playerBySeat.isPassedInRound);
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000FCB0 File Offset: 0x0000E0B0
	private void _updateFightFlag()
	{
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
		if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
		{
			return;
		}
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
		{
			return;
		}
		if (mainPlayer.teamType != playerBySeat.teamType)
		{
			this._showStatusNone();
			return;
		}
		this.votePlayers.Clear();
		this.notVotePlayers.Clear();
		BattleMain.instance.GetPlayerManager().GetTeamVotePlayers(this.votePlayers, playerBySeat.teamType);
		BattleMain.instance.GetPlayerManager().GetTeamNotVotePlayers(this.notVotePlayers, playerBySeat.teamType);
		if (this.votePlayers.Count <= 0 && this.notVotePlayers.Count <= 0)
		{
			this._showStatusNone();
			return;
		}
		if (this.votePlayers.Count <= 0)
		{
			if (this.notVotePlayers[0].GetPlayerSeat() == playerBySeat.GetPlayerSeat())
			{
				this._showStatusNextRound();
			}
			else
			{
				this._showStatusNone();
			}
			return;
		}
		bool flag = playerBySeat.isVote && !playerBySeat.hasFighted;
		if (flag)
		{
			this._showStatusApplyBattle();
		}
		else
		{
			this._showStatusNone();
		}
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000FDF8 File Offset: 0x0000E1F8
	private void _showStatusApplyBattle()
	{
		this.mRedtriangle.CustomActive(true);
		this.mRedtipapplybattle.CustomActive(true);
		this.mRedtipnextround.CustomActive(false);
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000FE1E File Offset: 0x0000E21E
	private void _showStatusNextRound()
	{
		this.mRedtriangle.CustomActive(true);
		this.mRedtipapplybattle.CustomActive(false);
		this.mRedtipnextround.CustomActive(true);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000FE44 File Offset: 0x0000E244
	private void _showStatusNone()
	{
		this.mRedtriangle.CustomActive(false);
		this.mRedtipapplybattle.CustomActive(false);
		this.mRedtipnextround.CustomActive(false);
	}

	// Token: 0x040001B1 RID: 433
	public ComCommonBind mBind;

	// Token: 0x040001B2 RID: 434
	private RectTransform mBg;

	// Token: 0x040001B3 RID: 435
	private Image mIcon;

	// Token: 0x040001B4 RID: 436
	private GameObject mIconRoot;

	// Token: 0x040001B5 RID: 437
	private Text mName;

	// Token: 0x040001B6 RID: 438
	private GameObject mDeadFlag;

	// Token: 0x040001B7 RID: 439
	private Outline mTeamFlag;

	// Token: 0x040001B8 RID: 440
	private GameObject mLocalPlayerFlag;

	// Token: 0x040001B9 RID: 441
	private GameObject mRedtipapplybattle;

	// Token: 0x040001BA RID: 442
	private GameObject mRedtipnextround;

	// Token: 0x040001BB RID: 443
	private GameObject mRedtiproot;

	// Token: 0x040001BC RID: 444
	private GameObject mRedtriangle;

	// Token: 0x040001BD RID: 445
	private GameObject mFightFlag;

	// Token: 0x040001BE RID: 446
	private byte mSeat = byte.MaxValue;

	// Token: 0x040001BF RID: 447
	private List<BattlePlayer> votePlayers = new List<BattlePlayer>();

	// Token: 0x040001C0 RID: 448
	private List<BattlePlayer> notVotePlayers = new List<BattlePlayer>();
}
