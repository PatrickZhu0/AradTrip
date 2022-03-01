using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010E6 RID: 4326
	public class TeamDungeonBattleFrame : ClientFrame
	{
		// Token: 0x0600A3EB RID: 41963 RVA: 0x0021A1CC File Offset: 0x002185CC
		protected override void _bindExUI()
		{
			this.mLiuxingqipao = this.mBind.GetGameObject("Liuxingqipao");
			this.mSlider_LiuxingComplete = this.mBind.GetCom<Slider>("Slider_LiuxingComplete");
			this.mText_CompleteNum = this.mBind.GetCom<Text>("Text_CompleteNum");
			this.mImage_LiuXingTimeReduce = this.mBind.GetCom<Image>("Image_LiuXingTimeReduce");
			this.mImage_LiuxingAttackCD = this.mBind.GetCom<Image>("Image_LiuxingAttackCD");
			this.mText_CDTime = this.mBind.GetCom<Text>("Text_CDTime");
			this.mBtn_Attack = this.mBind.GetCom<ComButtonEx>("Btn_Attack");
			if (null != this.mBtn_Attack)
			{
				this.mBtn_Attack.onClick.AddListener(new UnityAction(this._onBtn_AttackButtonClick));
			}
			this.mBtn_AttackEffect = this.mBind.GetGameObject("Btn_AttackEffect");
			this.mXianshijisha = this.mBind.GetGameObject("Xianshijisha");
			this.mText_KillCount = this.mBind.GetCom<Text>("Text_KillCount");
			this.mText_KillTime = this.mBind.GetCom<Text>("Text_KillTime");
			this.mTeamBossEnergyBar = this.mBind.GetGameObject("TeamBossEnergyBar");
			this.mEnergyValue = this.mBind.GetCom<Slider>("EnergyValue");
			this.mEnergyStat = this.mBind.GetGameObject("energyStat");
			this.mEnergyFull = this.mBind.GetGameObject("energyFull");
			this.mPurpleEffect = this.mBind.GetGameObject("purpleEffect");
			this.mBlueEffect = this.mBind.GetGameObject("blueEffect");
			this.mYellowEffect = this.mBind.GetGameObject("yellowEffect");
			this.mFullEffect = this.mBind.GetGameObject("fullEffect");
			this.mKillCompleteGO = this.mBind.GetGameObject("KillCompleteGO");
			this.mKillTimeGO = this.mBind.GetGameObject("KillTimeGO");
			this.mTunshiGo = this.mBind.GetCom<RectTransform>("TunshiGo");
			this.mTunshiText = this.mBind.GetCom<Text>("TunshiText");
			this.mPointerTransform = this.mBind.GetCom<RectTransform>("Pointer");
			this.mFogPercentGO = this.mBind.GetGameObject("FogPercentBar");
			this.mFogMaxEffect = this.mBind.GetGameObject("FogMaxEffect");
		}

		// Token: 0x0600A3EC RID: 41964 RVA: 0x0021A444 File Offset: 0x00218844
		protected override void _unbindExUI()
		{
			this.mLiuxingqipao = null;
			this.mSlider_LiuxingComplete = null;
			this.mText_CompleteNum = null;
			this.mImage_LiuXingTimeReduce = null;
			this.mImage_LiuxingAttackCD = null;
			this.mText_CDTime = null;
			if (null != this.mBtn_Attack)
			{
				this.mBtn_Attack.onClick.RemoveListener(new UnityAction(this._onBtn_AttackButtonClick));
			}
			this.mBtn_Attack = null;
			this.mBtn_AttackEffect = null;
			this.mXianshijisha = null;
			this.mText_KillCount = null;
			this.mText_KillTime = null;
			this.mTeamBossEnergyBar = null;
			this.mEnergyValue = null;
			this.mEnergyStat = null;
			this.mEnergyFull = null;
			this.mPurpleEffect = null;
			this.mBlueEffect = null;
			this.mYellowEffect = null;
			this.mFullEffect = null;
			this.mKillCompleteGO = null;
			this.mKillTimeGO = null;
			this.mTunshiGo = null;
			this.mTunshiText = null;
			this.mPointerTransform = null;
			this.mFogPercentGO = null;
			this.mFogMaxEffect = null;
		}

		// Token: 0x0600A3ED RID: 41965 RVA: 0x0021A534 File Offset: 0x00218934
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/TeamDungeonBattleFrame";
		}

		// Token: 0x0600A3EE RID: 41966 RVA: 0x0021A53B File Offset: 0x0021893B
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mLastBossEnergyLevel = 0;
		}

		// Token: 0x0600A3EF RID: 41967 RVA: 0x0021A54A File Offset: 0x0021894A
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A3F0 RID: 41968 RVA: 0x0021A54D File Offset: 0x0021894D
		protected override void _OnUpdate(float timeElapsed)
		{
			base._OnUpdate(timeElapsed);
			this.UpdateLiuXingReduceBar(timeElapsed);
			this.UpdateLiuXingAttackCD(timeElapsed);
		}

		// Token: 0x0600A3F1 RID: 41969 RVA: 0x0021A564 File Offset: 0x00218964
		public void SetNoTimeLimitKillNum(int curNum, int totalNum)
		{
			if (this.mXianshijisha != null && !this.mXianshijisha.activeSelf)
			{
				this.mXianshijisha.CustomActive(true);
			}
			if (this.mKillTimeGO != null && this.mKillTimeGO.activeSelf)
			{
				this.mKillTimeGO.SetActive(false);
			}
			if (this.mKillCompleteGO != null && !this.mKillCompleteGO.activeSelf)
			{
				this.mKillCompleteGO.SetActive(true);
			}
			if (this.mText_KillCount != null)
			{
				this.mText_KillCount.text = string.Format("{0}/{1}", curNum, totalNum);
			}
		}

		// Token: 0x0600A3F2 RID: 41970 RVA: 0x0021A62A File Offset: 0x00218A2A
		public void SetKillNum(int curNum, int totalNum)
		{
			this.mText_KillCount.text = string.Format("{0}/{1}", curNum, totalNum);
			this.mXianshijisha.CustomActive(true);
		}

		// Token: 0x0600A3F3 RID: 41971 RVA: 0x0021A65C File Offset: 0x00218A5C
		public void SetKillTime(int remainTime)
		{
			float num = (float)(remainTime / 1000);
			int num2 = (int)num / 3600;
			int num3 = ((int)num - num2 * 3600) / 60;
			int num4 = (int)num - num2 * 3600 - num3 * 60;
			if (this.mText_KillTime != null)
			{
				this.mText_KillTime.text = string.Format("{0:D2}:{1:D2}", num3, num4);
			}
			if (this.mXianshijisha != null)
			{
				this.mXianshijisha.CustomActive(true);
			}
		}

		// Token: 0x0600A3F4 RID: 41972 RVA: 0x0021A6E8 File Offset: 0x00218AE8
		public void InitLiuXingData(int totalTime)
		{
			this.curTotalTime = (float)totalTime;
			this.curTime = (float)totalTime;
			this.mSlider_LiuxingComplete.value = 1f;
			this.mLiuxingqipao.CustomActive(true);
		}

		// Token: 0x0600A3F5 RID: 41973 RVA: 0x0021A716 File Offset: 0x00218B16
		public void RefreshLiuXingTime(int time)
		{
			this.curTime -= (float)time;
			this.mSlider_LiuxingComplete.value = this.curTime / this.curTotalTime;
			this.mLiuxingqipao.CustomActive(true);
		}

		// Token: 0x0600A3F6 RID: 41974 RVA: 0x0021A74B File Offset: 0x00218B4B
		public void AttackFial(int time)
		{
			this.curDelayTime = this.delayTime;
			this.reduceTime += (float)time;
			this.RefreshLiuXingTime(time);
		}

		// Token: 0x0600A3F7 RID: 41975 RVA: 0x0021A76F File Offset: 0x00218B6F
		public void SetLiuXingCompleteNum(int curNum, int TotalNum)
		{
			this.mText_CompleteNum.text = string.Format("{0}/{1}", curNum, TotalNum);
			this.mLiuxingqipao.CustomActive(true);
		}

		// Token: 0x0600A3F8 RID: 41976 RVA: 0x0021A79E File Offset: 0x00218B9E
		public void SetLiuXingAttackBtn(Mechanism2064.Del del)
		{
			this.liuXingAttackDel = del;
			this.curCdTime = 2f;
			this.mBtn_Attack.CustomActive(true);
			this.mLiuxingqipao.CustomActive(true);
		}

		// Token: 0x0600A3F9 RID: 41977 RVA: 0x0021A7CC File Offset: 0x00218BCC
		private void _onBtn_AttackButtonClick()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_dianjifankui01", true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, this.mBtn_AttackEffect, false);
			}
			this.curCdTime = this.cdTime;
			this.mBtn_AttackEffect.CustomActive(true);
			if (this.liuXingAttackDel != null)
			{
				this.liuXingAttackDel();
			}
		}

		// Token: 0x0600A3FA RID: 41978 RVA: 0x0021A834 File Offset: 0x00218C34
		public void PlayAttackResultEffect(bool isSuccess)
		{
			string path = "Effects/UI/Prefab/EffUI_tuanben/Prefab/EffUI_tuanben_wanchengdu_zengjia";
			if (!isSuccess)
			{
				path = "Effects/UI/Prefab/EffUI_tuanben/Prefab/EffUI_tuanben_wanchengdu_jianshao";
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, this.mSlider_LiuxingComplete.gameObject, false);
				gameObject.transform.localPosition = new Vector3(0f, -6f, 0f);
			}
		}

		// Token: 0x0600A3FB RID: 41979 RVA: 0x0021A8A0 File Offset: 0x00218CA0
		private void UpdateLiuXingReduceBar(float timeDeleta)
		{
			if (this.reduceTime <= 0f)
			{
				this.mImage_LiuXingTimeReduce.fillAmount = this.curTime / this.curTotalTime;
				return;
			}
			if (this.curDelayTime <= 0f)
			{
				float num = timeDeleta * 10000f;
				this.reduceTime -= num;
				this.mImage_LiuXingTimeReduce.fillAmount -= num / this.curTotalTime;
			}
			else
			{
				this.curDelayTime -= timeDeleta;
			}
		}

		// Token: 0x0600A3FC RID: 41980 RVA: 0x0021A92C File Offset: 0x00218D2C
		private void UpdateLiuXingAttackCD(float deltaTime)
		{
			if (this.curCdTime <= 0f)
			{
				this.mImage_LiuxingAttackCD.CustomActive(false);
				this.mText_CDTime.CustomActive(false);
				this.mBtn_Attack.interactable = true;
			}
			else
			{
				this.curCdTime -= deltaTime;
				this.mImage_LiuxingAttackCD.fillAmount = this.curCdTime / this.cdTime;
				this.mText_CDTime.text = this.curCdTime.ToString("0.0");
				this.mImage_LiuxingAttackCD.CustomActive(true);
				this.mText_CDTime.CustomActive(true);
				this.mBtn_Attack.interactable = false;
			}
		}

		// Token: 0x0600A3FD RID: 41981 RVA: 0x0021A9D8 File Offset: 0x00218DD8
		private void RefreshBossEnergyUIEffect(int level)
		{
			if (level == 0)
			{
				if (this.mPurpleEffect != null)
				{
					this.mPurpleEffect.CustomActive(false);
				}
				if (this.mYellowEffect != null)
				{
					this.mYellowEffect.CustomActive(false);
				}
				if (this.mBlueEffect != null)
				{
					this.mBlueEffect.CustomActive(false);
				}
			}
			else if (level == 1)
			{
				if (this.mPurpleEffect != null)
				{
					this.mPurpleEffect.CustomActive(false);
				}
				if (this.mYellowEffect != null)
				{
					this.mYellowEffect.CustomActive(false);
				}
				if (this.mBlueEffect != null)
				{
					this.mBlueEffect.CustomActive(true);
				}
			}
			else if (level == 2)
			{
				if (this.mPurpleEffect != null)
				{
					this.mPurpleEffect.CustomActive(false);
				}
				if (this.mYellowEffect != null)
				{
					this.mYellowEffect.CustomActive(true);
				}
				if (this.mBlueEffect != null)
				{
					this.mBlueEffect.CustomActive(false);
				}
			}
			else if (level == 3)
			{
				if (this.mPurpleEffect != null)
				{
					this.mPurpleEffect.CustomActive(true);
				}
				if (this.mYellowEffect != null)
				{
					this.mYellowEffect.CustomActive(false);
				}
				if (this.mBlueEffect != null)
				{
					this.mBlueEffect.CustomActive(false);
				}
			}
		}

		// Token: 0x0600A3FE RID: 41982 RVA: 0x0021AB6C File Offset: 0x00218F6C
		public void SetBossEnergyBarActive(bool isActive)
		{
			if (this.mTeamBossEnergyBar != null)
			{
				this.mTeamBossEnergyBar.CustomActive(isActive);
			}
			if (this.mEnergyFull != null)
			{
				this.mEnergyFull.CustomActive(!isActive);
			}
			if (this.mEnergyStat != null)
			{
				this.mEnergyStat.CustomActive(isActive);
			}
			if (isActive)
			{
				this.RefreshBossEnergyUIEffect(this.mLastBossEnergyLevel);
			}
		}

		// Token: 0x0600A3FF RID: 41983 RVA: 0x0021ABE8 File Offset: 0x00218FE8
		public void SetBossEnergyValue(float value, int level)
		{
			if (value <= 0f || value > 99f)
			{
				if (this.mEnergyFull != null && !this.mEnergyFull.activeInHierarchy)
				{
					this.mEnergyFull.CustomActive(true);
					if (this.mFullEffect != null)
					{
						this.mFullEffect.CustomActive(true);
					}
					this.mLastBossEnergyLevel = 0;
					this.RefreshBossEnergyUIEffect(this.mLastBossEnergyLevel);
				}
				if (this.mEnergyStat != null && this.mEnergyStat.activeInHierarchy)
				{
					this.mEnergyStat.CustomActive(false);
				}
			}
			else
			{
				if (this.mEnergyFull != null && this.mEnergyFull.activeInHierarchy)
				{
					this.mEnergyFull.CustomActive(false);
					if (this.mFullEffect != null)
					{
						this.mFullEffect.CustomActive(false);
					}
				}
				if (this.mEnergyStat != null)
				{
					if (!this.mEnergyStat.activeInHierarchy)
					{
						this.mEnergyStat.CustomActive(true);
					}
					if (this.mEnergyValue != null)
					{
						this.mEnergyValue.value = value;
					}
				}
				if (level != this.mLastBossEnergyLevel)
				{
					this.RefreshBossEnergyUIEffect(level);
					this.mLastBossEnergyLevel = level;
				}
			}
		}

		// Token: 0x0600A400 RID: 41984 RVA: 0x0021AD48 File Offset: 0x00219148
		public void ShowCompelteCount(int curCount, int totalCount)
		{
			this.mTunshiGo.gameObject.CustomActive(true);
			this.mTunshiText.text = string.Format("{0}/{1}", curCount, totalCount);
		}

		// Token: 0x0600A401 RID: 41985 RVA: 0x0021AD7C File Offset: 0x0021917C
		public void SetFogActive(bool _flag)
		{
			if (null != this.mFogPercentGO)
			{
				this.mFogPercentGO.CustomActive(_flag);
			}
		}

		// Token: 0x0600A402 RID: 41986 RVA: 0x0021AD9B File Offset: 0x0021919B
		public void SetFogEffectActive(bool _flag)
		{
			if (null != this.mFogMaxEffect)
			{
				this.mFogMaxEffect.CustomActive(_flag);
			}
		}

		// Token: 0x0600A403 RID: 41987 RVA: 0x0021ADBC File Offset: 0x002191BC
		public void SetFogPercent(int _value, int _maxValue)
		{
			if (null == this.mPointerTransform)
			{
				return;
			}
			int num = _value * 180 / _maxValue - 90;
			ShortcutExtensions.DORotate(this.mPointerTransform.transform, new Vector3(0f, 0f, (float)(-(float)num)), 0.5f, 0);
		}

		// Token: 0x04005B79 RID: 23417
		private GameObject mLiuxingqipao;

		// Token: 0x04005B7A RID: 23418
		private Slider mSlider_LiuxingComplete;

		// Token: 0x04005B7B RID: 23419
		private Text mText_CompleteNum;

		// Token: 0x04005B7C RID: 23420
		private Image mImage_LiuXingTimeReduce;

		// Token: 0x04005B7D RID: 23421
		private Image mImage_LiuxingAttackCD;

		// Token: 0x04005B7E RID: 23422
		private Text mText_CDTime;

		// Token: 0x04005B7F RID: 23423
		private ComButtonEx mBtn_Attack;

		// Token: 0x04005B80 RID: 23424
		private GameObject mBtn_AttackEffect;

		// Token: 0x04005B81 RID: 23425
		private GameObject mXianshijisha;

		// Token: 0x04005B82 RID: 23426
		private Text mText_KillCount;

		// Token: 0x04005B83 RID: 23427
		private Text mText_KillTime;

		// Token: 0x04005B84 RID: 23428
		private GameObject mTeamBossEnergyBar;

		// Token: 0x04005B85 RID: 23429
		private Slider mEnergyValue;

		// Token: 0x04005B86 RID: 23430
		private GameObject mEnergyStat;

		// Token: 0x04005B87 RID: 23431
		private GameObject mEnergyFull;

		// Token: 0x04005B88 RID: 23432
		private GameObject mPurpleEffect;

		// Token: 0x04005B89 RID: 23433
		private GameObject mBlueEffect;

		// Token: 0x04005B8A RID: 23434
		private GameObject mYellowEffect;

		// Token: 0x04005B8B RID: 23435
		private GameObject mFullEffect;

		// Token: 0x04005B8C RID: 23436
		private GameObject mKillCompleteGO;

		// Token: 0x04005B8D RID: 23437
		private GameObject mKillTimeGO;

		// Token: 0x04005B8E RID: 23438
		private RectTransform mTunshiGo;

		// Token: 0x04005B8F RID: 23439
		private Text mTunshiText;

		// Token: 0x04005B90 RID: 23440
		private RectTransform mPointerTransform;

		// Token: 0x04005B91 RID: 23441
		private GameObject mFogPercentGO;

		// Token: 0x04005B92 RID: 23442
		private GameObject mFogMaxEffect;

		// Token: 0x04005B93 RID: 23443
		private int mLastBossEnergyLevel;

		// Token: 0x04005B94 RID: 23444
		private Mechanism2064.Del liuXingAttackDel;

		// Token: 0x04005B95 RID: 23445
		private float curTotalTime;

		// Token: 0x04005B96 RID: 23446
		private float curTime;

		// Token: 0x04005B97 RID: 23447
		private float reduceTime;

		// Token: 0x04005B98 RID: 23448
		private float delayTime = 0.3f;

		// Token: 0x04005B99 RID: 23449
		private float curDelayTime;

		// Token: 0x04005B9A RID: 23450
		private float cdTime = 0.7f;

		// Token: 0x04005B9B RID: 23451
		private float curCdTime;
	}
}
