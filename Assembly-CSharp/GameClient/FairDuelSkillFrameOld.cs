using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001362 RID: 4962
	public class FairDuelSkillFrameOld : ClientFrame
	{
		// Token: 0x0600C0A5 RID: 49317 RVA: 0x002D9816 File Offset: 0x002D7C16
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FairDuel/FairDuelSkillFrame";
		}

		// Token: 0x0600C0A6 RID: 49318 RVA: 0x002D981D File Offset: 0x002D7C1D
		protected override void _OnOpenFrame()
		{
			this._InitLeftIdleSkillComUIList();
			this._UpdataSKillBar(true);
			this.BindUIEvent();
			this.InitData();
		}

		// Token: 0x0600C0A7 RID: 49319 RVA: 0x002D9838 File Offset: 0x002D7C38
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0600C0A8 RID: 49320 RVA: 0x002D9848 File Offset: 0x002D7C48
		protected override void _bindExUI()
		{
			this.mCloseBtn = this.mBind.GetCom<Button>("Close");
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			this.mComUIList = this.mBind.GetCom<ComUIListScript>("Viewport");
			this.mDetail_SkillIcomImg = this.mBind.GetCom<Image>("skillIcon");
			this.mDetail_SkillNameTxt = this.mBind.GetCom<Text>("name");
			this.mDetail_SkillLvlTxt = this.mBind.GetCom<Text>("rightLevel");
			this.mSkillConsumeMpTxt = this.mBind.GetCom<Text>("skillConsumeMPText");
			this.mSkillConsumeThingTxt = this.mBind.GetCom<Text>("skillConsumeThingText");
			this.mSkillDexTxt = this.mBind.GetCom<Text>("Content");
			this.mSkillCDTxt = this.mBind.GetCom<Text>("skillCDNumTxt");
			this.mSkillTypeTxt = this.mBind.GetCom<Text>("skillTypeTxt");
			this.mJopTipTxt = this.mBind.GetCom<Text>("jobtipTxt");
			this.mGiveUpDropMe = this.mBind.GetCom<Drop_Me>("DropBG");
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
		}

		// Token: 0x0600C0A9 RID: 49321 RVA: 0x002D9AAC File Offset: 0x002D7EAC
		protected override void _unbindExUI()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
				this.mCloseBtn = null;
			}
			if (this.mComUIList != null)
			{
				this.mComUIList = null;
			}
			if (this.mDetail_SkillIcomImg != null)
			{
				this.mDetail_SkillIcomImg = null;
			}
			if (this.mDetail_SkillNameTxt != null)
			{
				this.mDetail_SkillNameTxt = null;
			}
			if (this.mDetail_SkillLvlTxt != null)
			{
				this.mDetail_SkillLvlTxt = null;
			}
			if (this.mSkillConsumeMpTxt != null)
			{
				this.mSkillConsumeMpTxt = null;
			}
			if (this.mSkillConsumeThingTxt != null)
			{
				this.mSkillConsumeThingTxt = null;
			}
			if (this.mSkillCDTxt == null)
			{
				this.mSkillCDTxt = null;
			}
			if (this.mSkillDexTxt != null)
			{
				this.mSkillDexTxt = null;
			}
			if (this.mSkillTypeTxt != null)
			{
				this.mSkillTypeTxt = null;
			}
			if (this.mJopTipTxt != null)
			{
				this.mJopTipTxt = null;
			}
			if (this.mGiveUpDropMe != null)
			{
				this.mGiveUpDropMe = null;
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
		}

		// Token: 0x0600C0AA RID: 49322 RVA: 0x002D9C78 File Offset: 0x002D8078
		private void InitData()
		{
			List<ItemProperty> equipedEquipments = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
			this.mskillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, equipedEquipments, SkillSystemSourceType.None);
		}

		// Token: 0x0600C0AB RID: 49323 RVA: 0x002D9CA3 File Offset: 0x002D80A3
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600C0AC RID: 49324 RVA: 0x002D9CC0 File Offset: 0x002D80C0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600C0AD RID: 49325 RVA: 0x002D9CDD File Offset: 0x002D80DD
		private void ClearData()
		{
			this.mskillLevelAddInfo.Clear();
		}

		// Token: 0x0600C0AE RID: 49326 RVA: 0x002D9CEC File Offset: 0x002D80EC
		private void _InitLeftIdleSkillComUIList()
		{
			if (!this.mComUIList.IsInitialised())
			{
				this.mComUIList.Initialize();
				this.mComUIList.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisivale);
				this.mComUIList.OnItemRecycle = new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle);
			}
			this.mComUIList.UpdateElementAmount(DataManager<SkillDataManager>.GetInstance().FairDuelSkillList.Count);
		}

		// Token: 0x0600C0AF RID: 49327 RVA: 0x002D9D5C File Offset: 0x002D815C
		private void _OnSkillBarChanged(UIEvent uiEvent)
		{
			this._UpdataSKillBar(false);
		}

		// Token: 0x0600C0B0 RID: 49328 RVA: 0x002D9D68 File Offset: 0x002D8168
		private void OnItemVisivale(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= DataManager<SkillDataManager>.GetInstance().FairDuelSkillList.Count)
			{
				return;
			}
			Skill skill = DataManager<SkillDataManager>.GetInstance().FairDuelSkillList[item.m_index];
			if (skill == null)
			{
				return;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skill.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Image com = component.GetCom<Image>("skillIcon");
			Text com2 = component.GetCom<Text>("Level");
			Image com3 = component.GetCom<Image>("allocate");
			Toggle com4 = component.GetCom<Toggle>("tgSkill");
			Drag_Me com5 = component.GetCom<Drag_Me>("dragme");
			com5.Id = skill.id;
			if (com5 != null)
			{
				com5.ResponseDrag = new Drag_Me.OnResDrag(this._DealSkillBarDrag);
			}
			if (com != null)
			{
				ETCImageLoader.LoadSprite(ref com, tableItem.Icon, true);
			}
			if (com2 != null)
			{
				com2.text = string.Format("Lv.{0}/{1}", skill.level, tableItem.TopLevelLimit);
			}
			if (com3 != null)
			{
				com3.CustomActive(this.IsEquipedSkill((int)skill.id));
			}
			if (com4 != null)
			{
				com4.onValueChanged.RemoveAllListeners();
				int iIndex = item.m_index;
				com4.onValueChanged.AddListener(delegate(bool value)
				{
					this._OnSelectSkill(iIndex, value);
				});
				if (item.m_index == 0)
				{
					com4.isOn = true;
				}
			}
		}

		// Token: 0x0600C0B1 RID: 49329 RVA: 0x002D9F2C File Offset: 0x002D832C
		private bool IsEquipedSkill(int skillID)
		{
			bool result = false;
			List<SkillBarGrid> fairDuelSkillBar = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar;
			for (int i = 0; i < fairDuelSkillBar.Count; i++)
			{
				if ((int)fairDuelSkillBar[i].id == skillID)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600C0B2 RID: 49330 RVA: 0x002D9F78 File Offset: 0x002D8378
		private void OnItemRecycle(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Toggle com = component.GetCom<Toggle>("tgSkill");
			com.onValueChanged.RemoveAllListeners();
			Drag_Me com2 = component.GetCom<Drag_Me>("dragme");
			if (com2 != null)
			{
				com2.ResponseDrag = null;
			}
		}

		// Token: 0x0600C0B3 RID: 49331 RVA: 0x002D9FD0 File Offset: 0x002D83D0
		private void _OnSelectSkill(int index, bool value)
		{
			if (!value || index < 0)
			{
				return;
			}
			if (index >= DataManager<SkillDataManager>.GetInstance().FairDuelSkillList.Count)
			{
				return;
			}
			Skill skill = DataManager<SkillDataManager>.GetInstance().FairDuelSkillList[index];
			this._ShowSkillInfo(skill);
		}

		// Token: 0x0600C0B4 RID: 49332 RVA: 0x002DA01C File Offset: 0x002D841C
		private void _ShowSkillInfo(Skill skill)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skill.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mDetail_SkillIcomImg != null)
			{
				ETCImageLoader.LoadSprite(ref this.mDetail_SkillIcomImg, tableItem.Icon, true);
			}
			if (this.mDetail_SkillNameTxt != null)
			{
				this.mDetail_SkillNameTxt.text = tableItem.Name;
			}
			if (this.mDetail_SkillLvlTxt != null)
			{
				this.mDetail_SkillLvlTxt.text = string.Format("Lv.{0}", skill.level);
			}
			if (this.mSkillTypeTxt != null)
			{
				this.mSkillTypeTxt.text = DataManager<SkillDataManager>.GetInstance().GetSkillType(tableItem);
			}
			if (this.mJopTipTxt != null)
			{
				bool flag = DataManager<SkillDataManager>.GetInstance().IsSkillJobAdaptToTargetJob(tableItem, DataManager<PlayerBaseData>.GetInstance().JobTableID);
				this.mJopTipTxt.CustomActive(!flag);
			}
			if (this.mSkillDexTxt != null)
			{
				this.mSkillDexTxt.text = DataManager<SkillDataManager>.GetInstance().GetSkillDescription(tableItem);
			}
			byte b = SkillTreeFrame.CalFinalShowLv(skill.id);
			this._UpdateSkillConsumeMPAndThing(tableItem, b);
			this._UpdateSkillCDText(skill.id, tableItem, b);
			this._UpdateSkillAttribute(tableItem);
		}

		// Token: 0x0600C0B5 RID: 49333 RVA: 0x002DA170 File Offset: 0x002D8570
		private void _UpdateSkillConsumeMPAndThing(SkillTable skillTable, byte curSkillLv)
		{
			byte level = 1;
			if (curSkillLv >= 1)
			{
				level = curSkillLv;
			}
			float num = (float)TableManager.GetValueFromUnionCell(skillTable.MPCost, (int)level, false);
			if (this.mSkillConsumeMpTxt != null)
			{
				this.mSkillConsumeMpTxt.text = string.Format("{0}", num);
			}
			float num2 = (float)TableManager.GetValueFromUnionCell(skillTable.CrystalCost, (int)level, false);
			if (num2 > 0f)
			{
				if (this.mSkillConsumeMpTxt != null)
				{
					this.mSkillConsumeThingTxt.CustomActive(true);
					this.mSkillConsumeThingTxt.text = string.Format("{0}个", num2);
				}
			}
			else if (this.mSkillConsumeThingTxt != null)
			{
				this.mSkillConsumeThingTxt.CustomActive(false);
			}
		}

		// Token: 0x0600C0B6 RID: 49334 RVA: 0x002DA238 File Offset: 0x002D8638
		private void _UpdateSkillCDText(ushort skillID, SkillTable skillTable, byte curSkillLevel)
		{
			SkillLevelAddInfo skillLevelAddInfo = new SkillLevelAddInfo();
			skillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetAddedSkillInfo((int)skillID, this.mskillLevelAddInfo);
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
			if (this.mSkillCDTxt != null)
			{
				this.mSkillCDTxt.text = string.Format("{0}S", num);
			}
		}

		// Token: 0x0600C0B7 RID: 49335 RVA: 0x002DA310 File Offset: 0x002D8710
		private void _UpdateSkillAttribute(SkillTable skillTable)
		{
			for (int i = 0; i < this.mAttributeGoArry.Length; i++)
			{
				this.mAttributeGoArry[i].gameObject.CustomActive(false);
			}
			if (skillTable == null)
			{
				return;
			}
			if (skillTable.SkillEffect == null)
			{
				return;
			}
			for (int j = 0; j < skillTable.SkillEffect.Length; j++)
			{
				if (j < this.mAttributeGoArry.Length)
				{
					string text = this._GetSkillTypeText((byte)skillTable.SkillEffect[j]);
					if (text != string.Empty)
					{
						this.mAttributeTypeTxtArry[j].text = text;
						this.mAttributeGoArry[j].gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x0600C0B8 RID: 49336 RVA: 0x002DA3D0 File Offset: 0x002D87D0
		private string _GetSkillTypeText(byte effectIndex)
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

		// Token: 0x0600C0B9 RID: 49337 RVA: 0x002DA4E4 File Offset: 0x002D88E4
		private void _UpdataSKillBar(bool bIsiInit = false)
		{
			for (int i = 0; i < this.mSkillBarPosBind.Length; i++)
			{
				Toggle com = this.mSkillBarPosBind[i].GetCom<Toggle>("SkillBarElement");
				Image com2 = this.mSkillBarPosBind[i].GetCom<Image>("Icon");
				Image com3 = this.mSkillBarPosBind[i].GetCom<Image>("plus");
				Drag_Me com4 = this.mSkillBarPosBind[i].GetCom<Drag_Me>("dragme");
				Drop_Me com5 = this.mSkillBarPosBind[i].GetCom<Drop_Me>("dropme");
				int id = 0;
				for (int j = 0; j < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; j++)
				{
					SkillBarGrid skillBarGrid = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j];
					if (i + 1 == (int)skillBarGrid.slot)
					{
						id = (int)skillBarGrid.id;
						break;
					}
				}
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (com3 != null)
				{
					com3.CustomActive(tableItem == null);
				}
				if (com2 != null)
				{
					if (tableItem == null)
					{
						com2.color = new Color(1f, 1f, 1f, 0f);
					}
					else
					{
						com2.color = new Color(1f, 1f, 1f, 1f);
					}
				}
				if (bIsiInit)
				{
					if (com4 != null)
					{
						com4.index = i;
						com4.ResponseDrag = new Drag_Me.OnResDrag(this._DealSkillBarDrag);
					}
					if (com5 != null)
					{
						com5.slot = i;
						com5.ResponseDrop = new Drop_Me.OnResDrop(this._DealSkillBarDrop);
					}
				}
				if (tableItem != null)
				{
					if (com2 != null)
					{
						ETCImageLoader.LoadSprite(ref com2, tableItem.Icon, true);
					}
				}
			}
			if (bIsiInit && this.mGiveUpDropMe != null)
			{
				this.mGiveUpDropMe.ResponseDrop = new Drop_Me.OnResDrop(this._DealSkillBarDrop);
				this.mGiveUpDropMe.SetAutoReplace(false);
				this.mGiveUpDropMe.SetHighLight(false);
			}
		}

		// Token: 0x0600C0BA RID: 49338 RVA: 0x002DA70C File Offset: 0x002D8B0C
		private bool _DealSkillBarDrag(PointerEventData eventData, bool bIsDrag)
		{
			GameObject lastPress = eventData.lastPress;
			if (lastPress == null)
			{
				return false;
			}
			GameObject gameObject = lastPress.transform.parent.gameObject;
			if (gameObject == null)
			{
				return false;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return false;
			}
			Drag_Me com = component.GetCom<Drag_Me>("dragme");
			if (com == null)
			{
				return false;
			}
			int i = 0;
			while (i < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count)
			{
				if (com.index + 1 == (int)DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot)
				{
					if (DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id == 0)
					{
						return false;
					}
					break;
				}
				else
				{
					i++;
				}
			}
			return true;
		}

		// Token: 0x0600C0BB RID: 49339 RVA: 0x002DA7E8 File Offset: 0x002D8BE8
		private void _DealSkillBarDrop(PointerEventData dragData, GameObject beDropedImgParent)
		{
			GameObject lastPress = dragData.lastPress;
			if (lastPress == null)
			{
				return;
			}
			GameObject gameObject = lastPress.transform.parent.gameObject;
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Drag_Me com = component.GetCom<Drag_Me>("dragme");
			if (com == null)
			{
				return;
			}
			GameObject gameObject2 = beDropedImgParent.transform.parent.gameObject;
			if (gameObject2 == null)
			{
				return;
			}
			ComCommonBind component2 = gameObject2.GetComponent<ComCommonBind>();
			if (component2 == null)
			{
				return;
			}
			Drop_Me com2 = component2.GetCom<Drop_Me>("dropme");
			if (com2 == null)
			{
				return;
			}
			if (com.index == com2.slot)
			{
				return;
			}
			SkillBarGrid skillBarGrid = new SkillBarGrid();
			SkillBarGrid skillBarGrid2 = new SkillBarGrid();
			skillBarGrid.slot = (byte)(com.index + 1);
			skillBarGrid2.slot = (byte)(com2.slot + 1);
			for (int i = 0; i < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; i++)
			{
				if (skillBarGrid.slot == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot && DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id != 0)
				{
					skillBarGrid.id = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id;
				}
				if (skillBarGrid2.slot == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot)
				{
					skillBarGrid2.id = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id;
				}
			}
			SceneExchangeSkillBarReq sceneExchangeSkillBarReq = new SceneExchangeSkillBarReq();
			if (com.DragGroup == EDragGroup.SkillPlane && com2.DropGroup == EDropGroup.SkillPlane)
			{
				if (skillBarGrid.id == 0)
				{
					return;
				}
				ushort id = skillBarGrid.id;
				skillBarGrid.id = skillBarGrid2.id;
				skillBarGrid2.id = id;
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[2];
				sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid2;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[1] = skillBarGrid;
				sceneExchangeSkillBarReq.configType = 2;
			}
			else if (com.DragGroup == EDragGroup.SkillPlane && com2.DropGroup == EDropGroup.GiveUp)
			{
				if (skillBarGrid.id == 0)
				{
					return;
				}
				SkillBarGrid skillBarGrid3 = skillBarGrid;
				skillBarGrid3.id = 0;
				skillBarGrid3.slot = skillBarGrid.slot;
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[1];
				sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid3;
				sceneExchangeSkillBarReq.configType = 2;
			}
			else if (com.DragGroup == EDragGroup.SkillTree && com2.DropGroup == EDropGroup.SkillPlane)
			{
				SkillBarGrid skillBarGrid4 = new SkillBarGrid();
				skillBarGrid4.id = com.Id;
				skillBarGrid4.slot = (byte)(com2.slot + 1);
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				if (this.IsEquipedSkill((int)com.Id))
				{
					SkillBarGrid skillBarGrid5 = new SkillBarGrid();
					for (int j = 0; j < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; j++)
					{
						if (com.Id == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].id && DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].slot != 0)
						{
							skillBarGrid5.slot = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].slot;
						}
					}
					skillBarGrid5.id = 0;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[2];
					sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid4;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[1] = skillBarGrid5;
					sceneExchangeSkillBarReq.configType = 2;
				}
				else
				{
					sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[1];
					sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid4;
					sceneExchangeSkillBarReq.configType = 2;
				}
			}
			NetManager.Instance().SendCommand<SceneExchangeSkillBarReq>(ServerType.GATE_SERVER, sceneExchangeSkillBarReq);
		}

		// Token: 0x0600C0BC RID: 49340 RVA: 0x002DAD1F File Offset: 0x002D911F
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C0BD RID: 49341 RVA: 0x002DAD22 File Offset: 0x002D9122
		private void OnCloseBtnClick()
		{
			this.frameMgr.CloseFrame<FairDuelSkillFrameOld>(this, false);
		}

		// Token: 0x04006CD7 RID: 27863
		private Button mCloseBtn;

		// Token: 0x04006CD8 RID: 27864
		private ComUIListScript mComUIList;

		// Token: 0x04006CD9 RID: 27865
		private Image mDetail_SkillIcomImg;

		// Token: 0x04006CDA RID: 27866
		private Text mDetail_SkillNameTxt;

		// Token: 0x04006CDB RID: 27867
		private Text mDetail_SkillLvlTxt;

		// Token: 0x04006CDC RID: 27868
		private Text mSkillConsumeMpTxt;

		// Token: 0x04006CDD RID: 27869
		private Text mSkillConsumeThingTxt;

		// Token: 0x04006CDE RID: 27870
		private Text mSkillCDTxt;

		// Token: 0x04006CDF RID: 27871
		private GameObject[] mAttributeGoArry = new GameObject[6];

		// Token: 0x04006CE0 RID: 27872
		private Text[] mAttributeTypeTxtArry = new Text[6];

		// Token: 0x04006CE1 RID: 27873
		private Text mSkillDexTxt;

		// Token: 0x04006CE2 RID: 27874
		private Text mSkillTypeTxt;

		// Token: 0x04006CE3 RID: 27875
		private Text mJopTipTxt;

		// Token: 0x04006CE4 RID: 27876
		private Drop_Me mGiveUpDropMe;

		// Token: 0x04006CE5 RID: 27877
		[UIControl("skillBarRoot/BarPos{0}", typeof(ComCommonBind), 1)]
		private ComCommonBind[] mSkillBarPosBind = new ComCommonBind[11];

		// Token: 0x04006CE6 RID: 27878
		private Dictionary<int, SkillLevelAddInfo> mskillLevelAddInfo = new Dictionary<int, SkillLevelAddInfo>();
	}
}
