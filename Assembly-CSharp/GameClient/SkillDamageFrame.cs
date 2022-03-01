using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010DA RID: 4314
	public class SkillDamageFrame : ClientFrame
	{
		// Token: 0x0600A346 RID: 41798 RVA: 0x00216460 File Offset: 0x00214860
		protected override void _bindExUI()
		{
			this.mDropdown_Select = this.mBind.GetCom<Dropdown>("Dropdown_Select");
			if (null != this.mDropdown_Select)
			{
				this.mDropdown_Select.onValueChanged.AddListener(new UnityAction<int>(this._onDropdown_SelectDropdownValueChange));
			}
			this.mContent = this.mBind.GetCom<RectTransform>("Content");
			this.mItem = this.mBind.GetGameObject("Item");
			this.mText_CurentPage = this.mBind.GetCom<Text>("Text_CurentPage");
			this.mButton_Left = this.mBind.GetCom<Button>("Button_Left");
			if (null != this.mButton_Left)
			{
				this.mButton_Left.onClick.AddListener(new UnityAction(this._onButton_LeftButtonClick));
			}
			this.mButton_Right = this.mBind.GetCom<Button>("Button_Right");
			if (null != this.mButton_Right)
			{
				this.mButton_Right.onClick.AddListener(new UnityAction(this._onButton_RightButtonClick));
			}
			this.mButton_Close = this.mBind.GetCom<Button>("Button_Close");
			if (null != this.mButton_Close)
			{
				this.mButton_Close.onClick.AddListener(new UnityAction(this._onButton_CloseButtonClick));
			}
			this.mButton_Reset = this.mBind.GetCom<Button>("Button_Reset");
			if (null != this.mButton_Reset)
			{
				this.mButton_Reset.onClick.AddListener(new UnityAction(this._onButton_ResetButtonClick));
			}
			this.mText_TotalDamage = this.mBind.GetCom<Text>("Text_TotalDamage");
			this.mButton_Back = this.mBind.GetCom<Button>("Button_Back");
			if (null != this.mButton_Back)
			{
				this.mButton_Back.onClick.AddListener(new UnityAction(this._onButton_BackButtonClick));
			}
			this.mScrollRect = this.mBind.GetCom<ScrollRect>("ScrollRect");
			this.mScrollRectTrans = this.mBind.GetCom<RectTransform>("ScrollRectTrans");
			this.mHelpBtn = this.mBind.GetCom<Button>("HelpBtn");
			if (null != this.mHelpBtn)
			{
				this.mHelpBtn.onClick.AddListener(new UnityAction(this._onHelpBtnButtonClick));
			}
		}

		// Token: 0x0600A347 RID: 41799 RVA: 0x002166C8 File Offset: 0x00214AC8
		protected override void _unbindExUI()
		{
			if (null != this.mDropdown_Select)
			{
				this.mDropdown_Select.onValueChanged.RemoveListener(new UnityAction<int>(this._onDropdown_SelectDropdownValueChange));
			}
			this.mDropdown_Select = null;
			this.mContent = null;
			this.mItem = null;
			this.mText_CurentPage = null;
			if (null != this.mButton_Left)
			{
				this.mButton_Left.onClick.RemoveListener(new UnityAction(this._onButton_LeftButtonClick));
			}
			this.mButton_Left = null;
			if (null != this.mButton_Right)
			{
				this.mButton_Right.onClick.RemoveListener(new UnityAction(this._onButton_RightButtonClick));
			}
			this.mButton_Right = null;
			if (null != this.mButton_Close)
			{
				this.mButton_Close.onClick.RemoveListener(new UnityAction(this._onButton_CloseButtonClick));
			}
			this.mButton_Close = null;
			if (null != this.mButton_Reset)
			{
				this.mButton_Reset.onClick.RemoveListener(new UnityAction(this._onButton_ResetButtonClick));
			}
			this.mButton_Reset = null;
			this.mText_TotalDamage = null;
			if (null != this.mButton_Back)
			{
				this.mButton_Back.onClick.RemoveListener(new UnityAction(this._onButton_BackButtonClick));
			}
			this.mButton_Back = null;
			this.mScrollRect = null;
			this.mScrollRectTrans = null;
			if (null != this.mHelpBtn)
			{
				this.mHelpBtn.onClick.RemoveListener(new UnityAction(this._onHelpBtnButtonClick));
			}
			this.mHelpBtn = null;
		}

		// Token: 0x0600A348 RID: 41800 RVA: 0x0021686B File Offset: 0x00214C6B
		private void _onDropdown_SelectDropdownValueChange(int index)
		{
			this.RefershSelect(index);
		}

		// Token: 0x0600A349 RID: 41801 RVA: 0x00216874 File Offset: 0x00214C74
		private void _onButton_LeftButtonClick()
		{
			this.LeftPageBtn();
		}

		// Token: 0x0600A34A RID: 41802 RVA: 0x0021687C File Offset: 0x00214C7C
		private void _onButton_RightButtonClick()
		{
			this.RightPageBtn();
		}

		// Token: 0x0600A34B RID: 41803 RVA: 0x00216884 File Offset: 0x00214C84
		private void _onButton_CloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600A34C RID: 41804 RVA: 0x0021688D File Offset: 0x00214C8D
		private void _onButton_ResetButtonClick()
		{
			this.Reset();
		}

		// Token: 0x0600A34D RID: 41805 RVA: 0x00216895 File Offset: 0x00214C95
		private void _onButton_BackButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600A34E RID: 41806 RVA: 0x0021689E File Offset: 0x00214C9E
		private void _onHelpBtnButtonClick()
		{
		}

		// Token: 0x0600A34F RID: 41807 RVA: 0x002168A0 File Offset: 0x00214CA0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/SkillDamageFrame";
		}

		// Token: 0x0600A350 RID: 41808 RVA: 0x002168A7 File Offset: 0x00214CA7
		private void LeftPageBtn()
		{
			if (this.damageDataList == null || this.damageDataList.Count <= 1)
			{
				return;
			}
			if (this.pageIndex <= 0)
			{
				return;
			}
			this.pageIndex--;
			this.InitSelectDropDown();
		}

		// Token: 0x0600A351 RID: 41809 RVA: 0x002168E8 File Offset: 0x00214CE8
		private void RightPageBtn()
		{
			if (this.damageDataList == null || this.damageDataList.Count <= 1)
			{
				return;
			}
			if (this.pageIndex >= this.damageDataList.Count - 1)
			{
				return;
			}
			this.pageIndex++;
			this.InitSelectDropDown();
		}

		// Token: 0x0600A352 RID: 41810 RVA: 0x00216940 File Offset: 0x00214D40
		private void RefershSelect(int selectIndex)
		{
			if (this.damageDataList == null || this.damageDataList.Count <= 0)
			{
				return;
			}
			this.selectMonsterId = this.damageDataList[this.pageIndex].monsterIdList[selectIndex];
			this.RefreshAllData();
		}

		// Token: 0x0600A353 RID: 41811 RVA: 0x00216998 File Offset: 0x00214D98
		public void InitData(bool isTrainingPve = false)
		{
			BeActor mainPlayer = this.GetMainPlayer();
			this.damageDataList.Clear();
			this.isTrainingPveFlag = isTrainingPve;
			if (this.isTrainingPveFlag && mainPlayer != null && mainPlayer.skillDamageManager != null && mainPlayer.skillDamageManager.skillDamageData.skillDamageDic != null && mainPlayer.skillDamageManager.skillDamageData.skillDamageDic.Count > 0)
			{
				SkillDamageData skillDamageData = mainPlayer.skillDamageManager.skillDamageData;
				skillDamageData.dungeonName = "练习场";
				this.damageDataList.Add(skillDamageData);
				mainPlayer.skillDamageManager.SetTimingFlag(false);
			}
			if (mainPlayer != null && mainPlayer.skillDamageManager != null)
			{
				List<SkillDamageData> skillDamageData2 = mainPlayer.skillDamageManager.GetSkillDamageData();
				if (skillDamageData2 != null)
				{
					for (int i = 0; i < skillDamageData2.Count; i++)
					{
						if (this.damageDataList.Count < 3)
						{
							this.damageDataList.Add(skillDamageData2[i]);
						}
					}
				}
			}
			if (this.damageDataList == null || this.damageDataList.Count == 0)
			{
				return;
			}
			this.pageIndex = 0;
			this.InitSelectDropDown();
		}

		// Token: 0x0600A354 RID: 41812 RVA: 0x00216AC8 File Offset: 0x00214EC8
		private void InitSelectDropDown()
		{
			this.mScrollRectTrans.anchoredPosition = Vector2.zero;
			this.mScrollRect.StopMovement();
			if (this.damageDataList == null || this.damageDataList.Count <= 0)
			{
				return;
			}
			if (this.damageDataList[this.pageIndex].monsterNameList == null)
			{
				return;
			}
			List<string> monsterNameList = this.damageDataList[this.pageIndex].monsterNameList;
			this.mDropdown_Select.ClearOptions();
			if (monsterNameList == null || monsterNameList.Count <= 0)
			{
				return;
			}
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
			for (int i = 0; i < monsterNameList.Count; i++)
			{
				list.Add(new Dropdown.OptionData
				{
					text = monsterNameList[i]
				});
			}
			this.mDropdown_Select.AddOptions(list);
			this.selectMonsterId = this.damageDataList[this.pageIndex].monsterIdList[0];
			this.RefershSelect(0);
		}

		// Token: 0x0600A355 RID: 41813 RVA: 0x00216BDC File Offset: 0x00214FDC
		private void RefreshAllData()
		{
			this.HideAll();
			this.RefreshPageBtn();
			this.RefreshDungeonName();
			this.RefreshUIList();
		}

		// Token: 0x0600A356 RID: 41814 RVA: 0x00216BF8 File Offset: 0x00214FF8
		private void HideAll()
		{
			if (this.mContent == null)
			{
				return;
			}
			int childCount = this.mContent.childCount;
			for (int i = 0; i < childCount; i++)
			{
				this.mContent.GetChild(i).gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600A357 RID: 41815 RVA: 0x00216C4C File Offset: 0x0021504C
		private void RefreshUIList()
		{
			if (this.mContent == null)
			{
				return;
			}
			List<SkillDamageFrame.SkillDamage> skillDamageData = this.GetSkillDamageData();
			if (skillDamageData == null)
			{
				return;
			}
			int childCount = this.mContent.childCount;
			int num = 0;
			for (int i = 0; i < skillDamageData.Count; i++)
			{
				ComCommonBind component;
				if (num + 1 < childCount)
				{
					component = this.mContent.GetChild(num + 1).GetComponent<ComCommonBind>();
				}
				else
				{
					component = Object.Instantiate<GameObject>(this.mItem).GetComponent<ComCommonBind>();
				}
				Utility.AttachTo(component.gameObject, this.mContent.gameObject, false);
				string iconPath = skillDamageData[i].IconPath;
				string name = skillDamageData[i].Name;
				string useCount = skillDamageData[i].UseCount.ToString();
				string damage = skillDamageData[i].Damage.ToString();
				string percent = skillDamageData[i].Percent;
				this.SetSkillIconImage(component.GetCom<Image>("Image"), iconPath);
				this.SetTextData(component.GetCom<Text>("skillName"), name);
				this.SetTextData(component.GetCom<Text>("useCount"), useCount);
				this.SetTextData(component.GetCom<Text>("damage"), damage);
				this.SetTextData(component.GetCom<Text>("damagePercent"), percent);
				component.GetCom<Image>("Bg1").CustomActive(false);
				component.GetCom<Image>("Bg2").CustomActive(false);
				if ((i + 1) % 2 != 0)
				{
					component.GetCom<Image>("Bg1").CustomActive(true);
				}
				else
				{
					component.GetCom<Image>("Bg2").CustomActive(true);
				}
				Transform shareBtn = component.GetCom<Button>("Button_Option").transform;
				component.GetCom<Button>("Button_Option").onClick.AddListener(delegate()
				{
					this.OnShareBtnClick(name, useCount, damage, percent, shareBtn.transform.position);
				});
				component.CustomActive(true);
				num++;
			}
		}

		// Token: 0x0600A358 RID: 41816 RVA: 0x00216E98 File Offset: 0x00215298
		private void RefreshDungeonName()
		{
			if (this.damageDataList == null || this.damageDataList.Count <= 0)
			{
				return;
			}
			string dungeonName = this.damageDataList[this.pageIndex].dungeonName;
			if (dungeonName == null)
			{
				this.mText_CurentPage.text = null;
			}
			else
			{
				this.mText_CurentPage.text = "副本:" + dungeonName;
			}
			SkillDamageData data = this.damageDataList[this.pageIndex];
			BeActor mainPlayer = this.GetMainPlayer();
			if (data.skillDamageDic == null || data.skillDamageDic.Count <= 0)
			{
				this.mText_TotalDamage = null;
			}
			else
			{
				long totalDamage = mainPlayer.skillDamageManager.GetTotalDamage(this.selectMonsterId, data);
				double num = mainPlayer.skillDamageManager.GetMonsterTime(this.selectMonsterId, data);
				if (num == 0.0)
				{
					this.mText_TotalDamage.text = "   总伤害数值:" + totalDamage;
				}
				else
				{
					num = (double)((int)((double)totalDamage / (num / 1000.0)));
					this.mText_TotalDamage.text = string.Concat(new object[]
					{
						"每秒伤害数值：",
						num,
						"   总伤害数值:",
						totalDamage
					});
				}
			}
		}

		// Token: 0x0600A359 RID: 41817 RVA: 0x00216FF4 File Offset: 0x002153F4
		private void RefreshPageBtn()
		{
			this.mButton_Left.CustomActive(false);
			this.mButton_Right.CustomActive(false);
			if (this.damageDataList == null || this.damageDataList.Count == 0)
			{
				return;
			}
			if (this.pageIndex != 0)
			{
				this.mButton_Left.CustomActive(true);
			}
			if (this.pageIndex != this.damageDataList.Count - 1)
			{
				this.mButton_Right.CustomActive(true);
			}
		}

		// Token: 0x0600A35A RID: 41818 RVA: 0x00217070 File Offset: 0x00215470
		private void Reset()
		{
			BeActor mainPlayer = this.GetMainPlayer();
			if (this.isTrainingPveFlag && mainPlayer != null && mainPlayer.skillDamageManager != null && mainPlayer.skillDamageManager.skillDamageData.skillDamageDic != null)
			{
				mainPlayer.skillDamageManager.skillDamageData = default(SkillDamageData);
			}
			this.damageDataList.Clear();
			if (mainPlayer != null && mainPlayer.skillDamageManager != null)
			{
				mainPlayer.skillDamageManager.ClearSkillDamageData();
			}
			this.RefreshAllData();
			this.InitSelectDropDown();
			this.mText_CurentPage.text = string.Empty;
			this.mText_TotalDamage.text = string.Empty;
		}

		// Token: 0x0600A35B RID: 41819 RVA: 0x0021711C File Offset: 0x0021551C
		private void SetSkillIconImage(Image image, string path)
		{
			if (image == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref image, path, true);
		}

		// Token: 0x0600A35C RID: 41820 RVA: 0x00217135 File Offset: 0x00215535
		private void SetTextData(Text text, string str)
		{
			if (text == null)
			{
				return;
			}
			text.text = str;
		}

		// Token: 0x0600A35D RID: 41821 RVA: 0x0021714C File Offset: 0x0021554C
		private void OnShareBtnClick(string skillName, string useCount, string totalDamage, string damagePercent, Vector3 pos)
		{
			string msg = string.Format("技能名称:{0},技能使用次数:{1},造成总伤害:{2},伤害占比:{3}", new object[]
			{
				skillName,
				useCount,
				totalDamage,
				damagePercent
			});
			ShareToChatFrame shareToChatFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ShareToChatFrame>(FrameLayer.Middle, null, string.Empty) as ShareToChatFrame;
			if (shareToChatFrame != null)
			{
				shareToChatFrame.InitData(pos, msg);
			}
		}

		// Token: 0x0600A35E RID: 41822 RVA: 0x002171A4 File Offset: 0x002155A4
		private List<SkillDamageFrame.SkillDamage> GetSkillDamageData()
		{
			if (this.damageDataList == null || this.damageDataList.Count <= 0)
			{
				return null;
			}
			SkillDamageData data = this.damageDataList[this.pageIndex];
			if (data.origionSkillIdList == null || data.origionSkillIdList.Count <= 0)
			{
				return null;
			}
			BeActor mainPlayer = this.GetMainPlayer();
			List<SkillDamageFrame.SkillDamage> list = new List<SkillDamageFrame.SkillDamage>();
			for (int i = 0; i < data.origionSkillIdList.Count; i++)
			{
				SkillDamageFrame.SkillDamage item = default(SkillDamageFrame.SkillDamage);
				int num = data.origionSkillIdList[i];
				SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(num, string.Empty, string.Empty);
				item.IconPath = tableItem.Icon;
				if (tableItem.IsAttackCombo == 1)
				{
					item.Name = "普通攻击";
				}
				else
				{
					item.Name = tableItem.Name;
				}
				item.UseCount = this.GetSkillUseCount(data, num);
				if (mainPlayer != null && mainPlayer.skillDamageManager != null)
				{
					item.Damage = mainPlayer.skillDamageManager.GetSkilDamage(num, this.selectMonsterId, data);
					item.Percent = mainPlayer.skillDamageManager.GetSkillDamagePercent(num, this.selectMonsterId, data);
				}
				if (item.Damage != 0L)
				{
					list.Add(item);
				}
			}
			list.Sort((SkillDamageFrame.SkillDamage damage1, SkillDamageFrame.SkillDamage damage2) => damage2.Damage.CompareTo(damage1.Damage));
			return list;
		}

		// Token: 0x0600A35F RID: 41823 RVA: 0x0021732C File Offset: 0x0021572C
		private int GetSkillUseCount(SkillDamageData data, int skillId)
		{
			int index = 0;
			for (int i = 0; i < data.origionSkillIdList.Count; i++)
			{
				if (skillId == data.origionSkillIdList[i])
				{
					index = i;
					break;
				}
			}
			return data.origionSkillIdUseCount[index];
		}

		// Token: 0x0600A360 RID: 41824 RVA: 0x00217380 File Offset: 0x00215780
		private BeActor GetMainPlayer()
		{
			if (BattleMain.instance == null)
			{
				return BeUtility.GetMainPlayerActor(false, null, SkillSystemSourceType.None);
			}
			if (BattleMain.instance.GetPlayerManager() == null)
			{
				return null;
			}
			if (BattleMain.instance.GetPlayerManager().GetMainPlayer() == null)
			{
				return null;
			}
			return BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
		}

		// Token: 0x04005B04 RID: 23300
		private Dropdown mDropdown_Select;

		// Token: 0x04005B05 RID: 23301
		private RectTransform mContent;

		// Token: 0x04005B06 RID: 23302
		private GameObject mItem;

		// Token: 0x04005B07 RID: 23303
		private Text mText_CurentPage;

		// Token: 0x04005B08 RID: 23304
		private Button mButton_Left;

		// Token: 0x04005B09 RID: 23305
		private Button mButton_Right;

		// Token: 0x04005B0A RID: 23306
		private Button mButton_Close;

		// Token: 0x04005B0B RID: 23307
		private Button mButton_Reset;

		// Token: 0x04005B0C RID: 23308
		private Text mText_TotalDamage;

		// Token: 0x04005B0D RID: 23309
		private Button mButton_Back;

		// Token: 0x04005B0E RID: 23310
		private ScrollRect mScrollRect;

		// Token: 0x04005B0F RID: 23311
		private RectTransform mScrollRectTrans;

		// Token: 0x04005B10 RID: 23312
		private Button mHelpBtn;

		// Token: 0x04005B11 RID: 23313
		private List<SkillDamageData> damageDataList = new List<SkillDamageData>();

		// Token: 0x04005B12 RID: 23314
		private int pageIndex = -1;

		// Token: 0x04005B13 RID: 23315
		private int selectMonsterId;

		// Token: 0x04005B14 RID: 23316
		private bool isTrainingPveFlag;

		// Token: 0x020010DB RID: 4315
		public struct SkillDamage
		{
			// Token: 0x04005B16 RID: 23318
			public long Damage;

			// Token: 0x04005B17 RID: 23319
			public string IconPath;

			// Token: 0x04005B18 RID: 23320
			public string Name;

			// Token: 0x04005B19 RID: 23321
			public int UseCount;

			// Token: 0x04005B1A RID: 23322
			public string Percent;
		}
	}
}
