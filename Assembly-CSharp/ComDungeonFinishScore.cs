using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ECC RID: 3788
public class ComDungeonFinishScore : MonoBehaviour
{
	// Token: 0x060094F9 RID: 38137 RVA: 0x001BF9C0 File Offset: 0x001BDDC0
	public void Init(int sumExp, DungeonScore finalScore)
	{
		this._setOneSplit("sumexp", sumExp);
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
		if (null != this.mExpBar)
		{
			this.mExpBar.TextFormat = delegate(ulong exp)
			{
				KeyValuePair<ulong, ulong> curRoleExp = Singleton<TableManager>.instance.GetCurRoleExp(exp);
				if (curRoleExp.Value == 0UL)
				{
					return "100%";
				}
				double num = curRoleExp.Key / curRoleExp.Value;
				return string.Format("{0:P}", num, curRoleExp.Key, curRoleExp.Value);
			};
			this.mExpBar.SetExp(DataManager<BattleDataManager>.GetInstance().originExp, true, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			this._onExpUpdate(null);
		}
		this._setCallback(0, () => BattleMain.instance.GetDungeonStatistics().AllHitCount(), () => BattleMain.instance.GetDungeonStatistics().HitCountScore());
		this._setCallback(1, () => BattleMain.instance.GetDungeonStatistics().AllFightTime(true), () => BattleMain.instance.GetDungeonStatistics().AllFightTimeScore(true));
		this._setCallback(2, () => BattleMain.instance.GetDungeonStatistics().AllRebornCount(), () => BattleMain.instance.GetDungeonStatistics().RebornCountScore());
		if (this.infos != null)
		{
			for (int i = 0; i < this.infos.Length; i++)
			{
				if (this.infos[i] != null)
				{
					this.infos[i].curScore = (int)finalScore;
				}
			}
		}
		this._updateInfo();
		this._setScore(finalScore);
	}

	// Token: 0x060094FA RID: 38138 RVA: 0x001BFB7C File Offset: 0x001BDF7C
	private void _onExpUpdate(UIEvent ui)
	{
		if (null != this.mExpBar)
		{
			this.mExpBar.SetExp(DataManager<PlayerBaseData>.GetInstance().Exp, false, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
		}
	}

	// Token: 0x060094FB RID: 38139 RVA: 0x001BFBD0 File Offset: 0x001BDFD0
	private void _setOneSplit(string key, int va)
	{
		if (null != this.mScoreBind)
		{
			ComFlyNumber com = this.mScoreBind.GetCom<ComFlyNumber>(key);
			if (null != com)
			{
				com.SetNumber(va);
			}
		}
	}

	// Token: 0x060094FC RID: 38140 RVA: 0x001BFC0E File Offset: 0x001BE00E
	private float _getCurrentVipExpRate()
	{
		return Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.DUNGEON_EXP);
	}

	// Token: 0x060094FD RID: 38141 RVA: 0x001BFC16 File Offset: 0x001BE016
	private bool _hasVipExpRate()
	{
		return this._getCurrentVipExpRate() > 0f;
	}

	// Token: 0x060094FE RID: 38142 RVA: 0x001BFC25 File Offset: 0x001BE025
	private float _getCurrentVipGoldRate()
	{
		return Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.DUNGEON_DROP_GOLD);
	}

	// Token: 0x060094FF RID: 38143 RVA: 0x001BFC2D File Offset: 0x001BE02D
	private bool _hasVipGoldRate()
	{
		return this._getCurrentVipGoldRate() > 0f;
	}

