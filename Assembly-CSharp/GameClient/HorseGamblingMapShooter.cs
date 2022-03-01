using System;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001685 RID: 5765
	public class HorseGamblingMapShooter : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C59 RID: 7257
		// (get) Token: 0x0600E2A3 RID: 58019 RVA: 0x003A37CF File Offset: 0x003A1BCF
		// (set) Token: 0x0600E2A4 RID: 58020 RVA: 0x003A37D7 File Offset: 0x003A1BD7
		public HorseGamblingMapShooter.EPosition Position { get; set; }

		// Token: 0x17001C5A RID: 7258
		// (get) Token: 0x0600E2A5 RID: 58021 RVA: 0x003A37E0 File Offset: 0x003A1BE0
		public int Id
		{
			get
			{
				return this.mId;
			}
		}

		// Token: 0x17001C5B RID: 7259
		// (get) Token: 0x0600E2A6 RID: 58022 RVA: 0x003A37E8 File Offset: 0x003A1BE8
		// (set) Token: 0x0600E2A7 RID: 58023 RVA: 0x003A37F0 File Offset: 0x003A1BF0
		public int RandomId { get; private set; }

		// Token: 0x0600E2A8 RID: 58024 RVA: 0x003A37FC File Offset: 0x003A1BFC
		public void Init(bool isRight)
		{
			if (isRight)
			{
				Vector3 localScale = this.mRatePanel.transform.localScale;
				localScale.x = -Mathf.Abs(localScale.x);
				this.mRatePanel.transform.localScale = localScale;
				this.mTextName.alignment = 5;
				this.mTextName.transform.localScale = localScale;
				this.mTextWinOdds.alignment = 5;
				this.mTextWinOdds.transform.localScale = localScale;
			}
			else
			{
				Vector3 localScale2 = this.mRatePanel.transform.localScale;
				localScale2.x = Mathf.Abs(localScale2.x);
				this.mRatePanel.transform.localScale = localScale2;
				this.mTextName.transform.localScale = localScale2;
				this.mTextName.alignment = 3;
				this.mTextWinOdds.alignment = 3;
				this.mTextWinOdds.transform.localScale = localScale2;
			}
			this.mRatePanel.CustomActive(false);
		}

		// Token: 0x0600E2A9 RID: 58025 RVA: 0x003A3900 File Offset: 0x003A1D00
		public void SetData(IHorseGamblingMapShooterModel model, UnityAction<HorseGamblingMapShooter> onShooterClick, bool isRefresh = false, bool isRight = false)
		{
			if (model == null)
			{
				this.Dispose();
				return;
			}
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(model.Id, string.Empty, string.Empty);
			HorseGamblingShooterModel shooterModel = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterModel(model.Id);
			if (shooterModel == null)
			{
				return;
			}
			if (shooterModel.IsUnknown && DataManager<HorseGamblingDataManager>.GetInstance().State == BetHorsePhaseType.PHASE_TYPE_STAKE)
			{
				tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(0, string.Empty, string.Empty);
			}
			if (tableItem == null)
			{
				return;
			}
			string iconPath = tableItem.IconPath;
			if (!string.IsNullOrEmpty(iconPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, iconPath, true);
			}
			this.mImageIcon.CustomActive(true);
			this.UpdateOdds(model);
			this.ShowBattleResult(model);
			this.mTextName.SafeSetText(tableItem.Name);
			this.mOnClick = onShooterClick;
			this.mId = model.Id;
			this.mButton.SafeRemoveAllListener();
			this.mButton.SafeAddOnClickListener(new UnityAction(this.OnButtonClick));
			if (this.mIsShowRefreshEffect)
			{
				if (isRefresh)
				{
					this.mEffectRefresh.CustomActive(false);
					this.mEffectRefresh.CustomActive(true);
				}
				this.mIsShowRefreshEffect = false;
			}
		}

		// Token: 0x0600E2AA RID: 58026 RVA: 0x003A3A38 File Offset: 0x003A1E38
		public void ShowUnBattleData(IHorseGamblingMapShooterModel model, UnityAction<HorseGamblingMapShooter> onShooterClick)
		{
			if (model == null)
			{
				this.Dispose();
				return;
			}
			string shooterIconPath = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(model.Id);
			if (!string.IsNullOrEmpty(shooterIconPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, shooterIconPath, true);
			}
			this.mImageIcon.CustomActive(true);
			this.UpdateOdds(model);
			this.mImageResult.CustomActive(false);
			this.mImageDeath.CustomActive(false);
			this.mGray.enabled = false;
			this.mOnClick = onShooterClick;
			this.mId = model.Id;
			this.mButton.SafeRemoveAllListener();
			this.mButton.SafeAddOnClickListener(new UnityAction(this.OnButtonClick));
		}

		// Token: 0x0600E2AB RID: 58027 RVA: 0x003A3AE8 File Offset: 0x003A1EE8
		public void ShowChampion(UnityAction<HorseGamblingMapShooter> onShooterClick, int id)
		{
			this.mId = id;
			this.mImageIcon.CustomActive(true);
			string shooterIconPath = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(id);
			if (!string.IsNullOrEmpty(shooterIconPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, shooterIconPath, true);
			}
			this.mOnClick = onShooterClick;
			this.mButton.SafeRemoveAllListener();
			this.mButton.SafeAddOnClickListener(new UnityAction(this.OnButtonClick));
			this.mImageResult.CustomActive(false);
			this.mRatePanel.CustomActive(false);
			ETCImageLoader.LoadSprite(ref this.mImageResult, this.mChampionSprite, true);
		}

		// Token: 0x0600E2AC RID: 58028 RVA: 0x003A3B84 File Offset: 0x003A1F84
		public void ShowBattleResult(IHorseGamblingMapShooterModel model)
		{
			if (model == null)
			{
				return;
			}
			EHorseGamblingBattleResult battleState = model.BattleState;
			if (battleState != EHorseGamblingBattleResult.NotBattle)
			{
				if (battleState != EHorseGamblingBattleResult.Win)
				{
					if (battleState == EHorseGamblingBattleResult.Lose)
					{
						this.mImageResult.CustomActive(false);
						this.mImageDeath.CustomActive(true);
						this.mGray.enabled = true;
					}
				}
				else
				{
					this.mImageResult.CustomActive(true);
					ETCImageLoader.LoadSprite(ref this.mImageResult, this.mWinSprite, true);
					this.mImageDeath.CustomActive(false);
					this.mGray.enabled = false;
				}
			}
			else
			{
				this.mImageResult.CustomActive(false);
				this.mImageDeath.CustomActive(false);
				this.mGray.enabled = false;
			}
		}

		// Token: 0x0600E2AD RID: 58029 RVA: 0x003A3C48 File Offset: 0x003A2048
		public void UpdateOdds(IHorseGamblingMapShooterModel model)
		{
			this.mRatePanel.CustomActive(model.IsShowOdds);
			if (model.IsShowOdds)
			{
				float shooterOdds = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterOdds(model.Id);
				this.mTextWinOdds.SafeSetText(string.Format(TR.Value("horse_gambling_map_shooter_odd"), shooterOdds));
			}
		}

		// Token: 0x0600E2AE RID: 58030 RVA: 0x003A3CA4 File Offset: 0x003A20A4
		public void Reset()
		{
			this.mRatePanel.CustomActive(false);
			this.mImageResult.CustomActive(false);
			this.mImageDeath.CustomActive(false);
			ETCImageLoader.LoadSprite(ref this.mImageIcon, this.mShooterUnknownIconPath, true);
			this.mGray.enabled = false;
			this.mImageResult.CustomActive(false);
		}

		// Token: 0x0600E2AF RID: 58031 RVA: 0x003A3D00 File Offset: 0x003A2100
		public void RandomShooter()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BetHorseShooter>();
			if (table != null && table.Count > 0)
			{
				List<int> list = new List<int>(table.Keys);
				this.RandomId = list[Random.Range(0, list.Count - 1)];
				ETCImageLoader.LoadSprite(ref this.mImageIcon, ((BetHorseShooter)table[list[this.RandomId]]).IconPath, true);
			}
		}

		// Token: 0x0600E2B0 RID: 58032 RVA: 0x003A3D79 File Offset: 0x003A2179
		public void StopRamdom()
		{
			this.mEffectRefresh.CustomActive(false);
			this.mEffectRefresh.CustomActive(true);
		}

		// Token: 0x0600E2B1 RID: 58033 RVA: 0x003A3D93 File Offset: 0x003A2193
		public void SetSelected(bool value)
		{
			this.mEffectSelected.CustomActive(value);
			if (value)
			{
				this.mSelectTween.DORestart(false);
			}
		}

		// Token: 0x0600E2B2 RID: 58034 RVA: 0x003A3DB3 File Offset: 0x003A21B3
		private void OnButtonClick()
		{
			if (this.mOnClick != null)
			{
				this.mOnClick.Invoke(this);
			}
		}

		// Token: 0x0600E2B3 RID: 58035 RVA: 0x003A3DCC File Offset: 0x003A21CC
		public void Dispose()
		{
			this.mButton.SafeRemoveOnClickListener(new UnityAction(this.OnButtonClick));
		}

		// Token: 0x0400879D RID: 34717
		[SerializeField]
		private Image mImageIcon;

		// Token: 0x0400879E RID: 34718
		[SerializeField]
		private Text mTextWinOdds;

		// Token: 0x0400879F RID: 34719
		[SerializeField]
		private Text mTextName;

		// Token: 0x040087A0 RID: 34720
		[SerializeField]
		private Image mImageResult;

		// Token: 0x040087A1 RID: 34721
		[SerializeField]
		private Button mButton;

		// Token: 0x040087A2 RID: 34722
		[SerializeField]
		private UIGray mGray;

		// Token: 0x040087A3 RID: 34723
		[SerializeField]
		private GameObject mImageDeath;

		// Token: 0x040087A4 RID: 34724
		[SerializeField]
		private GameObject mRatePanel;

		// Token: 0x040087A5 RID: 34725
		[SerializeField]
		private GameObject mEffectSelected;

		// Token: 0x040087A6 RID: 34726
		[SerializeField]
		private GameObject mEffectRefresh;

		// Token: 0x040087A7 RID: 34727
		[SerializeField]
		private DOTweenAnimation mSelectTween;

		// Token: 0x040087A8 RID: 34728
		[SerializeField]
		private string mShooterUnknownIconPath = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Touxiang_00";

		// Token: 0x040087A9 RID: 34729
		[SerializeField]
		private string mWinSprite = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Text_Shengli";

		// Token: 0x040087AA RID: 34730
		[SerializeField]
		private string mLoseSprite = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Text_ShiBai";

		// Token: 0x040087AB RID: 34731
		[SerializeField]
		private string mChampionSprite = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Text_Guanjun";

		// Token: 0x040087AC RID: 34732
		private UnityAction<HorseGamblingMapShooter> mOnClick;

		// Token: 0x040087AE RID: 34734
		private int mId;

		// Token: 0x040087B0 RID: 34736
		private bool mIsShowRefreshEffect = true;

		// Token: 0x02001686 RID: 5766
		public enum EPosition
		{
			// Token: 0x040087B2 RID: 34738
			None,
			// Token: 0x040087B3 RID: 34739
			Top,
			// Token: 0x040087B4 RID: 34740
			Bottom
		}
	}
}
