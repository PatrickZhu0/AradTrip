using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200198B RID: 6539
	internal class PKBattleResultFrame : ClientFrame
	{
		// Token: 0x0600FE59 RID: 65113 RVA: 0x004649B1 File Offset: 0x00462DB1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKBattleResult";
		}

		// Token: 0x0600FE5A RID: 65114 RVA: 0x004649B8 File Offset: 0x00462DB8
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FE5B RID: 65115 RVA: 0x004649BC File Offset: 0x00462DBC
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.mNeedUpdateAutoClose)
			{
				this.mAutoCloseTimer += timeElapsed;
				if (this.mAutoCloseTimer >= this.mAutoCloseTimerAcc)
				{
					this.frameMgr.CloseFrame<PKBattleResultFrame>(this, false);
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				}
			}
		}

		// Token: 0x0600FE5C RID: 65116 RVA: 0x00464A10 File Offset: 0x00462E10
		protected override void _OnOpenFrame()
		{
			if (this.userData is SceneMatchPkRaceEnd)
			{
				this.m_msgRet = new PKBattleResultData(this.userData as SceneMatchPkRaceEnd);
			}
			else
			{
				if (!(this.userData is SceneRoomMatchPkRaceEnd))
				{
					Logger.LogErrorFormat("[战斗] 战斗结算 错误传入类型", new object[0]);
					return;
				}
				this.m_msgRet = new PKBattleResultData(this.userData as SceneRoomMatchPkRaceEnd);
			}
			this.m_ePKResult = (PKResult)this.m_msgRet.result;
			this.m_promotionInfo = DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo((int)this.m_msgRet.oldSeasonLevel, this.m_ePKResult);
			if (this.m_reportBtn != null)
			{
				this.m_reportBtn.CustomActive(this.m_msgRet.pkType != 17);
			}
			this.m_objRankRoot.CustomActive(this.m_msgRet.pkType != 4 && this.m_msgRet.pkType != 11 && this.m_msgRet.pkType != 17);
			this.m_objPromotionRoot.CustomActive(this.m_msgRet.pkType != 4 && this.m_msgRet.pkType != 11 && this.m_msgRet.pkType != 17);
			this.mDescNode.CustomActive(this.m_msgRet.pkType != 4 && this.m_msgRet.pkType != 11 && this.m_msgRet.pkType != 17);
			this._InitTitle();
			this._InitPKRank();
			this._InitPromotion();
			this._InitDesc();
			this._StatisticResult();
			this._bindUIEvent();
			if (this.m_msgRet.pkType == 13 || this.m_msgRet.pkType == 14)
			{
				this.m_objDescRoot.CustomActive(false);
				this.m_objRankRoot.CustomActive(false);
			}
			if (this.m_msgRet.pkType == 17)
			{
				this.mNeedUpdateAutoClose = true;
				this.mAutoCloseTimerAcc = (float)((!(this.mCounter != null)) ? 10 : this.mCounter.mLeftTime);
				if (this.mOKButton != null)
				{
					DOTweenAnimation[] componentsInChildren = this.mOKButton.GetComponentsInChildren<DOTweenAnimation>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i] != null)
						{
							componentsInChildren[i].DOComplete();
						}
					}
				}
			}
		}

		// Token: 0x0600FE5D RID: 65117 RVA: 0x00464C97 File Offset: 0x00463097
		protected override void _OnCloseFrame()
		{
			this.m_msgRet = null;
			this.m_promotionInfo = null;
			this.m_ePKResult = PKResult.INVALID;
			this._ClearTitle();
			this._ClearPKRank();
			this._ClearPromotion();
			this._ClearDesc();
			this._unBindUIEvent();
		}

		// Token: 0x0600FE5E RID: 65118 RVA: 0x00464CCC File Offset: 0x004630CC
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileSucc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600FE5F RID: 65119 RVA: 0x00464D04 File Offset: 0x00463104
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileSucc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600FE60 RID: 65120 RVA: 0x00464D3C File Offset: 0x0046313C
		private void _OnCounterChanged(UIEvent ui)
		{
			this._UpdateGloryTxt();
		}

		// Token: 0x0600FE61 RID: 65121 RVA: 0x00464D44 File Offset: 0x00463144
		private void _InitTitle()
		{
			this.m_objTitleWin.SetActive(false);
			this.m_objTitleFail.SetActive(false);
			this.m_objTitleDraw.SetActive(false);
			this.m_objTitleError.SetActive(false);
			this.m_objPromotionSuccess.SetActive(false);
			this.m_objPromotionFail.SetActive(false);
			EPromotionState eState = this.m_promotionInfo.eState;
			if (eState == EPromotionState.Invalid || eState == EPromotionState.Promoting)
			{
				if (this.m_ePKResult == PKResult.WIN)
				{
					this.m_objTitleWin.SetActive(true);
				}
				else if (this.m_ePKResult == PKResult.LOSE)
				{
					this.m_objTitleFail.SetActive(true);
				}
				else if (this.m_ePKResult == PKResult.DRAW)
				{
					this.m_objTitleDraw.SetActive(true);
				}
				else if (this.m_ePKResult == PKResult.INVALID)
				{
					this.m_objTitleError.SetActive(true);
				}
			}
			else if (eState == EPromotionState.Successed)
			{
				this.m_objPromotionSuccess.SetActive(true);
				MonoSingleton<AudioManager>.instance.PlaySound(15);
			}
			else if (eState == EPromotionState.Failed)
			{
				this.m_objPromotionFail.SetActive(true);
				MonoSingleton<AudioManager>.instance.PlaySound(16);
			}
		}

		// Token: 0x0600FE62 RID: 65122 RVA: 0x00464E6B File Offset: 0x0046326B
		private void _ClearTitle()
		{
		}

		// Token: 0x0600FE63 RID: 65123 RVA: 0x00464E70 File Offset: 0x00463270
		private void _InitPKRank()
		{
			this.m_comPKRank = ComPKRank.CreateTwo(this.m_objRankRoot);
			if (this.m_comPKRank != null)
			{
				int nStartID;
				int nStartStar;
				int nStartExp;
				int nEndID;
				int nEndStar;
				int nEndExp;
				if (this.m_ePKResult == PKResult.INVALID)
				{
					nStartID = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					nStartStar = DataManager<SeasonDataManager>.GetInstance().seasonStar;
					nStartExp = DataManager<SeasonDataManager>.GetInstance().seasonExp;
					nEndID = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					nEndStar = DataManager<SeasonDataManager>.GetInstance().seasonStar;
					nEndExp = DataManager<SeasonDataManager>.GetInstance().seasonExp;
				}
				else
				{
					nStartID = (int)this.m_msgRet.oldSeasonLevel;
					nStartStar = (int)this.m_msgRet.oldSeasonStar;
					nStartExp = (int)this.m_msgRet.oldSeasonExp;
					int num;
					int num2;
					this._GetWinStreakInfo(out num, out num2);
					if (num >= num2)
					{
						DataManager<SeasonDataManager>.GetInstance().GetPreLevel((int)this.m_msgRet.newSeasonLevel, (int)this.m_msgRet.newSeasonStar, (int)this.m_msgRet.newSeasonExp, out nEndID, out nEndStar, out nEndExp);
					}
					else
					{
						nEndID = (int)this.m_msgRet.newSeasonLevel;
						nEndStar = (int)this.m_msgRet.newSeasonStar;
						nEndExp = (int)this.m_msgRet.newSeasonExp;
					}
				}
				this.m_comPKRank.Initialize(nStartID, nStartExp);
				if (this.m_msgRet.changeSeasonExp > 0)
				{
					this.m_labScore.gameObject.SetActive(true);
					this.m_labScore.text = TR.Value("pk_rank_battle_increase_score", this.m_msgRet.changeSeasonExp);
				}
				else if (this.m_msgRet.changeSeasonExp < 0)
				{
					this.m_labScore.gameObject.SetActive(true);
					this.m_labScore.text = TR.Value("pk_rank_battle_decrease_score", this.m_msgRet.changeSeasonExp);
				}
				else
				{
					this.m_labScore.gameObject.SetActive(false);
				}
				if (this.m_msgRet.pkType == 17)
				{
					this.m_labScore.gameObject.SetActive(false);
				}
				if (this.m_promotionInfo.eState != EPromotionState.Promoting)
				{
					DOTweenAnimation component = this.m_objRankRoot.GetComponent<DOTweenAnimation>();
					if (component != null && component.onStepComplete != null && this.m_objRankRoot.activeSelf)
					{
						component.onStepComplete.AddListener(delegate()
						{
							this.m_comPKRank.StartRankChange(nStartID, nStartStar, nStartExp, nEndID, nEndStar, nEndExp);
						});
					}
				}
			}
		}

		// Token: 0x0600FE64 RID: 65124 RVA: 0x00465114 File Offset: 0x00463514
		private void _OnUpLoadFileSucc(UIEvent a_event)
		{
			if (this.m_reportBtn != null)
			{
				this.m_reportBtn.CustomActive(false);
			}
		}

		// Token: 0x0600FE65 RID: 65125 RVA: 0x00465133 File Offset: 0x00463533
		private void _ClearPKRank()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Clear();
				this.m_comPKRank = null;
			}
		}

		// Token: 0x0600FE66 RID: 65126 RVA: 0x00465158 File Offset: 0x00463558
		private void _InitPromotion()
		{
			if (this.m_promotionInfo.eState != EPromotionState.Promoting && this.m_promotionInfo.eState != EPromotionState.Failed)
			{
				this.m_objPromotionRoot.SetActive(false);
				return;
			}
			PromotionInfo info = DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo((int)this.m_msgRet.oldSeasonLevel, PKResult.INVALID);
			if (info.eState == EPromotionState.Promoting)
			{
				this.m_objPromotionRoot.SetActive(true);
				this._SetChildrenEnable(this.m_objRecordConetnt, false);
				for (int i = 0; i < info.nTotalCount; i++)
				{
					GameObject gameObject;
					if (i < this.m_objRecordConetnt.transform.childCount)
					{
						gameObject = this.m_objRecordConetnt.transform.GetChild(i).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
						gameObject.transform.SetParent(this.m_objRecordConetnt.transform, false);
					}
					gameObject.SetActive(true);
					this._SetChildrenEnable(gameObject, false);
				}
				for (int j = 0; j < info.arrRecords.Count; j++)
				{
					GameObject gameObject2 = this.m_objRecordConetnt.transform.GetChild(j).gameObject;
					if (info.arrRecords[j] == 1)
					{
						Utility.FindGameObject(gameObject2, "Win", true).SetActive(true);
					}
					else if (info.arrRecords[j] == 2 || info.arrRecords[j] == 4)
					{
						Utility.FindGameObject(gameObject2, "Lose", true).SetActive(true);
					}
				}
				if (this.m_ePKResult != PKResult.INVALID)
				{
					DOTweenAnimation component = this.m_objRecordRoot.GetComponent<DOTweenAnimation>();
					if (component != null && component.onStepComplete != null)
					{
						component.onStepComplete.AddListener(delegate()
						{
							GameObject gameObject3 = this.m_objRecordConetnt.transform.GetChild(info.arrRecords.Count).gameObject;
							if (this.m_ePKResult == PKResult.WIN)
							{
								GameObject gameObject4 = Utility.FindGameObject(gameObject3, "Win", true);
								gameObject4.SetActive(true);
								this._PlayAnims(gameObject4.GetComponents<DOTweenAnimation>());
								Utility.FindGameObject(gameObject3, "EffUI_ui_sheng", true).SetActive(true);
								MonoSingleton<AudioManager>.instance.PlaySound(17);
							}
							else if (this.m_ePKResult == PKResult.LOSE || this.m_ePKResult == PKResult.DRAW)
							{
								GameObject gameObject5 = Utility.FindGameObject(gameObject3, "Lose", true);
								gameObject5.SetActive(true);
								this._PlayAnims(gameObject5.GetComponents<DOTweenAnimation>());
								Utility.FindGameObject(gameObject3, "EffUI_ui_bai", true).SetActive(true);
								MonoSingleton<AudioManager>.instance.PlaySound(18);
							}
						});
					}
				}
				this.m_labPromotionDesc.text = TR.Value("pk_rank_detail_promotion_rule", info.nTotalCount, info.nTargetWinCount, DataManager<SeasonDataManager>.GetInstance().GetRankName(info.nNextSeasonLevel, true));
			}
			else
			{
				this.m_objPromotionRoot.SetActive(false);
			}
		}

		// Token: 0x0600FE67 RID: 65127 RVA: 0x004653B8 File Offset: 0x004637B8
		private void _ClearPromotion()
		{
		}

		// Token: 0x0600FE68 RID: 65128 RVA: 0x004653BC File Offset: 0x004637BC
		private void _UpdateGloryTxt()
		{
			this.m_objDescTemplate.SetActive(false);
			List<string> list = new List<string>();
			EPromotionState eState = this.m_promotionInfo.eState;
			if (eState == EPromotionState.Invalid)
			{
				list.Add(TR.Value("pk_rank_battle_coin_get", this.m_msgRet.addPkCoinFromRace));
				list.Add(TR.Value("pk_rank_battle_coin_info", this.m_msgRet.totalPkCoinFromRace, this._GetDailyMaxPKCoin(), DataManager<PlayerBaseData>.GetInstance().VipLevel));
				list.Add(TR.Value("pk_rank_battle_glory_get", this.m_msgRet.changeGlory));
				list.Add(TR.Value("pk_rank_battle_glory_info", this._GetWeeklyTotalGlory(), this._GetWeeklyMaxPVPGlory()));
				int num;
				int num2;
				this._GetWinStreakInfo(out num, out num2);
				list.Add(TR.Value("pk_rank_battle_winning_streak", num2, num));
				int num3 = (num < num2) ? -1 : 2;
			}
			else if (eState == EPromotionState.Promoting || eState == EPromotionState.Successed)
			{
				list.Add(TR.Value("pk_rank_battle_coin_get", this.m_msgRet.addPkCoinFromRace));
				list.Add(TR.Value("pk_rank_battle_coin_info", this.m_msgRet.totalPkCoinFromRace, this._GetDailyMaxPKCoin(), DataManager<PlayerBaseData>.GetInstance().VipLevel));
				list.Add(TR.Value("pk_rank_battle_glory_get", this.m_msgRet.changeGlory));
				list.Add(TR.Value("pk_rank_battle_glory_info", this._GetWeeklyTotalGlory(), this._GetWeeklyMaxPVPGlory()));
			}
			else if (eState == EPromotionState.Failed)
			{
				list.Add(TR.Value("pk_rank_battle_promotion_failed"));
			}
			for (int i = 0; i < list.Count; i++)
			{
				Text component = this.arrObjDescs[i].GetComponent<Text>();
				if (component != null)
				{
					component.text = list[i];
				}
			}
		}

		// Token: 0x0600FE69 RID: 65129 RVA: 0x004655E0 File Offset: 0x004639E0
		private void _InitDesc()
		{
			this.m_objDescTemplate.SetActive(false);
			List<string> list = new List<string>();
			int nIdx = -1;
			EPromotionState eState = this.m_promotionInfo.eState;
			if (eState == EPromotionState.Invalid)
			{
				list.Add(TR.Value("pk_rank_battle_coin_get", this.m_msgRet.addPkCoinFromRace));
				list.Add(TR.Value("pk_rank_battle_coin_info", this.m_msgRet.totalPkCoinFromRace, this._GetDailyMaxPKCoin(), DataManager<PlayerBaseData>.GetInstance().VipLevel));
				list.Add(TR.Value("pk_rank_battle_glory_get", this.m_msgRet.changeGlory));
				list.Add(TR.Value("pk_rank_battle_glory_info", this._GetWeeklyTotalGlory(), this._GetWeeklyMaxPVPGlory()));
				int num;
				int num2;
				this._GetWinStreakInfo(out num, out num2);
				list.Add(TR.Value("pk_rank_battle_winning_streak", num2, num));
				nIdx = ((num < num2) ? -1 : 2);
			}
			else if (eState == EPromotionState.Promoting || eState == EPromotionState.Successed)
			{
				list.Add(TR.Value("pk_rank_battle_coin_get", this.m_msgRet.addPkCoinFromRace));
				list.Add(TR.Value("pk_rank_battle_coin_info", this.m_msgRet.totalPkCoinFromRace, this._GetDailyMaxPKCoin(), DataManager<PlayerBaseData>.GetInstance().VipLevel));
				list.Add(TR.Value("pk_rank_battle_glory_get", this.m_msgRet.changeGlory));
				list.Add(TR.Value("pk_rank_battle_glory_info", this._GetWeeklyTotalGlory(), this._GetWeeklyMaxPVPGlory()));
			}
			else if (eState == EPromotionState.Failed)
			{
				list.Add(TR.Value("pk_rank_battle_promotion_failed"));
			}
			this.arrObjDescs = this._CreateDescs(list);
			DOTweenAnimation component = this.m_objDescRoot.GetComponent<DOTweenAnimation>();
			if (component != null && component.onStepComplete != null)
			{
				component.onStepComplete.AddListener(delegate()
				{
					this.m_corShowDesc = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._ShowDescs(this.arrObjDescs, nIdx));
				});
			}
		}

		// Token: 0x0600FE6A RID: 65130 RVA: 0x0046581C File Offset: 0x00463C1C
		private List<GameObject> _CreateDescs(List<string> a_arrDescs)
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < a_arrDescs.Count; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_objDescTemplate);
				if (i < 2)
				{
					gameObject.transform.SetParent(this.m_objDescUpTxt.transform, false);
				}
				else if (i < 4)
				{
					gameObject.transform.SetParent(this.m_objDescMiddleTxt.transform, false);
				}
				else
				{
					gameObject.transform.SetParent(this.m_objDescRoot.transform, false);
				}
				gameObject.GetComponent<Text>().text = a_arrDescs[i];
				gameObject.SetActive(true);
				list.Add(gameObject);
			}
			return list;
		}

		// Token: 0x0600FE6B RID: 65131 RVA: 0x004658D0 File Offset: 0x00463CD0
		private IEnumerator _ShowDescs(List<GameObject> a_arrObjDescs, int a_nWinStreakSuccessIdx = -1)
		{
			string errormsg = string.Empty;
			int i = 0;
			while (i < a_arrObjDescs.Count)
			{
				try
				{
					if (a_arrObjDescs[i] == null)
					{
						goto IL_2B2;
					}
					DOTweenAnimation[] components = a_arrObjDescs[i].GetComponents<DOTweenAnimation>();
					if (components != null)
					{
						if (i != a_nWinStreakSuccessIdx)
						{
							for (int j = 0; j < components.Length; j++)
							{
								DOTweenAnimation dotweenAnimation = components[j];
								if (dotweenAnimation == null)
								{
									errormsg += string.Format("[ _ShowDescs {0} WinStreakSuccess {1} is null]", a_nWinStreakSuccessIdx, j);
								}
								else if (dotweenAnimation.id != "special")
								{
									dotweenAnimation.isActive = true;
									if (dotweenAnimation.tween == null)
									{
										dotweenAnimation.CreateTween();
									}
									if (dotweenAnimation.tween != null)
									{
										TweenExtensions.Restart(dotweenAnimation.tween, true);
									}
									else
									{
										errormsg += string.Format("[ _ShowDescs {0} WinStreakSuccess {1} is createTween failure]", a_nWinStreakSuccessIdx, j);
									}
								}
							}
						}
						else
						{
							for (int k = 0; k < components.Length; k++)
							{
								DOTweenAnimation dotweenAnimation2 = components[k];
								if (dotweenAnimation2 == null)
								{
									errormsg += string.Format("[ _ShowDescs {0} not WinStreakSuccess {1} is null]", a_nWinStreakSuccessIdx, k);
								}
								else if (dotweenAnimation2.id != "common")
								{
									dotweenAnimation2.isActive = true;
									if (dotweenAnimation2.onStepComplete != null && this.m_objRankRoot.activeSelf)
									{
										dotweenAnimation2.onStepComplete.AddListener(delegate()
										{
											int a_nStartRankID;
											int a_nStartStar;
											int a_nStartExp;
											DataManager<SeasonDataManager>.GetInstance().GetPreLevel((int)this.m_msgRet.newSeasonLevel, (int)this.m_msgRet.newSeasonStar, (int)this.m_msgRet.newSeasonExp, out a_nStartRankID, out a_nStartStar, out a_nStartExp);
											this.m_comPKRank.StartRankChange(a_nStartRankID, a_nStartStar, a_nStartExp, (int)this.m_msgRet.newSeasonLevel, (int)this.m_msgRet.newSeasonStar, (int)this.m_msgRet.newSeasonExp);
										});
									}
									if (dotweenAnimation2.tween == null)
									{
										dotweenAnimation2.CreateTween();
									}
									if (dotweenAnimation2.tween != null)
									{
										TweenExtensions.Restart(dotweenAnimation2.tween, true);
									}
									else
									{
										errormsg += string.Format("[ _ShowDescs {0} not WinStreakSuccess {1} is createTween failure]", a_nWinStreakSuccessIdx, k);
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("[nulljudge] {0}", new object[]
					{
						ex.ToString()
					});
				}
				goto IL_28E;
				IL_2B2:
				i++;
				continue;
				IL_28E:
				yield return Yielders.GetWaitForSeconds(0.2f);
				goto IL_2B2;
			}
			yield break;
		}

		// Token: 0x0600FE6C RID: 65132 RVA: 0x004658F9 File Offset: 0x00463CF9
		private void _ClearDesc()
		{
			if (this.m_corShowDesc != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_corShowDesc);
				this.m_corShowDesc = null;
			}
		}

		// Token: 0x0600FE6D RID: 65133 RVA: 0x00465920 File Offset: 0x00463D20
		private int _GetDailyMaxPKCoin()
		{
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(10, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.PK_MONEY_LIMIT);
			return num + (int)curVipLevelPrivilegeData;
		}

		// Token: 0x0600FE6E RID: 65134 RVA: 0x00465960 File Offset: 0x00463D60
		private int _GetWeeklyTotalGlory()
		{
			int result = 0;
			if (DataManager<CountDataManager>.GetInstance() != null)
			{
				result = DataManager<CountDataManager>.GetInstance().GetCount("pk_season_1v1_honor");
			}
			return result;
		}

		// Token: 0x0600FE6F RID: 65135 RVA: 0x0046598C File Offset: 0x00463D8C
		private int _GetWeeklyMaxPVPGlory()
		{
			int result = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(648, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Value;
			}
			return result;
		}

		// Token: 0x0600FE70 RID: 65136 RVA: 0x004659C4 File Offset: 0x00463DC4
		private void _GetWinStreakInfo(out int a_nCurrentWinStreak, out int a_nMaxWinStreak)
		{
			if (this.m_promotionInfo.eState == EPromotionState.Invalid)
			{
				a_nCurrentWinStreak = DataManager<CountDataManager>.GetInstance().GetCount("season_win_streak");
				if (this.m_ePKResult != PKResult.WIN)
				{
					if (this.m_ePKResult == PKResult.LOSE)
					{
						a_nCurrentWinStreak = 0;
					}
				}
			}
			else
			{
				a_nCurrentWinStreak = 0;
			}
			a_nMaxWinStreak = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(160, string.Empty, string.Empty).Value;
		}

		// Token: 0x0600FE71 RID: 65137 RVA: 0x00465A3C File Offset: 0x00463E3C
		private PKResult _GetBattleResult()
		{
			if (this.m_msgRet != null)
			{
				return (PKResult)this.m_msgRet.result;
			}
			return PKResult.INVALID;
		}

		// Token: 0x0600FE72 RID: 65138 RVA: 0x00465A58 File Offset: 0x00463E58
		private void _StatisticResult()
		{
			string param = string.Empty;
			if (this.m_ePKResult == PKResult.WIN)
			{
				param = "胜利";
			}
			else if (this.m_ePKResult == PKResult.LOSE)
			{
				param = "失败";
			}
			else if (this.m_ePKResult == PKResult.DRAW)
			{
				param = "平局";
			}
			else if (this.m_ePKResult == PKResult.INVALID)
			{
				param = "异常";
			}
			Singleton<GameStatisticManager>.GetInstance().DoStatPk(StatPKType.RESULT, param);
		}

		// Token: 0x0600FE73 RID: 65139 RVA: 0x00465AD0 File Offset: 0x00463ED0
		private void _SetChildrenEnable(GameObject a_obj, bool a_bEnable)
		{
			for (int i = 0; i < a_obj.transform.childCount; i++)
			{
				a_obj.transform.GetChild(i).gameObject.SetActive(a_bEnable);
			}
		}

		// Token: 0x0600FE74 RID: 65140 RVA: 0x00465B10 File Offset: 0x00463F10
		private float _PlayAnims(DOTweenAnimation[] a_arrAnims)
		{
			float num = 0f;
			for (int i = 0; i < a_arrAnims.Length; i++)
			{
				a_arrAnims[i].isActive = true;
				if (a_arrAnims[i].tween == null)
				{
					a_arrAnims[i].CreateTween();
				}
				TweenExtensions.Restart(a_arrAnims[i].tween, true);
				float num2 = a_arrAnims[i].delay + a_arrAnims[i].duration;
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x0600FE75 RID: 65141 RVA: 0x00465B80 File Offset: 0x00463F80
		[UIEventHandle("Content/OkNode/Ok")]
		private void _OnConfirmClicked()
		{
			if (this.m_msgRet != null && this.m_msgRet.pkType == 3)
			{
				DataManager<BudoManager>.GetInstance().pkResult = this.m_ePKResult;
				DataManager<BudoManager>.GetInstance().ReturnFromPk = true;
			}
			DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = false;
			if (this.m_ePKResult == PKResult.WIN && DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.ChiJi)
			{
				this.frameMgr.CloseFrame<PKBattleResultFrame>(this, false);
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemGameBattle>(null, null, false);
			}
			else if (DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.ChiJi)
			{
				DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = true;
				this.frameMgr.CloseFrame<PKBattleResultFrame>(this, false);
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
			else
			{
				this.frameMgr.CloseFrame<PKBattleResultFrame>(this, false);
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
		}

		// Token: 0x0600FE76 RID: 65142 RVA: 0x00465C5E File Offset: 0x0046405E
		[UIEventHandle("Reporter")]
		private void _OnReporterClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKReporterFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FE77 RID: 65143 RVA: 0x00465C74 File Offset: 0x00464074
		protected override void _bindExUI()
		{
			this.mDescNode = this.mBind.GetGameObject("DescNode");
			this.mCounter = this.mBind.GetCom<ComCountScript>("TimerCounter");
			this.mOKButton = this.mBind.GetCom<Button>("OKButton");
		}

		// Token: 0x0600FE78 RID: 65144 RVA: 0x00465CC3 File Offset: 0x004640C3
		protected override void _unbindExUI()
		{
			this.mOKButton = null;
			this.mDescNode = null;
		}

		// Token: 0x0400A05E RID: 41054
		[UIObject("Content/TitleNode/Title/Win")]
		private GameObject m_objTitleWin;

		// Token: 0x0400A05F RID: 41055
		[UIObject("Content/TitleNode/Title/Fail")]
		private GameObject m_objTitleFail;

		// Token: 0x0400A060 RID: 41056
		[UIObject("Content/TitleNode/Title/Draw")]
		private GameObject m_objTitleDraw;

		// Token: 0x0400A061 RID: 41057
		[UIObject("Content/TitleNode/Title/Error")]
		private GameObject m_objTitleError;

		// Token: 0x0400A062 RID: 41058
		[UIObject("Content/TitleNode/Title/PromotionSuccess")]
		private GameObject m_objPromotionSuccess;

		// Token: 0x0400A063 RID: 41059
		[UIObject("Content/TitleNode/Title/PromotionFail")]
		private GameObject m_objPromotionFail;

		// Token: 0x0400A064 RID: 41060
		[UIObject("Content/RankNode/RankRoot")]
		private GameObject m_objRankRoot;

		// Token: 0x0400A065 RID: 41061
		[UIObject("Content/PromotionNode")]
		private GameObject m_objPromotionRoot;

		// Token: 0x0400A066 RID: 41062
		[UIObject("Content/PromotionNode/Records")]
		private GameObject m_objRecordRoot;

		// Token: 0x0400A067 RID: 41063
		[UIObject("Content/PromotionNode/Records")]
		private GameObject m_objRecordConetnt;

		// Token: 0x0400A068 RID: 41064
		[UIObject("Content/PromotionNode/Records/Template")]
		private GameObject m_objRecordTemplate;

		// Token: 0x0400A069 RID: 41065
		[UIControl("Content/PromotionNode/Desc", null, 0)]
		private Text m_labPromotionDesc;

		// Token: 0x0400A06A RID: 41066
		[UIObject("Content/DescNode/DescGroup")]
		private GameObject m_objDescRoot;

		// Token: 0x0400A06B RID: 41067
		[UIObject("Content/DescNode/DescGroup/Text")]
		private GameObject m_objDescTemplate;

		// Token: 0x0400A06C RID: 41068
		[UIObject("Content/DescNode/DescGroup/UpTxt")]
		private GameObject m_objDescUpTxt;

		// Token: 0x0400A06D RID: 41069
		[UIObject("Content/DescNode/DescGroup/MiddleTxt")]
		private GameObject m_objDescMiddleTxt;

		// Token: 0x0400A06E RID: 41070
		[UIControl("Content/RankNode/Score", null, 0)]
		private Text m_labScore;

		// Token: 0x0400A06F RID: 41071
		[UIObject("Reporter")]
		private GameObject m_reportBtn;

		// Token: 0x0400A070 RID: 41072
		private ComPKRank m_comPKRank;

		// Token: 0x0400A071 RID: 41073
		private PKBattleResultData m_msgRet;

		// Token: 0x0400A072 RID: 41074
		private PromotionInfo m_promotionInfo;

		// Token: 0x0400A073 RID: 41075
		private PKResult m_ePKResult = PKResult.INVALID;

		// Token: 0x0400A074 RID: 41076
		private Coroutine m_corShowDesc;

		// Token: 0x0400A075 RID: 41077
		private bool mNeedUpdateAutoClose;

		// Token: 0x0400A076 RID: 41078
		private float mAutoCloseTimer;

		// Token: 0x0400A077 RID: 41079
		private float mAutoCloseTimerAcc = 10f;

		// Token: 0x0400A078 RID: 41080
		private List<GameObject> arrObjDescs;

		// Token: 0x0400A079 RID: 41081
		private GameObject mDescNode;

		// Token: 0x0400A07A RID: 41082
		private ComCountScript mCounter;

		// Token: 0x0400A07B RID: 41083
		private Button mOKButton;
	}
}