	// Token: 0x06009500 RID: 38144 RVA: 0x001BFC3C File Offset: 0x001BE03C
	private bool _hasMonthCard()
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		return mainPlayer != null && mainPlayer.IsPlayerMonthCard();
	}

	// Token: 0x06009501 RID: 38145 RVA: 0x001BFC68 File Offset: 0x001BE068
	public void SetExpSplit(int baseExp, int drugExp, int scoreExp, int diffExp, int vipexp = 0, int vipgold = 0, int monthCardGold = 0, int tapAdd = 0, int relationExp = 0)
	{
		this._setOneSplit("base", baseExp);
		this._setOneSplit("drug", drugExp);
		this._setOneSplit("score", scoreExp);
		this._setOneSplit("diff", diffExp);
		Text com = this.mScoreBind.GetCom<Text>("viplevelexp");
		Text com2 = this.mScoreBind.GetCom<Text>("viplevelgold");
		ComFlyNumber com3 = this.mScoreBind.GetCom<ComFlyNumber>("vipcountgold");
		ComFlyNumber com4 = this.mScoreBind.GetCom<ComFlyNumber>("vipcountexp");
		Text com5 = this.mScoreBind.GetCom<Text>("normallevelexp");
		Text com6 = this.mScoreBind.GetCom<Text>("normalcountexp");
		GameObject gameObject = this.mScoreBind.GetGameObject("normalExpRoot");
		GameObject gameObject2 = this.mScoreBind.GetGameObject("vipExpRoot");
		GameObject gameObject3 = this.mScoreBind.GetGameObject("vipGoldRoot");
		GameObject gameObject4 = this.mScoreBind.GetGameObject("monthCardRoot");
		Text com7 = this.mScoreBind.GetCom<Text>("monthGoldAdd");
		GameObject gameObject5 = this.mScoreBind.GetGameObject("tapRoot");
		Text com8 = this.mScoreBind.GetCom<Text>("tapExp");
		GameObject gameObject6 = this.mScoreBind.GetGameObject("relationroot");
		Text com9 = this.mScoreBind.GetCom<Text>("relationExp");
		bool flag = tapAdd > relationExp;
		gameObject2.SetActive(false);
		gameObject.SetActive(false);
		gameObject4.SetActive(false);
		gameObject3.SetActive(false);
		gameObject5.SetActive(flag && tapAdd > 0);
		gameObject6.SetActive(!flag && relationExp > 0);
		if (tapAdd > 0 && null != com8)
		{
			com8.text = tapAdd.ToString();
		}
		if (relationExp > 0 && com9 != null)
		{
			com9.text = relationExp.ToString();
		}
		if (this._hasVipExpRate())
		{
			gameObject2.SetActive(true);
			com.text = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
			com4.SetNumber(vipexp);
		}
		else
		{
			gameObject.SetActive(true);
			KeyValuePair<int, float> firstValidVipLevelPrivilegeData = Utility.GetFirstValidVipLevelPrivilegeData(VipPrivilegeTable.eType.DUNGEON_EXP);
			if (firstValidVipLevelPrivilegeData.Key > 0)
			{
				com5.text = firstValidVipLevelPrivilegeData.Key.ToString();
				com6.text = ((int)(firstValidVipLevelPrivilegeData.Value * 100f)).ToString();
			}
		}
		if (this._hasVipGoldRate())
		{
			gameObject3.SetActive(true);
			com2.text = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
			com3.SetNumber(vipgold);
		}
		if (this._hasMonthCard() || monthCardGold > 0)
		{
			gameObject4.SetActive(true);
			com7.text = monthCardGold.ToString();
		}
	}

	// Token: 0x06009502 RID: 38146 RVA: 0x001BFF54 File Offset: 0x001BE354
	private void _setCallback(int idx, ComDungeonScoreInfo.ScoreInfoCallback cb, ComDungeonScoreInfo.ScoreInfoScoreCallback scb)
	{
		if (idx < this.infos.Length && idx >= 0 && this.infos[idx] != null)
		{
			this.infos[idx].SetCallback(cb);
			this.infos[idx].SetScoreCallback(scb);
		}
	}

	// Token: 0x06009503 RID: 38147 RVA: 0x001BFFA5 File Offset: 0x001BE3A5
	private void _updateInfoByIdx(int idx)
	{
		if (idx < this.infos.Length && idx >= 0 && this.infos[idx] != null)
		{
			this.infos[idx].UpdateInfo();
		}
	}

	// Token: 0x06009504 RID: 38148 RVA: 0x001BFFDC File Offset: 0x001BE3DC
	public void Uninit()
	{
		for (int i = 0; i < this.infos.Length; i++)
		{
			this._setCallback(i, null, null);
		}
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
	}

	// Token: 0x06009505 RID: 38149 RVA: 0x001C0024 File Offset: 0x001BE424
	private void _set1Image(Image image, bool isSucces, string spritename)
	{
		if (null != this.mScoreBind)
		{
			this.mScoreBind.GetSprite(spritename, ref image);
			if (isSucces)
			{
				GameObject prefabInstance = this.mScoreBind.GetPrefabInstance("effect");
				Utility.AttachTo(prefabInstance, image.gameObject, false);
			}
		}
	}

	// Token: 0x06009506 RID: 38150 RVA: 0x001C0074 File Offset: 0x001BE474
	private void _setScore(DungeonScore finalScore)
	{
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (null != this.mScoreDesText)
		{
			this.mScoreDesText.text = finalScore.ToString();
		}
		if (null != this.mDiffDesText)
		{
			DungeonID dungeonID = new DungeonID(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId);
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId, string.Empty, string.Empty);
			string hardString = ChapterUtility.GetHardString(dungeonID.diffID);
			string hardColorString = ChapterUtility.GetHardColorString(dungeonID.diffID);
			if (tableItem != null && (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_HARD || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_NORMAL))
			{
				hardString = ChapterUtility.GetHardString(3);
				hardColorString = ChapterUtility.GetHardColorString(3);
			}
			this.mDiffDesText.text = string.Format("<color={0}>{1}</color>", hardColorString, hardString);
		}
		if (null != this.mScoreBind)
		{
			Image com = this.mScoreBind.GetCom<Image>("s0");
			Image com2 = this.mScoreBind.GetCom<Image>("s1");
			Image com3 = this.mScoreBind.GetCom<Image>("s2");
			GameObject gameObject = this.mScoreBind.GetGameObject("fail");
			GameObject gameObject2 = this.mScoreBind.GetGameObject("successroot");
			GameObject gameObject3 = this.mScoreBind.GetGameObject("failroot");
			com.enabled = false;
			com2.enabled = false;
			com3.enabled = false;
			gameObject2.CustomActive(true);
			gameObject.CustomActive(false);
			gameObject3.CustomActive(false);
			switch (finalScore)
			{
			case DungeonScore.C:
				gameObject.CustomActive(true);
				gameObject3.CustomActive(true);
				gameObject2.CustomActive(false);
				Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "C");
				break;
			case DungeonScore.B:
			case DungeonScore.A:
				com2.enabled = true;
				this._set1Image(com2, true, "a");
				Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "A");
				break;
			case DungeonScore.S:
				com2.enabled = true;
				this._set1Image(com2, true, "s");
				Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "S");
				break;
			case DungeonScore.SS:
				com2.enabled = true;
				com3.enabled = true;
				this._set1Image(com2, true, "s");
				this._set1Image(com3, true, "s");
				Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "SS");
				break;
			case DungeonScore.SSS:
				com.enabled = true;
				com2.enabled = true;
				com3.enabled = true;
				this._set1Image(com, true, "s");
				this._set1Image(com2, true, "s");
				this._set1Image(com3, true, "s");
				Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "SSS");
				break;
			}
		}
	}

	// Token: 0x06009507 RID: 38151 RVA: 0x001C0400 File Offset: 0x001BE800
	private void _updateInfo()
	{
		for (int i = 0; i < this.infos.Length; i++)
		{
			this._updateInfoByIdx(i);
		}
	}

	// Token: 0x04004BB0 RID: 19376
	public ComDungeonScoreInfo[] infos;

	// Token: 0x04004BB1 RID: 19377
	public Image mDungeonScore;

	// Token: 0x04004BB2 RID: 19378
	public Sprite[] mScoreList;

	// Token: 0x04004BB3 RID: 19379
	public GameObject mSuccessRoot;

	// Token: 0x04004BB4 RID: 19380
	public GameObject mSuccessScore;

	// Token: 0x04004BB5 RID: 19381
	public GameObject mSuccessEffect;

	// Token: 0x04004BB6 RID: 19382
	public GameObject mFailRoot;

	// Token: 0x04004BB7 RID: 19383
	public Text mScoreDesText;

	// Token: 0x04004BB8 RID: 19384
	public Text mDiffDesText;

	// Token: 0x04004BB9 RID: 19385
	public ComExpBar mExpBar;

	// Token: 0x04004BBA RID: 19386
	public ComCommonBind mScoreBind;
}
