using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BDC RID: 7132
	public class TAPQuestionnaireFrame : ClientFrame
	{
		// Token: 0x06011791 RID: 71569 RVA: 0x00513624 File Offset: 0x00511A24
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPQuestionnaireFrame";
		}

		// Token: 0x06011792 RID: 71570 RVA: 0x0051362B File Offset: 0x00511A2B
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this._InitData();
			this._InitUI();
		}

		// Token: 0x06011793 RID: 71571 RVA: 0x0051363F File Offset: 0x00511A3F
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x06011794 RID: 71572 RVA: 0x00513653 File Offset: 0x00511A53
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x06011795 RID: 71573 RVA: 0x00513655 File Offset: 0x00511A55
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x06011796 RID: 71574 RVA: 0x00513658 File Offset: 0x00511A58
		private void _InitData()
		{
			this.activeTimeIndex = 0;
			this.abilityIndex = 0;
			this.regionIndex = 0;
			this.declaration = null;
			this.questionGOList.Clear();
			this.activeAnswer.Clear();
			this.abilityAnswer.Clear();
			GameObject[] collection = new GameObject[]
			{
				this.mQuestionOneRoot,
				this.mQuestionTwoRoot,
				this.mQuestionThreeRoot,
				this.mQuesionFourRoot,
				this.mSubmitAnswer
			};
			this.questionGOList.AddRange(collection);
			TAPType taptype = DataManager<TAPNewDataManager>.GetInstance().IsTeacher();
			if (taptype > TAPType.Pupil)
			{
				this.tapType = TAPQuestionType.Teacher;
			}
			else
			{
				this.tapType = TAPQuestionType.Pupil;
			}
		}

		// Token: 0x06011797 RID: 71575 RVA: 0x00513707 File Offset: 0x00511B07
		private void _StartQuestion()
		{
		}

		// Token: 0x06011798 RID: 71576 RVA: 0x0051370C File Offset: 0x00511B0C
		private void _ClearData()
		{
			this.activeTimeIndex = 0;
			this.abilityIndex = 0;
			this.regionIndex = 0;
			this.declaration = null;
			this.questionGOList.Clear();
			this.activeAnswer.Clear();
			this.abilityAnswer.Clear();
			this.haveInformation = false;
			this.activeTimeStr = null;
			this.abilityStr = null;
			this.regionStr = null;
		}

		// Token: 0x06011799 RID: 71577 RVA: 0x00513774 File Offset: 0x00511B74
		private void _InitUI()
		{
			this._InitNormalQuestion();
			this._InitRegionQuestion();
			this._InitAnswerInformation();
			if (this.haveInformation)
			{
				this._OpenSubmitAnswer();
			}
			else
			{
				this._StartAnswerQuestion();
			}
			if (this.tapType == TAPQuestionType.Teacher)
			{
				this.mSubmitText.text = "查找徒弟";
			}
			else
			{
				this.mSubmitText.text = "查找师父";
			}
		}

		// Token: 0x0601179A RID: 71578 RVA: 0x005137E0 File Offset: 0x00511BE0
		private void _ClearUI()
		{
		}

		// Token: 0x0601179B RID: 71579 RVA: 0x005137E4 File Offset: 0x00511BE4
		private void _InitNormalQuestion()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<TAPQuestionnaireTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				TAPQuestionnaireTable tapquestionnaireTable = keyValuePair.Value as TAPQuestionnaireTable;
				if (tapquestionnaireTable != null)
				{
					if (tapquestionnaireTable.Type == (int)this.tapType)
					{
						if (tapquestionnaireTable.QuestionIndex == 1)
						{
							this.mActiveTimeQuestionText.text = tapquestionnaireTable.QuestionDes;
							this.mSubmitQuestionText1.text = tapquestionnaireTable.QuestionDes;
							int answerIndex = tapquestionnaireTable.AnswerIndex;
							if (answerIndex != 1)
							{
								if (answerIndex != 2)
								{
									if (answerIndex == 3)
									{
										this.mActiveTimeAnswer3.text = tapquestionnaireTable.AnswerDes;
										this.activeAnswer.Add(tapquestionnaireTable.AnswerDes);
									}
								}
								else
								{
									this.mActiveTimeAnswer2.text = tapquestionnaireTable.AnswerDes;
									this.activeAnswer.Add(tapquestionnaireTable.AnswerDes);
								}
							}
							else
							{
								this.mActiveTimeAnswer1.text = tapquestionnaireTable.AnswerDes;
								this.activeAnswer.Add(tapquestionnaireTable.AnswerDes);
							}
						}
						if (tapquestionnaireTable.QuestionIndex == 2)
						{
							this.mAbilityQuestionText.text = tapquestionnaireTable.QuestionDes;
							this.mSubmitQuestionText2.text = tapquestionnaireTable.QuestionDes;
							int answerIndex2 = tapquestionnaireTable.AnswerIndex;
							if (answerIndex2 != 1)
							{
								if (answerIndex2 != 2)
								{
									if (answerIndex2 == 3)
									{
										this.mAbilityAnswer3.text = tapquestionnaireTable.AnswerDes;
										this.abilityAnswer.Add(tapquestionnaireTable.AnswerDes);
									}
								}
								else
								{
									this.mAbilityAnswer2.text = tapquestionnaireTable.AnswerDes;
									this.abilityAnswer.Add(tapquestionnaireTable.AnswerDes);
								}
							}
							else
							{
								this.mAbilityAnswer1.text = tapquestionnaireTable.AnswerDes;
								this.abilityAnswer.Add(tapquestionnaireTable.AnswerDes);
							}
						}
					}
				}
			}
		}

		// Token: 0x0601179C RID: 71580 RVA: 0x005139DC File Offset: 0x00511DDC
		private void _InitRegionQuestion()
		{
			List<string> list = new List<string>();
			list = DataManager<TAPNewDataManager>.GetInstance().GetFirstLetterList();
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/RegionSelectBtn", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("Text");
				com.text = list[i];
				Button com2 = component.GetCom<Button>("RegionSelectBtn");
				string region = list[i];
				if ((list[i][0] >= 'A' && list[i][0] <= 'Z') || (list[i][0] >= 'a' && list[i][0] <= 'z'))
				{
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						this._SelectFirstLetter(region);
					});
				}
				else
				{
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						this._SelectRegion(region);
					});
				}
				Utility.AttachTo(gameObject, this.mFirstLetterRoot, false);
			}
		}

		// Token: 0x0601179D RID: 71581 RVA: 0x00513B34 File Offset: 0x00511F34
		private void _InitAnswerInformation()
		{
			TAPQuestionnaireInformation tapQuestionnaireInformation = DataManager<TAPNewDataManager>.GetInstance().tapQuestionnaireInformation;
			if (tapQuestionnaireInformation == null)
			{
				return;
			}
			if (tapQuestionnaireInformation.activeTimeType == 0)
			{
				this.haveInformation = false;
			}
			else
			{
				this.haveInformation = true;
				this.activeTimeIndex = (int)tapQuestionnaireInformation.activeTimeType;
				this.abilityIndex = (int)tapQuestionnaireInformation.masterType;
				this.regionIndex = (int)tapQuestionnaireInformation.regionId;
				this.activeTimeStr = this.activeAnswer[(int)(tapQuestionnaireInformation.activeTimeType - 1)];
				this.abilityStr = this.abilityAnswer[(int)(tapQuestionnaireInformation.masterType - 1)];
				AreaProvinceTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AreaProvinceTable>((int)tapQuestionnaireInformation.regionId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.regionStr = tableItem.Name;
				}
				this.mActiveTimeAnswer.text = this.activeTimeStr;
				this.mAbilityAnswer.text = this.abilityStr;
				this.mRegionAnswer.text = this.regionStr;
				this.declaration = tapQuestionnaireInformation.declaration;
				if (this.declaration == null || this.declaration.Length == 0)
				{
					if (this.tapType == TAPQuestionType.Teacher)
					{
						this.declaration = TR.Value("tap_teacher_region");
					}
					else
					{
						this.declaration = TR.Value("tap_pupil_region");
					}
				}
				this.mInputField.text = this.declaration;
			}
		}

		// Token: 0x0601179E RID: 71582 RVA: 0x00513C90 File Offset: 0x00512090
		private void _SelectFirstLetter(string firstLetter)
		{
			this._AnswerQuestion(3);
			List<string> list = new List<string>();
			list = DataManager<TAPNewDataManager>.GetInstance().GetRegionList(firstLetter);
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/RegionNameSelectBtn", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("Text");
				string tempStr = list[i];
				com.text = tempStr;
				Button com2 = component.GetCom<Button>("RegionSelectBtn");
				com2.onClick.RemoveAllListeners();
				com2.onClick.AddListener(delegate()
				{
					this._SelectRegion(tempStr);
				});
				Utility.AttachTo(gameObject, this.mRegionRoot, false);
			}
		}

		// Token: 0x0601179F RID: 71583 RVA: 0x00513D7D File Offset: 0x0051217D
		private void _SelectRegion(string region)
		{
			this._AnswerQuestion(4);
			this.regionIndex = DataManager<TAPNewDataManager>.GetInstance().GetRegionID(region);
			this.regionStr = region;
			this._SetSubmitAnswer();
		}

		// Token: 0x060117A0 RID: 71584 RVA: 0x00513DA4 File Offset: 0x005121A4
		private void _SetSubmitAnswer()
		{
			this.mActiveTimeAnswer.text = this.activeTimeStr;
			this.mAbilityAnswer.text = this.abilityStr;
			this.mRegionAnswer.text = this.regionStr;
		}

		// Token: 0x060117A1 RID: 71585 RVA: 0x00513DD9 File Offset: 0x005121D9
		private void _StartAnswerQuestion()
		{
			this.curIndex = 0;
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117A2 RID: 71586 RVA: 0x00513DE9 File Offset: 0x005121E9
		private void _OpenSubmitAnswer()
		{
			this.curIndex = this.questionGOList.Count - 1;
			this._AnswerQuestion(this.curIndex);
		}

		// Token: 0x060117A3 RID: 71587 RVA: 0x00513E0C File Offset: 0x0051220C
		private void _AnswerQuestion(int index = -1)
		{
			if (index != -1)
			{
				this.curIndex = index;
			}
			if (this.curIndex > this.questionGOList.Count)
			{
				this.frameMgr.CloseFrame<TAPQuestionnaireFrame>(this, false);
			}
			if (this.curIndex == this.questionGOList.Count - 1)
			{
				this.mTitleName.text = TR.Value("tap_question_last_name");
				this.mTitleQuestionText.text = TR.Value("tap_question_submit_title");
			}
			else
			{
				this.mTitleName.text = TR.Value("tap_question_normal_name");
				if (this.tapType == TAPQuestionType.Teacher)
				{
					this.mTitleQuestionText.text = TR.Value("tap_question_teacher_title");
				}
				else
				{
					this.mTitleQuestionText.text = TR.Value("tap_question_pupil_title");
				}
			}
			for (int i = 0; i < this.questionGOList.Count; i++)
			{
				this.questionGOList[i].CustomActive(false);
				if (i == this.curIndex)
				{
					this.questionGOList[i].CustomActive(true);
				}
			}
			this.curIndex++;
			int num;
			if (this.curIndex > 2)
			{
				num = 3;
			}
			else
			{
				num = this.curIndex;
			}
			this.mSchedule.text = string.Format("第（{0} / 3）题", num);
		}

		// Token: 0x060117A4 RID: 71588 RVA: 0x00513F74 File Offset: 0x00512374
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mSchedule = this.mBind.GetCom<Text>("Schedule");
			this.mQuestionOneRoot = this.mBind.GetGameObject("QuestionOneRoot");
			this.mQuestionTwoRoot = this.mBind.GetGameObject("QuestionTwoRoot");
			this.mQuestionThreeRoot = this.mBind.GetGameObject("QuestionThreeRoot");
			this.mQuesionFourRoot = this.mBind.GetGameObject("QuesionFourRoot");
			this.mSubmitAnswer = this.mBind.GetGameObject("SubmitAnswer");
			this.mActiveTimeSubmit1 = this.mBind.GetCom<Button>("ActiveTimeSubmit1");
			if (null != this.mActiveTimeSubmit1)
			{
				this.mActiveTimeSubmit1.onClick.AddListener(new UnityAction(this._onActiveTimeSubmit1ButtonClick));
			}
			this.mActiveTimeSubmit2 = this.mBind.GetCom<Button>("ActiveTimeSubmit2");
			if (null != this.mActiveTimeSubmit2)
			{
				this.mActiveTimeSubmit2.onClick.AddListener(new UnityAction(this._onActiveTimeSubmit2ButtonClick));
			}
			this.mActiveTimeSubmit3 = this.mBind.GetCom<Button>("ActiveTimeSubmit3");
			if (null != this.mActiveTimeSubmit3)
			{
				this.mActiveTimeSubmit3.onClick.AddListener(new UnityAction(this._onActiveTimeSubmit3ButtonClick));
			}
			this.mAbilitySubmit1 = this.mBind.GetCom<Button>("AbilitySubmit1");
			if (null != this.mAbilitySubmit1)
			{
				this.mAbilitySubmit1.onClick.AddListener(new UnityAction(this._onAbilitySubmit1ButtonClick));
			}
			this.mAbilitySubmit2 = this.mBind.GetCom<Button>("AbilitySubmit2");
			if (null != this.mAbilitySubmit2)
			{
				this.mAbilitySubmit2.onClick.AddListener(new UnityAction(this._onAbilitySubmit2ButtonClick));
			}
			this.mAbilitySubmit3 = this.mBind.GetCom<Button>("AbilitySubmit3");
			if (null != this.mAbilitySubmit3)
			{
				this.mAbilitySubmit3.onClick.AddListener(new UnityAction(this._onAbilitySubmit3ButtonClick));
			}
			this.mFirstLetterRoot = this.mBind.GetGameObject("FirstLetterRoot");
			this.mRegionRoot = this.mBind.GetGameObject("RegionRoot");
			this.mActiveTimeAnswer = this.mBind.GetCom<Text>("ActiveTimeAnswer");
			this.mAbilityAnswer = this.mBind.GetCom<Text>("AbilityAnswer");
			this.mRegionAnswer = this.mBind.GetCom<Text>("RegionAnswer");
			this.mDeclarationAnswer = this.mBind.GetCom<Text>("DeclarationAnswer");
			this.mReWrite = this.mBind.GetCom<Button>("ReWrite");
			if (null != this.mReWrite)
			{
				this.mReWrite.onClick.AddListener(new UnityAction(this._onReWriteButtonClick));
			}
			this.mWorldSay = this.mBind.GetCom<Button>("WorldSay");
			if (null != this.mWorldSay)
			{
				this.mWorldSay.onClick.AddListener(new UnityAction(this._onWorldSayButtonClick));
			}
			this.mSubmit = this.mBind.GetCom<Button>("Submit");
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.AddListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mInputField = this.mBind.GetCom<InputField>("InputField");
			if (null != this.mInputField)
			{
				this.mInputField.onValueChanged.AddListener(new UnityAction<string>(this._OnValueChanged));
			}
			this.mActiveTimeQuestionText = this.mBind.GetCom<Text>("ActiveTimeQuestionText");
			this.mActiveTimeAnswer1 = this.mBind.GetCom<Text>("ActiveTimeAnswer1");
			this.mActiveTimeAnswer2 = this.mBind.GetCom<Text>("ActiveTimeAnswer2");
			this.mActiveTimeAnswer3 = this.mBind.GetCom<Text>("ActiveTimeAnswer3");
			this.mAbilityQuestionText = this.mBind.GetCom<Text>("AbilityQuestionText");
			this.mAbilityAnswer1 = this.mBind.GetCom<Text>("AbilityAnswer1");
			this.mAbilityAnswer2 = this.mBind.GetCom<Text>("AbilityAnswer2");
			this.mAbilityAnswer3 = this.mBind.GetCom<Text>("AbilityAnswer3");
			this.mSubmitText = this.mBind.GetCom<Text>("SubmitText");
			this.mTitleName = this.mBind.GetCom<Text>("TitleName");
			this.mTitleQuestionText = this.mBind.GetCom<Text>("TitleQuestionText");
			this.mSubmitQuestionText1 = this.mBind.GetCom<Text>("SubmitQuestionText1");
			this.mSubmitQuestionText2 = this.mBind.GetCom<Text>("SubmitQuestionText2");
			this.mSubmitQuestionText3 = this.mBind.GetCom<Text>("SubmitQuestionText3");
		}

		// Token: 0x060117A5 RID: 71589 RVA: 0x005144A0 File Offset: 0x005128A0
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mSchedule = null;
			this.mQuestionOneRoot = null;
			this.mQuestionTwoRoot = null;
			this.mQuestionThreeRoot = null;
			this.mQuesionFourRoot = null;
			this.mSubmitAnswer = null;
			if (null != this.mActiveTimeSubmit1)
			{
				this.mActiveTimeSubmit1.onClick.RemoveListener(new UnityAction(this._onActiveTimeSubmit1ButtonClick));
			}
			this.mActiveTimeSubmit1 = null;
			if (null != this.mActiveTimeSubmit2)
			{
				this.mActiveTimeSubmit2.onClick.RemoveListener(new UnityAction(this._onActiveTimeSubmit2ButtonClick));
			}
			this.mActiveTimeSubmit2 = null;
			if (null != this.mActiveTimeSubmit3)
			{
				this.mActiveTimeSubmit3.onClick.RemoveListener(new UnityAction(this._onActiveTimeSubmit3ButtonClick));
			}
			this.mActiveTimeSubmit3 = null;
			if (null != this.mAbilitySubmit1)
			{
				this.mAbilitySubmit1.onClick.RemoveListener(new UnityAction(this._onAbilitySubmit1ButtonClick));
			}
			this.mAbilitySubmit1 = null;
			if (null != this.mAbilitySubmit2)
			{
				this.mAbilitySubmit2.onClick.RemoveListener(new UnityAction(this._onAbilitySubmit2ButtonClick));
			}
			this.mAbilitySubmit2 = null;
			if (null != this.mAbilitySubmit3)
			{
				this.mAbilitySubmit3.onClick.RemoveListener(new UnityAction(this._onAbilitySubmit3ButtonClick));
			}
			this.mAbilitySubmit3 = null;
			this.mFirstLetterRoot = null;
			this.mRegionRoot = null;
			this.mActiveTimeAnswer = null;
			this.mAbilityAnswer = null;
			this.mRegionAnswer = null;
			this.mDeclarationAnswer = null;
			if (null != this.mReWrite)
			{
				this.mReWrite.onClick.RemoveListener(new UnityAction(this._onReWriteButtonClick));
			}
			this.mReWrite = null;
			if (null != this.mWorldSay)
			{
				this.mWorldSay.onClick.RemoveListener(new UnityAction(this._onWorldSayButtonClick));
			}
			this.mWorldSay = null;
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.RemoveListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mSubmit = null;
			if (null != this.mInputField)
			{
				this.mInputField.onValueChanged.RemoveListener(new UnityAction<string>(this._OnValueChanged));
			}
			this.mInputField = null;
			this.mActiveTimeQuestionText = null;
			this.mActiveTimeAnswer1 = null;
			this.mActiveTimeAnswer2 = null;
			this.mActiveTimeAnswer3 = null;
			this.mAbilityQuestionText = null;
			this.mAbilityAnswer1 = null;
			this.mAbilityAnswer2 = null;
			this.mAbilityAnswer3 = null;
			this.mSubmitText = null;
			this.mTitleName = null;
			this.mTitleQuestionText = null;
			this.mSubmitQuestionText1 = null;
			this.mSubmitQuestionText2 = null;
			this.mSubmitQuestionText3 = null;
		}

		// Token: 0x060117A6 RID: 71590 RVA: 0x0051479F File Offset: 0x00512B9F
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPQuestionnaireFrame>(this, false);
		}

		// Token: 0x060117A7 RID: 71591 RVA: 0x005147B0 File Offset: 0x00512BB0
		private void _onActiveTimeSubmit1ButtonClick()
		{
			this.activeTimeIndex = 1;
			Text componentInChildren = this.mActiveTimeSubmit1.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.activeTimeStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117A8 RID: 71592 RVA: 0x005147F0 File Offset: 0x00512BF0
		private void _onActiveTimeSubmit2ButtonClick()
		{
			this.activeTimeIndex = 2;
			Text componentInChildren = this.mActiveTimeSubmit2.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.activeTimeStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117A9 RID: 71593 RVA: 0x00514830 File Offset: 0x00512C30
		private void _onActiveTimeSubmit3ButtonClick()
		{
			this.activeTimeIndex = 3;
			Text componentInChildren = this.mActiveTimeSubmit3.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.activeTimeStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117AA RID: 71594 RVA: 0x00514870 File Offset: 0x00512C70
		private void _onAbilitySubmit1ButtonClick()
		{
			this.abilityIndex = 1;
			Text componentInChildren = this.mAbilitySubmit1.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.abilityStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117AB RID: 71595 RVA: 0x005148B0 File Offset: 0x00512CB0
		private void _onAbilitySubmit2ButtonClick()
		{
			this.abilityIndex = 2;
			Text componentInChildren = this.mAbilitySubmit2.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.abilityStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117AC RID: 71596 RVA: 0x005148F0 File Offset: 0x00512CF0
		private void _onAbilitySubmit3ButtonClick()
		{
			this.abilityIndex = 3;
			Text componentInChildren = this.mAbilitySubmit3.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				this.abilityStr = componentInChildren.text;
			}
			this._AnswerQuestion(-1);
		}

		// Token: 0x060117AD RID: 71597 RVA: 0x0051492F File Offset: 0x00512D2F
		private void _onReWriteButtonClick()
		{
			this._StartAnswerQuestion();
		}

		// Token: 0x060117AE RID: 71598 RVA: 0x00514938 File Offset: 0x00512D38
		private void _onWorldSayButtonClick()
		{
			if (this.declaration == null || this.declaration.Length == 0)
			{
				if (this.tapType == TAPQuestionType.Teacher)
				{
					this.declaration = TR.Value("tap_teacher_region");
				}
				else
				{
					this.declaration = TR.Value("tap_pupil_region");
				}
			}
			DataManager<TAPNewDataManager>.GetInstance().SendTAPInformation(this.activeTimeIndex, this.abilityIndex, this.regionIndex, this.declaration);
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacherOrPupil"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (this.tapType == TAPQuestionType.Teacher)
			{
				if (!DataManager<TAPNewDataManager>.GetInstance().canSearchTeacher())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacher2"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (DataManager<TAPNewDataManager>.GetInstance().canSearchPupil())
				{
					DataManager<TAPNewDataManager>.GetInstance().AnnounceWorld(RelationAnnounceType.Master);
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_world_announce"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchPupil"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else if (DataManager<TAPNewDataManager>.GetInstance().canSearchTeacher())
			{
				DataManager<TAPNewDataManager>.GetInstance().AnnounceWorld(RelationAnnounceType.Disciple);
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_world_announce"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacher"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.frameMgr.CloseFrame<TAPQuestionnaireFrame>(this, false);
		}

		// Token: 0x060117AF RID: 71599 RVA: 0x00514AA0 File Offset: 0x00512EA0
		private void _onSubmitButtonClick()
		{
			if (this.declaration == null || this.declaration.Length == 0)
			{
				if (this.tapType == TAPQuestionType.Teacher)
				{
					this.declaration = TR.Value("tap_teacher_region");
				}
				else
				{
					this.declaration = TR.Value("tap_pupil_region");
				}
			}
			DataManager<TAPNewDataManager>.GetInstance().SendTAPInformation(this.activeTimeIndex, this.abilityIndex, this.regionIndex, this.declaration);
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacherOrPupil"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (this.tapType == TAPQuestionType.Teacher)
			{
				if (!DataManager<TAPNewDataManager>.GetInstance().canSearchTeacher())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacher2"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (DataManager<TAPNewDataManager>.GetInstance().canSearchPupil())
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchPupil"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else if (DataManager<TAPNewDataManager>.GetInstance().canSearchTeacher())
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_searchTeacher"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.frameMgr.CloseFrame<TAPQuestionnaireFrame>(this, false);
		}

		// Token: 0x060117B0 RID: 71600 RVA: 0x00514BFC File Offset: 0x00512FFC
		private void _OnValueChanged(string value)
		{
			this.declaration = value;
		}

		// Token: 0x0400B581 RID: 46465
		private const string regionFirstSelectGOPath = "UIFlatten/Prefabs/TAP/RegionSelectBtn";

		// Token: 0x0400B582 RID: 46466
		private const string regionGOPath = "UIFlatten/Prefabs/TAP/RegionNameSelectBtn";

		// Token: 0x0400B583 RID: 46467
		private int activeTimeIndex;

		// Token: 0x0400B584 RID: 46468
		private int abilityIndex;

		// Token: 0x0400B585 RID: 46469
		private int regionIndex;

		// Token: 0x0400B586 RID: 46470
		private string declaration;

		// Token: 0x0400B587 RID: 46471
		private List<GameObject> questionGOList = new List<GameObject>();

		// Token: 0x0400B588 RID: 46472
		private List<string> activeAnswer = new List<string>();

		// Token: 0x0400B589 RID: 46473
		private List<string> abilityAnswer = new List<string>();

		// Token: 0x0400B58A RID: 46474
		private int curIndex = -1;

		// Token: 0x0400B58B RID: 46475
		private TAPQuestionType tapType;

		// Token: 0x0400B58C RID: 46476
		private bool haveInformation;

		// Token: 0x0400B58D RID: 46477
		private string activeTimeStr;

		// Token: 0x0400B58E RID: 46478
		private string abilityStr;

		// Token: 0x0400B58F RID: 46479
		private string regionStr;

		// Token: 0x0400B590 RID: 46480
		private Button mClose;

		// Token: 0x0400B591 RID: 46481
		private Text mSchedule;

		// Token: 0x0400B592 RID: 46482
		private GameObject mQuestionOneRoot;

		// Token: 0x0400B593 RID: 46483
		private GameObject mQuestionTwoRoot;

		// Token: 0x0400B594 RID: 46484
		private GameObject mQuestionThreeRoot;

		// Token: 0x0400B595 RID: 46485
		private GameObject mQuesionFourRoot;

		// Token: 0x0400B596 RID: 46486
		private GameObject mSubmitAnswer;

		// Token: 0x0400B597 RID: 46487
		private Button mActiveTimeSubmit1;

		// Token: 0x0400B598 RID: 46488
		private Button mActiveTimeSubmit2;

		// Token: 0x0400B599 RID: 46489
		private Button mActiveTimeSubmit3;

		// Token: 0x0400B59A RID: 46490
		private Button mAbilitySubmit1;

		// Token: 0x0400B59B RID: 46491
		private Button mAbilitySubmit2;

		// Token: 0x0400B59C RID: 46492
		private Button mAbilitySubmit3;

		// Token: 0x0400B59D RID: 46493
		private GameObject mFirstLetterRoot;

		// Token: 0x0400B59E RID: 46494
		private GameObject mRegionRoot;

		// Token: 0x0400B59F RID: 46495
		private Text mActiveTimeAnswer;

		// Token: 0x0400B5A0 RID: 46496
		private Text mAbilityAnswer;

		// Token: 0x0400B5A1 RID: 46497
		private Text mRegionAnswer;

		// Token: 0x0400B5A2 RID: 46498
		private Text mDeclarationAnswer;

		// Token: 0x0400B5A3 RID: 46499
		private Button mReWrite;

		// Token: 0x0400B5A4 RID: 46500
		private Button mWorldSay;

		// Token: 0x0400B5A5 RID: 46501
		private Button mSubmit;

		// Token: 0x0400B5A6 RID: 46502
		private InputField mInputField;

		// Token: 0x0400B5A7 RID: 46503
		private Text mActiveTimeQuestionText;

		// Token: 0x0400B5A8 RID: 46504
		private Text mActiveTimeAnswer1;

		// Token: 0x0400B5A9 RID: 46505
		private Text mActiveTimeAnswer2;

		// Token: 0x0400B5AA RID: 46506
		private Text mActiveTimeAnswer3;

		// Token: 0x0400B5AB RID: 46507
		private Text mAbilityQuestionText;

		// Token: 0x0400B5AC RID: 46508
		private Text mAbilityAnswer1;

		// Token: 0x0400B5AD RID: 46509
		private Text mAbilityAnswer2;

		// Token: 0x0400B5AE RID: 46510
		private Text mAbilityAnswer3;

		// Token: 0x0400B5AF RID: 46511
		private Text mSubmitText;

		// Token: 0x0400B5B0 RID: 46512
		private Text mTitleName;

		// Token: 0x0400B5B1 RID: 46513
		private Text mTitleQuestionText;

		// Token: 0x0400B5B2 RID: 46514
		private Text mSubmitQuestionText1;

		// Token: 0x0400B5B3 RID: 46515
		private Text mSubmitQuestionText2;

		// Token: 0x0400B5B4 RID: 46516
		private Text mSubmitQuestionText3;
	}
}
