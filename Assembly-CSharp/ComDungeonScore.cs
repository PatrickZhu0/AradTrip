using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ED5 RID: 3797
[ExecuteInEditMode]
public class ComDungeonScore : ComBaseComponet
{
	// Token: 0x06009542 RID: 38210 RVA: 0x001C2578 File Offset: 0x001C0978
	public new void Init()
	{
		for (int i = 0; i < this.infos.Length; i++)
		{
			this.infos[i].Init();
		}
		this._setScore(DungeonScore.SSS);
		this.mCountCnt = this.mCnt;
		this.mState = ComDungeonScore.eState.Close;
		if (this.mState == ComDungeonScore.eState.Close)
		{
			this.mRoot.transform.localPosition = new Vector3(172f, 0f, 0f);
		}
		else
		{
			this.mRoot.transform.localPosition = new Vector3(-172f, 0f, 0f);
		}
	}

	// Token: 0x06009543 RID: 38211 RVA: 0x001C2620 File Offset: 0x001C0A20
	public void UpdateRoot()
	{
		if (this.mState == ComDungeonScore.eState.Close)
		{
			this.mState = ComDungeonScore.eState.Open;
			this._updateInfos();
		}
		else
		{
			this.mState = ComDungeonScore.eState.Close;
		}
		if (this.mCountCnt > 0)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ClientBattleMainFadeInFadeOut, this.mState == ComDungeonScore.eState.Open, null, null, null);
		}
		this._setRootState(this.mState == ComDungeonScore.eState.Open);
		if (this.onFadeChanged != null)
		{
			this.onFadeChanged(this.mState);
		}
	}

	// Token: 0x06009544 RID: 38212 RVA: 0x001C26A8 File Offset: 0x001C0AA8
	private void _setRootState(bool isOpen)
	{
		if (isOpen)
		{
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.mRoot.transform.localPosition, delegate(Vector3 r)
			{
				this.mRoot.transform.localPosition = r;
			}, new Vector3(-172f, 0f, 0f), this.mTime), 6);
		}
		else
		{
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.mRoot.transform.localPosition, delegate(Vector3 r)
			{
				this.mRoot.transform.localPosition = r;
			}, new Vector3(172f, 0f, 0f), this.mTime), 6);
		}
	}

	// Token: 0x06009545 RID: 38213 RVA: 0x001C273C File Offset: 0x001C0B3C
	public void SetScore(DungeonScore score)
	{
		this._setScore(score);
		if (this.mState == ComDungeonScore.eState.Open)
		{
			this._updateInfos();
		}
	}

	// Token: 0x06009546 RID: 38214 RVA: 0x001C2758 File Offset: 0x001C0B58
	protected override void _bindExUI()
	{
		this.mScoreImageRoot0 = this.mBind.GetGameObject("scoreImageRoot0");
		this.mScoreImageRoot1 = this.mBind.GetGameObject("scoreImageRoot1");
		this.mScoreImageRoot2 = this.mBind.GetGameObject("scoreImageRoot2");
		this.mScoreImage0 = this.mBind.GetCom<Image>("scoreImage0");
		this.mScoreImage1 = this.mBind.GetCom<Image>("scoreImage1");
		this.mScoreImage2 = this.mBind.GetCom<Image>("scoreImage2");
	}

	// Token: 0x06009547 RID: 38215 RVA: 0x001C27E9 File Offset: 0x001C0BE9
	protected override void _unbindExUI()
	{
		this.mScoreImageRoot0 = null;
		this.mScoreImageRoot1 = null;
		this.mScoreImageRoot2 = null;
		this.mScoreImage0 = null;
		this.mScoreImage1 = null;
		this.mScoreImage2 = null;
	}

	// Token: 0x06009548 RID: 38216 RVA: 0x001C2818 File Offset: 0x001C0C18
	private void _setScore(DungeonScore score)
	{
		if (this.mRealScore != score)
		{
			this.mRealScore = score;
			if (!base.isInited)
			{
				return;
			}
			this.mScoreImageRoot0.CustomActive(false);
			this.mScoreImageRoot1.CustomActive(false);
			this.mScoreImageRoot2.CustomActive(false);
			this.mBind.GetSprite("s", ref this.mScoreImage0);
			this.mBind.GetSprite("s", ref this.mScoreImage1);
			this.mBind.GetSprite("s", ref this.mScoreImage2);
			switch (score)
			{
			case DungeonScore.C:
			case DungeonScore.B:
			case DungeonScore.A:
				this.mScoreImageRoot2.CustomActive(true);
				this.mBind.GetSprite("a", ref this.mScoreImage2);
				break;
			case DungeonScore.S:
				this.mScoreImageRoot2.CustomActive(true);
				break;
			case DungeonScore.SS:
				this.mScoreImageRoot0.CustomActive(true);
				this.mScoreImageRoot1.CustomActive(true);
				break;
			case DungeonScore.SSS:
				this.mScoreImageRoot0.CustomActive(true);
				this.mScoreImageRoot1.CustomActive(true);
				this.mScoreImageRoot2.CustomActive(true);
				break;
			}
		}
	}

	// Token: 0x06009549 RID: 38217 RVA: 0x001C294C File Offset: 0x001C0D4C
	private void _updateInfos()
	{
		for (int i = 0; i < this.infos.Length; i++)
		{
			this.infos[i].UpdateInfo();
		}
	}

	// Token: 0x0600954A RID: 38218 RVA: 0x001C297F File Offset: 0x001C0D7F
	private void Update()
	{
	}

	// Token: 0x04004C20 RID: 19488
	public float mTime = 0.5f;

	// Token: 0x04004C21 RID: 19489
	public float mDelay = 2f;

	// Token: 0x04004C22 RID: 19490
	public int mCnt = 2;

	// Token: 0x04004C23 RID: 19491
	private int mCountCnt = 2;

	// Token: 0x04004C24 RID: 19492
	public ComDungeonScoreInfo[] infos;

	// Token: 0x04004C25 RID: 19493
	public Sprite[] mImages;

	// Token: 0x04004C26 RID: 19494
	public DungeonScore mRealScore;

	// Token: 0x04004C27 RID: 19495
	public Image mScoreImage;

	// Token: 0x04004C28 RID: 19496
	public GameObject mRoot;

	// Token: 0x04004C29 RID: 19497
	public ComDungeonScore.eState mState = ComDungeonScore.eState.Open;

	// Token: 0x04004C2A RID: 19498
	public ComDungeonScore.OnFadeChanged onFadeChanged;

	// Token: 0x04004C2B RID: 19499
	private GameObject mScoreImageRoot0;

	// Token: 0x04004C2C RID: 19500
	private GameObject mScoreImageRoot1;

	// Token: 0x04004C2D RID: 19501
	private GameObject mScoreImageRoot2;

	// Token: 0x04004C2E RID: 19502
	private Image mScoreImage0;

	// Token: 0x04004C2F RID: 19503
	private Image mScoreImage1;

	// Token: 0x04004C30 RID: 19504
	private Image mScoreImage2;

	// Token: 0x04004C31 RID: 19505
	private float mTickTime;

	// Token: 0x02000ED6 RID: 3798
	public enum eState
	{
		// Token: 0x04004C33 RID: 19507
		Close,
		// Token: 0x04004C34 RID: 19508
		Open
	}

	// Token: 0x02000ED7 RID: 3799
	// (Invoke) Token: 0x06009550 RID: 38224
	public delegate void OnFadeChanged(ComDungeonScore.eState state);
}
