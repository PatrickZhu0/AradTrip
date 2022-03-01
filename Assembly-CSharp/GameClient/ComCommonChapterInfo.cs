using System;
using System.Collections;
using System.Collections.Generic;
using ActivityLimitTime;
using Battle;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EA3 RID: 3747
	public class ComCommonChapterInfo : MonoBehaviour, IChapterInfoCommon, IChapterInfoDiffculte, IChapterInfoDrops, IChapterPassReward, IChapterScore, IChapterMonsterInfo, IChapterProcess, IChapterInfoDrugs, IChapterDungeonMap, IChapterNodeState, IChapterConsume, IChapterActivityTimes, IChapterMask
	{
		// Token: 0x060093DF RID: 37855 RVA: 0x001B9E42 File Offset: 0x001B8242
		public void SetActivityTimes(int id)
		{
			if (null != this.mCommonConsumeResumeLeftTimes)
			{
				this.mCommonConsumeResumeLeftTimes.SetData(ComCommonConsume.eType.Count, ComCommonConsume.eCountType.MouCount, id);
			}
		}

		// Token: 0x060093E0 RID: 37856 RVA: 0x001B9E64 File Offset: 0x001B8264
		public void SetFatigueConsume(int value, bool isLimit, int dungonID)
		{
			GameObject gameObject = this.mConsume.GetGameObject("fatigueroot");
			if (value > 0)
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungonID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				GameObject gameObject2 = this.mConsume.GetGameObject("Icon1");
				bool flag = false;
				ActivityLimitTimeData activityLimitTimeData = null;
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.FindFatigueCombustionActivityIsOpen(ref flag, ref activityLimitTimeData);
				Text com = this.mConsume.GetCom<Text>("fatigue");
				if (isLimit)
				{
					com.text = string.Format(">{0}", value);
				}
				else
				{
					if (tableItem.CostFatiguePerArea == value)
					{
						com.text = string.Format("{0}", value);
					}
					else
					{
						com.text = string.Format("{0}~{1}", tableItem.CostFatiguePerArea, value);
					}
					gameObject2.CustomActive(false);
					if (flag && activityLimitTimeData != null && !TeamUtility.IsEliteDungeonID(dungonID))
					{
						bool flag2 = false;
						for (int i = 0; i < activityLimitTimeData.activityDetailDataList.Count; i++)
						{
							if (activityLimitTimeData.activityDetailDataList[i].ActivityDetailState == ActivityTaskState.Finished)
							{
								flag2 = true;
							}
						}
						bool flag3 = tableItem.SubType == DungeonTable.eSubType.S_NORMAL;
						if (flag2 && flag3)
						{
							gameObject2.CustomActive(true);
							if (tableItem.CostFatiguePerArea * 2 == value * 2)
							{
								com.text = TR.Value("fatigue_combustion_fatiguedouble2", value * 2);
							}
							else
							{
								com.text = TR.Value("fatigue_combustion_fatiguedouble", tableItem.CostFatiguePerArea * 2, value * 2);
							}
						}
					}
				}
				if (TeamUtility.IsEliteDungeonID(dungonID) && DataManager<TeamDataManager>.GetInstance().IsNotCostFatigueInEliteDungeon)
				{
					com.text = "0";
				}
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		// Token: 0x060093E1 RID: 37857 RVA: 0x001BA06C File Offset: 0x001B846C
		public void SetHellConsume(string stext, int value, string spritePath, bool ishell)
		{
			GameObject gameObject = this.mConsume.GetGameObject("hellroot");
			Text com = this.mConsume.GetCom<Text>("name");
			Image com2 = this.mConsume.GetCom<Image>("icon");
			com.text = stext;
			if (spritePath == null || spritePath.Length <= 0)
			{
				com2.sprite = null;
			}
			else
			{
				ETCImageLoader.LoadSprite(ref com2, spritePath, true);
			}
			if (value > 0)
			{
				Text com3 = this.mConsume.GetCom<Text>("hell");
				com3.text = string.Format("{0}", value);
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		// Token: 0x060093E2 RID: 37858 RVA: 0x001BA11C File Offset: 0x001B851C
		public void SetChapterState(eChapterNodeState[] state, int[] limitLevel)
		{
			this.difficultyUnlockDic.Clear();
			bool value = false;
			for (int i = 0; i < this.mDiffCommonBind.Length; i++)
			{
				ComCommonBind comCommonBind = this.mDiffCommonBind[i];
				GameObject gameObject = comCommonBind.GetGameObject("scoreroot");
				GameObject gameObject2 = comCommonBind.GetGameObject("failroot");
				GameObject gameObject3 = comCommonBind.GetGameObject("passroot");
				GameObject gameObject4 = comCommonBind.GetGameObject("diffimageroot");
				GameObject gameObject5 = comCommonBind.GetGameObject("reclevelroot");
				GameObject gameObject6 = comCommonBind.GetGameObject("levelRoot");
				Image com = comCommonBind.GetCom<Image>("bg");
				GameObject gameObject7 = comCommonBind.GetGameObject("root");
				Text com2 = comCommonBind.GetCom<Text>("levelRootLevel");
				if (gameObject7 != null)
				{
					gameObject7.CustomActive(true);
				}
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
				}
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(false);
				}
				if (gameObject3 != null)
				{
					gameObject3.CustomActive(false);
				}
				if (gameObject5 != null)
				{
					gameObject5.CustomActive(true);
				}
				if (gameObject6 != null)
				{
					gameObject6.CustomActive(false);
				}
				if (i < limitLevel.Length && com2 != null)
				{
					com2.text = limitLevel[i].ToString();
				}
				if (i < state.Length)
				{
					switch (state[i])
					{
					case eChapterNodeState.Miss:
						if (gameObject7 != null)
						{
							gameObject7.CustomActive(false);
						}
						break;
					case eChapterNodeState.Lock:
						if (gameObject3 != null)
						{
							gameObject3.CustomActive(true);
						}
						value = false;
						break;
					case eChapterNodeState.LockLevel:
						if (gameObject6 != null)
						{
							gameObject6.CustomActive(true);
						}
						value = false;
						break;
					case eChapterNodeState.Unlock:
						if (gameObject2 != null)
						{
							gameObject2.CustomActive(true);
						}
						value = true;
						break;
					case eChapterNodeState.Passed:
						if (gameObject != null)
						{
							gameObject.CustomActive(true);
						}
						value = true;
						break;
					}
					this.difficultyUnlockDic.Add(i, value);
				}
			}
		}

		// Token: 0x060093E3 RID: 37859 RVA: 0x001BA33C File Offset: 0x001B873C
		public void SetChapterScore(DungeonScore[] score)
		{
			if (null == this.mResBind)
			{
				return;
			}
			for (int i = 0; i < this.mDiffCommonBind.Length; i++)
			{
				ComCommonBind comCommonBind = this.mDiffCommonBind[i];
				GameObject gameObject = comCommonBind.GetGameObject("scoreImage0");
				GameObject gameObject2 = comCommonBind.GetGameObject("scoreImage1");
				GameObject gameObject3 = comCommonBind.GetGameObject("scoreImage2");
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
				Image component = gameObject.GetComponent<Image>();
				Image component2 = gameObject2.GetComponent<Image>();
				Image component3 = gameObject3.GetComponent<Image>();
				comCommonBind.GetSprite("s", ref component);
				comCommonBind.GetSprite("s", ref component2);
				comCommonBind.GetSprite("s", ref component3);
				if (i < score.Length)
				{
					switch (score[i])
					{
					case DungeonScore.C:
					case DungeonScore.B:
					case DungeonScore.A:
					{
						gameObject.SetActive(true);
						Image component4 = gameObject.GetComponent<Image>();
						comCommonBind.GetSprite("a", ref component4);
						break;
					}
					case DungeonScore.S:
						gameObject.SetActive(true);
						break;
					case DungeonScore.SS:
						gameObject.SetActive(true);
						gameObject2.SetActive(true);
						break;
					case DungeonScore.SSS:
						gameObject.SetActive(true);
						gameObject2.SetActive(true);
						gameObject3.SetActive(true);
						break;
					}
				}
			}
		}

		// Token: 0x060093E4 RID: 37860 RVA: 0x001BA485 File Offset: 0x001B8885
		public void SetDungeonMap(IDungeonData data)
		{
			if (null != this.mDungeonMap)
			{
				this.mDungeonMap.SetDungeonData(data);
			}
		}

		// Token: 0x060093E5 RID: 37861 RVA: 0x001BA4A4 File Offset: 0x001B88A4
		public void SetBuffDrugs(IList<int> drugs)
		{
			if (null != this.mChapterInfoDrug)
			{
				this.mChapterInfoDrug.SetBuffDrugs(drugs);
			}
		}

		// Token: 0x060093E6 RID: 37862 RVA: 0x001BA4C4 File Offset: 0x001B88C4
		public void UpDateCost(bool isOn, DungeonID dungeonID)
		{
			this.mCostInfoRoot.CustomActive(isOn);
			if (null != this.mCostInfoText)
			{
				List<CostItemManager.CostInfo> allMarkedBuffDrugsCost = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsCost(dungeonID.dungeonID);
				int num = 0;
				for (int i = 0; i < allMarkedBuffDrugsCost.Count; i++)
				{
					num += allMarkedBuffDrugsCost[i].nCount;
				}
				if (num == 0)
				{
					this.mCostInfoRoot.CustomActive(false);
				}
				this.mCostInfoText.text = num.ToString();
			}
		}

		// Token: 0x060093E7 RID: 37863 RVA: 0x001BA554 File Offset: 0x001B8954
		public void SetBuffDrugsInfo(IList<int> buffDrugList)
		{
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
			BeEntityData entityData = BeUtility.GetMainPlayerActor(false, null, SkillSystemSourceType.None).GetEntityData();
			BattleData battleData = entityData.battleData;
			if (buffDrugList.Count < 4)
			{
				return;
			}
			if (this.infoText.Length < 4)
			{
				return;
			}
			this._setAttackInfo(this.infoText[0], mainPlayerActorAttribute.attack, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugList[0]));
			this._setAttackInfo(this.infoText[1], mainPlayerActorAttribute.magicAttack, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugList[0]));
			this._setHpInfo(this.infoText[2], battleData, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugList[1]));
			this._setPercentInfo(this.infoText[3], DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugList[2]));
			this._setPercentInfo(this.infoText[4], DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugList[3]));
		}

		// Token: 0x060093E8 RID: 37864 RVA: 0x001BA644 File Offset: 0x001B8A44
		private void _setAttackInfo(Text infoText, float attack, bool isOn)
		{
			int id;
			int.TryParse(infoText.gameObject.name, out id);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int onUseBuffId = tableItem.OnUseBuffId;
			BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			int fixValue = tableItem2.attack.fixValue;
			int fixValue2 = tableItem2.attackAddRate.fixValue;
			if (isOn)
			{
				infoText.text = "+" + this._floatToInt((attack + (float)fixValue) * (1f + (float)fixValue2 / (float)GlobalLogic.VALUE_1000) - attack).ToString();
				infoText.color = Color.green;
			}
			else
			{
				infoText.text = TR.Value("chapter_value_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x060093E9 RID: 37865 RVA: 0x001BA734 File Offset: 0x001B8B34
		private void _setHpInfo(Text infoText, BattleData bData, bool isOn)
		{
			if (isOn)
			{
				int id;
				int.TryParse(infoText.gameObject.name, out id);
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				int onUseBuffId = tableItem.OnUseBuffId;
				BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				int fixValue = tableItem2.maxHp.fixValue;
				int fixValue2 = tableItem2.maxHpAddRate.fixValue;
				int num = this._floatToInt((float)(bData.fMaxHp + fixValue) * (1f + (float)fixValue2 / (float)GlobalLogic.VALUE_1000) - (float)bData.fMaxHp);
				int fMaxHp = bData.fMaxHp;
				bData._maxHp += fixValue;
				bData._maxHp += IntMath.Float2Int((float)bData._maxHp * ((float)fixValue2 / (float)GlobalLogic.VALUE_1000));
				int num2 = bData.fMaxHp - fMaxHp;
				infoText.text = TR.Value("chapter_buffdrug_hpdisplay", num, num2);
			}
			else
			{
				infoText.text = TR.Value("chapter_value_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x060093EA RID: 37866 RVA: 0x001BA884 File Offset: 0x001B8C84
		private void _setPercentInfo(Text infoText, bool isOn)
		{
			int id;
			int.TryParse(infoText.gameObject.name, out id);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int onUseBuffId = tableItem.OnUseBuffId;
			BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			int num = (tableItem2.ciriticalAttack.fixValue != 0) ? tableItem2.ciriticalAttack.fixValue : tableItem2.dodge.fixValue;
			if (isOn)
			{
				infoText.text = TR.Value("chapter_percent_string", num / 10);
				infoText.color = Color.green;
			}
			else
			{
				infoText.text = TR.Value("chapter_percent_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x060093EB RID: 37867 RVA: 0x001BA964 File Offset: 0x001B8D64
		private int _floatToInt(float f)
		{
			int result;
			if (f > 0f)
			{
				result = (int)(f * 10f + 5f) / 10;
			}
			else if (f < 0f)
			{
				result = (int)(f * 10f - 5f) / 10;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x060093EC RID: 37868 RVA: 0x001BA9BA File Offset: 0x001B8DBA
		private void Awake()
		{
			this._initDiffculte();
		}

		// Token: 0x060093ED RID: 37869 RVA: 0x001BA9C4 File Offset: 0x001B8DC4
		public void SetName(string name)
		{
			if (null != this.mName)
			{
				this.mName.text = name;
			}
			if (null != this.mResBind)
			{
				Text com = this.mResBind.GetCom<Text>("title");
				if (null != com)
				{
					com.text = name;
				}
			}
		}

		// Token: 0x060093EE RID: 37870 RVA: 0x001BAA23 File Offset: 0x001B8E23
		public void SetDescription(string desc)
		{
			if (null != this.mDescription)
			{
				this.mDescription.text = desc;
			}
		}

		// Token: 0x060093EF RID: 37871 RVA: 0x001BAA42 File Offset: 0x001B8E42
		public void SetRecommnedLevel(string level)
		{
			if (null != this.mRecommondLevel)
			{
				this.mRecommondLevel.text = level;
			}
		}

		// Token: 0x060093F0 RID: 37872 RVA: 0x001BAA64 File Offset: 0x001B8E64
		public void SetRecommnedLevel(string[] level)
		{
			for (int i = 0; i < this.mDiffCommonBind.Length; i++)
			{
				Text com = this.mDiffCommonBind[i].GetCom<Text>("reclevel");
				if (i < level.Length)
				{
					com.text = level[i];
				}
				else
				{
					com.text = string.Empty;
				}
			}
		}

		// Token: 0x060093F1 RID: 37873 RVA: 0x001BAABF File Offset: 0x001B8EBF
		public void SetRecommnedWeapon(string weapon)
		{
			if (null != this.mRecommondWeapon)
			{
				this.mRecommondWeapon.text = weapon;
			}
		}

		// Token: 0x060093F2 RID: 37874 RVA: 0x001BAADE File Offset: 0x001B8EDE
		public void SetOpenTime(string opentime)
		{
			if (null != this.mOpenTime)
			{
				this.mOpenTime.text = opentime;
			}
		}

		// Token: 0x060093F3 RID: 37875 RVA: 0x001BAAFD File Offset: 0x001B8EFD
		public void SetDropList(IList<int> drops, int dungonID)
		{
			if (null != this.mComItemList)
			{
				this.mComItemList.SetItems(drops);
			}
			if (null != this.mComChapterInfoDrop)
			{
				this.mComChapterInfoDrop.SetDropList(drops, dungonID);
			}
		}

		// Token: 0x060093F4 RID: 37876 RVA: 0x001BAB3A File Offset: 0x001B8F3A
		public void UpdateDropCount(List<ComItemList.Items> drops)
		{
			if (null != this.mComItemList)
			{
				this.mComItemList.SetItems(drops.ToArray());
			}
		}

		// Token: 0x060093F5 RID: 37877 RVA: 0x001BAB60 File Offset: 0x001B8F60
		private void _initDiffculte()
		{
			for (int i = 0; i < this.mDiffList.Length; i++)
			{
				int idx = i;
				this.mDiffList[i].onValueChanged.AddListener(delegate(bool isOn)
				{
					if (isOn && this.mCallback != null)
					{
						try
						{
							this.mCallback(idx);
						}
						catch (Exception ex)
						{
							Logger.LogErrorFormat("SetDiffculteCallback error e : {0}", new object[]
							{
								ex.ToString()
							});
						}
					}
				});
			}
		}

		// Token: 0x060093F6 RID: 37878 RVA: 0x001BABB8 File Offset: 0x001B8FB8
		public GameObject GetDiffculteRoot()
		{
			return this.mDiffRoot;
		}

		// Token: 0x060093F7 RID: 37879 RVA: 0x001BABC0 File Offset: 0x001B8FC0
		public void SetActiveDiffculteByIdx(int idx, bool enabled)
		{
			int num = this.mDiffList.Length;
			if (idx >= 0 && idx < num)
			{
				this.mDiffList[idx].gameObject.SetActive(enabled);
			}
		}

		// Token: 0x060093F8 RID: 37880 RVA: 0x001BABF7 File Offset: 0x001B8FF7
		public void SetDiffculteCallback(ChapterDiffCallback cb)
		{
			this.mCallback = cb;
		}

		// Token: 0x060093F9 RID: 37881 RVA: 0x001BAC00 File Offset: 0x001B9000
		public void SetLevelLimite(int[] limit)
		{
			int i = 0;
			while (i < this.mAllDiffText.Length && i < limit.Length)
			{
				if (this.mAllDiffText[i] != null)
				{
					this.mAllDiffText[i].text = string.Format("{0}", limit[i]);
				}
				i++;
			}
			for (i = limit.Length; i < this.mAllDiffText.Length; i++)
			{
				if (this.mAllDiffText[i] != null)
				{
					this.mAllDiffText[i].text = string.Empty;
				}
			}
		}

		// Token: 0x060093FA RID: 37882 RVA: 0x001BACA4 File Offset: 0x001B90A4
		public void SetLevelDescription(string[] descs)
		{
			int i = 0;
			while (i < this.mAllDiffDesc.Length && i < descs.Length)
			{
				if (this.mAllDiffDesc[i] != null)
				{
					this.mAllDiffDesc[i].text = descs[i];
				}
				i++;
			}
			for (i = descs.Length; i < this.mAllDiffDesc.Length; i++)
			{
				if (this.mAllDiffDesc[i] != null)
				{
					this.mAllDiffDesc[i].text = string.Empty;
				}
			}
		}

		// Token: 0x060093FB RID: 37883 RVA: 0x001BAD38 File Offset: 0x001B9138
		public void SetTopDiffculte(int top)
		{
			int num = this.mDiffList.Length;
			if (num > 0)
			{
				top = Mathf.Clamp(top, 0, num - 1);
				for (int i = 0; i <= top; i++)
				{
					this.mDiffList[i].interactable = true;
				}
				for (int j = top + 1; j < num; j++)
				{
					this.mDiffList[j].interactable = false;
				}
			}
		}

		// Token: 0x060093FC RID: 37884 RVA: 0x001BADA4 File Offset: 0x001B91A4
		public int GetDiffculte()
		{
			for (int i = 0; i < this.mDiffList.Length; i++)
			{
				if (this.mDiffList[i].isOn)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x060093FD RID: 37885 RVA: 0x001BADE0 File Offset: 0x001B91E0
		private int _getExpRate(int diff)
		{
			int[] array = new int[]
			{
				0,
				10,
				20,
				50
			};
			return array[diff % 4];
		}

		// Token: 0x060093FE RID: 37886 RVA: 0x001BAE04 File Offset: 0x001B9204
		private int _getGlodRate(int diff)
		{
			int[] array = new int[]
			{
				0,
				5,
				10,
				20
			};
			return array[diff % 4];
		}

		// Token: 0x060093FF RID: 37887 RVA: 0x001BAE28 File Offset: 0x001B9228
		public void SetDiffculte(int diff, int dungeonId)
		{
			int num = this.mDiffList.Length;
			if (diff < num && diff >= 0)
			{
				this.mDiffList[diff].isOn = true;
			}
			this.UpdateDiffInfo(dungeonId);
		}

		// Token: 0x06009400 RID: 37888 RVA: 0x001BAE61 File Offset: 0x001B9261
		public void SetLock(bool isLock)
		{
			if (this.mDiffUnlock)
			{
				this.mDiffUnlock.SetActive(!isLock);
			}
			if (this.mDiffLock)
			{
				this.mDiffLock.SetActive(isLock);
			}
		}

		// Token: 0x06009401 RID: 37889 RVA: 0x001BAEA0 File Offset: 0x001B92A0
		public void UpdateDiffInfo(int dungeonId)
		{
			for (int i = 0; i < this.mDiffList.Length; i++)
			{
				if (this.mDiffList[i].isOn)
				{
					if (null != this.mDiffName)
					{
						this.mDiffName.text = this.mDiffNameList[i].text;
					}
					if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(dungeonId))
					{
						if (null != this.mDiffExpRate)
						{
							this.mDiffExpRate.text = this._getExpRate(i).ToString();
						}
						if (null != this.mDiffGlodRate)
						{
							this.mDiffGlodRate.text = 200.ToString();
						}
					}
					else
					{
						if (null != this.mDiffExpRate)
						{
							this.mDiffExpRate.text = this._getExpRate(i).ToString();
						}
						if (null != this.mDiffGlodRate)
						{
							this.mDiffGlodRate.text = this._getGlodRate(i).ToString();
						}
					}
					if (null != this.mDiffLastDiff && i > 0)
					{
						this.mDiffLastDiff.text = this.mDiffNameList[i - 1].text;
					}
					if (null != this.mDiffPassUnlock)
					{
						this.mDiffPassUnlock.text = this.mDiffUnlockScore[i];
					}
					if (this.groupStartEffectGameObject != null)
					{
						bool bActive = false;
						this.difficultyUnlockDic.TryGetValue(i, out bActive);
						this.groupStartEffectGameObject.CustomActive(bActive);
					}
				}
			}
		}

		// Token: 0x06009402 RID: 37890 RVA: 0x001BB060 File Offset: 0x001B9460
		private void _setItem(DungeonItem.eType type, ComItem item, int num)
		{
			ItemConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemConfigTable>((int)type, string.Empty, string.Empty);
			int itemID = tableItem.ItemID;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData != null)
			{
				itemData.CanSell = false;
				itemData.UseType = ItemTable.eCanUse.CanNot;
				itemData.Count = num;
				item.SetActive(true);
				item.Setup(itemData, delegate(GameObject go, ItemData data)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(data, null, 4, true, false, true);
				});
			}
			else
			{
				Logger.LogError("DropItem not found with id : " + itemID);
			}
		}

		// Token: 0x06009403 RID: 37891 RVA: 0x001BB0F4 File Offset: 0x001B94F4
		public void SetExp(int num)
		{
			if (null != this.mExp)
			{
				this._setItem(DungeonItem.eType.Exp, this.mExp, num);
			}
		}

		// Token: 0x06009404 RID: 37892 RVA: 0x001BB119 File Offset: 0x001B9519
		public void SetGold(int num)
		{
			if (null != this.mGlod)
			{
				this._setItem(DungeonItem.eType.Glod, this.mGlod, num);
			}
		}

		// Token: 0x06009405 RID: 37893 RVA: 0x001BB13E File Offset: 0x001B953E
		public void SetHitCount(int cnt)
		{
			if (null != this.mHitCount)
			{
				this.mHitCount.text = cnt.ToString();
			}
		}

		// Token: 0x06009406 RID: 37894 RVA: 0x001BB169 File Offset: 0x001B9569
		public void SetRebornCount(int cnt)
		{
			if (null != this.mRebornCount)
			{
				this.mRebornCount.text = cnt.ToString();
			}
		}

		// Token: 0x06009407 RID: 37895 RVA: 0x001BB194 File Offset: 0x001B9594
		public void SetFightTime(int time)
		{
			if (null != this.mFightTime)
			{
				this.mFightTime.SetTime(time);
			}
		}

		// Token: 0x06009408 RID: 37896 RVA: 0x001BB1B3 File Offset: 0x001B95B3
		public void SetPassed(bool isPassed)
		{
		}

		// Token: 0x06009409 RID: 37897 RVA: 0x001BB1B5 File Offset: 0x001B95B5
		public void SetBestScore(DungeonScore score)
		{
			if (null != this.mScore)
			{
				this.mScore.SetScore(score);
			}
		}

		// Token: 0x0600940A RID: 37898 RVA: 0x001BB1D4 File Offset: 0x001B95D4
		public GameObject GetScoreRoot()
		{
			return this.mScoreRoot;
		}

		// Token: 0x0600940B RID: 37899 RVA: 0x001BB1DC File Offset: 0x001B95DC
		public void SetMonsterList(List<int> monsters)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < monsters.Count; i++)
			{
				if (!list.Contains(monsters[i]))
				{
					UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(monsters[i], string.Empty, string.Empty);
					if (tableItem != null && tableItem.IsShowPortrait > 0)
					{
						if (tableItem.Type == UnitTable.eType.BOSS)
						{
							list.Insert(0, monsters[i]);
						}
						else
						{
							list.Add(monsters[i]);
						}
					}
				}
			}
			int num = list.Count - 1;
			if (num < 0)
			{
				return;
			}
			int j = 0;
			int num2 = 0;
			while (j < this.mMonsterList.Length)
			{
				if (num2 >= list.Count)
				{
					this.mMonsterList[j].SetVisible(false);
				}
				else
				{
					this.mMonsterList[j].SetMonster(list[num2++]);
				}
				j++;
			}
		}

		// Token: 0x0600940C RID: 37900 RVA: 0x001BB2E0 File Offset: 0x001B96E0
		public GameObject GetProcessRoot()
		{
			if (null != this.mProcessBind && null != this.mProcessBind.transform.parent)
			{
				return this.mProcessBind.transform.parent.gameObject;
			}
			return null;
		}

		// Token: 0x0600940D RID: 37901 RVA: 0x001BB330 File Offset: 0x001B9730
		private void _loadProcessUnit(GameObject root, string spriteName, string name, bool showFlag = false)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UI/Prefabs/Chapter/ChapterNormalProcessUnit", true, 0U);
			Utility.AttachTo(gameObject, root, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (null != component)
			{
				Image com = component.GetCom<Image>("image");
				this.mProcessBind.GetSprite(spriteName, ref com);
				com.SetNativeSize();
				Text com2 = component.GetCom<Text>("num");
				com2.text = name;
				GameObject gameObject2 = component.GetGameObject("current");
				gameObject2.SetActive(showFlag);
			}
		}

		// Token: 0x0600940E RID: 37902 RVA: 0x001BB3B4 File Offset: 0x001B97B4
		private void _loadProcessGap(GameObject root)
		{
			GameObject gameObject = new GameObject();
			LayoutElement layoutElement = gameObject.AddComponent<LayoutElement>();
			layoutElement.flexibleWidth = 1f;
			layoutElement.flexibleHeight = 1f;
			Utility.AttachTo(gameObject, root, false);
		}

		// Token: 0x0600940F RID: 37903 RVA: 0x001BB3EC File Offset: 0x001B97EC
		private string _getShowSprite(ComChapterDungeonUnit.eState state, bool flag)
		{
			if (state != ComChapterDungeonUnit.eState.Passed && state != ComChapterDungeonUnit.eState.LockPassed)
			{
				return (!flag) ? "prelock" : "normallock";
			}
			return (!flag) ? "prepass" : "normalpass";
		}

		// Token: 0x06009410 RID: 37904 RVA: 0x001BB42C File Offset: 0x001B982C
		public void SetProcess(int id, int[] presList)
		{
			if (presList == null)
			{
				presList = new int[0];
			}
			DungeonID dungeonID = new DungeonID(id);
			dungeonID.diffID = 0;
			int num = presList.Length;
			for (int i = 0; i < presList.Length; i++)
			{
				if (presList[i] == dungeonID.dungeonID)
				{
					num = i;
				}
			}
			if (null != this.mProcessBind)
			{
				GameObject gameObject = this.mProcessBind.GetGameObject("root");
				for (int j = 0; j < presList.Length; j++)
				{
					ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(presList[j]);
					string spriteName = this._getShowSprite(dungeonState, num == j);
					this._loadProcessUnit(gameObject, spriteName, string.Format("{0}", j + 1), num == j);
					this._loadProcessGap(gameObject);
				}
				dungeonID.prestoryID = 0;
				ComChapterDungeonUnit.eState dungeonState2 = ChapterUtility.GetDungeonState(dungeonID.dungeonID);
				string spriteName2 = this._getShowSprite(dungeonState2, num == presList.Length);
				this._loadProcessUnit(gameObject, spriteName2, string.Format("{0}", presList.Length + 1), num == presList.Length);
				Slider com = this.mProcessBind.GetCom<Slider>("slider");
				com.value = (float)num * 1f / (float)presList.Length;
			}
		}

		// Token: 0x06009411 RID: 37905 RVA: 0x001BB568 File Offset: 0x001B9968
		public void SetChapterMask(int dungeonID)
		{
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			if (ComCommonChapterInfo._isAllDiffNoScores(dungeonID) && ChapterUtility.PreconditionIDList(dungeonID2.dungeonIDWithOutPrestory).Count != 0)
			{
				if (!PlayerPrefs.HasKey(this._getChapterOnceFinishBossString(dungeonID2.dungeonIDWithOutDiff)))
				{
					PlayerPrefs.SetInt(this._getChapterOnceFinishBossString(dungeonID2.dungeonIDWithOutDiff), 1);
				}
				this._showChapterMask(dungeonID, true);
			}
			else if (PlayerPrefs.HasKey(this._getChapterOnceFinishBossString(dungeonID2.dungeonIDWithOutDiff)))
			{
				this._showChapterMask(dungeonID, false);
				base.StartCoroutine(this._playFinishEffect());
				PlayerPrefs.DeleteKey(this._getChapterOnceFinishBossString(dungeonID2.dungeonIDWithOutDiff));
			}
		}

		// Token: 0x06009412 RID: 37906 RVA: 0x001BB610 File Offset: 0x001B9A10
		private void _showChapterMask(int dungeonID, bool isShowNewEffect)
		{
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			IList<int> list = ChapterUtility.PreconditionIDList(dungeonID2.dungeonIDWithOutPrestory);
			int num = list.Count + 1;
			int num2 = list.Count / 4;
			int num3 = list.IndexOf(dungeonID) + 1;
			if (num3 >= 1 && num3 <= num2 * 4)
			{
				int num4 = (num3 - 1) / 4;
				int startIndex = num4 * 4 + 1;
				int dungeonIndex = num3 - 4 * num4;
				this._showMaskItem(4, startIndex, dungeonIndex, false, isShowNewEffect);
			}
			else
			{
				int num5 = num - 4 * num2;
				int startIndex2 = 4 * num2 + 1;
				int dungeonIndex2;
				if (num3 == 0)
				{
					dungeonIndex2 = num5;
				}
				else
				{
					dungeonIndex2 = num3 % 4;
				}
				this._showMaskItem(num5, startIndex2, dungeonIndex2, true, isShowNewEffect);
			}
		}

		// Token: 0x06009413 RID: 37907 RVA: 0x001BB6BC File Offset: 0x001B9ABC
		private void _hideChapterMask()
		{
			Image com = this.mResBind.GetCom<Image>("BackgroundGray");
			com.gameObject.CustomActive(false);
			UIGray com2 = this.mResBind.GetCom<UIGray>("BackgroundUIGray");
			com2.gameObject.CustomActive(false);
			RectTransform com3 = this.mResBind.GetCom<RectTransform>("ChapterMask");
			com3.gameObject.CustomActive(false);
			for (int i = 0; i < this.mBarList.Length; i++)
			{
				this.mBarList[i].bar.CustomActive(false);
			}
		}

		// Token: 0x06009414 RID: 37908 RVA: 0x001BB750 File Offset: 0x001B9B50
		private IEnumerator _playFinishEffect()
		{
			this.LoadEffect("Effects/UI/Prefab/EffUI_juqingguanka/Prefab/EffUI_juqingguanka_hetu", this.mFinishPuzzleEffect);
			this.mFinishPuzzleEffect.CustomActive(true);
			this.mRefuse.CustomActive(true);
			yield return new WaitForSeconds((this.barDieTime <= 0f) ? 0f : this.barDieTime);
			this._hideChapterMask();
			yield return new WaitForSeconds((this.pauseTime - this.barDieTime <= 0f) ? 0f : (this.pauseTime - this.barDieTime));
			this.mFinishPuzzleEffect.CustomActive(false);
			this.mRefuse.CustomActive(false);
			yield break;
		}

		// Token: 0x06009415 RID: 37909 RVA: 0x001BB76C File Offset: 0x001B9B6C
		private void _showMaskItem(int type, int startIndex, int dungeonIndex, bool showBoss, bool isShowNewEffect)
		{
			Image com = this.mResBind.GetCom<Image>("Background");
			Image com2 = this.mResBind.GetCom<Image>("CharactorIcon");
			Image com3 = this.mResBind.GetCom<Image>("BackgroundGray");
			Image com4 = this.mResBind.GetCom<Image>("CharactorGray");
			UIGray com5 = this.mResBind.GetCom<UIGray>("BackgroundUIGray");
			RectTransform com6 = this.mResBind.GetCom<RectTransform>("ChapterMask");
			com5.enabled = false;
			com3.sprite = com.sprite;
			com3.material = com.material;
			com4.sprite = com2.sprite;
			com4.material = com2.material;
			com4.rectTransform.sizeDelta = com2.rectTransform.sizeDelta;
			com5.enabled = true;
			com6.gameObject.CustomActive(true);
			Utility.AttachTo(com.gameObject, com3.transform.parent.gameObject, false);
			float x = com.rectTransform.sizeDelta.x;
			float y = com.rectTransform.sizeDelta.y;
			string text = "Effects/UI/Prefab/EffUI_juqingguanka/Prefab/EffUI_juqingguanka_kuang";
			switch (type)
			{
			case 0:
				com6.gameObject.CustomActive(false);
				break;
			case 1:
				com6.gameObject.CustomActive(false);
				break;
			case 2:
				if (dungeonIndex == 1)
				{
					com6.sizeDelta = new Vector2(x / 2f, y);
					com6.anchoredPosition = new Vector3(x / 4f, -y / 2f, 0f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 2)
				{
					com6.gameObject.CustomActive(false);
				}
				break;
			case 3:
				if (dungeonIndex == 1)
				{
					com6.sizeDelta = new Vector2(x / 2f, y / 2f);
					com6.anchoredPosition = new Vector3(x / 4f, -y / 4f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 2)
				{
					com6.sizeDelta = new Vector2(x / 2f, y);
					com6.anchoredPosition = new Vector2(x / 4f, -y / 2f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 3)
				{
					com6.gameObject.CustomActive(false);
				}
				if (type != dungeonIndex)
				{
					text += "2";
				}
				break;
			case 4:
				if (dungeonIndex == 1)
				{
					com6.sizeDelta = new Vector2(x * 89f / 456f, y);
					com6.anchoredPosition = new Vector3(x * 44f / 456f, -y / 2f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 2)
				{
					com6.sizeDelta = new Vector2(x * 185f / 456f, y);
					com6.anchoredPosition = new Vector3(x * 93f / 456f, -y / 2f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 3)
				{
					com6.sizeDelta = new Vector2(x * 278f / 456f, y);
					com6.anchoredPosition = new Vector3(x * 139f / 456f, -y / 2f);
					Utility.AttachTo(com.gameObject, com6.gameObject, false);
				}
				if (dungeonIndex == 4)
				{
					com6.gameObject.CustomActive(false);
				}
				if (type != dungeonIndex)
				{
					text += "3";
				}
				else
				{
					text += "4";
				}
				break;
			default:
				com6.gameObject.CustomActive(false);
				break;
			}
			if (type != 0 && type != 1 && null != this.mBarList[type - 1].posList[dungeonIndex - 1] && isShowNewEffect)
			{
				this.LoadEffect(text, this.mBarList[type - 1].posList[dungeonIndex - 1]);
			}
			for (int i = 0; i < this.mBarList.Length; i++)
			{
				if (type != i + 1)
				{
					this.mBarList[i].bar.CustomActive(false);
				}
				else
				{
					this.mBarList[i].bar.CustomActive(true);
					for (int j = 0; j < type; j++)
					{
						this.mBarList[i].numList[j].text = (startIndex + j).ToString();
						if (type == j + 1 && showBoss && null != this.mBarList[i].posList[j] && isShowNewEffect)
						{
							this.LoadEffect("Effects/UI/Prefab/EffUI_juqingguanka/Prefab/map_boss", this.mBarList[i].posList[j]);
						}
						if (dungeonIndex == j + 1 && null != this.mBarList[i].posList[j] && isShowNewEffect)
						{
							this.LoadEffect("Effects/UI/Prefab/EffUI_juqingguanka/Prefab/player_main", this.mBarList[i].posList[j]);
						}
					}
				}
			}
			if (!showBoss)
			{
				com2.gameObject.CustomActive(false);
				com4.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06009416 RID: 37910 RVA: 0x001BBD48 File Offset: 0x001BA148
		private void LoadEffect(string effectPath, GameObject parent)
		{
			if (string.IsNullOrEmpty(effectPath) || null == parent)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(effectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, parent, false);
			}
		}

		// Token: 0x06009417 RID: 37911 RVA: 0x001BBD90 File Offset: 0x001BA190
		public void SetBarState(int diffID)
		{
			GameObject gameObject = this.mResBind.GetGameObject("BarListRoot");
			if (null != gameObject)
			{
				if (diffID == 0)
				{
					gameObject.CustomActive(true);
				}
				else
				{
					gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06009418 RID: 37912 RVA: 0x001BBDD4 File Offset: 0x001BA1D4
		public static bool _isAllDiffNoScores(int dungeonID)
		{
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(dungeonID);
			for (int i = 0; i <= dungeonTopHard; i++)
			{
				dungeonID2.diffID = i;
				if (ChapterUtility.GetDungeonBestScore(dungeonID2.dungeonID) != DungeonScore.C)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009419 RID: 37913 RVA: 0x001BBE1C File Offset: 0x001BA21C
		private string _getChapterOnceFinishBossString(int dungeonID)
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (ClientApplication.playerinfo != null)
			{
				arg = ClientApplication.playerinfo.serverID.ToString();
			}
			if (DataManager<PlayerBaseData>.GetInstance() != null)
			{
				arg2 = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
			}
			return TR.Value("chapter_has_prestory_and_once_finish_boss", arg, arg2, dungeonID);
		}

		// Token: 0x04004ABF RID: 19135
		public ComCommonConsume mCommonConsumeResumeLeftTimes;

		// Token: 0x04004AC0 RID: 19136
		public ComCommonBind mResBind;

		// Token: 0x04004AC1 RID: 19137
		public ComCommonBind mConsume;

		// Token: 0x04004AC2 RID: 19138
		public ComCommonBind[] mDiffCommonBind = new ComCommonBind[0];

		// Token: 0x04004AC3 RID: 19139
		private Dictionary<int, bool> difficultyUnlockDic = new Dictionary<int, bool>();

		// Token: 0x04004AC4 RID: 19140
		public ComChapterDungeonMap mDungeonMap;

		// Token: 0x04004AC5 RID: 19141
		public ComChapterInfoDrug mChapterInfoDrug;

		// Token: 0x04004AC6 RID: 19142
		public GameObject mCostInfoRoot;

		// Token: 0x04004AC7 RID: 19143
		public Text mCostInfoText;

		// Token: 0x04004AC8 RID: 19144
		public Text[] infoText;

		// Token: 0x04004AC9 RID: 19145
		public Text mName;

		// Token: 0x04004ACA RID: 19146
		public Text mDescription;

		// Token: 0x04004ACB RID: 19147
		public Text mRecommondLevel;

		// Token: 0x04004ACC RID: 19148
		public Text mRecommondWeapon;

		// Token: 0x04004ACD RID: 19149
		public Text mOpenTime;

		// Token: 0x04004ACE RID: 19150
		public ComItemList mComItemList;

		// Token: 0x04004ACF RID: 19151
		public ComChapterInfoDrop mComChapterInfoDrop;

		// Token: 0x04004AD0 RID: 19152
		public ChapterDiffCallback mCallback;

		// Token: 0x04004AD1 RID: 19153
		public Toggle[] mDiffList = new Toggle[0];

		// Token: 0x04004AD2 RID: 19154
		public GameObject mDiffRoot;

		// Token: 0x04004AD3 RID: 19155
		public Text[] mAllDiffText = new Text[0];

		// Token: 0x04004AD4 RID: 19156
		public Text[] mAllDiffDesc = new Text[0];

		// Token: 0x04004AD5 RID: 19157
		public Text mDiffName;

		// Token: 0x04004AD6 RID: 19158
		public Text mDiffExpRate;

		// Token: 0x04004AD7 RID: 19159
		public Text mDiffGlodRate;

		// Token: 0x04004AD8 RID: 19160
		public Text mDiffPassUnlock;

		// Token: 0x04004AD9 RID: 19161
		public Text mDiffLastDiff;

		// Token: 0x04004ADA RID: 19162
		public Text[] mDiffNameList;

		// Token: 0x04004ADB RID: 19163
		public string[] mDiffUnlockScore;

		// Token: 0x04004ADC RID: 19164
		public GameObject mDiffUnlock;

		// Token: 0x04004ADD RID: 19165
		public GameObject mDiffLock;

		// Token: 0x04004ADE RID: 19166
		public ComItem mExp;

		// Token: 0x04004ADF RID: 19167
		public ComItem mGlod;

		// Token: 0x04004AE0 RID: 19168
		public Text mHitCount;

		// Token: 0x04004AE1 RID: 19169
		public Text mRebornCount;

		// Token: 0x04004AE2 RID: 19170
		public ComTime mFightTime;

		// Token: 0x04004AE3 RID: 19171
		public ComChapterDungeonScore mScore;

		// Token: 0x04004AE4 RID: 19172
		public GameObject mScoreRoot;

		// Token: 0x04004AE5 RID: 19173
		public ComMonsterItem[] mMonsterList;

		// Token: 0x04004AE6 RID: 19174
		public ComCommonBind mProcessBind;

		// Token: 0x04004AE7 RID: 19175
		private const string kProcessNodePath = "UI/Prefabs/Chapter/ChapterNormalProcessUnit";

		// Token: 0x04004AE8 RID: 19176
		[SerializeField]
		private float barDieTime;

		// Token: 0x04004AE9 RID: 19177
		[SerializeField]
		private float pauseTime;

		// Token: 0x04004AEA RID: 19178
		[SerializeField]
		private ComCommonChapterInfo.ChapterPuzzle[] mBarList;

		// Token: 0x04004AEB RID: 19179
		[SerializeField]
		private GameObject mFinishPuzzleEffect;

		// Token: 0x04004AEC RID: 19180
		[SerializeField]
		private GameObject mRefuse;

		// Token: 0x04004AED RID: 19181
		private const string nowEffectPath = "Effects/UI/Prefab/EffUI_juqingguanka/Prefab/EffUI_juqingguanka_kuang";

		// Token: 0x04004AEE RID: 19182
		public GameObject groupStartEffectGameObject;

		// Token: 0x02000EA4 RID: 3748
		private enum PuzzleType
		{
			// Token: 0x04004AF1 RID: 19185
			None,
			// Token: 0x04004AF2 RID: 19186
			One,
			// Token: 0x04004AF3 RID: 19187
			Two,
			// Token: 0x04004AF4 RID: 19188
			Three,
			// Token: 0x04004AF5 RID: 19189
			Four
		}

		// Token: 0x02000EA5 RID: 3749
		[Serializable]
		public struct ChapterPuzzle
		{
			// Token: 0x04004AF6 RID: 19190
			public GameObject bar;

			// Token: 0x04004AF7 RID: 19191
			public Text[] numList;

			// Token: 0x04004AF8 RID: 19192
			public GameObject[] posList;
		}
	}
}
