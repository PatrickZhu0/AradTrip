using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F0D RID: 3853
	public class ComPKRank : MonoBehaviour
	{
		// Token: 0x06009660 RID: 38496 RVA: 0x001C7684 File Offset: 0x001C5A84
		public static ComPKRank Create(GameObject a_objParent)
		{
			if (a_objParent == null)
			{
				Logger.LogError("ComPKRank Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/Pk/PKRankTwo", true, 0U);
			if (gameObject != null)
			{
				ComPKRank component = gameObject.GetComponent<ComPKRank>();
				if (component != null)
				{
					component.gameObject.transform.SetParent(a_objParent.transform, false);
					return component;
				}
			}
			return null;
		}

		// Token: 0x06009661 RID: 38497 RVA: 0x001C76F4 File Offset: 0x001C5AF4
		public static ComPKRank CreateTwo(GameObject a_objParent)
		{
			if (a_objParent == null)
			{
				Logger.LogError("ComPKRank Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/Pk/PKRank", true, 0U);
			if (gameObject != null)
			{
				ComPKRank component = gameObject.GetComponent<ComPKRank>();
				if (component != null)
				{
					component.gameObject.transform.SetParent(a_objParent.transform, false);
					return component;
				}
			}
			return null;
		}

		// Token: 0x06009662 RID: 38498 RVA: 0x001C7764 File Offset: 0x001C5B64
		private void Awake()
		{
			this.m_arrRankUpAnims.Clear();
			this.m_arrRankDownAnims.Clear();
			this.m_arrRankNormalAnims.Clear();
			Component[] componentsInChildren = base.gameObject.GetComponentsInChildren(typeof(DOTweenAnimation));
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				DOTweenAnimation dotweenAnimation = componentsInChildren[i] as DOTweenAnimation;
				if (dotweenAnimation != null)
				{
					if (dotweenAnimation.id == ComPKRank.ms_strAnimRankUpTag)
					{
						this.m_arrRankUpAnims.Add(dotweenAnimation);
						dotweenAnimation.isActive = false;
					}
					else if (dotweenAnimation.id == ComPKRank.ms_strAnimRankDownTag)
					{
						this.m_arrRankDownAnims.Add(dotweenAnimation);
						dotweenAnimation.isActive = false;
					}
					else
					{
						this.m_arrRankNormalAnims.Add(dotweenAnimation);
						dotweenAnimation.isActive = false;
					}
				}
			}
		}

		// Token: 0x06009663 RID: 38499 RVA: 0x001C783E File Offset: 0x001C5C3E
		private void OnValidate()
		{
			if (this.test)
			{
				this.StartRankChange(this.startID, this.startStar, this.startExp, this.endID, this.endStar, this.endExp);
				this.test = false;
			}
		}

		// Token: 0x06009664 RID: 38500 RVA: 0x001C787C File Offset: 0x001C5C7C
		public void Initialize(int a_nRankID, int a_nExp)
		{
			this._SetupRank(a_nRankID, a_nExp, false);
		}

		// Token: 0x06009665 RID: 38501 RVA: 0x001C7887 File Offset: 0x001C5C87
		public void Clear()
		{
			if (this.IsRankChanging())
			{
				this.StopRankChange();
			}
			if (this.m_iterRankNormal != null)
			{
				base.StopCoroutine(this.m_iterRankNormal);
				this.m_iterRankNormal = null;
			}
		}

		// Token: 0x06009666 RID: 38502 RVA: 0x001C78B8 File Offset: 0x001C5CB8
		public void StartRankChange(int a_nStartRankID, int a_nStartStar, int a_nStartExp, int a_nEndRankID, int a_nEndStar, int a_nEndExp)
		{
			this.StopRankChange();
			if (Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nStartRankID, string.Empty, string.Empty) == null || Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nEndRankID, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (a_nStartRankID > a_nEndRankID)
			{
				this.m_iterRankDecrease = base.StartCoroutine(this._DecreaseRank(a_nStartRankID, a_nStartExp, a_nEndRankID, a_nEndExp));
			}
			else if (a_nStartRankID < a_nEndRankID)
			{
				this.m_iterRankIncrease = base.StartCoroutine(this._IncreaseRank(a_nStartRankID, a_nStartExp, a_nEndRankID, a_nEndExp));
			}
			else if (a_nStartExp > a_nEndExp)
			{
				this.m_iterRankDecrease = base.StartCoroutine(this._DecreaseRank(a_nStartRankID, a_nStartExp, a_nEndRankID, a_nEndExp));
			}
			else if (a_nStartExp < a_nEndExp)
			{
				this.m_iterRankIncrease = base.StartCoroutine(this._IncreaseRank(a_nStartRankID, a_nStartExp, a_nEndRankID, a_nEndExp));
			}
			else
			{
				this._SetupRank(a_nEndRankID, a_nEndExp, false);
			}
		}

		// Token: 0x06009667 RID: 38503 RVA: 0x001C79A0 File Offset: 0x001C5DA0
		public void StopRankChange()
		{
			if (this.m_iterRankIncrease != null)
			{
				base.StopCoroutine(this.m_iterRankIncrease);
				this.m_iterRankIncrease = null;
			}
			if (this.m_iterRankDecrease != null)
			{
				base.StopCoroutine(this.m_iterRankDecrease);
				this.m_iterRankDecrease = null;
			}
		}

		// Token: 0x06009668 RID: 38504 RVA: 0x001C79DE File Offset: 0x001C5DDE
		public bool IsRankChanging()
		{
			return this.m_iterRankIncrease != null || this.m_iterRankDecrease != null;
		}

		// Token: 0x06009669 RID: 38505 RVA: 0x001C79FA File Offset: 0x001C5DFA
		public bool IsRankIncreasing()
		{
			return this.m_iterRankIncrease != null;
		}

		// Token: 0x0600966A RID: 38506 RVA: 0x001C7A08 File Offset: 0x001C5E08
		public bool IsRankDecreasing()
		{
			return this.m_iterRankDecrease != null;
		}

		// Token: 0x0600966B RID: 38507 RVA: 0x001C7A18 File Offset: 0x001C5E18
		private IEnumerator _IncreaseRank(int a_nStartRankID, int a_nStartExp, int a_nEndRankID, int a_nEndExp)
		{
			this._SetupRank(a_nStartRankID, a_nStartExp, false);
			yield return Yielders.EndOfFrame;
			int nNewExp = a_nStartExp;
			SeasonLevelTable oldRank = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nStartRankID, string.Empty, string.Empty);
			while (oldRank != null)
			{
				SeasonLevelTable newRank = null;
				if (oldRank.ID >= a_nEndRankID)
				{
					newRank = oldRank;
				}
				else
				{
					newRank = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(oldRank.AfterId, string.Empty, string.Empty);
				}
				if (newRank != null)
				{
					if (oldRank.MainLevel < newRank.MainLevel)
					{
						SeasonLevelTable newTableData = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(newRank.ID, string.Empty, string.Empty);
						string strEffectCtrl = (newRank.ID < DataManager<SeasonDataManager>.GetInstance().GetMaxRankID()) ? "EffectUpMainLevel" : "EffectUpMaxLevel";
						ComEffectController controller = Utility.GetComponetInChild<ComEffectController>(base.gameObject, strEffectCtrl);
						if (controller != null)
						{
							controller.Clear();
							controller.RegisterEvent(EEffectEvent.SeasonLevel_StartChangeLevel, delegate
							{
								this._ClearAllStars();
							});
							controller.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelIcon, delegate
							{
								this._SetupRankIcon(newTableData);
							});
							controller.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelName, delegate
							{
								this._SetupRankName(newTableData);
							});
							controller.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelStar, delegate
							{
								this._SetupRankStars(newTableData, true);
							});
							controller.RegisterEvent(EEffectEvent.SeasonLevel_FinishChangeLevel, delegate
							{
								this._SetupRankStars(newTableData, false);
							});
							controller.Play();
							yield return Yielders.GetWaitForSeconds(controller.Duration());
						}
					}
					else
					{
						if (oldRank.MainLevel != newRank.MainLevel)
						{
							Logger.LogErrorFormat("【段位表】错误  ID:{0}的大段位 > 下一个段位ID:{1}的大段位！", new object[]
							{
								oldRank.ID,
								oldRank.AfterId
							});
							break;
						}
						if (oldRank.SmallLevel > newRank.SmallLevel)
						{
							SeasonLevelTable newTableData = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(newRank.ID, string.Empty, string.Empty);
							ComEffectController controller2 = Utility.GetComponetInChild<ComEffectController>(base.gameObject, "EffectUpSubLevel");
							if (controller2 != null)
							{
								controller2.Clear();
								controller2.RegisterEvent(EEffectEvent.SeasonLevel_StartChangeLevel, delegate
								{
									this._ClearAllStars();
								});
								controller2.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelIcon, delegate
								{
									this._SetupRankIcon(newTableData);
								});
								controller2.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelName, delegate
								{
									this._SetupRankName(newTableData);
								});
								controller2.RegisterEvent(EEffectEvent.SeasonLevel_ChangeLevelStar, delegate
								{
									this._SetupRankStars(newTableData, true);
								});
								controller2.RegisterEvent(EEffectEvent.SeasonLevel_FinishChangeLevel, delegate
								{
									this._SetupRankStars(newTableData, false);
								});
								controller2.Play();
								yield return Yielders.GetWaitForSeconds(controller2.Duration());
							}
						}
						else
						{
							if (newRank.SmallLevel != oldRank.SmallLevel)
							{
								Logger.LogErrorFormat("【段位表】错误 ID:{0}的小段位 > 下一个段位ID:{1}的小段位！", new object[]
								{
									oldRank.ID,
									oldRank.AfterId
								});
								break;
							}
							if (oldRank.Star < newRank.Star)
							{
								nNewExp = oldRank.MaxExp;
								yield return this._ShowIncreaseExp(nNewExp, oldRank.MaxExp);
								yield return this._ShowIncreaseStar(newRank.Star - 1);
								nNewExp = 0;
								yield return this._ShowIncreaseExp(nNewExp, newRank.MaxExp);
							}
							else
							{
								if (newRank.Star != oldRank.Star)
								{
									Logger.LogErrorFormat("【段位表】错误 ID:{0}的星星 > 下一个段位ID:{1}的星星！", new object[]
									{
										oldRank.ID,
										oldRank.AfterId
									});
									break;
								}
								nNewExp = a_nEndExp;
								yield return this._ShowIncreaseExp(a_nEndExp, newRank.MaxExp);
							}
						}
					}
					if (newRank.ID >= a_nEndRankID && nNewExp >= a_nEndExp)
					{
						break;
					}
					oldRank = newRank;
				}
				else if (oldRank.AfterId != 0)
				{
					Logger.LogErrorFormat("【段位表】错误 ID:{0}的下一个段位ID:{1}不存在！", new object[]
					{
						oldRank.ID,
						oldRank.AfterId
					});
					break;
				}
			}
			this.m_iterRankIncrease = null;
			yield break;
		}

		// Token: 0x0600966C RID: 38508 RVA: 0x001C7A50 File Offset: 0x001C5E50
		private IEnumerator _ShowIncreaseExp(int a_nExp, int a_nMaxExp)
		{
			float fProgress = (float)a_nExp / (float)a_nMaxExp;
			if (fProgress < 0f)
			{
				fProgress = 0f;
			}
			else if (fProgress > 1f)
			{
				fProgress = 1f;
			}
			while (this.sliderExp.value < fProgress)
			{
				float fValue = this.sliderExp.value + this.expSpeed * Time.deltaTime;
				if (fValue >= 1f)
				{
					this.sliderExp.value = 1f;
					this.labExp.text = string.Format("{0}/{1}", a_nMaxExp, a_nMaxExp);
					break;
				}
				this.sliderExp.value = fValue;
				this.labExp.text = string.Format("{0}/{1}", (int)(fValue * (float)a_nMaxExp), a_nMaxExp);
				yield return Yielders.EndOfFrame;
			}
			this.sliderExp.value = fProgress;
			this.labExp.text = string.Format("{0}/{1}", a_nExp, a_nMaxExp);
			if (this.sliderExp.value >= 1f)
			{
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			yield break;
		}

		// Token: 0x0600966D RID: 38509 RVA: 0x001C7A7C File Offset: 0x001C5E7C
		private IEnumerator _ShowIncreaseStar(int a_nIdx)
		{
			if (a_nIdx >= 0 && a_nIdx < this.rectStarRoot.childCount)
			{
				GameObject objRoot = this.rectStarRoot.GetChild(a_nIdx).gameObject;
				GameObject objEffect = Utility.FindGameObject(objRoot, ComPKRank.ms_strGetStarEffect, false);
				if (objEffect == null)
				{
					objEffect = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(ComPKRank.ms_strGetStarEffectPath, true, 0U);
					objEffect.transform.SetParent(objRoot.transform, false);
					objEffect.name = ComPKRank.ms_strGetStarEffect;
				}
				objEffect.SetActive(true);
				yield return Yielders.GetWaitForSeconds(this.starEffectTime);
				MonoSingleton<AudioManager>.instance.PlaySound(17);
				Utility.FindGameObject(objRoot, "Light", true).SetActive(true);
			}
			yield return Yielders.GetWaitForSeconds(0.1f);
			yield break;
		}

		// Token: 0x0600966E RID: 38510 RVA: 0x001C7AA0 File Offset: 0x001C5EA0
		private IEnumerator _DecreaseRank(int a_nStartRankID, int a_nStartExp, int a_nEndRankID, int a_nEndExp)
		{
			this._SetupRank(a_nStartRankID, a_nStartExp, false);
			yield return Yielders.EndOfFrame;
			int nNewExp = a_nStartExp;
			SeasonLevelTable oldRank = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nStartRankID, string.Empty, string.Empty);
			while (oldRank != null)
			{
				SeasonLevelTable newRank = null;
				if (oldRank.ID <= a_nEndRankID)
				{
					newRank = oldRank;
				}
				else
				{
					newRank = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(oldRank.PreId, string.Empty, string.Empty);
				}
				if (newRank != null)
				{
					if (oldRank.MainLevel > newRank.MainLevel)
					{
						SeasonLevelTable newTableData = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(newRank.ID, string.Empty, string.Empty);
						nNewExp = 0;
						yield return this._ShowDecreaseExp(nNewExp, oldRank.MaxExp);
						yield return this._ShowDecreaseStar(oldRank.Star - 1);
						nNewExp = newRank.MaxExp;
						yield return this._ShowDecreaseExp(nNewExp, newRank.MaxExp);
						this._PlayParticles(Utility.FindGameObject(base.gameObject, "EffUI_shibai_da", true));
						yield return Yielders.GetWaitForSeconds(this.downAnimDelay);
						yield return Yielders.GetWaitForSeconds(this._PlayAnims(this.m_arrRankDownAnims));
						this._SetupRankIcon(newTableData);
						this._SetupRankStars(newTableData, false);
						this._RewindAnims(this.m_arrRankDownAnims);
						yield return Yielders.GetWaitForSeconds(this._PlayAnims(this.m_arrRankUpAnims));
						this._SetupRankName(newTableData);
						yield return Yielders.GetWaitForSeconds(0.5f);
						this._StopEffect();
					}
					else
					{
						if (newRank.MainLevel != oldRank.MainLevel)
						{
							Logger.LogErrorFormat("【段位表】错误 ID:{0}的大段位 < 上一个段位ID:{1}的大段位！", new object[]
							{
								oldRank.ID,
								oldRank.PreId
							});
							break;
						}
						if (newRank.SmallLevel > oldRank.SmallLevel)
						{
							SeasonLevelTable newTableData2 = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(newRank.ID, string.Empty, string.Empty);
							nNewExp = 0;
							yield return this._ShowDecreaseExp(nNewExp, oldRank.MaxExp);
							yield return this._ShowDecreaseStar(oldRank.Star - 1);
							nNewExp = newRank.MaxExp;
							yield return this._ShowDecreaseExp(nNewExp, newRank.MaxExp);
							this._PlayParticles(Utility.FindGameObject(base.gameObject, "EffUI_shibai_xiao", true));
							yield return Yielders.GetWaitForSeconds(this.downAnimDelay);
							yield return Yielders.GetWaitForSeconds(this._PlayAnims(this.m_arrRankDownAnims));
							this._SetupRankIcon(newTableData2);
							this._SetupRankStars(newTableData2, false);
							this._RewindAnims(this.m_arrRankDownAnims);
							yield return Yielders.GetWaitForSeconds(this._PlayAnims(this.m_arrRankUpAnims));
							this._SetupRankName(newTableData2);
							yield return Yielders.GetWaitForSeconds(0.5f);
							this._StopEffect();
						}
						else
						{
							if (newRank.SmallLevel != oldRank.SmallLevel)
							{
								Logger.LogErrorFormat("【段位表】错误 ID:{0}的小段位 < 上一个段位ID:{1}的小段位！", new object[]
								{
									oldRank.ID,
									oldRank.PreId
								});
								break;
							}
							if (oldRank.Star > newRank.Star)
							{
								nNewExp = 0;
								yield return this._ShowDecreaseExp(nNewExp, oldRank.MaxExp);
								yield return this._ShowDecreaseStar(oldRank.Star - 1);
								nNewExp = newRank.MaxExp;
								yield return this._ShowDecreaseExp(nNewExp, newRank.MaxExp);
								yield return Yielders.GetWaitForSeconds(0.3f);
							}
							else
							{
								if (newRank.Star != oldRank.Star)
								{
									Logger.LogErrorFormat("【段位表】错误 ID:{0}的星星 < 上一个段位ID:{1}的星星！", new object[]
									{
										oldRank.ID,
										oldRank.PreId
									});
									break;
								}
								nNewExp = a_nEndExp;
								yield return this._ShowDecreaseExp(nNewExp, oldRank.MaxExp);
							}
						}
					}
					if (newRank.ID <= a_nEndRankID && nNewExp <= a_nEndExp)
					{
						break;
					}
					oldRank = newRank;
				}
				else if (oldRank.PreId != 0)
				{
					Logger.LogErrorFormat("【段位表】错误 ID:{0}的上一个段位ID:{1}不存在！", new object[]
					{
						oldRank.ID,
						oldRank.PreId
					});
					break;
				}
			}
			this.m_iterRankDecrease = null;
			yield break;
		}

		// Token: 0x0600966F RID: 38511 RVA: 0x001C7AD8 File Offset: 0x001C5ED8
		private IEnumerator _ShowDecreaseExp(int a_nExp, int a_nMaxExp)
		{
			float fProgress = (float)a_nExp / (float)a_nMaxExp;
			if (fProgress < 0f)
			{
				fProgress = 0f;
			}
			else if (fProgress > 1f)
			{
				fProgress = 1f;
			}
			while (this.sliderExp.value > fProgress)
			{
				float fValue = this.sliderExp.value - this.expSpeed * Time.deltaTime;
				if (fValue <= 0f)
				{
					this.sliderExp.value = 0f;
					this.labExp.text = string.Format("{0}/{1}", 0, a_nMaxExp);
					break;
				}
				this.sliderExp.value = fValue;
				this.labExp.text = string.Format("{0}/{1}", (int)(fValue * (float)a_nMaxExp), a_nMaxExp);
				yield return Yielders.EndOfFrame;
			}
			this.sliderExp.value = fProgress;
			this.labExp.text = string.Format("{0}/{1}", a_nExp, a_nMaxExp);
			if (this.sliderExp.value <= 0f)
			{
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			yield break;
		}

		// Token: 0x06009670 RID: 38512 RVA: 0x001C7B04 File Offset: 0x001C5F04
		private IEnumerator _ShowDecreaseStar(int a_nIdx)
		{
			if (a_nIdx >= 0 && a_nIdx < this.rectStarRoot.childCount)
			{
				GameObject objRoot = this.rectStarRoot.GetChild(a_nIdx).gameObject;
				GameObject objEffect = Utility.FindGameObject(objRoot, ComPKRank.ms_strLoseStarEffect, false);
				if (objEffect == null)
				{
					objEffect = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(ComPKRank.ms_strLoseStarEffectPath, true, 0U);
					objEffect.transform.SetParent(objRoot.transform, false);
					objEffect.name = ComPKRank.ms_strLoseStarEffect;
				}
				objEffect.SetActive(true);
				yield return Yielders.GetWaitForSeconds(this.starEffectTime);
				MonoSingleton<AudioManager>.instance.PlaySound(18);
				Utility.FindGameObject(objRoot, "Light", true).SetActive(false);
			}
			yield break;
		}

		// Token: 0x06009671 RID: 38513 RVA: 0x001C7B28 File Offset: 0x001C5F28
		private void _SetupRank(int a_nRankID, int a_nExp, bool bClearStar = false)
		{
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(a_nRankID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._SetupRankIcon(tableItem);
				this._SetupRankName(tableItem);
				this._SetupRankStars(tableItem, bClearStar);
				this._SetupRankExp(tableItem, a_nExp);
				if (DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo(a_nRankID, PKResult.INVALID).eState == EPromotionState.Promoting)
				{
					ComEffectController componetInChild = Utility.GetComponetInChild<ComEffectController>(base.gameObject, "EffectPromotion");
					if (componetInChild != null)
					{
						componetInChild.Clear();
						componetInChild.Play();
					}
				}
			}
			else
			{
				Logger.LogErrorFormat("段位表不存在段位ID：{0}", new object[]
				{
					a_nRankID
				});
			}
		}

		// Token: 0x06009672 RID: 38514 RVA: 0x001C7BCD File Offset: 0x001C5FCD
		private void _ClearAllStars()
		{
			this.objRankMaxRoot.SetActive(false);
			this.rectStarRoot.gameObject.SetActive(false);
		}

		// Token: 0x06009673 RID: 38515 RVA: 0x001C7BEC File Offset: 0x001C5FEC
		private void _SetupRankStars(SeasonLevelTable a_tableData, bool a_bOnlySlots)
		{
			if (a_tableData == null)
			{
				this.objRankMaxRoot.SetActive(false);
				this.rectStarRoot.gameObject.SetActive(false);
				return;
			}
			if (a_tableData.AfterId == 0)
			{
				this.objRankMaxRoot.SetActive(true);
				this.rectStarRoot.gameObject.SetActive(false);
				this.labRankMax.text = string.Format("x{0}", DataManager<SeasonDataManager>.GetInstance().seasonStar);
			}
			else
			{
				this.objRankMaxRoot.SetActive(false);
				this.rectStarRoot.gameObject.SetActive(true);
				for (int i = 0; i < this.rectStarRoot.childCount; i++)
				{
					this.rectStarRoot.GetChild(i).gameObject.SetActive(false);
				}
				for (int j = 0; j < a_tableData.MaxStar; j++)
				{
					GameObject gameObject = this.rectStarRoot.GetChild(j).gameObject;
					gameObject.SetActive(true);
					if (a_bOnlySlots)
					{
						Utility.FindGameObject(gameObject, "Light", true).SetActive(false);
					}
					else
					{
						Utility.FindGameObject(gameObject, "Light", true).SetActive(j + 1 <= a_tableData.Star);
					}
					GameObject gameObject2 = Utility.FindGameObject(gameObject, ComPKRank.ms_strGetStarEffect, false);
					if (gameObject2 != null)
					{
						gameObject2.SetActive(false);
					}
					GameObject gameObject3 = Utility.FindGameObject(gameObject, ComPKRank.ms_strLoseStarEffect, false);
					if (gameObject3 != null)
					{
						gameObject3.SetActive(false);
					}
				}
			}
		}

		// Token: 0x06009674 RID: 38516 RVA: 0x001C7D70 File Offset: 0x001C6170
		private void _SetupRankExp(SeasonLevelTable a_tableData, int a_nExp)
		{
			if (a_tableData == null)
			{
				this.sliderExp.value = 0f;
				this.labExp.text = string.Empty;
				return;
			}
			float num = (float)a_nExp / (float)a_tableData.MaxExp;
			if (num > 1f)
			{
				num = 1f;
			}
			if (num < 0f)
			{
				num = 0f;
			}
			this.sliderExp.value = num;
			this.labExp.text = string.Format("{0}/{1}", a_nExp, a_tableData.MaxExp);
		}

		// Token: 0x06009675 RID: 38517 RVA: 0x001C7E04 File Offset: 0x001C6204
		private void _SetupRankIcon(SeasonLevelTable a_tableData)
		{
			if (a_tableData == null)
			{
				this.imgRankIcon.gameObject.SetActive(false);
			}
			else
			{
				this.imgRankIcon.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref this.imgRankIcon, a_tableData.Icon, true);
			}
		}

		// Token: 0x06009676 RID: 38518 RVA: 0x001C7E51 File Offset: 0x001C6251
		private void _SetupRankName(SeasonLevelTable a_tableData)
		{
			if (a_tableData == null)
			{
				this.labRank.text = string.Empty;
			}
			else
			{
				this.labRank.text = DataManager<SeasonDataManager>.GetInstance().GetRankName(a_tableData.ID, true);
			}
		}

		// Token: 0x06009677 RID: 38519 RVA: 0x001C7E8C File Offset: 0x001C628C
		private void _PlayParticles(GameObject a_objRoot)
		{
			a_objRoot.SetActive(true);
			GeUIEffectParticle[] componentsInChildren = a_objRoot.GetComponentsInChildren<GeUIEffectParticle>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].StartEmit();
			}
		}

		// Token: 0x06009678 RID: 38520 RVA: 0x001C7EC4 File Offset: 0x001C62C4
		private void _StopEffect()
		{
			for (int i = 0; i < this.objEffects.Length; i++)
			{
				if (this.objEffects[i] != null)
				{
					this.objEffects[i].SetActive(false);
				}
			}
		}

		// Token: 0x06009679 RID: 38521 RVA: 0x001C7F0C File Offset: 0x001C630C
		private float _PlayAnims(List<DOTweenAnimation> a_arrAnims)
		{
			float num = 0f;
			for (int i = 0; i < a_arrAnims.Count; i++)
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

		// Token: 0x0600967A RID: 38522 RVA: 0x001C7F98 File Offset: 0x001C6398
		private void _RewindAnims(List<DOTweenAnimation> a_arrAnims)
		{
			for (int i = 0; i < a_arrAnims.Count; i++)
			{
				a_arrAnims[i].DORewind();
				a_arrAnims[i].isActive = false;
			}
		}

		// Token: 0x04004D33 RID: 19763
		public RectTransform rectStarRoot;

		// Token: 0x04004D34 RID: 19764
		public GameObject objStarTemplate;

		// Token: 0x04004D35 RID: 19765
		public Text labRank;

		// Token: 0x04004D36 RID: 19766
		public Image imgRankIcon;

		// Token: 0x04004D37 RID: 19767
		public GameObject objRankMaxRoot;

		// Token: 0x04004D38 RID: 19768
		public Text labRankMax;

		// Token: 0x04004D39 RID: 19769
		public Slider sliderExp;

		// Token: 0x04004D3A RID: 19770
		public Text labExp;

		// Token: 0x04004D3B RID: 19771
		public GameObject[] objEffects = new GameObject[0];

		// Token: 0x04004D3C RID: 19772
		public bool test;

		// Token: 0x04004D3D RID: 19773
		public int startID = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();

		// Token: 0x04004D3E RID: 19774
		public int startStar;

		// Token: 0x04004D3F RID: 19775
		public int startExp;

		// Token: 0x04004D40 RID: 19776
		public int endID = 14505;

		// Token: 0x04004D41 RID: 19777
		public int endStar;

		// Token: 0x04004D42 RID: 19778
		public int endExp;

		// Token: 0x04004D43 RID: 19779
		public float starEffectTime = 0.45f;

		// Token: 0x04004D44 RID: 19780
		public float textChangeDelay = 0.25f;

		// Token: 0x04004D45 RID: 19781
		public float upAnimDelay = 0.5f;

		// Token: 0x04004D46 RID: 19782
		public float downAnimDelay = 0.5f;

		// Token: 0x04004D47 RID: 19783
		public float expSpeed = 1f;

		// Token: 0x04004D48 RID: 19784
		private static float ms_fStarAngleInterval = 45f;

		// Token: 0x04004D49 RID: 19785
		private static string ms_strGetStarEffectPath = "Effects/Scene_effects/EffectUI/EffUI_ui_xing";

		// Token: 0x04004D4A RID: 19786
		private static string ms_strGetStarEffect = "GetEffect";

		// Token: 0x04004D4B RID: 19787
		private static string ms_strLoseStarEffectPath = "Effects/Scene_effects/EffectUI/EffUI_ui_xingjiang";

		// Token: 0x04004D4C RID: 19788
		private static string ms_strLoseStarEffect = "LoseEffect";

		// Token: 0x04004D4D RID: 19789
		private static string ms_strAnimRankUpTag = "shengduan";

		// Token: 0x04004D4E RID: 19790
		private static string ms_strAnimRankDownTag = "jiangduan";

		// Token: 0x04004D4F RID: 19791
		private static string ms_strAnimNormalTag = "tongyong";

		// Token: 0x04004D50 RID: 19792
		private Coroutine m_iterRankIncrease;

		// Token: 0x04004D51 RID: 19793
		private Coroutine m_iterRankDecrease;

		// Token: 0x04004D52 RID: 19794
		private Coroutine m_iterRankNormal;

		// Token: 0x04004D53 RID: 19795
		private List<DOTweenAnimation> m_arrRankUpAnims = new List<DOTweenAnimation>();

		// Token: 0x04004D54 RID: 19796
		private List<DOTweenAnimation> m_arrRankDownAnims = new List<DOTweenAnimation>();

		// Token: 0x04004D55 RID: 19797
		private List<DOTweenAnimation> m_arrRankNormalAnims = new List<DOTweenAnimation>();
	}
}
