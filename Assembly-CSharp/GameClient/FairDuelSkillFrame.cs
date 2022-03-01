using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001361 RID: 4961
	public class FairDuelSkillFrame : ClientFrame
	{
		// Token: 0x0600C068 RID: 49256 RVA: 0x002D643F File Offset: 0x002D483F
		public Dictionary<ushort, byte> GetChangeList()
		{
			return this.mChangeList;
		}

		// Token: 0x0600C069 RID: 49257 RVA: 0x002D6447 File Offset: 0x002D4847
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			if (this.mSkillPlaneView != null)
			{
				this.mSkillPlaneView.InitGiveUpDrog();
			}
		}

		// Token: 0x0600C06A RID: 49258 RVA: 0x002D6474 File Offset: 0x002D4874
		protected override void _OnCloseFrame()
		{
			if (this.mSkillPosList != null)
			{
				this.mSkillPosList.Clear();
			}
			if (this.mUniqueSkillTreeGo != null)
			{
				this.mUniqueSkillTreeGo = null;
			}
			if (this.mSkillPosPanelIndexList != null)
			{
				this.mSkillPosPanelIndexList.Clear();
			}
			if (this.mUniqueSkillTransNameList != null)
			{
				this.mUniqueSkillTransNameList.Clear();
			}
			this.UnBindUIEvent();
		}

		// Token: 0x0600C06B RID: 49259 RVA: 0x002D64E1 File Offset: 0x002D48E1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FairDuel/FairDuelSkillFrame";
		}

		// Token: 0x0600C06C RID: 49260 RVA: 0x002D64E8 File Offset: 0x002D48E8
		protected override void _bindExUI()
		{
			this.mCloseBtn = this.mBind.GetCom<Button>("Close");
			this.mDownLvBtn = this.mBind.GetCom<Button>("btLvDown");
			this.mUpLvBtn = this.mBind.GetCom<Button>("btLvUp");
			this.mSkillPlanBtn = this.mBind.GetCom<Button>("btSkillPlan");
			this.mInitSkillBarBtn = this.mBind.GetCom<Button>("skillInitButton");
			this.mCommandSkillBarBtn = this.mBind.GetCom<Button>("skillConfigButton");
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			if (this.mDownLvBtn != null)
			{
				this.mDownLvBtn.onClick.AddListener(new UnityAction(this.OnDownLvBtnClick));
			}
			if (this.mUpLvBtn != null)
			{
				this.mUpLvBtn.onClick.AddListener(new UnityAction(this.OnUpLvBtnClick));
			}
			if (this.mSkillPlanBtn != null)
			{
				this.mSkillPlanBtn.onClick.AddListener(new UnityAction(this.OnShowSkillPlaneClick));
			}
			if (this.mInitSkillBarBtn != null)
			{
				this.mInitSkillBarBtn.onClick.AddListener(new UnityAction(this.OnInitSkillBarBtnClick));
			}
			if (this.mCommandSkillBarBtn != null)
			{
				this.mCommandSkillBarBtn.onClick.AddListener(new UnityAction(this.OnCommandBarBtnClick));
			}
			this.mTotalSpTxt = this.mBind.GetCom<Text>("totalSp");
			this.mSkillTreeRoot = this.mBind.GetGameObject("root");
			this.mSkillInfoRoot = this.mBind.GetGameObject("RightRoot");
			this.mSelectSkillImg = this.mBind.GetCom<Image>("skillIcon");
			this.mSelectSkillNameTxt = this.mBind.GetCom<Text>("name");
			this.mSelectSkillAddLvTxt = this.mBind.GetCom<Text>("addlevel");
			this.mSelectSkillLvTxt = this.mBind.GetCom<Text>("rightLevel");
			this.mLevelMaxImage = this.mBind.GetCom<Image>("MaxImage");
			this.mLevelLimitDesTxt = this.mBind.GetCom<Text>("levelLimitState");
			this.mNeedLevelTxt = this.mBind.GetCom<Text>("needLevel");
			this.mSelectDesTxt = this.mBind.GetCom<Text>("SelectSkillDesTxt");
			this.mSelectTypeTxt = this.mBind.GetCom<Text>("SelectSkillTypeTxt");
			this.mSelectCDTxt = this.mBind.GetCom<Text>("skillCDNum");
			this.mSelectSkillConsumeMPTxt = this.mBind.GetCom<Text>("skillConsumeMPText");
			this.mSelectSkillConsumeThingTxt = this.mBind.GetCom<Text>("skillConsumeThingText");
			this.mSelectSkillNeedSpTxt = this.mBind.GetCom<Text>("needSP");
			this.mSelectCurSkillAttriTxt = this.mBind.GetCom<Text>("SelectCurSkillAttriTxt");
			this.mSelectNextSkillAttriTxt = this.mBind.GetCom<Text>("SelectNextSkillAttriTxt");
			this.mSkillBtnRootGo = this.mBind.GetGameObject("SkillBtnRootGo");
			this.mAttributeGoArry[0] = this.mBind.GetGameObject("Type0");
			this.mAttributeGoArry[1] = this.mBind.GetGameObject("Type1");
			this.mAttributeGoArry[2] = this.mBind.GetGameObject("Type2");
			this.mAttributeGoArry[3] = this.mBind.GetGameObject("Type3");
			this.mAttributeGoArry[4] = this.mBind.GetGameObject("Type4");
			this.mAttributeGoArry[5] = this.mBind.GetGameObject("Type5");
			this.mAttributeTypeTxtArry[0] = this.mBind.GetCom<Text>("Text0");
			this.mAttributeTypeTxtArry[1] = this.mBind.GetCom<Text>("Text1");
			this.mAttributeTypeTxtArry[2] = this.mBind.GetCom<Text>("Text2");
			this.mAttributeTypeTxtArry[3] = this.mBind.GetCom<Text>("Text3");
			this.mAttributeTypeTxtArry[4] = this.mBind.GetCom<Text>("Text4");
			this.mAttributeTypeTxtArry[5] = this.mBind.GetCom<Text>("Text5");
			this.mSkillPlaneView = this.mBind.GetCom<FairDuelPlaneSkillView>("FairDuelSkillPlan");
			this.mSkillPanelBtnRoot = this.mBind.GetGameObject("skillInitConfigRoot");
			this.mTipGo = this.mBind.GetGameObject("tips");
			this.mTipTxt = this.mBind.GetCom<Text>("TipTxt");
			this.mSkillPlaneBtnTxt = this.mBind.GetCom<Text>("btnSkillPlanBtnTxt");
		}

		// Token: 0x0600C06D RID: 49261 RVA: 0x002D69B8 File Offset: 0x002D4DB8
		protected override void _unbindExUI()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
				this.mCloseBtn = null;
			}
			if (this.mDownLvBtn != null)
			{
				this.mDownLvBtn.onClick.RemoveListener(new UnityAction(this.OnDownLvBtnClick));
				this.mDownLvBtn = null;
			}
			if (this.mUpLvBtn != null)
			{
				this.mUpLvBtn.onClick.RemoveListener(new UnityAction(this.OnUpLvBtnClick));
				this.mUpLvBtn = null;
			}
			if (this.mSkillPlanBtn != null)
			{
				this.mSkillPlanBtn.onClick.RemoveListener(new UnityAction(this.OnShowSkillPlaneClick));
				this.mSkillPlanBtn = null;
			}
			if (this.mInitSkillBarBtn != null)
			{
				this.mInitSkillBarBtn.onClick.RemoveListener(new UnityAction(this.OnInitSkillBarBtnClick));
				this.mInitSkillBarBtn = null;
			}
			if (this.mCommandSkillBarBtn != null)
			{
				this.mCommandSkillBarBtn.onClick.RemoveListener(new UnityAction(this.OnCommandBarBtnClick));
				this.mCommandSkillBarBtn = null;
			}
			if (this.mTotalSpTxt != null)
			{
				this.mTotalSpTxt = null;
			}
			if (this.mSkillTreeRoot != null)
			{
				this.mSkillTreeRoot = null;
			}
			if (this.mSkillInfoRoot != null)
			{
				this.mSkillInfoRoot = null;
			}
			if (this.mSelectSkillImg != null)
			{
				this.mSelectSkillImg = null;
			}
			if (this.mSelectSkillNameTxt != null)
			{
				this.mSelectSkillNameTxt = null;
			}
			if (this.mSelectSkillAddLvTxt != null)
			{
				this.mSelectSkillAddLvTxt = null;
			}
			if (this.mSelectSkillLvTxt != null)
			{
				this.mSelectSkillLvTxt = null;
			}
			if (this.mLevelMaxImage != null)
			{
				this.mLevelMaxImage = null;
			}
			if (this.mLevelLimitDesTxt != null)
			{
				this.mLevelLimitDesTxt = null;
			}
			if (this.mNeedLevelTxt != null)
			{
				this.mNeedLevelTxt = null;
			}
			if (this.mSelectDesTxt != null)
			{
				this.mSelectDesTxt = null;
			}
			if (this.mSelectTypeTxt != null)
			{
				this.mSelectTypeTxt = null;
			}
			if (this.mSelectCDTxt != null)
			{
				this.mSelectCDTxt = null;
			}
			if (this.mSelectSkillNeedSpTxt != null)
			{
				this.mSelectSkillNeedSpTxt = null;
			}
			if (this.mSelectNextSkillAttriTxt != null)
			{
				this.mSelectNextSkillAttriTxt = null;
			}
			if (this.mSelectCurSkillAttriTxt != null)
			{
				this.mSelectCurSkillAttriTxt = null;
			}
			if (this.mDownLvBtn != null)
			{
				this.mDownLvBtn = null;
			}
			if (this.mUpLvBtn != null)
			{
				this.mUpLvBtn = null;
			}
			if (this.mSelectSkillConsumeThingTxt != null)
			{
				this.mSelectSkillConsumeThingTxt = null;
			}
			if (this.mAttributeGoArry != null)
			{
				for (int i = 0; i < this.mAttributeGoArry.Length; i++)
				{
					if (this.mAttributeGoArry[i] != null)
					{
						this.mAttributeGoArry[i] = null;
					}
				}
			}
			if (this.mAttributeTypeTxtArry != null)
			{
				for (int j = 0; j < this.mAttributeTypeTxtArry.Length; j++)
				{
					if (this.mAttributeTypeTxtArry[j] != null)
					{
						this.mAttributeTypeTxtArry[j] = null;
					}
				}
			}
			if (this.mSkillPlaneView != null)
			{
				this.mSkillPlaneView = null;
			}
			if (this.mSkillPanelBtnRoot != null)
			{
				this.mSkillPanelBtnRoot = null;
			}
			if (this.mTipGo != null)
			{
				this.mTipGo = null;
			}
			if (this.mTipTxt != null)
			{
				this.mTipTxt = null;
			}
			if (this.mSkillPlaneBtnTxt != null)
			{
				this.mSkillPlaneBtnTxt = null;
			}
			if (this.mSkillBtnRootGo != null)
			{
				this.mSkillBtnRootGo = null;
			}
		}

		// Token: 0x0600C06E RID: 49262 RVA: 0x002D6DD8 File Offset: 0x002D51D8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SpChanged, new ClientEventSystem.UIEventHandler(this.OnSpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this.OnSkillBarChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillListChanged, new ClientEventSystem.UIEventHandler(this.OnSkillListChanged));
		}

		// Token: 0x0600C06F RID: 49263 RVA: 0x002D6E34 File Offset: 0x002D5234
		private void UpdateSkillAddedLv()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			this.mAddSkillInfo.Clear();
			this.mAddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, null, SkillSystemSourceType.FairDuel);
			for (int i = 0; i < this.mSkillPosList.Count; i++)
			{
				ComSkillTreeEle componentInChildren = this.mSkillPosList[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					int num = -1;
					if (!dictionary.TryGetValue(i + 1, out num))
					{
						componentInChildren.SkillLvUp.gameObject.CustomActive(false);
					}
					else
					{
						int addLevel = this.GetAddLevel(num);
						if (addLevel > 0)
						{
							componentInChildren.SkillAddlevel.text = string.Format("(+{0})", addLevel);
						}
						else
						{
							componentInChildren.SkillAddlevel.text = string.Empty;
						}
						if (num == (int)this.mCurSelSkillTreeID)
						{
							if (addLevel > 0)
							{
								this.mSelectSkillAddLvTxt.text = string.Format("(+{0})", addLevel);
							}
							else
							{
								this.mSelectSkillAddLvTxt.text = string.Empty;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C070 RID: 49264 RVA: 0x002D6F60 File Offset: 0x002D5360
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SpChanged, new ClientEventSystem.UIEventHandler(this.OnSpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this.OnSkillBarChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillListChanged, new ClientEventSystem.UIEventHandler(this.OnSkillListChanged));
		}

		// Token: 0x0600C071 RID: 49265 RVA: 0x002D6FBB File Offset: 0x002D53BB
		private void OnSpChanged(UIEvent uiEvent)
		{
			this.mTotalSp = DataManager<PlayerBaseData>.GetInstance().FairDuelSp;
			if (this.mTotalSpTxt != null)
			{
				this.mTotalSpTxt.text = this.mTotalSp.ToString();
			}
		}

		// Token: 0x0600C072 RID: 49266 RVA: 0x002D6FFC File Offset: 0x002D53FC
		private void OnSkillListChanged(UIEvent uiEvent)
		{
			int addLevel = this.GetAddLevel((int)this.mCurSelSkillTreeID);
			ComSkillTreeEle componentInChildren = this.mSkillPosList[this.mCurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			if (addLevel > 0)
			{
				componentInChildren.SkillAddlevel.text = string.Format("(+{0})", addLevel);
			}
			else
			{
				componentInChildren.SkillAddlevel.text = string.Empty;
			}
			this.UpdateSkillAddedLv();
		}

		// Token: 0x0600C073 RID: 49267 RVA: 0x002D706A File Offset: 0x002D546A
		private void OnSkillBarChanged(UIEvent uiEvent)
		{
			this.UpdateSkillTree(false);
			this.UpdateSelectedSkillInfo(DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill);
		}

		// Token: 0x0600C074 RID: 49268 RVA: 0x002D7084 File Offset: 0x002D5484
		private void InitInterface()
		{
			this.mMaxPlayerLvl = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			this.mAddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, null, SkillSystemSourceType.FairDuel);
			DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_EQUAL_PVP;
			if (Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (this.mSkillPlaneView != null)
			{
				this.mSkillPlaneView.Hide();
				this.mIsHaveOpenSkillPlane = false;
			}
			this.mTotalSp = DataManager<PlayerBaseData>.GetInstance().FairDuelSp;
			this.CreateSkillTreePreFerb();
			this.UpdateSkillTree(true);
			this.UpdatePlanIsFull();
		}

		// Token: 0x0600C075 RID: 49269 RVA: 0x002D712C File Offset: 0x002D552C
		private void CreateSkillTreePreFerb()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mUniqueSkillTreeGo = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mUniqueSkillPath, true, 0U);
			if (this.mUniqueSkillTreeGo == null)
			{
				Logger.LogError("can't create obj in SkillTreeFrame");
				return;
			}
			this.mUniqueSkillTreeGo.transform.SetParent(this.mSkillTreeRoot.transform, false);
			this.mSkillTreeScrollView = Utility.FindGameObject(this.frame, this.mLeftRootPath, true);
			if (this.mSkillTreeScrollView == null)
			{
				return;
			}
			this.mUniqueContent = Utility.FindGameObject(this.frame, this.mLeftRootPath + "/Viewport/Content", true);
			if (this.mUniqueContent == null)
			{
				return;
			}
			RectTransform[] componentsInChildren = this.mUniqueSkillTreeGo.GetComponentsInChildren<RectTransform>();
			this.mUniqueSkillTransNameList = new List<string>();
			int num = 1;
			int num2 = 1;
			this.mSkillPosList.Clear();
			this.mSkillPosPanelIndexList.Clear();
			this.mSkillTreeEleTemp = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mSkillTreeElementPath, true, 0U);
			if (this.mSkillTreeEleTemp == null)
			{
				return;
			}
			this.mSkillTreeEleTemp.name = this.mSkillTreeEleTemp.name.Replace("(Clone)", string.Empty);
			int i = 0;
			while (i < componentsInChildren.Length)
			{
				if (!componentsInChildren[i].name.Equals(string.Format("ActiveSkillPanel{0}", num)))
				{
					goto IL_1A9;
				}
				if (num <= tableItem.MaxSkillPanelIndex)
				{
					num++;
					goto IL_1A9;
				}
				componentsInChildren[i].gameObject.SetActive(false);
				num++;
				IL_215:
				i++;
				continue;
				IL_1A9:
				if (componentsInChildren[i].name.Equals(string.Format("Pos{0}", num2)))
				{
					componentsInChildren[i].gameObject.CustomActive(false);
					this.mUniqueSkillTransNameList.Add(componentsInChildren[i].name);
					this.mSkillPosList.Add(componentsInChildren[i].gameObject);
					this.mSkillPosPanelIndexList.Add(num - 1);
					num2++;
					goto IL_215;
				}
				goto IL_215;
			}
		}

		// Token: 0x0600C076 RID: 49270 RVA: 0x002D735E File Offset: 0x002D575E
		private void UpdateSkillTree(bool isInit)
		{
			base.StartCoroutine(this.EUpdateSkillTree(DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill, isInit));
		}

		// Token: 0x0600C077 RID: 49271 RVA: 0x002D7378 File Offset: 0x002D5778
		private IEnumerator EUpdateSkillTree(Dictionary<int, int> buttonBindSkill, bool isInit)
		{
			List<int> alreadyShowNewOpenSkill = new List<int>();
			List<int> newOpenSkillList = new List<int>();
			if (this.mTotalSpTxt != null)
			{
				this.mTotalSpTxt.text = this.mTotalSp.ToString();
			}
			if (isInit && this.mSkillInfoRoot != null)
			{
				this.mSkillInfoRoot.CustomActive(false);
			}
			Dictionary<int, ComSkillTreeEle> skillTreeEleDic = new Dictionary<int, ComSkillTreeEle>();
			for (int i = 0; i < this.mSkillPosList.Count; i++)
			{
				ComSkillTreeEle comSkillTreeEle = this.mSkillPosList[i].GetComponentInChildren<ComSkillTreeEle>();
				if (comSkillTreeEle == null)
				{
					comSkillTreeEle = this.CreateComSkillTreeEle(this.mSkillPosList[i], i, this.mSkillPosPanelIndexList[i]);
				}
				if (!(comSkillTreeEle == null))
				{
					comSkillTreeEle.SkillAddlevel.text = string.Empty;
					Drag_Me componentInChildren = this.mSkillPosList[i].GetComponentInChildren<Drag_Me>();
					int num = -1;
					if (!buttonBindSkill.TryGetValue(i + 1, out num) || num == -1)
					{
						this.mSkillPosList[i].gameObject.CustomActive(false);
					}
					else
					{
						this.mSkillPosList[i].gameObject.CustomActive(true);
						SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
						byte b = this.CalFinalShowLv((ushort)num);
						bool bIsNewOpen = false;
						if (componentInChildren != null)
						{
							componentInChildren.ResponseDrag = new Drag_Me.OnResDrag(this.mSkillPlaneView.DealSkillBarDrag);
							componentInChildren.Id = (ushort)num;
						}
						if ((int)b >= tableItem.TopLevelLimit)
						{
							comSkillTreeEle.SkillNames.color = Color.white;
							comSkillTreeEle.Skilllevel.text = "Lv." + tableItem.TopLevelLimit.ToString() + "/" + tableItem.TopLevelLimit.ToString();
							skillTreeEleDic.Add(num, comSkillTreeEle);
						}
						else
						{
							if (this.mMaxPlayerLvl < tableItem.LevelLimit && tableItem.IsPreJob == 0)
							{
								comSkillTreeEle.Skilllevel.text = "Lv.0/" + tableItem.TopLevelLimit.ToString();
								comSkillTreeEle.Skilllevel.color = Color.gray;
								comSkillTreeEle.SkillNames.color = Color.gray;
							}
							else
							{
								if (b <= 0)
								{
									comSkillTreeEle.Skilllevel.text = "Lv.0/" + tableItem.TopLevelLimit.ToString();
									comSkillTreeEle.Skilllevel.color = Color.gray;
								}
								else
								{
									comSkillTreeEle.Skilllevel.text = "Lv." + b.ToString() + "/" + tableItem.TopLevelLimit.ToString();
									comSkillTreeEle.Skilllevel.color = Color.white;
									skillTreeEleDic.Add(num, comSkillTreeEle);
								}
								comSkillTreeEle.SkillNames.color = Color.white;
								newOpenSkillList = DataManager<SkillDataManager>.GetInstance().NewOpenComSkillList;
								int num2 = 0;
								if (num2 < newOpenSkillList.Count)
								{
									if (num == newOpenSkillList[num2])
									{
										this.PlayNewSkillEffect(ref comSkillTreeEle.SkillIcon);
									}
									if (!DataManager<SkillDataManager>.GetInstance().IsEquipFairDuelSKill(num))
									{
										comSkillTreeEle.NewIcon.gameObject.CustomActive(true);
									}
									else
									{
										comSkillTreeEle.NewIcon.gameObject.CustomActive(false);
									}
									alreadyShowNewOpenSkill.Add(num);
									bIsNewOpen = true;
								}
							}
							comSkillTreeEle.Skilllevel.gameObject.CustomActive(true);
						}
						this.UpdateShowLvUpImage(comSkillTreeEle, (ushort)num, b, false, bIsNewOpen);
						if (i < 5)
						{
							comSkillTreeEle.SkillNames.text = tableItem.Name;
							comSkillTreeEle.Skilllevel.text = string.Empty;
						}
						else
						{
							comSkillTreeEle.SkillNames.text = string.Empty;
						}
						this.ClearSkillLvUpEffect(comSkillTreeEle, i);
						this.ClearSkillLvDownEffect(comSkillTreeEle, i);
						this.ShowIcon(tableItem, comSkillTreeEle, b);
						if (DataManager<SkillDataManager>.GetInstance().IsEquipFairDuelSKill(num))
						{
							comSkillTreeEle.SkillAllocate.gameObject.CustomActive(true);
						}
						else
						{
							comSkillTreeEle.SkillAllocate.gameObject.CustomActive(false);
						}
						if (tableItem.SkillCategory == 4)
						{
							if (DataManager<PlayerBaseData>.GetInstance().AwakeState <= 0)
							{
								comSkillTreeEle.AwakeText.text = "完成觉醒任务后解锁";
								comSkillTreeEle.AwakeText.gameObject.CustomActive(true);
							}
							else
							{
								comSkillTreeEle.AwakeText.gameObject.CustomActive(false);
							}
						}
					}
				}
			}
			foreach (KeyValuePair<int, ComSkillTreeEle> keyValuePair in skillTreeEleDic)
			{
				int addLevel = this.GetAddLevel(keyValuePair.Key);
				if (addLevel > 0)
				{
					Dictionary<int, ComSkillTreeEle>.Enumerator curItemIter;
					KeyValuePair<int, ComSkillTreeEle> keyValuePair2 = curItemIter.Current;
					keyValuePair2.Value.SkillAddlevel.text = string.Format("(+{0})", addLevel);
				}
				else
				{
					Dictionary<int, ComSkillTreeEle>.Enumerator curItemIter;
					KeyValuePair<int, ComSkillTreeEle> keyValuePair3 = curItemIter.Current;
					keyValuePair3.Value.SkillAddlevel.text = string.Empty;
				}
			}
			yield return null;
			skillTreeEleDic.Clear();
			DataManager<SkillDataManager>.GetInstance().UpdateLockSkillList(alreadyShowNewOpenSkill);
			yield break;
		}

		// Token: 0x0600C078 RID: 49272 RVA: 0x002D73A4 File Offset: 0x002D57A4
		private void PlayNewSkillEffect(ref Image SkillIcon)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mNewSkillEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x0600C079 RID: 49273 RVA: 0x002D73E4 File Offset: 0x002D57E4
		private int GetAddLevel(int skillTreeID)
		{
			return DataManager<SkillDataManager>.GetInstance().GetAddedSkillLevel(skillTreeID, this.mAddSkillInfo);
		}

		// Token: 0x0600C07A RID: 49274 RVA: 0x002D7408 File Offset: 0x002D5808
		private void ShowIcon(SkillTable skillData, ComSkillTreeEle comEle, byte showLv)
		{
			if (skillData.Icon != "-")
			{
				ETCImageLoader.LoadSprite(ref comEle.SkillIcon, skillData.Icon, true);
				comEle.SkillIcon.GetComponent<UIGray>().ResetMaterial();
				if (this.mMaxPlayerLvl < skillData.LevelLimit && skillData.IsPreJob == 0)
				{
					comEle.SkillIcon.GetComponent<UIGray>().SetEnable(true);
				}
				else if (DataManager<SkillDataManager>.GetInstance().CanFairDuelLvUpByCurRoleLv(skillData, showLv, (ushort)this.mMaxPlayerLvl))
				{
					if (showLv <= 0)
					{
						this.UpdatePvpForbid(ref comEle, skillData.ID, true);
					}
					else
					{
						this.UpdatePvpForbid(ref comEle, skillData.ID, false);
					}
				}
				else
				{
					this.UpdatePvpForbid(ref comEle, skillData.ID, false);
				}
				comEle.SkillIcon.gameObject.CustomActive(true);
			}
			else
			{
				comEle.SkillIcon.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600C07B RID: 49275 RVA: 0x002D74FC File Offset: 0x002D58FC
		public byte CalFinalShowLv(ushort SkillID)
		{
			byte result = 0;
			byte b = 0;
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", SkillID));
				return result;
			}
			if (this.mMaxPlayerLvl < tableItem.LevelLimit && tableItem.IsPreJob == 0)
			{
				return result;
			}
			bool flag = this.mChangeList.TryGetValue(SkillID, out b);
			Skill[] array = DataManager<SkillDataManager>.GetInstance().FairDuelSkillList.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id == SkillID)
				{
					if (flag)
					{
						byte b2 = 0;
						bool flag2 = DataManager<SkillDataManager>.GetInstance().CheckInitSkills((int)this.mCurSelSkillTreeID);
						if (flag2)
						{
							b2 = 1;
						}
						if ((int)((sbyte)array[i].level) + (int)((sbyte)b) > (int)b2)
						{
							result = (byte)((int)((sbyte)array[i].level) + (int)((sbyte)b));
						}
						else
						{
							result = b2;
						}
					}
					else
					{
						result = array[i].level;
					}
					return result;
				}
			}
			if (b > 0)
			{
				result = b;
			}
			return result;
		}

		// Token: 0x0600C07C RID: 49276 RVA: 0x002D761C File Offset: 0x002D5A1C
		private void UpdateShowLvUpImage(ComSkillTreeEle comele, ushort SkillID, byte SkillLv, bool ShowNotify = true, bool bIsNewOpen = false)
		{
			if (this.CheckLvUp(SkillID, SkillLv, false))
			{
				comele.CanLearn.gameObject.CustomActive(false);
				if (SkillLv > 0)
				{
					comele.SkillLvUp.gameObject.CustomActive(true);
					comele.redpoint.gameObject.CustomActive(false);
				}
				else
				{
					comele.SkillLvUp.gameObject.CustomActive(false);
					comele.redpoint.gameObject.CustomActive(true);
					if (!bIsNewOpen)
					{
						comele.CanLearn.gameObject.CustomActive(true);
					}
				}
			}
			else
			{
				comele.SkillLvUp.gameObject.CustomActive(false);
				comele.redpoint.gameObject.CustomActive(false);
				comele.CanLearn.gameObject.CustomActive(false);
			}
			if (!bIsNewOpen)
			{
				comele.NewIcon.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600C07D RID: 49277 RVA: 0x002D7700 File Offset: 0x002D5B00
		private bool CheckLvUp(ushort SkillID, byte SkillLv, bool ShowNotify = true)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (SkillLv >= (byte)tableItem.TopLevelLimit)
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1016, string.Empty);
				}
				return false;
			}
			if (SkillLv == 0 && tableItem.PreSkills.Count > 0 && tableItem.PreSkills[0] > 0 && !this.CheckPreSkills(tableItem, ShowNotify))
			{
				return false;
			}
			uint num = this.mTotalSp;
			if ((ulong)num < (ulong)((long)tableItem.LearnSPCost))
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1005, string.Empty);
				}
				return false;
			}
			return tableItem.SkillCategory != 4 || DataManager<PlayerBaseData>.GetInstance().AwakeState > 0;
		}

		// Token: 0x0600C07E RID: 49278 RVA: 0x002D77D4 File Offset: 0x002D5BD4
		private bool CheckLvDown(ushort SkillID, byte SkillLv, bool ShowNotify = true)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			int num = 0;
			if (DataManager<SkillDataManager>.GetInstance().CheckInitSkills((int)SkillID) || tableItem.IsPreJob == 1)
			{
				num = 1;
			}
			if ((int)SkillLv <= num)
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1017, string.Empty);
				}
				return false;
			}
			List<SkillBarGrid> fairDuelSkillBar = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar;
			for (int i = 0; i < fairDuelSkillBar.Count; i++)
			{
				if (fairDuelSkillBar[i].id == SkillID && SkillLv <= 1)
				{
					if (ShowNotify)
					{
						SystemNotifyManager.SystemNotify(1018, string.Empty);
					}
					return false;
				}
			}
			return tableItem.PostSkills.Count <= 0 || tableItem.PostSkills[0] <= 0 || this.CheckPostSkills(SkillLv, tableItem, ShowNotify);
		}

		// Token: 0x0600C07F RID: 49279 RVA: 0x002D78CC File Offset: 0x002D5CCC
		private bool CheckPostSkills(byte CurSelSkillLv, SkillTable skillData, bool ShowNotify)
		{
			if (skillData.PostSkills.Count != skillData.NeedLevel.Count)
			{
				Logger.LogError(string.Format("技能表 {0} 的后置技能与所需等级数组长度不等，请检查表格", skillData.ID));
				return false;
			}
			for (int i = 0; i < skillData.NeedLevel.Count; i++)
			{
				if ((int)CurSelSkillLv <= skillData.NeedLevel[i])
				{
					SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillData.PostSkills[i], string.Empty, string.Empty);
					if (tableItem == null)
					{
						Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillData.PostSkills[i]));
						return false;
					}
					int num = 0;
					bool flag = DataManager<SkillDataManager>.GetInstance().CheckInitSkills(tableItem.ID);
					if (flag)
					{
						num = 1;
					}
					if ((int)this.CalFinalShowLv((ushort)skillData.PostSkills[i]) > num)
					{
						object[] args = new object[]
						{
							tableItem.Name
						};
						if (ShowNotify)
						{
							SystemNotifyManager.SystemNotify(1020, args);
						}
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600C080 RID: 49280 RVA: 0x002D79E8 File Offset: 0x002D5DE8
		private bool CheckPreSkills(SkillTable skillData, bool ShowNotify)
		{
			if (skillData.PreSkills.Count != skillData.PreSkillsLevel.Count)
			{
				Logger.LogError(string.Format("技能表 {0} 的前置技能与等级数组长度不等，请检查表格", skillData.ID));
				return false;
			}
			for (int i = 0; i < skillData.PreSkills.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillData.PreSkills[i], string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillData.PreSkills[i]));
					return false;
				}
				if (this.CalFinalShowLv((ushort)skillData.PreSkills[i]) < (byte)skillData.PreSkillsLevel[i])
				{
					object[] args = new object[]
					{
						tableItem.Name,
						skillData.PreSkillsLevel[i]
					};
					if (ShowNotify)
					{
						SystemNotifyManager.SystemNotify(1019, args);
					}
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600C081 RID: 49281 RVA: 0x002D7AF0 File Offset: 0x002D5EF0
		private void ClearSkillLvUpEffect(ComSkillTreeEle comele, int iIndex)
		{
			string path = string.Empty;
			path = this.mLeftRootPath + string.Format(this.mEffectLvDownRootPath, comele.iPanelIndex, iIndex + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600C082 RID: 49282 RVA: 0x002D7B50 File Offset: 0x002D5F50
		private void ClearSkillLvDownEffect(ComSkillTreeEle comele, int iIndex)
		{
			string path = string.Empty;
			path = this.mLeftRootPath + string.Format(this.mEffectLvDownRootPath, comele.iPanelIndex, iIndex + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600C083 RID: 49283 RVA: 0x002D7BB0 File Offset: 0x002D5FB0
		private ComSkillTreeEle CreateComSkillTreeEle(GameObject rootGo, int skillIndex, int panelIndex)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.mSkillTreeEleTemp);
			if (gameObject == null)
			{
				return null;
			}
			Utility.AttachTo(gameObject, rootGo, false);
			ComSkillTreeEle componentInChildren = gameObject.GetComponentInChildren<ComSkillTreeEle>();
			if (componentInChildren == null)
			{
				return null;
			}
			if (rootGo.transform.parent != null)
			{
				RectTransform component = rootGo.transform.parent.GetComponent<RectTransform>();
				if (component != null)
				{
					componentInChildren.mrt = component;
				}
			}
			componentInChildren.iPanelIndex = panelIndex;
			componentInChildren.SkillToggle.group = this.mUniqueSkillTreeGo.GetComponentInChildren<ToggleGroup>();
			componentInChildren.SkillToggle.onValueChanged.RemoveAllListeners();
			componentInChildren.SkillToggle.onValueChanged.AddListener(delegate(bool value)
			{
				this.OnSelectSkillEle(skillIndex, value);
			});
			if (skillIndex == 5)
			{
				componentInChildren.SkillToggle.isOn = true;
			}
			return componentInChildren;
		}

		// Token: 0x0600C084 RID: 49284 RVA: 0x002D7CA4 File Offset: 0x002D60A4
		private void OnSelectSkillEle(int skillIndex, bool value)
		{
			if (!value || skillIndex < 0)
			{
				return;
			}
			this.mCurSelSkillTreeBtnIdx = skillIndex;
			this.UpdateSelectedSkillInfo(DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill);
		}

		// Token: 0x0600C085 RID: 49285 RVA: 0x002D7CCC File Offset: 0x002D60CC
		private void UpdateSelectedSkillInfo(Dictionary<int, int> buttonBindSkill)
		{
			this.mCurSelSkillLv = 0;
			this.mCurSelSkillTreeID = 0;
			if (this.mCurSelSkillTreeBtnIdx < 0 || this.mCurSelSkillTreeBtnIdx >= this.mSkillPosList.Count)
			{
				return;
			}
			int num = -1;
			if (!buttonBindSkill.TryGetValue(this.mCurSelSkillTreeBtnIdx + 1, out num) || num == -1)
			{
				return;
			}
			ComSkillTreeEle componentInChildren = this.mSkillPosList[this.mCurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			if (componentInChildren == null)
			{
				return;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", num));
				return;
			}
			if (this.mSkillInfoRoot != null)
			{
				this.mSkillInfoRoot.CustomActive(true);
			}
			this.mCurSelSkillTreeID = (ushort)num;
			this.mCurSelSkillLv = this.CalFinalShowLv((ushort)num);
			ETCImageLoader.LoadSprite(ref this.mSelectSkillImg, tableItem.Icon, true);
			this.mSelectSkillNameTxt.text = tableItem.Name;
			int addLevel = this.GetAddLevel((int)this.mCurSelSkillTreeID);
			this.mSelectSkillAddLvTxt.text = string.Empty;
			if (addLevel > 0)
			{
				this.mSelectSkillAddLvTxt.text = string.Format("+{0}", addLevel);
			}
			else
			{
				this.mSelectSkillAddLvTxt.text = string.Empty;
			}
			this.UpdateRightLevel(this.mSkillPosList, tableItem, addLevel);
			this.UpdateSkillAttribute(tableItem);
			this.UpdateSkillCDText(this.mCurSelSkillTreeID, tableItem, this.mCurSelSkillLv);
			this.UpdateSkillConsumeMP(tableItem, this.mCurSelSkillLv);
			this.UpdateLvProperty(tableItem, this.mCurSelSkillLv);
			this.UpdateLvUpDownBtnState(componentInChildren, this.mCurSelSkillTreeID, this.mCurSelSkillLv);
			this.UpdateNeedSp(tableItem);
		}

		// Token: 0x0600C086 RID: 49286 RVA: 0x002D7E88 File Offset: 0x002D6288
		private void UpdateRightLevel(List<GameObject> skillPos, SkillTable skilldata, int AddedLv)
		{
			if (skilldata == null)
			{
				return;
			}
			this.mTotalSpTxt.text = this.mTotalSp.ToString();
			this.mSelectSkillLvTxt.text = string.Format("Lv.{0}", this.mCurSelSkillLv);
			if ((int)this.mCurSelSkillLv >= skilldata.TopLevelLimit)
			{
				this.mLevelMaxImage.CustomActive(true);
				this.mLevelLimitDesTxt.CustomActive(true);
				this.mNeedLevelTxt.CustomActive(false);
				this.mSelectSkillNeedSpTxt.CustomActive(false);
			}
			else
			{
				this.mLevelMaxImage.CustomActive(false);
				this.mLevelLimitDesTxt.CustomActive(false);
				this.mNeedLevelTxt.CustomActive(true);
				this.mSelectSkillNeedSpTxt.CustomActive(true);
				if (this.mMaxPlayerLvl < skilldata.LevelLimit && skilldata.IsPreJob == 0)
				{
					this.mNeedLevelTxt.text = string.Format("{0}级开放", skilldata.LevelLimit);
					this.mNeedLevelTxt.color = Color.red;
				}
				else
				{
					int skillNextOpenNeedRoleLv = DataManager<SkillDataManager>.GetInstance().GetSkillNextOpenNeedRoleLv(skilldata, (int)this.mCurSelSkillLv);
					this.mNeedLevelTxt.text = string.Format("等级需求:{0}", skillNextOpenNeedRoleLv);
					this.mNeedLevelTxt.color = Color.white;
				}
			}
			this.mSelectDesTxt.text = DataManager<SkillDataManager>.GetInstance().GetSkillDescription(skilldata);
			this.mSelectTypeTxt.text = DataManager<SkillDataManager>.GetInstance().GetSkillType(skilldata);
			this.mLevelLimitDesTxt.text = string.Format(TR.Value("skill_max_des"), skilldata.TopLevelLimit, skilldata.TopLevel);
		}

		// Token: 0x0600C087 RID: 49287 RVA: 0x002D8038 File Offset: 0x002D6438
		private void UpdateSkillCDText(ushort skillID, SkillTable skillTable, byte curSkillLevel)
		{
			SkillLevelAddInfo skillLevelAddInfo = new SkillLevelAddInfo();
			skillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetAddedSkillInfo((int)skillID, this.mAddSkillInfo);
			float num;
			if (skillLevelAddInfo == null)
			{
				if (curSkillLevel > 0)
				{
					num = (float)TableManager.GetValueFromUnionCell(skillTable.RefreshTimePVP, (int)curSkillLevel, true) / 1000f;
				}
				else
				{
					num = (float)TableManager.GetValueFromUnionCell(skillTable.RefreshTimePVP, 1, true) / 1000f;
				}
			}
			else if ((int)curSkillLevel + skillLevelAddInfo.totalAddLevel > 0)
			{
				num = (float)TableManager.GetValueFromUnionCell(skillTable.RefreshTimePVP, (int)curSkillLevel + skillLevelAddInfo.totalAddLevel, true) / 1000f;
			}
			else
			{
				num = (float)TableManager.GetValueFromUnionCell(skillTable.RefreshTimePVP, 1, true) / 1000f;
			}
			if (this.mSelectCDTxt != null)
			{
				this.mSelectCDTxt.text = string.Format("{0}S", num);
			}
		}

		// Token: 0x0600C088 RID: 49288 RVA: 0x002D8110 File Offset: 0x002D6510
		private void UpdateSkillConsumeMP(SkillTable skillData, byte CurSkillLevel)
		{
			byte level = 1;
			if (CurSkillLevel >= 1)
			{
				level = CurSkillLevel;
			}
			float num = (float)TableManager.GetValueFromUnionCell(skillData.MPCost, (int)level, false);
			this.mSelectSkillConsumeMPTxt.text = string.Format("{0}", num);
			float num2 = (float)TableManager.GetValueFromUnionCell(skillData.CrystalCost, (int)level, false);
			if (num2 > 0f)
			{
				this.mSelectSkillConsumeThingTxt.CustomActive(true);
				this.mSelectSkillConsumeThingTxt.text = string.Format("{0}个", num2);
			}
			else
			{
				this.mSelectSkillConsumeThingTxt.CustomActive(false);
			}
		}

		// Token: 0x0600C089 RID: 49289 RVA: 0x002D81A4 File Offset: 0x002D65A4
		private void UpdateNeedSp(SkillTable skillData)
		{
			this.mSelectSkillNeedSpTxt.text = string.Format("消耗技能点:{0}", skillData.LearnSPCost.ToString());
			if ((ulong)this.mTotalSp < (ulong)((long)skillData.LearnSPCost))
			{
				this.mSelectSkillNeedSpTxt.color = Color.red;
			}
			else
			{
				this.mSelectSkillNeedSpTxt.color = Color.white;
			}
		}

		// Token: 0x0600C08A RID: 49290 RVA: 0x002D8214 File Offset: 0x002D6614
		private void UpdateLvProperty(SkillTable skilldata, byte NeedShowSkillLv)
		{
			byte b = this.CalAlreadyLearnLv((ushort)skilldata.ID);
			if (NeedShowSkillLv < 0)
			{
				NeedShowSkillLv = 0;
			}
			int addLevel = this.GetAddLevel(skilldata.ID);
			string arg = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(skilldata.ID, (byte)((int)b + addLevel), (byte)((int)NeedShowSkillLv + addLevel), FightTypeLabel.PVP);
			this.mSelectCurSkillAttriTxt.text = string.Format(TR.Value("CurLvSkillDes"), arg);
			arg = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(skilldata.ID, (byte)((int)b + addLevel), (byte)((int)NeedShowSkillLv + addLevel + 1), FightTypeLabel.PVP);
			this.mSelectNextSkillAttriTxt.text = string.Format(TR.Value("NextLvSkillDes"), arg);
		}

		// Token: 0x0600C08B RID: 49291 RVA: 0x002D82B4 File Offset: 0x002D66B4
		private void UpdateSkillAttribute(SkillTable skillData)
		{
			for (int i = 0; i < this.mAttributeGoArry.Length; i++)
			{
				this.mAttributeGoArry[i].gameObject.CustomActive(false);
			}
			if (skillData == null)
			{
				return;
			}
			if (skillData.SkillEffect == null)
			{
				return;
			}
			for (int j = 0; j < skillData.SkillEffect.Count; j++)
			{
				if (j < 6)
				{
					string skillTypeText = this.getSkillTypeText((byte)skillData.SkillEffect[j]);
					if (!(skillTypeText == string.Empty))
					{
						this.mAttributeTypeTxtArry[j].text = skillTypeText;
						this.mAttributeGoArry[j].gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x0600C08C RID: 49292 RVA: 0x002D8374 File Offset: 0x002D6774
		private void UpdateLvUpDownBtnState(ComSkillTreeEle comele, ushort SkillID, byte SkillLv)
		{
			if (this.CheckLvUp(SkillID, SkillLv, false))
			{
				this.mUpLvBtn.gameObject.GetComponent<UIGray>().enabled = false;
				this.mUpLvBtn.enabled = true;
			}
			else
			{
				this.mUpLvBtn.gameObject.GetComponent<UIGray>().enabled = true;
				this.mUpLvBtn.enabled = false;
			}
			if (this.CheckLvDown(SkillID, SkillLv, false))
			{
				this.mDownLvBtn.gameObject.GetComponent<UIGray>().enabled = false;
				this.mDownLvBtn.enabled = true;
			}
			else
			{
				this.mDownLvBtn.gameObject.GetComponent<UIGray>().enabled = true;
				this.mDownLvBtn.enabled = false;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("该技能在技能表里面不存在,id={0}", SkillID));
			}
			else if (tableItem.CanUseInPVP == 3)
			{
				this.mDownLvBtn.gameObject.GetComponent<UIGray>().enabled = true;
				this.mDownLvBtn.enabled = false;
				this.mUpLvBtn.gameObject.GetComponent<UIGray>().enabled = true;
				this.mUpLvBtn.enabled = false;
			}
		}

		// Token: 0x0600C08D RID: 49293 RVA: 0x002D84B8 File Offset: 0x002D68B8
		private string getSkillTypeText(byte effectIndex)
		{
			string result = string.Empty;
			switch (effectIndex)
			{
			case 1:
				result = TR.Value("skill_start");
				break;
			case 2:
				result = TR.Value("skill_continuous");
				break;
			case 3:
				result = TR.Value("skill_hurt");
				break;
			case 4:
				result = TR.Value("displacement_skilll");
				break;
			case 5:
				result = TR.Value("control_skill");
				break;
			case 6:
				result = TR.Value("grab_skill");
				break;
			case 7:
				result = TR.Value("defense_skill");
				break;
			case 8:
				result = TR.Value("assistant_skill");
				break;
			case 9:
				result = TR.Value("physical_skill");
				break;
			case 10:
				result = TR.Value("magic_skill");
				break;
			case 11:
				result = TR.Value("near_skill");
				break;
			case 12:
				result = TR.Value("far_skill");
				break;
			}
			return result;
		}

		// Token: 0x0600C08E RID: 49294 RVA: 0x002D85CC File Offset: 0x002D69CC
		private byte CalAlreadyLearnLv(ushort SkillID)
		{
			byte result = 0;
			List<Skill> fairDuelSkillList = DataManager<SkillDataManager>.GetInstance().FairDuelSkillList;
			for (int i = 0; i < fairDuelSkillList.Count; i++)
			{
				if (fairDuelSkillList[i].id == SkillID)
				{
					result = fairDuelSkillList[i].level;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600C08F RID: 49295 RVA: 0x002D8622 File Offset: 0x002D6A22
		private void OnCloseBtnClick()
		{
			this.frameMgr.CloseFrame<FairDuelSkillFrame>(this, false);
		}

		// Token: 0x0600C090 RID: 49296 RVA: 0x002D8631 File Offset: 0x002D6A31
		private void OnUpLvBtnClick()
		{
			if (!this.CheckLvUp(this.mCurSelSkillTreeID, this.mCurSelSkillLv, true))
			{
				return;
			}
			this.mCurSelSkillLv += 1;
			this.UpdateChangedSkill(true);
			this.OnbtSave();
		}

		// Token: 0x0600C091 RID: 49297 RVA: 0x002D8668 File Offset: 0x002D6A68
		private void OnDownLvBtnClick()
		{
			if (!this.CheckLvDown(this.mCurSelSkillTreeID, this.mCurSelSkillLv, true))
			{
				return;
			}
			this.mCurSelSkillLv -= 1;
			this.UpdateChangedSkill(false);
			this.OnbtSave();
		}

		// Token: 0x0600C092 RID: 49298 RVA: 0x002D86A0 File Offset: 0x002D6AA0
		private void OnShowSkillPlaneClick()
		{
			if (this.mSkillPlaneView == null)
			{
				return;
			}
			if (!this.mIsHaveOpenSkillPlane)
			{
				if (this.mSkillPlaneBtnTxt != null)
				{
					this.mSkillPlaneBtnTxt.text = "返回";
				}
				this.mSkillPlaneView.Show(this);
				if (this.mTipGo != null)
				{
					this.mTipGo.CustomActive(false);
				}
				this.mIsHaveOpenSkillPlane = true;
			}
			else
			{
				if (this.mSkillPlaneBtnTxt != null)
				{
					this.mSkillPlaneBtnTxt.text = "技能配置";
				}
				this.mSkillPlaneView.Hide();
				this.mIsHaveOpenSkillPlane = false;
				this.mTipTxt.text = TR.Value("skill point03");
				this.UpdatePlanIsFull();
			}
			this.mSkillBtnRootGo.CustomActive(!this.mIsHaveOpenSkillPlane);
			this.mSkillPanelBtnRoot.CustomActive(this.mIsHaveOpenSkillPlane);
		}

		// Token: 0x0600C093 RID: 49299 RVA: 0x002D8794 File Offset: 0x002D6B94
		private void OnCommandBarBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_recommend_config_make_sure"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("skill_new_enter_skill_cancel"),
				RightButtonText = TR.Value("skill_new_enter_skill_sure"),
				OnRightButtonClickCallBack = new Action(this.EquipRecommendSkillConfig)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600C094 RID: 49300 RVA: 0x002D87F8 File Offset: 0x002D6BF8
		private void EquipRecommendSkillConfig()
		{
			if (!DataManager<SkillDataManager>.GetInstance().IsHaveSetFairDueSkillBar)
			{
				DataManager<SkillDataManager>.GetInstance().SendSetSkillConfigReq(1);
			}
			DataManager<SkillDataManager>.GetInstance().OnSendSceneRecommendSkillsReq(SkillConfigType.SKILL_CONFIG_EQUAL_PVP);
		}

		// Token: 0x0600C095 RID: 49301 RVA: 0x002D8820 File Offset: 0x002D6C20
		private void OnInitSkillBarBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_initialize_config"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("skill_new_enter_skill_cancel"),
				RightButtonText = TR.Value("skill_new_enter_skill_sure"),
				OnRightButtonClickCallBack = new Action(this.EquipInitSkillConfig)
			};
			if (!DataManager<SkillDataManager>.GetInstance().IsHaveSetFairDueSkillBar)
			{
				DataManager<SkillDataManager>.GetInstance().SendSetSkillConfigReq(1);
			}
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600C096 RID: 49302 RVA: 0x002D889E File Offset: 0x002D6C9E
		private void EquipInitSkillConfig()
		{
			DataManager<SkillDataManager>.GetInstance().OnSendSceneInitSkillsReq(SkillConfigType.SKILL_CONFIG_EQUAL_PVP);
		}

		// Token: 0x0600C097 RID: 49303 RVA: 0x002D88AC File Offset: 0x002D6CAC
		private void OnbtSave()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && this.mChangeList.Count > 0)
			{
				this.SendSkillChanged();
			}
		}

		// Token: 0x0600C098 RID: 49304 RVA: 0x002D88E8 File Offset: 0x002D6CE8
		private void SendSkillChanged()
		{
			NetManager netManager = NetManager.Instance();
			ChangeSkill[] array = this.CalSkillChange();
			if (array.Length > 0)
			{
				netManager.SendCommand<SceneChangeSkillsReq>(ServerType.GATE_SERVER, new SceneChangeSkillsReq
				{
					skills = array,
					configType = 3
				});
			}
			this.mChangeList.Clear();
		}

		// Token: 0x0600C099 RID: 49305 RVA: 0x002D8934 File Offset: 0x002D6D34
		public ChangeSkill[] CalSkillChange()
		{
			ChangeSkill[] array = new ChangeSkill[this.mChangeList.Count];
			int num = 0;
			foreach (ushort num2 in this.mChangeList.Keys)
			{
				array[num] = new ChangeSkill
				{
					id = num2,
					dif = this.mChangeList[num2]
				};
				num++;
			}
			return array;
		}

		// Token: 0x0600C09A RID: 49306 RVA: 0x002D89D0 File Offset: 0x002D6DD0
		private void UpdateChangedSkill(bool bIsUp)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)this.mCurSelSkillTreeID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", this.mCurSelSkillTreeID));
				return;
			}
			if (this.mCurSelSkillTreeBtnIdx < 0)
			{
				Logger.LogError("当前选择技能按钮索引小于0");
				return;
			}
			this.UpdateLvChangedSkillInfo(tableItem, bIsUp);
		}

		// Token: 0x0600C09B RID: 49307 RVA: 0x002D8A38 File Offset: 0x002D6E38
		private void UpdateLvChangedSkillInfo(SkillTable skilldata, bool bIsUp)
		{
			byte b = 0;
			if (this.mChangeList.TryGetValue(this.mCurSelSkillTreeID, out b))
			{
				this.mChangeList.Remove(this.mCurSelSkillTreeID);
			}
			if (bIsUp)
			{
				b += 1;
				this.mTotalSp -= (uint)((ushort)skilldata.LearnSPCost);
			}
			else
			{
				b -= 1;
				this.mTotalSp += (uint)((ushort)skilldata.LearnSPCost);
			}
			if (b != 0)
			{
				this.mChangeList.Add(this.mCurSelSkillTreeID, b);
			}
			int addLevel = this.GetAddLevel((int)this.mCurSelSkillTreeID);
			ComSkillTreeEle componentInChildren = this.mSkillPosList[this.mCurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			this.UpdateLvProperty(skilldata, this.mCurSelSkillLv);
			this.mTotalSpTxt.text = this.mTotalSp.ToString();
			if ((int)this.mCurSelSkillLv >= skilldata.TopLevelLimit)
			{
				componentInChildren.Skilllevel.text = "Lv." + skilldata.TopLevelLimit.ToString() + "/" + skilldata.TopLevelLimit.ToString();
				componentInChildren.Skilllevel.color = Color.white;
				componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(false);
			}
			else if (this.mMaxPlayerLvl < skilldata.LevelLimit && skilldata.IsPreJob == 0)
			{
				componentInChildren.Skilllevel.text = "Lv.0/" + skilldata.TopLevelLimit.ToString();
				componentInChildren.Skilllevel.color = Color.gray;
				componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(true);
			}
			else
			{
				if (this.mCurSelSkillLv <= 0)
				{
					componentInChildren.Skilllevel.text = "Lv.0/" + skilldata.TopLevelLimit.ToString();
					componentInChildren.Skilllevel.color = Color.gray;
					componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(true);
				}
				else
				{
					componentInChildren.Skilllevel.text = "Lv." + this.mCurSelSkillLv.ToString() + "/" + skilldata.TopLevelLimit.ToString();
					componentInChildren.Skilllevel.color = Color.white;
					componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(false);
				}
				if (bIsUp)
				{
					this.PlaySkillLvUpEffect(ref componentInChildren);
				}
				else
				{
					this.PlaySkillLvDownEffect(ref componentInChildren);
				}
			}
			if (this.mCurSelSkillTreeBtnIdx < 5)
			{
				componentInChildren.Skilllevel.gameObject.CustomActive(false);
			}
			this.UpdateSkillLvUp();
			this.UpdateLvUpDownBtnState(componentInChildren, this.mCurSelSkillTreeID, this.mCurSelSkillLv);
			this.UpdateRightLevel(this.mSkillPosList, skilldata, addLevel);
			this.UpdateNeedSp(skilldata);
			this.UpdateSkillConsumeMP(skilldata, this.mCurSelSkillLv);
			this.UpdateSkillCDText((ushort)skilldata.ID, skilldata, this.mCurSelSkillLv);
			if (bIsUp && this.mCurSelSkillLv == 1 && skilldata.SkillType == SkillTable.eSkillType.ACTIVE)
			{
				this.mTipTxt.text = TR.Value("skill point01");
				this.UpdatePlanIsFull();
			}
			else
			{
				this.mTipGo.CustomActive(false);
			}
		}

		// Token: 0x0600C09C RID: 49308 RVA: 0x002D8D88 File Offset: 0x002D7188
		private void UpdateSkillLvUp()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			for (int i = 0; i < this.mSkillPosList.Count; i++)
			{
				ComSkillTreeEle componentInChildren = this.mSkillPosList[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					int num = -1;
					if (!dictionary.TryGetValue(i + 1, out num))
					{
						componentInChildren.SkillLvUp.gameObject.CustomActive(false);
					}
					else
					{
						byte skillLv;
						if (i == this.mCurSelSkillTreeBtnIdx)
						{
							skillLv = this.mCurSelSkillLv;
						}
						else
						{
							skillLv = this.CalFinalShowLv((ushort)num);
						}
						this.UpdateShowLvUpImage(componentInChildren, (ushort)num, skillLv, false, false);
					}
				}
			}
		}

		// Token: 0x0600C09D RID: 49309 RVA: 0x002D8E40 File Offset: 0x002D7240
		private void PlaySkillLvUpEffect(ref ComSkillTreeEle comele)
		{
			string path = string.Empty;
			path = this.mLeftRootPath + string.Format(this.mEffectLvUpRootPath, comele.iPanelIndex, this.mCurSelSkillTreeBtnIdx + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mSkillLvUpEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, comele.SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x0600C09E RID: 49310 RVA: 0x002D8EDC File Offset: 0x002D72DC
		private void PlaySkillLvDownEffect(ref ComSkillTreeEle comele)
		{
			string path = string.Empty;
			path = this.mLeftRootPath + string.Format(this.mEffectLvDownRootPath, comele.iPanelIndex, this.mCurSelSkillTreeBtnIdx + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mSkillLvDownEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, comele.SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x0600C09F RID: 49311 RVA: 0x002D8F78 File Offset: 0x002D7378
		private void InitMaskEx()
		{
			MaskEx componentInChildren = this.mUniqueSkillTreeGo.gameObject.GetComponentInChildren<MaskEx>();
			if (componentInChildren != null)
			{
				componentInChildren.Init();
			}
		}

		// Token: 0x0600C0A0 RID: 49312 RVA: 0x002D8FA8 File Offset: 0x002D73A8
		private void UpdatePlanIsFull()
		{
			if (!DataManager<SkillDataManager>.GetInstance().IsFairDuelSkillBarFull(this.mMaxPlayerLvl))
			{
				this.mTipGo.CustomActive(true);
				DOTweenAnimation[] componentsInChildren = this.mTipGo.GetComponentsInChildren<DOTweenAnimation>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].DORestart(false);
				}
			}
			else
			{
				this.mTipGo.CustomActive(false);
			}
		}

		// Token: 0x0600C0A1 RID: 49313 RVA: 0x002D9010 File Offset: 0x002D7410
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, int skillID, bool isEnableIcon)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
			if (comele == null || tableItem == null)
			{
				return;
			}
			this.UpdatePvpForbid(ref comele, tableItem, isEnableIcon);
		}

		// Token: 0x0600C0A2 RID: 49314 RVA: 0x002D9050 File Offset: 0x002D7450
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, SkillTable skillData, bool isEnableIcon)
		{
			if (comele == null || skillData == null)
			{
				return;
			}
			bool flag = skillData.CanUseInPVP == 3;
			if (flag)
			{
				comele.PvPForbidImg.CustomActive(true);
				comele.SkillIcon.GetComponent<UIGray>().enabled = true;
				comele.SkillIcon.GetComponent<UIGray>().SetEnable(true);
				comele.SkillInfoGo.CustomActive(false);
			}
			else
			{
				this.UpdatePvpForbid(ref comele, isEnableIcon);
			}
		}

		// Token: 0x0600C0A3 RID: 49315 RVA: 0x002D90D8 File Offset: 0x002D74D8
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, bool isEnableIcon)
		{
			comele.SkillInfoGo.CustomActive(true);
			comele.PvPForbidImg.CustomActive(false);
			comele.SkillIcon.GetComponent<UIGray>().enabled = isEnableIcon;
			comele.SkillIcon.GetComponent<UIGray>().SetEnable(isEnableIcon);
		}

		// Token: 0x04006CA0 RID: 27808
		private Button mCloseBtn;

		// Token: 0x04006CA1 RID: 27809
		private string mUniqueSkillPath = "UIFlatten/Prefabs/Skill/JobSkillTree";

		// Token: 0x04006CA2 RID: 27810
		private string mSkillTreeElementPath = "UIFlatten/Prefabs/Skill/SkillTreeElement";

		// Token: 0x04006CA3 RID: 27811
		private string mLeftRootPath = "left/root/JobSkillTree(Clone)/ScrollView";

		// Token: 0x04006CA4 RID: 27812
		private string mEffectLvDownRootPath = "/Viewport/Content/ActiveSkillPanel{0}/Pos{1}/SkillTreeElement(Clone)/icon/SkillIcon/EffUI_jinengjiangji_guo(Clone)";

		// Token: 0x04006CA5 RID: 27813
		private string mEffectLvUpRootPath = "/Viewport/Content/ActiveSkillPanel{0}/Pos{1}/SkillTreeElement(Clone)/icon/SkillIcon/EffUI_jinengshengji_guo(Clone)";

		// Token: 0x04006CA6 RID: 27814
		private string mSkillLvUpEffectPath = "Effects/Scene_effects/EffectUI/EffUI_jinengshengji_guo";

		// Token: 0x04006CA7 RID: 27815
		private string mSkillLvDownEffectPath = "Effects/Scene_effects/EffectUI/EffUI_jinengjiangji_guo";

		// Token: 0x04006CA8 RID: 27816
		private string mNewSkillEffectPath = "Effects/Scene_effects/EffectUI/EffUI_newskill";

		// Token: 0x04006CA9 RID: 27817
		private List<GameObject> mSkillPosList = new List<GameObject>();

		// Token: 0x04006CAA RID: 27818
		private List<int> mSkillPosPanelIndexList = new List<int>();

		// Token: 0x04006CAB RID: 27819
		private GameObject mSkillTreeRoot;

		// Token: 0x04006CAC RID: 27820
		private GameObject mUniqueSkillTreeGo;

		// Token: 0x04006CAD RID: 27821
		private GameObject mSkillTreeScrollView;

		// Token: 0x04006CAE RID: 27822
		private GameObject mUniqueContent;

		// Token: 0x04006CAF RID: 27823
		private List<string> mUniqueSkillTransNameList;

		// Token: 0x04006CB0 RID: 27824
		private GameObject mSkillTreeEleTemp;

		// Token: 0x04006CB1 RID: 27825
		private Dictionary<ushort, byte> mChangeList = new Dictionary<ushort, byte>();

		// Token: 0x04006CB2 RID: 27826
		private ushort mCurSelSkillTreeID;

		// Token: 0x04006CB3 RID: 27827
		private int mCurSelSkillTreeBtnIdx;

		// Token: 0x04006CB4 RID: 27828
		private byte mCurSelSkillLv;

		// Token: 0x04006CB5 RID: 27829
		private uint mTotalSp;

		// Token: 0x04006CB6 RID: 27830
		private FairDuelPlaneSkillView mSkillPlaneView;

		// Token: 0x04006CB7 RID: 27831
		private GameObject mSkillPanelBtnRoot;

		// Token: 0x04006CB8 RID: 27832
		private GameObject mTipGo;

		// Token: 0x04006CB9 RID: 27833
		private Text mTipTxt;

		// Token: 0x04006CBA RID: 27834
		private bool mIsHaveOpenSkillPlane;

		// Token: 0x04006CBB RID: 27835
		private GameObject mSkillInfoRoot;

		// Token: 0x04006CBC RID: 27836
		private Image mSelectSkillImg;

		// Token: 0x04006CBD RID: 27837
		private Text mSelectSkillNameTxt;

		// Token: 0x04006CBE RID: 27838
		private Text mSelectSkillAddLvTxt;

		// Token: 0x04006CBF RID: 27839
		private Text mSelectSkillLvTxt;

		// Token: 0x04006CC0 RID: 27840
		private Image mLevelMaxImage;

		// Token: 0x04006CC1 RID: 27841
		private Text mLevelLimitDesTxt;

		// Token: 0x04006CC2 RID: 27842
		private Text mNeedLevelTxt;

		// Token: 0x04006CC3 RID: 27843
		private Text mSelectDesTxt;

		// Token: 0x04006CC4 RID: 27844
		private Text mSelectTypeTxt;

		// Token: 0x04006CC5 RID: 27845
		private Text mSelectCDTxt;

		// Token: 0x04006CC6 RID: 27846
		private Text mSelectSkillConsumeMPTxt;

		// Token: 0x04006CC7 RID: 27847
		private Text mSelectSkillConsumeThingTxt;

		// Token: 0x04006CC8 RID: 27848
		private Text mSelectSkillNeedSpTxt;

		// Token: 0x04006CC9 RID: 27849
		private Text mSelectCurSkillAttriTxt;

		// Token: 0x04006CCA RID: 27850
		private Text mSelectNextSkillAttriTxt;

		// Token: 0x04006CCB RID: 27851
		private Text mTotalSpTxt;

		// Token: 0x04006CCC RID: 27852
		private Button mDownLvBtn;

		// Token: 0x04006CCD RID: 27853
		private Button mUpLvBtn;

		// Token: 0x04006CCE RID: 27854
		private Button mSkillPlanBtn;

		// Token: 0x04006CCF RID: 27855
		private Text mSkillPlaneBtnTxt;

		// Token: 0x04006CD0 RID: 27856
		private Button mInitSkillBarBtn;

		// Token: 0x04006CD1 RID: 27857
		private Button mCommandSkillBarBtn;

		// Token: 0x04006CD2 RID: 27858
		private GameObject mSkillBtnRootGo;

		// Token: 0x04006CD3 RID: 27859
		private GameObject[] mAttributeGoArry = new GameObject[6];

		// Token: 0x04006CD4 RID: 27860
		private Text[] mAttributeTypeTxtArry = new Text[6];

		// Token: 0x04006CD5 RID: 27861
		private int mMaxPlayerLvl;

		// Token: 0x04006CD6 RID: 27862
		private Dictionary<int, SkillLevelAddInfo> mAddSkillInfo = new Dictionary<int, SkillLevelAddInfo>();
	}
}
