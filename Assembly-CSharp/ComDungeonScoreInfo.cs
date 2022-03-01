using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ED8 RID: 3800
public class ComDungeonScoreInfo : MonoBehaviour
{
	// Token: 0x06009554 RID: 38228 RVA: 0x001C29E4 File Offset: 0x001C0DE4
	public void Init()
	{
		if (this.mScoreType == ComDungeonScoreInfo.eScoreType.StandardDamage || this.mScoreType == ComDungeonScoreInfo.eScoreType.DamageNumber)
		{
			if (this.mNormalInfo != null)
			{
				for (int i = 0; i < this.mNormalInfo.Length; i++)
				{
					if (this.mNormalInfo[i] != null)
					{
						this.mNormalInfo[i].CustomActive(false);
					}
				}
			}
			if (this.mGuildeInfo != null)
			{
				for (int j = 0; j < this.mGuildeInfo.Length; j++)
				{
					if (this.mGuildeInfo[j] != null)
					{
						this.mGuildeInfo[j].CustomActive(true);
					}
				}
			}
			this.mDamageDesc = null;
			if (this.mScoreType == ComDungeonScoreInfo.eScoreType.StandardDamage && this.mGuildeInfo.Length > 1 && this.mGuildeInfo[1] != null)
			{
				this.mDamageDesc = this.mGuildeInfo[1].GetComponent<Text>();
			}
			if (this.mComTime != null)
			{
				this.mComTime.enabled = false;
			}
		}
		else
		{
			if (this.mNormalInfo != null)
			{
				for (int k = 0; k < this.mNormalInfo.Length; k++)
				{
					if (this.mNormalInfo[k] != null)
					{
						this.mNormalInfo[k].CustomActive(true);
					}
				}
			}
			if (this.mGuildeInfo != null)
			{
				for (int l = 0; l < this.mGuildeInfo.Length; l++)
				{
					if (this.mGuildeInfo[l] != null)
					{
						this.mGuildeInfo[l].CustomActive(false);
					}
				}
			}
			if (this.mComTime != null)
			{
				this.mComTime.enabled = true;
			}
		}
		this.SetScore(this.mMaxScore, this.mMaxScore);
		if (null != this.mWord)
		{
			this.mWord.text = string.Empty;
		}
	}

	// Token: 0x06009555 RID: 38229 RVA: 0x001C2BD6 File Offset: 0x001C0FD6
	public void SetTimeLimiteCallback(ComDungeonScoreInfo.TimeLimitCallback cb)
	{
		this.mTimeLimitCallback = cb;
	}

	// Token: 0x06009556 RID: 38230 RVA: 0x001C2BDF File Offset: 0x001C0FDF
	public void SetCallback(ComDungeonScoreInfo.ScoreInfoCallback cb)
	{
		this.mCallback = cb;
	}

	// Token: 0x06009557 RID: 38231 RVA: 0x001C2BE8 File Offset: 0x001C0FE8
	public void SetScoreCallback(ComDungeonScoreInfo.ScoreInfoScoreCallback cb)
	{
		this.mCallScoreback = cb;
	}

	// Token: 0x06009558 RID: 38232 RVA: 0x001C2BF4 File Offset: 0x001C0FF4
	private void SetScore(int score, int maxScore)
	{
		this.mCurScore = score;
		this.mMaxScore = maxScore;
		this.mMaxScore = this._getMaxScore();
		int num = this.mScore.Length;
		this.mCurScore %= this.mMaxScore + 1;
		if (this.mCurScore == this.mMaxScore)
		{
			this.mScoreImage.sprite = this.mScore[num - 1];
		}
		else if (this.mCurScore == 0)
		{
			this.mScoreImage.sprite = this.mScore[0];
		}
		else if (this.mCurScore < this.mMaxScore)
		{
			this.mScoreImage.sprite = this.mScore[this.mCurScore];
		}
	}

