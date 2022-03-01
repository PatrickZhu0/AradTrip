using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200169A RID: 5786
	public class HorseGamblingView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C8C RID: 7308
		// (get) Token: 0x0600E331 RID: 58161 RVA: 0x003A5EEE File Offset: 0x003A42EE
		public float RefreshOddsInterval
		{
			get
			{
				return this.mRefreshOddsInterval;
			}
		}

		// Token: 0x17001C8D RID: 7309
		// (get) Token: 0x0600E332 RID: 58162 RVA: 0x003A5EF6 File Offset: 0x003A42F6
		public int SelectShooterId
		{
			get
			{
				return (!(this.mSelectShooter == null)) ? this.mSelectShooter.Id : 0;
			}
		}

		// Token: 0x0600E333 RID: 58163 RVA: 0x003A5F1C File Offset: 0x003A431C
		public void Init(IHorseGablingDataManager dataManager, UnityAction onButtonSupplyClick, UnityAction onStakeRecordsClick, UnityAction onGameRecordsClick, UnityAction onShooterRecordClick, UnityAction onClose)
		{
			this.mDataManager = dataManager;
			if (dataManager == null)
			{
				this.Dispose();
				return;
			}
			this.mButtonClose.SafeAddOnClickListener(onClose);
			this.mButtonSupply.SafeAddOnClickListener(onButtonSupplyClick);
			this.mButtonGameRecords.SafeAddOnClickListener(onGameRecordsClick);
			this.mButtonStakeRecords.SafeAddOnClickListener(onStakeRecordsClick);
			this.mButtonShooterRecords.SafeAddOnClickListener(onShooterRecordClick);
			this.mToggleShooterInfo.SafeAddOnValueChangedListener(new UnityAction<bool>(this.OnToggleShooterInfo));
			this.mToggleShooterRecord.SafeAddOnValueChangedListener(new UnityAction<bool>(this.OnToggleShooterRecord));
			this.mShooterRecordList.InitialLizeWithExternalElement(this.mRecordItemPath);
			this.mShooterRecordList.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OnShooterRecordItemVisible);
			this.mShooterRecordList.OnItemUpdate = new ComUIListScript.OnItemUpdateDelegate(this.OnShooterRecordItemVisible);
			base.StartCoroutine(this.InitMapZones());
			this.UpdateTipText();
		}

		// Token: 0x0600E334 RID: 58164 RVA: 0x003A5FFC File Offset: 0x003A43FC
		public void Dispose()
		{
			base.StopAllCoroutines();
			this.mMapZones.Clear();
			this.mDataManager = null;
			this.mSelectShooter = null;
			this.mButtonClose.SafeRemoveAllListener();
			this.mToggleShooterInfo.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this.OnToggleShooterInfo));
			this.mToggleShooterRecord.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this.OnToggleShooterRecord));
			this.mButtonGameRecords.SafeRemoveAllListener();
			this.mButtonStakeRecords.SafeRemoveAllListener();
			this.mButtonShooterRecords.SafeRemoveAllListener();
			this.mButtonSupply.SafeRemoveAllListener();
			this.mShooterRecordList.onItemVisiable = null;
			this.mShooterRecordList.OnItemUpdate = null;
			this.StopAnimation();
		}

		// Token: 0x0600E335 RID: 58165 RVA: 0x003A60AC File Offset: 0x003A44AC
		public void UpdateData(IHorseGablingDataManager dataManager)
		{
			if (dataManager == null)
			{
				return;
			}
			this.mDataManager = dataManager;
			this.UpdateMapZones();
			if (!this.mIsInitWeather)
			{
				this.SetWeather();
			}
			if (dataManager.State != BetHorsePhaseType.PHASE_TYPE_STAKE)
			{
				this.SetButtonSupplyEnable(false);
			}
			else
			{
				this.SetButtonSupplyEnable(true);
			}
		}

		// Token: 0x0600E336 RID: 58166 RVA: 0x003A6100 File Offset: 0x003A4500
		public void UpdateState(BetHorsePhaseType status)
		{
			switch (status)
			{
			case BetHorsePhaseType.PHASE_TYPE_READY:
			case BetHorsePhaseType.PHASE_TYPE_DAY_END:
				this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_day_end_tip"), Function.GetTime((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp)));
				break;
			case BetHorsePhaseType.PHASE_TYPE_STAKE:
				this.SetButtonSupplyEnable(true);
				this.mIsRandomShooter = true;
				this.mIsInitWeather = false;
				this.ResetMapZones();
				this.mToggleShooterInfo.isOn = true;
				this.OnToggleShooterInfo(true);
				this.ResetShooterInfo();
				if (this.mSelectShooter != null)
				{
					this.mSelectShooter.SetSelected(false);
				}
				this.mSelectShooter = null;
				this.mTextHelp.SafeSetText(TR.Value("horse_gambling_match_tip"));
				break;
			case BetHorsePhaseType.PHASE_TYPE_ADJUST:
				this.SetButtonSupplyEnable(false);
				this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_adjust_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
				break;
			case BetHorsePhaseType.PHASE_TYPE_RESULT:
				this.mIsShowBattleAnimation = true;
				this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_show_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
				base.StartCoroutine(this.PlayBattleAnimation());
				break;
			}
		}

		// Token: 0x0600E337 RID: 58167 RVA: 0x003A625C File Offset: 0x003A465C
		public void UpdateOdds(IHorseGablingDataManager dataManager)
		{
			if (this.mIsRandomShooter)
			{
				return;
			}
			for (int i = 0; i < dataManager.MapZoneModels.Count; i++)
			{
				if (this.mMapZones.ContainsKey(dataManager.MapZoneModels[i].Id))
				{
					this.mMapZones[dataManager.MapZoneModels[i].Id].UpdateOdds(dataManager.MapZoneModels[i]);
				}
			}
		}

		// Token: 0x0600E338 RID: 58168 RVA: 0x003A62E0 File Offset: 0x003A46E0
		public void UpdateShooterInfo(IHorseGamblingShooterModel model)
		{
			if (model == null || this.mSelectShooter == null)
			{
				return;
			}
			if (this.mSelectShooter.Id == model.Id)
			{
				if (this.mIsShowShooterRecord)
				{
					this.ShowShooterRecord(model.Records);
				}
				else
				{
					this.ShowShooterInfo(model);
				}
			}
		}

		// Token: 0x0600E339 RID: 58169 RVA: 0x003A6340 File Offset: 0x003A4740
		private void UpdateMapZones()
		{
			if (this.mDataManager == null || this.mDataManager.MapZoneModels == null || this.mMapZones == null)
			{
				return;
			}
			this.UpdateTipText();
			if (this.mDataManager.MapZoneModels.Count == 0)
			{
				this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_first_game_tip"), Function.GetTime((int)this.mDataManager.TimeStamp)));
			}
			if (!this.mIsShowBattleAnimation && !this.mIsRandomShooter)
			{
				this.SetMapZoneDatas();
			}
		}

		// Token: 0x0600E33A RID: 58170 RVA: 0x003A63D8 File Offset: 0x003A47D8
		private void SetWeather()
		{
			if (this.mDataManager == null)
			{
				return;
			}
			for (int i = 0; i < this.mWeatherDatas.Count; i++)
			{
				if (this.mDataManager.Weather == this.mWeatherDatas[i].WeatherType)
				{
					this.mTextWeather.SafeSetText(this.mWeatherDatas[i].Description);
					ETCImageLoader.LoadSprite(ref this.mImageWeather, this.mWeatherDatas[i].Icon, true);
					if (this.mWeatherEffectRoot.transform.childCount > 0)
					{
						Transform child = this.mWeatherEffectRoot.GetChild(0);
						if (child != null)
						{
							Object.Destroy(child.gameObject);
						}
					}
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mWeatherDatas[i].EffectPrefabPath, true, 0U);
					if (gameObject != null)
					{
						gameObject.transform.SetParent(this.mWeatherEffectRoot, false);
					}
					this.mIsInitWeather = true;
					break;
				}
			}
		}

		// Token: 0x0600E33B RID: 58171 RVA: 0x003A6500 File Offset: 0x003A4900
		private IEnumerator PlayBattleAnimation()
		{
			this.mBattleStartAnim.CustomActive(true);
			yield return new WaitForSeconds(this.mBattleStartAnimationTime);
			this.mBattleStartAnim.CustomActive(false);
			foreach (HorseGamblingMapZone horseGamblingMapZone in this.mMapZones.Values)
			{
				if (horseGamblingMapZone.Phase == 1)
				{
					this.MapZoneShowUnBattle(horseGamblingMapZone);
				}
			}
			yield return new WaitForSeconds(this.mZoneBattleAnimationTime);
			foreach (HorseGamblingMapZone horseGamblingMapZone2 in this.mMapZones.Values)
			{
				if (horseGamblingMapZone2.Phase == 1)
				{
					this.MapZoneShowBattleResult(horseGamblingMapZone2);
				}
				else if (horseGamblingMapZone2.Phase == 2)
				{
					this.MapZoneShowUnBattle(horseGamblingMapZone2);
				}
			}
			yield return new WaitForSeconds(this.mZoneBattleAnimationTime);
			foreach (HorseGamblingMapZone horseGamblingMapZone3 in this.mMapZones.Values)
			{
				if (horseGamblingMapZone3.Phase == 2)
				{
					this.MapZoneShowBattleResult(horseGamblingMapZone3);
				}
				else if (horseGamblingMapZone3.Phase == 3)
				{
					this.MapZoneShowUnBattle(horseGamblingMapZone3);
				}
			}
			yield return new WaitForSeconds(this.mZoneBattleAnimationTime);
			foreach (HorseGamblingMapZone horseGamblingMapZone4 in this.mMapZones.Values)
			{
				if (horseGamblingMapZone4.Phase == 3)
				{
					horseGamblingMapZone4.HideBattleAnimation();
					for (int i = 0; i < this.mDataManager.MapZoneModels.Count; i++)
					{
						if (horseGamblingMapZone4.Id == this.mDataManager.MapZoneModels[i].Id)
						{
							horseGamblingMapZone4.ShowBattleResult(this.mDataManager.MapZoneModels[i]);
							this.ShowChampion(horseGamblingMapZone4, this.mDataManager.MapZoneModels[i].Shooters);
							break;
						}
					}
				}
			}
			this.mIsShowBattleAnimation = false;
			yield break;
		}

		// Token: 0x0600E33C RID: 58172 RVA: 0x003A651C File Offset: 0x003A491C
		private void ShowChampion(HorseGamblingMapZone zone, Dictionary<int, HorseGamblingMapShooterModel> shooters)
		{
			HorseGamblingMapZoneChampionComponent component = zone.GetComponent<HorseGamblingMapZoneChampionComponent>();
			if (component != null)
			{
				foreach (HorseGamblingMapShooterModel horseGamblingMapShooterModel in shooters.Values)
				{
					if (horseGamblingMapShooterModel.BattleState == EHorseGamblingBattleResult.Win)
					{
						component.ShowChampion(horseGamblingMapShooterModel.Id, new UnityAction<HorseGamblingMapShooter>(this.OnSelectShooter));
						break;
					}
				}
			}
		}

		// Token: 0x0600E33D RID: 58173 RVA: 0x003A65B0 File Offset: 0x003A49B0
		private void MapZoneShowBattleResult(HorseGamblingMapZone zone)
		{
			zone.HideBattleAnimation();
			for (int i = 0; i < this.mDataManager.MapZoneModels.Count; i++)
			{
				if (zone.Id == this.mDataManager.MapZoneModels[i].Id)
				{
					zone.ShowBattleResult(this.mDataManager.MapZoneModels[i]);
					break;
				}
			}
		}

		// Token: 0x0600E33E RID: 58174 RVA: 0x003A6624 File Offset: 0x003A4A24
		private void MapZoneShowUnBattle(HorseGamblingMapZone zone)
		{
			for (int i = 0; i < this.mDataManager.MapZoneModels.Count; i++)
			{
				if (zone.Id == this.mDataManager.MapZoneModels[i].Id)
				{
					zone.ShowUnBattle(this.mDataManager.MapZoneModels[i]);
					break;
				}
			}
		}

		// Token: 0x0600E33F RID: 58175 RVA: 0x003A6690 File Offset: 0x003A4A90
		private void UpdateTipText()
		{
			if (this.mDataManager != null)
			{
				switch (this.mDataManager.State)
				{
				case BetHorsePhaseType.PHASE_TYPE_READY:
				case BetHorsePhaseType.PHASE_TYPE_DAY_END:
					this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_day_end_tip"), Function.GetTime((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp)));
					break;
				case BetHorsePhaseType.PHASE_TYPE_STAKE:
					this.SetButtonSupplyEnable(true);
					this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_stake_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
					break;
				case BetHorsePhaseType.PHASE_TYPE_ADJUST:
					this.SetButtonSupplyEnable(false);
					this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_adjust_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
					break;
				case BetHorsePhaseType.PHASE_TYPE_RESULT:
					this.SetButtonSupplyEnable(false);
					this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_show_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
					break;
				}
			}
		}

		// Token: 0x0600E340 RID: 58176 RVA: 0x003A67C0 File Offset: 0x003A4BC0
		private void SetButtonSupplyEnable(bool value)
		{
			this.mButtonSupplyGray.enabled = !value;
			this.mButtonSupply.enabled = value;
		}

		// Token: 0x0600E341 RID: 58177 RVA: 0x003A67E0 File Offset: 0x003A4BE0
		private void ResetMapZones()
		{
			foreach (HorseGamblingMapZone horseGamblingMapZone in this.mMapZones.Values)
			{
				horseGamblingMapZone.Reset(horseGamblingMapZone.Phase != 3);
				if (horseGamblingMapZone.Phase == 3)
				{
					HorseGamblingMapZoneChampionComponent component = horseGamblingMapZone.GetComponent<HorseGamblingMapZoneChampionComponent>();
					if (component != null)
					{
						component.Reset();
					}
				}
			}
		}

		// Token: 0x0600E342 RID: 58178 RVA: 0x003A6874 File Offset: 0x003A4C74
		private IEnumerator InitMapZones()
		{
			for (int i = 0; i < this.mMapZoneGOList.Count; i++)
			{
				yield return null;
				bool isNeedAutoSelectShooter = this.mSelectShooter == null;
				UIPrefabWrapper wrapper = this.mMapZoneGOList[i].GetComponent<UIPrefabWrapper>();
				if (wrapper != null)
				{
					this.mMapZoneGOList[i] = wrapper.LoadUIPrefab(this.mMapZoneGOList[i].transform);
					HorseGamblingMapZone component = this.mMapZoneGOList[i].GetComponent<HorseGamblingMapZone>();
					if (component != null && this.mDataManager != null)
					{
						bool isShowShooter = component.Phase == 1 || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END;
						bool isShowWinLine = this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END;
						bool isShowBattleEffect = component.Phase != 3 || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END;
						component.Init(new UnityAction<HorseGamblingMapShooter>(this.OnSelectShooter), this.mShooterRoot, this.mTerrainRoot, this.mLineRoot, isShowShooter, isShowBattleEffect);
						this.mMapZones.Add(component.Id, component);
						if (this.mIsNeedSetMapZoneData && this.mDataManager.MapZoneModels != null)
						{
							for (int j = 0; j < this.mDataManager.MapZoneModels.Count; j++)
							{
								if (component.Id == this.mDataManager.MapZoneModels[j].Id)
								{
									if (component.Id == 1)
									{
										component.SetData(this.mDataManager.MapZoneModels[j], isShowShooter, isNeedAutoSelectShooter, isShowWinLine);
									}
									else
									{
										component.SetData(this.mDataManager.MapZoneModels[j], isShowShooter, false, isShowWinLine);
										if (component.Phase == 3)
										{
											HorseGamblingMapZoneChampionComponent component2 = component.GetComponent<HorseGamblingMapZoneChampionComponent>();
											if (component2 != null)
											{
												component2.Init(this.mShooterRoot);
											}
											if (this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END)
											{
												this.ShowChampion(component, this.mDataManager.MapZoneModels[j].Shooters);
											}
										}
									}
									break;
								}
							}
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600E343 RID: 58179 RVA: 0x003A6890 File Offset: 0x003A4C90
		private void Update()
		{
			if (this.mDataManager != null)
			{
				BetHorsePhaseType state = this.mDataManager.State;
				if (state != BetHorsePhaseType.PHASE_TYPE_STAKE)
				{
					if (state != BetHorsePhaseType.PHASE_TYPE_ADJUST)
					{
						if (state == BetHorsePhaseType.PHASE_TYPE_RESULT)
						{
							this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_show_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
						}
					}
					else
					{
						this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_adjust_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
					}
				}
				else
				{
					this.mTextHelp.SafeSetText(string.Format(TR.Value("horse_gambling_stake_tip"), Function.GetLeftMinutes((int)DataManager<HorseGamblingDataManager>.GetInstance().TimeStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
				}
			}
			if (this.mIsRandomShooter)
			{
				this.mAnimationDelta += Time.deltaTime;
				this.mAnimationDuration += Time.deltaTime;
				if (this.mAnimationDelta >= this.mAnimationInterval)
				{
					this.mAnimationDelta = 0f;
					foreach (HorseGamblingMapZone horseGamblingMapZone in this.mMapZones.Values)
					{
						if (horseGamblingMapZone.Phase == 1)
						{
							horseGamblingMapZone.RandomShooter();
						}
					}
					if (this.mSelectShooter != null)
					{
						BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(this.mSelectShooter.RandomId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ETCImageLoader.LoadSprite(ref this.mImageShooterPortrait, tableItem.PortraitPath, true);
						}
					}
				}
				if (this.mAnimationDuration >= this.mAnimationTime)
				{
					this.StopAnimation();
					foreach (HorseGamblingMapZone horseGamblingMapZone2 in this.mMapZones.Values)
					{
						if (horseGamblingMapZone2.Phase == 1)
						{
							horseGamblingMapZone2.StopRandomShooter();
						}
					}
					this.SetMapZoneDatas();
					this.OnToggleShooterInfo(true);
				}
			}
		}

		// Token: 0x0600E344 RID: 58180 RVA: 0x003A6AF0 File Offset: 0x003A4EF0
		private void ResetShooterInfo()
		{
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(0, string.Empty, string.Empty);
			this.mTextShooterName.SafeSetText(tableItem.Name);
			this.mTextShooterStatus.SafeSetText(TR.Value("horse_gambling_shooter_unknown_staus"));
			this.mTextShooterTerrain.SafeSetText(tableItem.Terrain);
			this.mImageShooterStatus.CustomActive(false);
			this.mImageShooterOccu.CustomActive(false);
			this.mTextShooterOccu.SafeSetText(tableItem.Occupation);
			this.mTextShooterWeather.SafeSetText(tableItem.Weather);
			this.mTextShooterWinRate.SafeSetText(TR.Value("horse_gambling_shooter_unknown_staus"));
			this.mTextShooterChampionCount.SafeSetText(TR.Value("horse_gambling_shooter_unknown_staus"));
			ETCImageLoader.LoadSprite(ref this.mImageShooterPortrait, tableItem.PortraitPath, true);
		}

		// Token: 0x0600E345 RID: 58181 RVA: 0x003A6BC4 File Offset: 0x003A4FC4
		private void SetMapZoneDatas()
		{
			if (this.mDataManager == null || this.mDataManager.MapZoneModels == null || this.mMapZones == null)
			{
				return;
			}
			bool isAutoSelect = this.mSelectShooter == null;
			bool isShowWinLine = this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END;
			for (int i = 0; i < this.mDataManager.MapZoneModels.Count; i++)
			{
				if (this.mMapZones.ContainsKey(this.mDataManager.MapZoneModels[i].Id))
				{
					HorseGamblingMapZone horseGamblingMapZone = this.mMapZones[this.mDataManager.MapZoneModels[i].Id];
					bool isShowShooter = horseGamblingMapZone.Phase == 1 || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END;
					horseGamblingMapZone.SetData(this.mDataManager.MapZoneModels[i], isShowShooter, isAutoSelect, isShowWinLine);
					if ((this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_RESULT || this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_DAY_END) && horseGamblingMapZone.Phase == 3)
					{
						this.ShowChampion(horseGamblingMapZone, this.mDataManager.MapZoneModels[i].Shooters);
					}
					isAutoSelect = false;
				}
			}
			this.mIsNeedSetMapZoneData = true;
		}

		// Token: 0x0600E346 RID: 58182 RVA: 0x003A6D30 File Offset: 0x003A5130
		private void StopAnimation()
		{
			this.mAnimationDuration = 0f;
			this.mAnimationDelta = 0f;
			this.mIsRandomShooter = false;
		}

		// Token: 0x0600E347 RID: 58183 RVA: 0x003A6D50 File Offset: 0x003A5150
		private void OnToggleShooterInfo(bool value)
		{
			if (value)
			{
				if (this.mDataManager == null || this.mSelectShooter == null)
				{
					return;
				}
				HorseGamblingShooterModel shooterModel = this.mDataManager.GetShooterModel(this.mSelectShooter.Id);
				if (shooterModel == null)
				{
					return;
				}
				this.ShowShooterInfo(shooterModel);
				this.mIsShowShooterRecord = false;
			}
		}

		// Token: 0x0600E348 RID: 58184 RVA: 0x003A6DAC File Offset: 0x003A51AC
		private void OnToggleShooterRecord(bool value)
		{
			if (value)
			{
				if (this.mDataManager == null || this.mSelectShooter == null)
				{
					return;
				}
				HorseGamblingShooterModel shooterModel = this.mDataManager.GetShooterModel(this.mSelectShooter.Id);
				if (shooterModel == null)
				{
					return;
				}
				if (shooterModel.IsUnknown && this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_STAKE)
				{
					this.mToggleShooterInfo.isOn = true;
				}
				else
				{
					ShooterRecord[] shooterHistory = this.mDataManager.GetShooterHistory(this.mSelectShooter.Id);
					this.ShowShooterRecord(shooterHistory);
					this.mIsShowShooterRecord = true;
				}
			}
		}

		// Token: 0x0600E349 RID: 58185 RVA: 0x003A6E4C File Offset: 0x003A524C
		private void OnSelectShooter(HorseGamblingMapShooter shooter)
		{
			if (shooter == null)
			{
				return;
			}
			if (this.mDataManager == null)
			{
				return;
			}
			if (this.mIsRandomShooter)
			{
				return;
			}
			HorseGamblingShooterModel shooterModel = this.mDataManager.GetShooterModel(shooter.Id);
			if (shooterModel == null)
			{
				return;
			}
			if (this.mSelectShooter != null)
			{
				this.mSelectShooter.SetSelected(false);
			}
			this.mSelectShooter = shooter;
			this.mSelectShooter.SetSelected(true);
			this.mTextShooterName.SafeSetText(shooterModel.Name);
			if (this.mPortraitSelectAnim != null)
			{
				this.mPortraitSelectAnim.DORestart(false);
			}
			ETCImageLoader.LoadSprite(ref this.mImageShooterPortrait, shooterModel.PortraitPath, true);
			if (this.mIsShowShooterRecord)
			{
				if (shooterModel.IsUnknown && this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_STAKE)
				{
					this.mToggleShooterInfo.isOn = true;
				}
				else
				{
					ShooterRecord[] shooterHistory = this.mDataManager.GetShooterHistory(this.mSelectShooter.Id);
					this.ShowShooterRecord(shooterHistory);
				}
			}
			else
			{
				this.ShowShooterInfo(shooterModel);
			}
			if (shooterModel.IsUnknown && this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_STAKE)
			{
				this.mToggleShooterRecord.enabled = false;
				this.mToggleShooterRecordGray.enabled = true;
			}
			else
			{
				this.mToggleShooterRecord.enabled = true;
				this.mToggleShooterRecordGray.enabled = false;
			}
		}

		// Token: 0x0600E34A RID: 58186 RVA: 0x003A6FBC File Offset: 0x003A53BC
		private void ShowShooterInfo(IHorseGamblingShooterModel shooterModel)
		{
			if (this.mIsRandomShooter || this.mDataManager == null)
			{
				return;
			}
			this.mShooterInfoGO.CustomActive(true);
			this.mShooterRecordGO.CustomActive(false);
			this.mImageShooterStatus.CustomActive(true);
			this.mImageShooterOccu.CustomActive(true);
			if (shooterModel.IsUnknown && this.mDataManager.State == BetHorsePhaseType.PHASE_TYPE_STAKE)
			{
				this.ResetShooterInfo();
			}
			else
			{
				for (int i = 0; i < this.mShooterStatusDatas.Count; i++)
				{
					if (this.mShooterStatusDatas[i].Status == shooterModel.Status)
					{
						this.mTextShooterStatus.SafeSetText(this.mShooterStatusDatas[i].Description);
						if (!string.IsNullOrEmpty(this.mShooterStatusDatas[i].Icon))
						{
							ETCImageLoader.LoadSprite(ref this.mImageShooterStatus, this.mShooterStatusDatas[i].Icon, true);
						}
						break;
					}
				}
				this.mTextShooterOccu.SafeSetText(shooterModel.Occupation);
				this.mTextShooterTerrain.SafeSetText(shooterModel.Terrain);
				this.mTextShooterWeather.SafeSetText(shooterModel.Weather);
				this.mTextShooterWinRate.SafeSetText(string.Format(TR.Value("horse_gambling_shooter_win_rate"), shooterModel.WinRate));
				this.mTextShooterChampionCount.SafeSetText(string.Format(TR.Value("horse_gambling_shooter_champion_count"), shooterModel.ChampionCount));
				ETCImageLoader.LoadSprite(ref this.mImageShooterOccu, shooterModel.OccupationIcon, true);
				ETCImageLoader.LoadSprite(ref this.mImageShooterPortrait, shooterModel.PortraitPath, true);
				this.mTextShooterName.SafeSetText(shooterModel.Name);
			}
		}

		// Token: 0x0600E34B RID: 58187 RVA: 0x003A718A File Offset: 0x003A558A
		private void ShowShooterRecord(ShooterRecord[] records)
		{
			this.mShooterInfoGO.CustomActive(false);
			this.mShooterRecordGO.CustomActive(true);
			if (records != null)
			{
				this.mShooterRecordList.UpdateElementAmount(records.Length);
			}
		}

		// Token: 0x0600E34C RID: 58188 RVA: 0x003A71B8 File Offset: 0x003A55B8
		private void OnShooterRecordItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			HorseGamblingShooterRecordItem component = item.GetComponent<HorseGamblingShooterRecordItem>();
			if (component == null)
			{
				Logger.LogError(string.Format("路径在{0}下的预置上没有挂载脚本HorseGamblingShooterRecordItem", this.mRecordItemPath));
				return;
			}
			if (this.mDataManager == null || this.mSelectShooter == null)
			{
				return;
			}
			ShooterRecord[] shooterHistory = this.mDataManager.GetShooterHistory(this.mSelectShooter.Id);
			if (shooterHistory == null)
			{
				return;
			}
			int num = shooterHistory.Length - 1 - item.m_index;
			if (num >= shooterHistory.Length || num < 0)
			{
				return;
			}
			ShooterRecord shooterRecord = shooterHistory[shooterHistory.Length - 1 - item.m_index];
			component.Init(shooterRecord.coutrId.ToString(), (shooterRecord.odds / 10000f).ToString(), shooterRecord.result == 1U, (item.m_index % 2 != 0) ? this.mShooterRecordBg1 : this.mShooterRecordBg2);
		}

		// Token: 0x04008816 RID: 34838
		[SerializeField]
		[Header("赔率刷新间隔")]
		private float mRefreshOddsInterval = 5f;

		// Token: 0x04008817 RID: 34839
		[SerializeField]
		private Button mButtonClose;

		// Token: 0x04008818 RID: 34840
		[SerializeField]
		private GameObject mShooterInfoGO;

		// Token: 0x04008819 RID: 34841
		[SerializeField]
		private GameObject mShooterRecordGO;

		// Token: 0x0400881A RID: 34842
		[SerializeField]
		private Toggle mToggleShooterInfo;

		// Token: 0x0400881B RID: 34843
		[SerializeField]
		private Toggle mToggleShooterRecord;

		// Token: 0x0400881C RID: 34844
		[SerializeField]
		private UIGray mToggleShooterRecordGray;

		// Token: 0x0400881D RID: 34845
		[SerializeField]
		private Text mTextShooterName;

		// Token: 0x0400881E RID: 34846
		[SerializeField]
		private Image mImageShooterPortrait;

		// Token: 0x0400881F RID: 34847
		[Header("射手信息")]
		[SerializeField]
		private Text mTextShooterStatus;

		// Token: 0x04008820 RID: 34848
		[SerializeField]
		private Text mTextShooterOccu;

		// Token: 0x04008821 RID: 34849
		[SerializeField]
		private Text mTextShooterTerrain;

		// Token: 0x04008822 RID: 34850
		[SerializeField]
		private Text mTextShooterWeather;

		// Token: 0x04008823 RID: 34851
		[SerializeField]
		private Text mTextShooterWinRate;

		// Token: 0x04008824 RID: 34852
		[SerializeField]
		private Text mTextShooterChampionCount;

		// Token: 0x04008825 RID: 34853
		[SerializeField]
		private Image mImageShooterStatus;

		// Token: 0x04008826 RID: 34854
		[SerializeField]
		private Image mImageShooterOccu;

		// Token: 0x04008827 RID: 34855
		[Header("射手战绩")]
		[SerializeField]
		private ComUIListScript mShooterRecordList;

		// Token: 0x04008828 RID: 34856
		[SerializeField]
		private Button mButtonShooterRecords;

		// Token: 0x04008829 RID: 34857
		[SerializeField]
		private string mRecordItemPath = "UIFlatten/Prefabs/HorseGambling/HorseGamblingShooterRecordItem";

		// Token: 0x0400882A RID: 34858
		private const int WIN_RATE_TO_PERCENT = 100;

		// Token: 0x0400882B RID: 34859
		[Header("地图")]
		[SerializeField]
		private List<GameObject> mMapZoneGOList;

		// Token: 0x0400882C RID: 34860
		[SerializeField]
		private Transform mShooterRoot;

		// Token: 0x0400882D RID: 34861
		[SerializeField]
		private Transform mLineRoot;

		// Token: 0x0400882E RID: 34862
		[SerializeField]
		private Transform mTerrainRoot;

		// Token: 0x0400882F RID: 34863
		private readonly Dictionary<int, HorseGamblingMapZone> mMapZones = new Dictionary<int, HorseGamblingMapZone>();

		// Token: 0x04008830 RID: 34864
		[SerializeField]
		private Image mImageWeather;

		// Token: 0x04008831 RID: 34865
		[SerializeField]
		private Text mTextWeather;

		// Token: 0x04008832 RID: 34866
		[SerializeField]
		private Text mTextHelp;

		// Token: 0x04008833 RID: 34867
		[SerializeField]
		private Button mButtonSupply;

		// Token: 0x04008834 RID: 34868
		[SerializeField]
		private UIGray mButtonSupplyGray;

		// Token: 0x04008835 RID: 34869
		[SerializeField]
		private Button mButtonStakeRecords;

		// Token: 0x04008836 RID: 34870
		[SerializeField]
		private Button mButtonGameRecords;

		// Token: 0x04008837 RID: 34871
		private bool mIsInitWeather;

		// Token: 0x04008838 RID: 34872
		[Header("射手状态数据")]
		[SerializeField]
		private List<HorseGamblingView.ShooterStatusIcon> mShooterStatusDatas;

		// Token: 0x04008839 RID: 34873
		[SerializeField]
		private string mShooterRecordBg1 = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_LieBiao_Bg_01";

		// Token: 0x0400883A RID: 34874
		[SerializeField]
		private string mShooterRecordBg2 = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_LieBiao_Bg_02";

		// Token: 0x0400883B RID: 34875
		[Header("天气数据")]
		[SerializeField]
		private List<HorseGamblingView.WeatherData> mWeatherDatas;

		// Token: 0x0400883C RID: 34876
		[SerializeField]
		private Transform mWeatherEffectRoot;

		// Token: 0x0400883D RID: 34877
		private IHorseGablingDataManager mDataManager;

		// Token: 0x0400883E RID: 34878
		private bool mIsShowShooterRecord;

		// Token: 0x0400883F RID: 34879
		private HorseGamblingMapShooter mSelectShooter;

		// Token: 0x04008840 RID: 34880
		[Header("动画特效")]
		private bool mIsRandomShooter;

		// Token: 0x04008841 RID: 34881
		private bool mIsShowBattleAnimation;

		// Token: 0x04008842 RID: 34882
		private float mAnimationDelta;

		// Token: 0x04008843 RID: 34883
		private float mAnimationDuration;

		// Token: 0x04008844 RID: 34884
		[SerializeField]
		private float mAnimationInterval = 0.1f;

		// Token: 0x04008845 RID: 34885
		[SerializeField]
		private float mAnimationTime = 1f;

		// Token: 0x04008846 RID: 34886
		[SerializeField]
		private float mZoneBattleAnimationTime = 2f;

		// Token: 0x04008847 RID: 34887
		[SerializeField]
		private float mBattleStartAnimationTime = 2f;

		// Token: 0x04008848 RID: 34888
		[SerializeField]
		private GameObject mBattleStartAnim;

		// Token: 0x04008849 RID: 34889
		[SerializeField]
		private DOTweenAnimation mPortraitSelectAnim;

		// Token: 0x0400884A RID: 34890
		private bool mIsNeedSetMapZoneData;

		// Token: 0x0200169B RID: 5787
		[Serializable]
		private struct ShooterStatusIcon
		{
			// Token: 0x0400884B RID: 34891
			[Header("状态")]
			public ShooterStatusType Status;

			// Token: 0x0400884C RID: 34892
			[Header("状态描述")]
			public string Description;

			// Token: 0x0400884D RID: 34893
			[Header("状态图标")]
			public string Icon;
		}

		// Token: 0x0200169C RID: 5788
		[Serializable]
		private struct WeatherData
		{
			// Token: 0x0400884E RID: 34894
			public WeatherType WeatherType;

			// Token: 0x0400884F RID: 34895
			public string Description;

			// Token: 0x04008850 RID: 34896
			public string Icon;

			// Token: 0x04008851 RID: 34897
			public string EffectPrefabPath;
		}
	}
}
