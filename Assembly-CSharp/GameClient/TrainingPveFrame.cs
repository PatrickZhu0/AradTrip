using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010E8 RID: 4328
	public class TrainingPveFrame : ClientFrame
	{
		// Token: 0x0600A405 RID: 41989 RVA: 0x0021B0C4 File Offset: 0x002194C4
		protected override void _bindExUI()
		{
			this.mButton_Open = this.mBind.GetCom<Button>("Button_Open");
			if (null != this.mButton_Open)
			{
				this.mButton_Open.onClick.AddListener(new UnityAction(this._onButton_OpenButtonClick));
			}
			this.mButton_Close = this.mBind.GetCom<Button>("Button_Close");
			if (null != this.mButton_Close)
			{
				this.mButton_Close.onClick.AddListener(new UnityAction(this._onButton_CloseButtonClick));
			}
			this.mContent = this.mBind.GetGameObject("Content");
			this.mDropdown_Name = this.mBind.GetCom<Dropdown>("Dropdown_Name");
			if (null != this.mDropdown_Name)
			{
				this.mDropdown_Name.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_NameDropdownValueChange));
			}
			this.mDropdown_Level = this.mBind.GetCom<Dropdown>("Dropdown_Level");
			if (null != this.mDropdown_Level)
			{
				this.mDropdown_Level.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_LevelDropdownValueChange));
			}
			this.mDropdown_Abnormal = this.mBind.GetCom<Dropdown>("Dropdown_Abnormal");
			if (null != this.mDropdown_Abnormal)
			{
				this.mDropdown_Abnormal.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_AbnormalDropdownValueChange));
			}
			this.mToggle_Bati = this.mBind.GetCom<Toggle>("Toggle_Bati");
			if (null != this.mToggle_Bati)
			{
				this.mToggle_Bati.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle_BatiToggleValueChange));
			}
			this.mToggle_Normal = this.mBind.GetCom<Toggle>("Toggle_Normal");
			if (null != this.mToggle_Normal)
			{
				this.mToggle_Normal.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle_NormalToggleValueChange));
			}
			this.mToggle_Second = this.mBind.GetCom<Toggle>("Toggle_Second");
			if (null != this.mToggle_Second)
			{
				this.mToggle_Second.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle_SecondToggleValueChange));
			}
			this.mDropdown_Baoji = this.mBind.GetCom<Dropdown>("Dropdown_Baoji");
			if (null != this.mDropdown_Baoji)
			{
				this.mDropdown_Baoji.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_BaojiDropdownValueChange));
			}
			this.mDropdown_Siwei = this.mBind.GetCom<Dropdown>("Dropdown_Siwei");
			if (null != this.mDropdown_Siwei)
			{
				this.mDropdown_Siwei.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_SiweiDropdownValueChange));
			}
			this.mDropdown_ShuxingQianghu = this.mBind.GetCom<Dropdown>("Dropdown_ShuxingQianghu");
			if (null != this.mDropdown_ShuxingQianghu)
			{
				this.mDropdown_ShuxingQianghu.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_ShuxingQianghuDropdownValueChange));
			}
			this.mDropdown_Renwusudu = this.mBind.GetCom<Dropdown>("Dropdown_Renwusudu");
			if (null != this.mDropdown_Renwusudu)
			{
				this.mDropdown_Renwusudu.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_RenwusuduDropdownValueChange));
			}
			this.mToggle_Pozhao = this.mBind.GetCom<Toggle>("Toggle_Pozhao");
			if (null != this.mToggle_Pozhao)
			{
				this.mToggle_Pozhao.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle_PozhaoToggleValueChange));
			}
			this.mToggle_Mingzhong = this.mBind.GetCom<Toggle>("Toggle_Mingzhong");
			if (null != this.mToggle_Mingzhong)
			{
				this.mToggle_Mingzhong.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle_MingzhongToggleValueChange));
			}
			this.mButton_ResetCD = this.mBind.GetCom<Button>("Button_ResetCD");
			if (null != this.mButton_ResetCD)
			{
				this.mButton_ResetCD.onClick.AddListener(new UnityAction(this._onButton_ResetCDButtonClick));
			}
			this.mButton_Damage = this.mBind.GetCom<Button>("Button_Damage");
			if (null != this.mButton_Damage)
			{
				this.mButton_Damage.onClick.AddListener(new UnityAction(this._onButton_DamageButtonClick));
			}
			this.mButton_Summon = this.mBind.GetCom<Button>("Button_Summon");
			if (null != this.mButton_Summon)
			{
				this.mButton_Summon.onClick.AddListener(new UnityAction(this._onButton_SummonButtonClick));
			}
			this.mButton_DeleteAll = this.mBind.GetCom<Button>("Button_DeleteAll");
			if (null != this.mButton_DeleteAll)
			{
				this.mButton_DeleteAll.onClick.AddListener(new UnityAction(this._onButton_DeleteAllButtonClick));
			}
			this.mButton_Exit = this.mBind.GetCom<Button>("Button_Exit");
			if (null != this.mButton_Exit)
			{
				this.mButton_Exit.onClick.AddListener(new UnityAction(this._onButton_ExitButtonClick));
			}
			this.mSecondContent = this.mBind.GetGameObject("SecondContent");
			this.mSecondTime = this.mBind.GetCom<Text>("SecondTime");
			this.mTime = this.mBind.GetCom<Text>("Time");
		}

		// Token: 0x0600A406 RID: 41990 RVA: 0x0021B624 File Offset: 0x00219A24
		protected override void _unbindExUI()
		{
			if (null != this.mButton_Open)
			{
				this.mButton_Open.onClick.RemoveListener(new UnityAction(this._onButton_OpenButtonClick));
			}
			this.mButton_Open = null;
			if (null != this.mButton_Close)
			{
				this.mButton_Close.onClick.RemoveListener(new UnityAction(this._onButton_CloseButtonClick));
			}
			this.mButton_Close = null;
			this.mContent = null;
			if (null != this.mDropdown_Name)
			{
				this.mDropdown_Name.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_NameDropdownValueChange));
			}
			this.mDropdown_Name = null;
			if (null != this.mDropdown_Level)
			{
				this.mDropdown_Level.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_LevelDropdownValueChange));
			}
			this.mDropdown_Level = null;
			if (null != this.mDropdown_Abnormal)
			{
				this.mDropdown_Abnormal.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_AbnormalDropdownValueChange));
			}
			this.mDropdown_Abnormal = null;
			if (null != this.mToggle_Bati)
			{
				this.mToggle_Bati.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle_BatiToggleValueChange));
			}
			this.mToggle_Bati = null;
			if (null != this.mToggle_Normal)
			{
				this.mToggle_Normal.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle_NormalToggleValueChange));
			}
			this.mToggle_Normal = null;
			if (null != this.mToggle_Second)
			{
				this.mToggle_Second.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle_SecondToggleValueChange));
			}
			this.mToggle_Second = null;
			if (null != this.mDropdown_Baoji)
			{
				this.mDropdown_Baoji.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_BaojiDropdownValueChange));
			}
			this.mDropdown_Baoji = null;
			if (null != this.mDropdown_Siwei)
			{
				this.mDropdown_Siwei.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_SiweiDropdownValueChange));
			}
			this.mDropdown_Siwei = null;
			if (null != this.mDropdown_ShuxingQianghu)
			{
				this.mDropdown_ShuxingQianghu.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_ShuxingQianghuDropdownValueChange));
			}
			this.mDropdown_ShuxingQianghu = null;
			if (null != this.mDropdown_Renwusudu)
			{
				this.mDropdown_Renwusudu.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_RenwusuduDropdownValueChange));
			}
			this.mDropdown_Renwusudu = null;
			if (null != this.mToggle_Pozhao)
			{
				this.mToggle_Pozhao.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle_PozhaoToggleValueChange));
			}
			this.mToggle_Pozhao = null;
			if (null != this.mToggle_Mingzhong)
			{
				this.mToggle_Mingzhong.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle_MingzhongToggleValueChange));
			}
			this.mToggle_Mingzhong = null;
			if (null != this.mButton_ResetCD)
			{
				this.mButton_ResetCD.onClick.RemoveListener(new UnityAction(this._onButton_ResetCDButtonClick));
			}
			this.mButton_ResetCD = null;
			if (null != this.mButton_Damage)
			{
				this.mButton_Damage.onClick.RemoveListener(new UnityAction(this._onButton_DamageButtonClick));
			}
			this.mButton_Damage = null;
			if (null != this.mButton_Summon)
			{
				this.mButton_Summon.onClick.RemoveListener(new UnityAction(this._onButton_SummonButtonClick));
			}
			this.mButton_Summon = null;
			if (null != this.mButton_DeleteAll)
			{
				this.mButton_DeleteAll.onClick.RemoveListener(new UnityAction(this._onButton_DeleteAllButtonClick));
			}
			this.mButton_DeleteAll = null;
			if (null != this.mButton_Exit)
			{
				this.mButton_Exit.onClick.RemoveListener(new UnityAction(this._onButton_ExitButtonClick));
			}
			this.mButton_Exit = null;
			this.mSecondContent = null;
			this.mSecondTime = null;
			this.mTime = null;
		}

		// Token: 0x0600A407 RID: 41991 RVA: 0x0021BA29 File Offset: 0x00219E29
		private void _onButton_OpenButtonClick()
		{
			this.mContent.CustomActive(true);
			this.mButton_Open.CustomActive(false);
		}

		// Token: 0x0600A408 RID: 41992 RVA: 0x0021BA43 File Offset: 0x00219E43
		private void _onButton_CloseButtonClick()
		{
			this.mButton_Open.CustomActive(true);
			this.mContent.CustomActive(false);
		}

		// Token: 0x0600A409 RID: 41993 RVA: 0x0021BA5D File Offset: 0x00219E5D
		private void _onDropdown_NameDropdownValueChange(int index)
		{
		}

		// Token: 0x0600A40A RID: 41994 RVA: 0x0021BA5F File Offset: 0x00219E5F
		private void _onDropdown_LevelDropdownValueChange(int index)
		{
		}

		// Token: 0x0600A40B RID: 41995 RVA: 0x0021BA61 File Offset: 0x00219E61
		private void _onDropdown_AbnormalDropdownValueChange(int index)
		{
		}

		// Token: 0x0600A40C RID: 41996 RVA: 0x0021BA63 File Offset: 0x00219E63
		private void _onToggle_BatiToggleValueChange(bool changed)
		{
		}

		// Token: 0x0600A40D RID: 41997 RVA: 0x0021BA65 File Offset: 0x00219E65
		private void _onToggle_NormalToggleValueChange(bool changed)
		{
			this.mSecondContent.CustomActive(false);
		}

		// Token: 0x0600A40E RID: 41998 RVA: 0x0021BA73 File Offset: 0x00219E73
		private void _onToggle_SecondToggleValueChange(bool changed)
		{
			this.mSecondContent.CustomActive(true);
		}

		// Token: 0x0600A40F RID: 41999 RVA: 0x0021BA81 File Offset: 0x00219E81
		private void _onDropdown_BaojiDropdownValueChange(int index)
		{
			if (this.battle != null)
			{
				this.battle.ChangeMainActorBuff(index, 0);
			}
		}

		// Token: 0x0600A410 RID: 42000 RVA: 0x0021BA9B File Offset: 0x00219E9B
		private void _onDropdown_SiweiDropdownValueChange(int index)
		{
			if (this.battle != null)
			{
				this.battle.ChangeMainActorBuff(index, 1);
			}
		}

		// Token: 0x0600A411 RID: 42001 RVA: 0x0021BAB5 File Offset: 0x00219EB5
		private void _onDropdown_ShuxingQianghuDropdownValueChange(int index)
		{
			if (this.battle != null)
			{
				this.battle.ChangeMainActorBuff(index, 2);
			}
		}

		// Token: 0x0600A412 RID: 42002 RVA: 0x0021BACF File Offset: 0x00219ECF
		private void _onDropdown_RenwusuduDropdownValueChange(int index)
		{
			if (this.battle != null)
			{
				this.battle.ChangeMainActorBuff(index, 3);
			}
		}

		// Token: 0x0600A413 RID: 42003 RVA: 0x0021BAE9 File Offset: 0x00219EE9
		private void _onToggle_PozhaoToggleValueChange(bool changed)
		{
			if (this.battle != null)
			{
				this.battle.ChangeActorBroken(changed);
			}
		}

		// Token: 0x0600A414 RID: 42004 RVA: 0x0021BB02 File Offset: 0x00219F02
		private void _onToggle_MingzhongToggleValueChange(bool changed)
		{
			if (this.battle != null)
			{
				this.battle.ChangeActorHitRate(changed);
			}
		}

		// Token: 0x0600A415 RID: 42005 RVA: 0x0021BB1B File Offset: 0x00219F1B
		private void _onButton_ResetCDButtonClick()
		{
			if (this.battle != null)
			{
				this.battle.ResetAllCD();
			}
		}

		// Token: 0x0600A416 RID: 42006 RVA: 0x0021BB34 File Offset: 0x00219F34
		private void _onButton_DamageButtonClick()
		{
			SkillDamageFrame skillDamageFrame = Singleton<ClientSystemManager>.instance.OpenFrame<SkillDamageFrame>(FrameLayer.Middle, null, string.Empty) as SkillDamageFrame;
			if (skillDamageFrame != null)
			{
				skillDamageFrame.InitData(true);
			}
		}

		// Token: 0x0600A417 RID: 42007 RVA: 0x0021BB68 File Offset: 0x00219F68
		private void _onButton_SummonButtonClick()
		{
			if (!this.mToggle_Second.isOn)
			{
				if (this.battle != null)
				{
					this.battle.SummonMonster();
				}
				this.mContent.CustomActive(false);
				this.mButton_Open.CustomActive(true);
			}
			else
			{
				if (this.battle != null)
				{
					this.battle.DeleteAllMonster();
				}
				this.mContent.CustomActive(false);
				this.mButton_Open.CustomActive(true);
				if (this.battle != null)
				{
					this.battle.ResetAllCD();
				}
				this.SwitchSecondMode(true);
				this.needDelaySummon = true;
			}
		}

		// Token: 0x0600A418 RID: 42008 RVA: 0x0021BC0B File Offset: 0x0021A00B
		private void _onButton_DeleteAllButtonClick()
		{
			if (this.battle != null)
			{
				this.battle.DeleteAllMonster();
			}
		}

		// Token: 0x0600A419 RID: 42009 RVA: 0x0021BC23 File Offset: 0x0021A023
		private void _onButton_ExitButtonClick()
		{
			this.OnPauseButtonClick();
		}

		// Token: 0x0600A41A RID: 42010 RVA: 0x0021BC2B File Offset: 0x0021A02B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/TrainingPveMain";
		}

		// Token: 0x0600A41B RID: 42011 RVA: 0x0021BC32 File Offset: 0x0021A032
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A41C RID: 42012 RVA: 0x0021BC35 File Offset: 0x0021A035
		protected override void _OnUpdate(float timeElapsed)
		{
			base._OnUpdate(timeElapsed);
			this.UpdateCountDown(timeElapsed);
			this.UpdateSecondTime(timeElapsed);
		}

		// Token: 0x0600A41D RID: 42013 RVA: 0x0021BC4C File Offset: 0x0021A04C
		public void InitUserData(TrainingPVEBattle trainingBattle)
		{
			this.battle = trainingBattle;
			this.InitTableData();
			this.InitDropDownData();
		}

		// Token: 0x0600A41E RID: 42014 RVA: 0x0021BC64 File Offset: 0x0021A064
		private void InitTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<PveTrainingMonsterTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			this.monsterIdArr = new int[table.Count];
			this.monsterNameDesArr = new string[table.Count];
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				PveTrainingMonsterTable pveTrainingMonsterTable = keyValuePair.Value as PveTrainingMonsterTable;
				this.monsterIdArr[num] = pveTrainingMonsterTable.ID;
				this.monsterNameDesArr[num] = pveTrainingMonsterTable.Name;
				PreloadManager.PreloadMonsterID(pveTrainingMonsterTable.ID, null, null, false);
				num++;
			}
		}

		// Token: 0x0600A41F RID: 42015 RVA: 0x0021BCFC File Offset: 0x0021A0FC
		private void InitDropDownData()
		{
			string text = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv.ToString();
			this.levelDesArr = new string[]
			{
				"30",
				"40",
				"50",
				"55",
				"60",
				text
			};
			this.InitSingleDropDownData(null, this.mDropdown_Name, this.monsterNameDesArr);
			this.InitSingleDropDownData("基本", this.mDropdown_Level, this.levelDesArr);
			this.InitAbnormalList();
			this.InitSingleDropDownData("暴击几率", this.mDropdown_Baoji, this.critRateDesArr);
			this.InitSingleDropDownData("人物四维", this.mDropdown_Siwei, this.staAddDesArr);
			this.InitSingleDropDownData("属性强化", this.mDropdown_ShuxingQianghu, this.attAddDesArr);
			this.InitSingleDropDownData("人物速度", this.mDropdown_Renwusudu, this.speedAddDesArr);
		}

		// Token: 0x0600A420 RID: 42016 RVA: 0x0021BDE8 File Offset: 0x0021A1E8
		private void InitSingleDropDownData(string defaultName, Dropdown dropDown, string[] strArr)
		{
			List<Dropdown.OptionData> list = ListPool<Dropdown.OptionData>.Get();
			if (defaultName != null)
			{
				list.Add(new Dropdown.OptionData
				{
					text = defaultName
				});
			}
			if (strArr != null)
			{
				for (int i = 0; i < strArr.Length; i++)
				{
					list.Add(new Dropdown.OptionData
					{
						text = strArr[i]
					});
				}
			}
			dropDown.AddOptions(list);
			ListPool<Dropdown.OptionData>.Release(list);
		}

		// Token: 0x0600A421 RID: 42017 RVA: 0x0021BE54 File Offset: 0x0021A254
		private void InitAbnormalList()
		{
			List<string> list = ListPool<string>.Get();
			list.Add("异常状态设置");
			for (int i = 0; i < this.abnormalDesArr.Length; i++)
			{
				list.Add(this.abnormalDesArr[i]);
			}
			this.mDropdown_Abnormal.AddOptions(list);
			ListPool<string>.Release(list);
		}

		// Token: 0x0600A422 RID: 42018 RVA: 0x0021BEAC File Offset: 0x0021A2AC
		public TrainingPveMonsterData GetSummonMonsterData()
		{
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			this.levelArr = new int[]
			{
				30,
				40,
				50,
				55,
				60,
				0
			};
			TrainingPveMonsterData result = default(TrainingPveMonsterData);
			int value = this.mDropdown_Name.value;
			result.monsterId = this.monsterIdArr[value];
			value = this.mDropdown_Level.value;
			if (value == 0)
			{
				result.level = 30;
			}
			else
			{
				result.level = this.levelArr[value - 1];
			}
			value = this.mDropdown_Abnormal.value;
			if (value != 0)
			{
				result.abnormalId = this.abnormaleArr[value - 1];
			}
			result.isBati = this.mToggle_Bati.isOn;
			result.isNormalMode = this.mToggle_Normal.isOn;
			result.isSecondMode = this.mToggle_Second.isOn;
			return result;
		}

		// Token: 0x0600A423 RID: 42019 RVA: 0x0021BF8D File Offset: 0x0021A38D
		private void OnPauseButtonClick()
		{
			if (this.battle == null)
			{
				return;
			}
			this.battle.ReturnToTown();
		}

		// Token: 0x0600A424 RID: 42020 RVA: 0x0021BFA8 File Offset: 0x0021A3A8
		private void SwitchSecondMode(bool isSecond)
		{
			bool enabled = !isSecond;
			this.mDropdown_Baoji.enabled = enabled;
			this.mDropdown_Baoji.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_Siwei.enabled = enabled;
			this.mDropdown_Siwei.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_Renwusudu.enabled = enabled;
			this.mDropdown_Renwusudu.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_ShuxingQianghu.enabled = enabled;
			this.mDropdown_ShuxingQianghu.GetComponent<UIGray>().enabled = isSecond;
			this.mToggle_Pozhao.enabled = enabled;
			this.mToggle_Pozhao.GetComponent<UIGray>().enabled = isSecond;
			this.mToggle_Mingzhong.enabled = enabled;
			this.mToggle_Mingzhong.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_Name.enabled = enabled;
			this.mDropdown_Name.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_Level.enabled = enabled;
			this.mDropdown_Level.GetComponent<UIGray>().enabled = isSecond;
			this.mDropdown_Abnormal.enabled = enabled;
			this.mDropdown_Abnormal.GetComponent<UIGray>().enabled = isSecond;
			this.mToggle_Bati.enabled = enabled;
			this.mToggle_Bati.GetComponent<UIGray>().enabled = isSecond;
			this.mButton_Summon.enabled = enabled;
			this.mButton_Summon.GetComponent<UIGray>().enabled = isSecond;
			this.mButton_ResetCD.enabled = enabled;
			this.mButton_ResetCD.GetComponent<UIGray>().enabled = isSecond;
			this.mToggle_Normal.enabled = enabled;
			this.mToggle_Normal.GetComponent<UIGray>().enabled = isSecond;
			this.mToggle_Second.enabled = enabled;
			this.mToggle_Second.GetComponent<UIGray>().enabled = isSecond;
		}

		// Token: 0x0600A425 RID: 42021 RVA: 0x0021C150 File Offset: 0x0021A550
		private void UpdateCountDown(float deltaTime)
		{
			if (!this.needDelaySummon)
			{
				return;
			}
			if (this.currentTime <= 0f)
			{
				this.mTime.CustomActive(false);
				this.currentTime = 3f;
				this.needDelaySummon = false;
				this.secondTime = 0f;
				this.secondMonster = this.battle.SummonMonster();
				this.isInSecond = true;
				this.mContent.CustomActive(false);
				this.mButton_Open.CustomActive(true);
				this.mSecondTime.text = "00:00:00";
			}
			else
			{
				this.mTime.CustomActive(true);
				this.mTime.text = Mathf.CeilToInt(this.currentTime).ToString();
				this.currentTime -= deltaTime;
			}
		}

		// Token: 0x0600A426 RID: 42022 RVA: 0x0021C228 File Offset: 0x0021A628
		private void UpdateSecondTime(float deltaTime)
		{
			if (!this.isInSecond)
			{
				return;
			}
			this.secondTime += deltaTime;
			if (this.secondMonster == null || this.secondMonster.IsDead())
			{
				this.SecondModeEnd();
				return;
			}
			float num = this.secondTime;
			int num2 = (int)num / 3600;
			int num3 = ((int)num - num2 * 3600) / 60;
			int num4 = (int)num - num2 * 3600 - num3 * 60;
			int num5 = (int)((this.secondTime - (float)((int)num)) * 1000f);
			string text = num5.ToString();
			if (text.Length >= 2)
			{
				text = num5.ToString().Substring(0, 2);
			}
			this.mSecondTime.text = string.Format("{0:D2}:{1:D2}:{2:D3}", num3, num4, text);
		}

		// Token: 0x0600A427 RID: 42023 RVA: 0x0021C307 File Offset: 0x0021A707
		private void SecondModeEnd()
		{
			this.isInSecond = false;
			this.SwitchSecondMode(false);
		}

		// Token: 0x04005BA2 RID: 23458
		private Button mButton_Open;

		// Token: 0x04005BA3 RID: 23459
		private Button mButton_Close;

		// Token: 0x04005BA4 RID: 23460
		private GameObject mContent;

		// Token: 0x04005BA5 RID: 23461
		private Dropdown mDropdown_Name;

		// Token: 0x04005BA6 RID: 23462
		private Dropdown mDropdown_Level;

		// Token: 0x04005BA7 RID: 23463
		private Dropdown mDropdown_Abnormal;

		// Token: 0x04005BA8 RID: 23464
		private Toggle mToggle_Bati;

		// Token: 0x04005BA9 RID: 23465
		private Toggle mToggle_Normal;

		// Token: 0x04005BAA RID: 23466
		private Toggle mToggle_Second;

		// Token: 0x04005BAB RID: 23467
		private Dropdown mDropdown_Baoji;

		// Token: 0x04005BAC RID: 23468
		private Dropdown mDropdown_Siwei;

		// Token: 0x04005BAD RID: 23469
		private Dropdown mDropdown_ShuxingQianghu;

		// Token: 0x04005BAE RID: 23470
		private Dropdown mDropdown_Renwusudu;

		// Token: 0x04005BAF RID: 23471
		private Toggle mToggle_Pozhao;

		// Token: 0x04005BB0 RID: 23472
		private Toggle mToggle_Mingzhong;

		// Token: 0x04005BB1 RID: 23473
		private Button mButton_ResetCD;

		// Token: 0x04005BB2 RID: 23474
		private Button mButton_Damage;

		// Token: 0x04005BB3 RID: 23475
		private Button mButton_Summon;

		// Token: 0x04005BB4 RID: 23476
		private Button mButton_DeleteAll;

		// Token: 0x04005BB5 RID: 23477
		private Button mButton_Exit;

		// Token: 0x04005BB6 RID: 23478
		private GameObject mSecondContent;

		// Token: 0x04005BB7 RID: 23479
		private Text mSecondTime;

		// Token: 0x04005BB8 RID: 23480
		private Text mTime;

		// Token: 0x04005BB9 RID: 23481
		private TrainingPVEBattle battle;

		// Token: 0x04005BBA RID: 23482
		public int[] monsterIdArr = new int[0];

		// Token: 0x04005BBB RID: 23483
		public string[] monsterNameDesArr = new string[0];

		// Token: 0x04005BBC RID: 23484
		private int[] levelArr = new int[0];

		// Token: 0x04005BBD RID: 23485
		private string[] levelDesArr = new string[0];

		// Token: 0x04005BBE RID: 23486
		private int[] abnormaleArr = new int[]
		{
			15,
			17,
			5,
			7,
			8,
			3,
			4,
			811043,
			6,
			9,
			10,
			18
		};

		// Token: 0x04005BBF RID: 23487
		private string[] abnormalDesArr = new string[]
		{
			"中毒",
			"灼烧",
			"出血",
			"睡眠",
			"冰冻",
			"眩晕",
			"石化",
			"诅咒",
			"感电",
			"束缚",
			"混乱",
			"失明"
		};

		// Token: 0x04005BC0 RID: 23488
		public int[] critBuffIdArr = new int[]
		{
			811001,
			811002,
			811003,
			811004,
			811005,
			811006,
			811007,
			811008,
			811009,
			811010
		};

		// Token: 0x04005BC1 RID: 23489
		private string[] critRateDesArr = new string[]
		{
			"10%",
			"20%",
			"30%",
			"40%",
			"50%",
			"60%",
			"70%",
			"80%",
			"90%",
			"100%"
		};

		// Token: 0x04005BC2 RID: 23490
		public int[] staAddBuffIdArr = new int[]
		{
			811011,
			811012,
			811013,
			811014,
			811015,
			811016,
			811017,
			811018,
			811019,
			811020
		};

		// Token: 0x04005BC3 RID: 23491
		private string[] staAddDesArr = new string[]
		{
			"50",
			"100",
			"150",
			"200",
			"250",
			"300",
			"350",
			"400",
			"450",
			"500"
		};

		// Token: 0x04005BC4 RID: 23492
		public int[] attAddBuffIdArr = new int[]
		{
			811021,
			811022,
			811023,
			811024,
			811025,
			811026,
			811027,
			811028,
			811029,
			811030
		};

		// Token: 0x04005BC5 RID: 23493
		private string[] attAddDesArr = new string[]
		{
			"10",
			"20",
			"30",
			"40",
			"50",
			"60",
			"70",
			"80",
			"90",
			"100"
		};

		// Token: 0x04005BC6 RID: 23494
		public int[] speedAddBuffIdArr = new int[]
		{
			811031,
			811032,
			811033,
			811034,
			811035,
			811036,
			811037,
			811038,
			811039,
			811040
		};

		// Token: 0x04005BC7 RID: 23495
		private string[] speedAddDesArr = new string[]
		{
			"10",
			"20",
			"30",
			"40",
			"50",
			"60",
			"70",
			"80",
			"90",
			"100"
		};

		// Token: 0x04005BC8 RID: 23496
		private bool needDelaySummon;

		// Token: 0x04005BC9 RID: 23497
		private bool isInSecond;

		// Token: 0x04005BCA RID: 23498
		private BeActor secondMonster;

		// Token: 0x04005BCB RID: 23499
		private float currentTime = 3f;

		// Token: 0x04005BCC RID: 23500
		private float secondTime;
	}
}