	// Token: 0x06009559 RID: 38233 RVA: 0x001C2CB0 File Offset: 0x001C10B0
	private int _getMaxScore()
	{
		int dungeonId = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId;
		DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ComDungeonScoreInfo.eScoreType eScoreType = this.mScoreType;
			if (eScoreType == ComDungeonScoreInfo.eScoreType.FightTime)
			{
				return tableItem.TimeSplitArg.eValues.everyValues.Count - 1;
			}
			if (eScoreType == ComDungeonScoreInfo.eScoreType.HitCount)
			{
				return tableItem.HitSplitArg.eValues.everyValues.Count - 1;
			}
			if (eScoreType == ComDungeonScoreInfo.eScoreType.ReborCount)
			{
				return tableItem.RebornSplitArg.eValues.everyValues.Count - 1;
			}
		}
		return 2;
	}

	// Token: 0x0600955A RID: 38234 RVA: 0x001C2D54 File Offset: 0x001C1154
	private int _getTopScore()
	{
		int dungeonId = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId;
		DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ComDungeonScoreInfo.eScoreType eScoreType = this.mScoreType;
			if (eScoreType == ComDungeonScoreInfo.eScoreType.FightTime)
			{
				return TableManager.GetValueFromUnionCell(tableItem.TimeSplitArg, tableItem.TimeSplitArg.eValues.everyValues.Count - 1, true);
			}
			if (eScoreType == ComDungeonScoreInfo.eScoreType.HitCount)
			{
				return TableManager.GetValueFromUnionCell(tableItem.HitSplitArg, tableItem.HitSplitArg.eValues.everyValues.Count - 1, true);
			}
			if (eScoreType == ComDungeonScoreInfo.eScoreType.ReborCount)
			{
				return TableManager.GetValueFromUnionCell(tableItem.RebornSplitArg, tableItem.RebornSplitArg.eValues.everyValues.Count - 1, true);
			}
		}
		return -1;
	}

	// Token: 0x0600955B RID: 38235 RVA: 0x001C2E1C File Offset: 0x001C121C
	private void _updateInfos()
	{
		int num = this._getTopScore();
		bool flag = false;
		int num2 = 0;
		if (this.mCallback != null)
		{
			num2 = this.mCallback();
		}
		switch (this.mScoreType)
		{
		case ComDungeonScoreInfo.eScoreType.HitCount:
			this.mLimitText.text = num.ToString();
			flag = (num > num2);
			break;
		case ComDungeonScoreInfo.eScoreType.FightTime:
			this.mComLimitTime.SetTime(num * 1000);
			flag = (num * 1000 > num2);
			break;
		case ComDungeonScoreInfo.eScoreType.ReborCount:
			this.mLimitText.text = num.ToString();
			flag = (num > num2);
			break;
		case ComDungeonScoreInfo.eScoreType.StandardDamage:
			if (this.mDamageDesc != null)
			{
				this.mDamageDesc.text = this.scoreStandard.ToString();
			}
			flag = (this.curScore >= this.scoreLevel);
			this.SetScore(this.curScore, this.scoreLevel);
			break;
		}
		if (null != this.mBind)
		{
			GameObject gameObject = this.mBind.GetGameObject("successRoot");
			if (null != gameObject)
			{
				gameObject.SetActive(flag);
			}
			GameObject gameObject2 = this.mBind.GetGameObject("failRoot");
			if (null != gameObject2)
			{
				gameObject2.SetActive(!flag);
			}
			if (flag)
			{
				GameObject prefabInstance = this.mBind.GetPrefabInstance("effect_dacheng");
				Utility.AttachTo(prefabInstance, this.mSuccesFail.gameObject, false);
			}
		}
	}

	// Token: 0x0600955C RID: 38236 RVA: 0x001C2FC0 File Offset: 0x001C13C0
	public void OnCountDownStart()
	{
		if (this.mComTime != null && this.mComTime.mCurrentText != null)
		{
			this.mComTime.mCurrentText.CustomActive(false);
		}
	}

	// Token: 0x0600955D RID: 38237 RVA: 0x001C2FFC File Offset: 0x001C13FC
	public void UpdateInfo()
	{
		this._updateInfos();
		if (this.mScoreType == ComDungeonScoreInfo.eScoreType.StandardDamage || this.mScoreType == ComDungeonScoreInfo.eScoreType.DamageNumber)
		{
			return;
		}
		if (this.mCallback != null)
		{
			try
			{
				int time = this.mCallback();
				if (this.mType == ComDungeonScoreInfo.eType.eValue)
				{
					this.mWord.text = time.ToString();
				}
				else if (this.mType == ComDungeonScoreInfo.eType.eTime)
				{
					if (this.mTimeLimitCallback != null)
					{
						try
						{
							this.mComTime.mTimeInLimit = this.mTimeLimitCallback() * 1000;
						}
						catch
						{
							this.mComTime.mTimeInLimit = int.MaxValue;
						}
					}
					this.mComTime.SetTime(time);
				}
			}
			catch
			{
			}
		}
		if (this.mCallScoreback != null)
		{
			try
			{
				int score = this.mCallScoreback();
				this.SetScore(score, this.mMaxScore);
			}
			catch
			{
			}
		}
	}

	// Token: 0x04004C35 RID: 19509
	public ComDungeonScoreInfo.eScoreType mScoreType;

	// Token: 0x04004C36 RID: 19510
	public Image mSuccesFail;

	// Token: 0x04004C37 RID: 19511
	public Text mLimitText;

	// Token: 0x04004C38 RID: 19512
	public ComTime mComLimitTime;

	// Token: 0x04004C39 RID: 19513
	public GameObject[] mNormalInfo;

	// Token: 0x04004C3A RID: 19514
	public GameObject[] mGuildeInfo;

	// Token: 0x04004C3B RID: 19515
	public ComCommonBind mBind;

	// Token: 0x04004C3C RID: 19516
	public Sprite[] mScore;

	// Token: 0x04004C3D RID: 19517
	public int mCurScore;

	// Token: 0x04004C3E RID: 19518
	public int mMaxScore = 2;

	// Token: 0x04004C3F RID: 19519
	public Image mScoreImage;

	// Token: 0x04004C40 RID: 19520
	public Text mWord;

	// Token: 0x04004C41 RID: 19521
	public ComDungeonScoreInfo.eType mType = ComDungeonScoreInfo.eType.eValue;

	// Token: 0x04004C42 RID: 19522
	public ComTime mComTime;

	// Token: 0x04004C43 RID: 19523
	public int scoreStandard;

	// Token: 0x04004C44 RID: 19524
	public int curScore;

	// Token: 0x04004C45 RID: 19525
	public int scoreLevel;

	// Token: 0x04004C46 RID: 19526
	public Text mDamageDesc;

	// Token: 0x04004C47 RID: 19527
	private ComDungeonScoreInfo.ScoreInfoCallback mCallback;

	// Token: 0x04004C48 RID: 19528
	private ComDungeonScoreInfo.ScoreInfoScoreCallback mCallScoreback;

	// Token: 0x04004C49 RID: 19529
	private ComDungeonScoreInfo.TimeLimitCallback mTimeLimitCallback;

	// Token: 0x04004C4A RID: 19530
	private int mTime;

	// Token: 0x02000ED9 RID: 3801
	public enum eType
	{
		// Token: 0x04004C4C RID: 19532
		eTime,
		// Token: 0x04004C4D RID: 19533
		eValue
	}

	// Token: 0x02000EDA RID: 3802
	public enum eScoreType
	{
		// Token: 0x04004C4F RID: 19535
		None,
		// Token: 0x04004C50 RID: 19536
		HitCount,
		// Token: 0x04004C51 RID: 19537
		FightTime,
		// Token: 0x04004C52 RID: 19538
		ReborCount,
		// Token: 0x04004C53 RID: 19539
		StandardDamage,
		// Token: 0x04004C54 RID: 19540
		DamageNumber
	}

	// Token: 0x02000EDB RID: 3803
	// (Invoke) Token: 0x0600955F RID: 38239
	public delegate int TimeLimitCallback();

	// Token: 0x02000EDC RID: 3804
	// (Invoke) Token: 0x06009563 RID: 38243
	public delegate int ScoreInfoCallback();

	// Token: 0x02000EDD RID: 3805
	// (Invoke) Token: 0x06009567 RID: 38247
	public delegate int ScoreInfoScoreCallback();
}
