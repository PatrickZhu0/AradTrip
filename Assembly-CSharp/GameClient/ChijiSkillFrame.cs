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
	// Token: 0x02001124 RID: 4388
	public class ChijiSkillFrame : ClientFrame
	{
		// Token: 0x0600A68E RID: 42638 RVA: 0x0022943F File Offset: 0x0022783F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiSkillFrame";
		}

		// Token: 0x0600A68F RID: 42639 RVA: 0x00229446 File Offset: 0x00227846
		protected override void _OnOpenFrame()
		{
			this.InitData();
			this.BindUIEvent();
			this._InitSkillListScrollListBind();
			this._RefreshSkillListCount();
			this._UpdateSkillBar(true);
			this.bInit = true;
		}

		// Token: 0x0600A690 RID: 42640 RVA: 0x0022946E File Offset: 0x0022786E
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this._ClearData();
		}

		// Token: 0x0600A691 RID: 42641 RVA: 0x0022947C File Offset: 0x0022787C
		private void _ClearData()
		{
			this.bInit = false;
			this.bCurSelectSkillLv = 0;
			this.pvpSkillLevelAddInfo.Clear();
		}

		// Token: 0x0600A692 RID: 42642 RVA: 0x00229498 File Offset: 0x00227898
		private void InitData()
		{
			List<ItemProperty> equipedEquipments = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
			this.pvpSkillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, equipedEquipments, SkillSystemSourceType.None);
		}

		// Token: 0x0600A693 RID: 42643 RVA: 0x002294C3 File Offset: 0x002278C3
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600A694 RID: 42644 RVA: 0x002294E0 File Offset: 0x002278E0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600A695 RID: 42645 RVA: 0x002294FD File Offset: 0x002278FD
		private void _OnSkillBarChanged(UIEvent iEvent)
		{
			this._UpdateSkillBar(false);
		}

		// Token: 0x0600A696 RID: 42646 RVA: 0x00229508 File Offset: 0x00227908
		private void _InitSkillListScrollListBind()
		{
			this.mChijiSkillUIListScript.Initialize();
			this.mChijiSkillUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateSkillScrollListBind(item);
				}
			};
			this.mChijiSkillUIListScript.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Toggle com = component.GetCom<Toggle>("tgSkill");
				com.onValueChanged.RemoveAllListeners();
			};
		}

		// Token: 0x0600A697 RID: 42647 RVA: 0x00229560 File Offset: 0x00227960
		private void _UpdateSkillScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= DataManager<SkillDataManager>.GetInstance().ChijiSkillList.Count)
			{
				return;
			}
			Skill skill = DataManager<SkillDataManager>.GetInstance().ChijiSkillList[item.m_index];
			if (skill.id == 1919)
			{
				component.gameObject.CustomActive(false);
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
			if (com != null)
			{
				ETCImageLoader.LoadSprite(ref com, tableItem.Icon, true);
			}
			if (com2 != null)
			{
				com2.text = string.Format("Lv.{0}", skill.level);
			}
			if (com3 != null)
			{
				List<SkillBarGrid> chijiSkillBar = DataManager<SkillDataManager>.GetInstance().ChijiSkillBar;
				bool bActive = false;
				for (int i = 0; i < chijiSkillBar.Count; i++)
				{
					if (chijiSkillBar[i].id == skill.id)
					{
						bActive = true;
						break;
					}
				}
				com3.CustomActive(bActive);
			}
			if (com4 != null)
			{
				com4.onValueChanged.RemoveAllListeners();
				int iIndex = item.m_index;
				com4.onValueChanged.AddListener(delegate(bool value)
				{
					this._OnSelectSkill(iIndex, value);
				});
				if (!this.bInit && item.m_index == 0)
				{
					com4.isOn = true;
				}
			}
			component.gameObject.CustomActive(true);
		}

		// Token: 0x0600A698 RID: 42648 RVA: 0x00229750 File Offset: 0x00227B50
		private void _RefreshSkillListCount()
		{
			if (DataManager<SkillDataManager>.GetInstance().ChijiSkillList != null)
			{
				this.mRightRoot.gameObject.CustomActive(DataManager<SkillDataManager>.GetInstance().ChijiSkillList.Count > 0);
				this.mChijiSkillUIListScript.SetElementAmount(DataManager<SkillDataManager>.GetInstance().ChijiSkillList.Count);
			}
		}

		// Token: 0x0600A699 RID: 42649 RVA: 0x002297A8 File Offset: 0x00227BA8
		private void _UpdateSkillBar(bool bIsiInit = false)
		{
			for (int i = 0; i < this.skillBarPosBind.Length; i++)
			{
				Toggle com = this.skillBarPosBind[i].GetCom<Toggle>("SkillBarElement");
				Image com2 = this.skillBarPosBind[i].GetCom<Image>("Icon");
				Image com3 = this.skillBarPosBind[i].GetCom<Image>("plus");
				Drag_Me com4 = this.skillBarPosBind[i].GetCom<Drag_Me>("dragme");
				Drop_Me com5 = this.skillBarPosBind[i].GetCom<Drop_Me>("dropme");
				int id = 0;
				for (int j = 0; j < DataManager<SkillDataManager>.GetInstance().ChijiSkillBar.Count; j++)
				{
					SkillBarGrid skillBarGrid = DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[j];
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
		}

		// Token: 0x0600A69A RID: 42650 RVA: 0x0022998C File Offset: 0x00227D8C
		private void _OnSelectSkill(int index, bool value)
		{
			if (index < 0 || !value)
			{
				return;
			}
			if (index >= DataManager<SkillDataManager>.GetInstance().ChijiSkillList.Count)
			{
				return;
			}
			Skill skillInfo = DataManager<SkillDataManager>.GetInstance().ChijiSkillList[index];
			this._UpdateSelectedSkillInfo(skillInfo);
		}

		// Token: 0x0600A69B RID: 42651 RVA: 0x002299D8 File Offset: 0x00227DD8
		private void _UpdateSelectedSkillInfo(Skill skillInfo)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skillInfo.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mName != null)
			{
				this.mName.text = tableItem.Name;
			}
			if (this.mSkillIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mSkillIcon, tableItem.Icon, true);
			}
			if (this.mRightLevel != null)
			{
				this.mRightLevel.text = string.Format("Lv.{0}", skillInfo.level);
			}
			if (this.mSkillType != null)
			{
				this.mSkillType.text = DataManager<SkillDataManager>.GetInstance().GetSkillType(tableItem);
			}
			if (this.mJobtip != null)
			{
				bool flag = DataManager<SkillDataManager>.GetInstance().IsSkillJobAdaptToTargetJob(tableItem, DataManager<PlayerBaseData>.GetInstance().JobTableID);
				this.mJobtip.CustomActive(!flag);
			}
			if (this.mRightContentDes != null)
			{
				this.mRightContentDes.text = DataManager<SkillDataManager>.GetInstance().GetSkillDescription(tableItem);
			}
			this.bCurSelectSkillLv = SkillTreeFrame.CalFinalShowLv(skillInfo.id);
			this.UpdateSkillAttribute(tableItem);
			this.UpdateSkillCDText(skillInfo.id, tableItem, this.bCurSelectSkillLv);
			this.UpdateSkillConsumeMP(tableItem, this.bCurSelectSkillLv);
		}

		// Token: 0x0600A69C RID: 42652 RVA: 0x00229B3C File Offset: 0x00227F3C
		private void UpdateSkillConsumeMP(SkillTable skillTable, byte curSkillLv)
		{
			byte level = 1;
			if (curSkillLv >= 1)
			{
				level = curSkillLv;
			}
			float num = (float)TableManager.GetValueFromUnionCell(skillTable.MPCost, (int)level, false);
			if (this.mSkillConsumeMpText != null)
			{
				this.mSkillConsumeMpText.text = string.Format("{0}", num);
			}
			float num2 = (float)TableManager.GetValueFromUnionCell(skillTable.CrystalCost, (int)level, false);
			if (num2 > 0f)
			{
				if (this.mSkillConsumeThingText != null)
				{
					this.mSkillConsumeThingText.gameObject.CustomActive(true);
					this.mSkillConsumeThingText.text = string.Format("{0}个", num2);
				}
			}
			else if (this.mSkillConsumeThingText != null)
			{
				this.mSkillConsumeThingText.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600A69D RID: 42653 RVA: 0x00229C10 File Offset: 0x00228010
		private void UpdateSkillCDText(ushort skillID, SkillTable skillTable, byte curSkillLevel)
		{
			SkillLevelAddInfo skillLevelAddInfo = new SkillLevelAddInfo();
			skillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetAddedSkillInfo((int)skillID, this.pvpSkillLevelAddInfo);
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
			if (this.mSkillCDNum != null)
			{
				this.mSkillCDNum.text = string.Format("{0}S", num);
			}
		}

		// Token: 0x0600A69E RID: 42654 RVA: 0x00229CE8 File Offset: 0x002280E8
		private void UpdateSkillAttribute(SkillTable skillTable)
		{
			for (int i = 0; i < this.attributeGos.Length; i++)
			{
				this.attributeGos[i].gameObject.CustomActive(false);
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
				if (j < this.attributeGos.Length)
				{
					string skillTypeText = this.GetSkillTypeText((byte)skillTable.SkillEffect[j]);
					if (skillTypeText != string.Empty)
					{
						this.attributeTypeTexts[j].text = skillTypeText;
						this.attributeGos[j].gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x0600A69F RID: 42655 RVA: 0x00229DA8 File Offset: 0x002281A8
		private bool _DealSkillBarDrag(PointerEventData DragData, bool bIsDrag = true)
		{
			GameObject lastPress = DragData.lastPress;
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
			bool result = false;
			for (int i = 0; i < DataManager<SkillDataManager>.GetInstance().ChijiSkillBar.Count; i++)
			{
				if (com.index + 1 == (int)DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].slot)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600A6A0 RID: 42656 RVA: 0x00229E74 File Offset: 0x00228274
		private void _DealSkillBarDrop(PointerEventData DragData, GameObject BeDropedImgParent)
		{
			GameObject lastPress = DragData.lastPress;
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
			GameObject gameObject2 = BeDropedImgParent.transform.parent.gameObject;
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
			for (int i = 0; i < DataManager<SkillDataManager>.GetInstance().ChijiSkillBar.Count; i++)
			{
				if (skillBarGrid.slot == DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].slot && DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].id != 0)
				{
					skillBarGrid.id = DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].id;
				}
				if (skillBarGrid2.slot == DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].slot)
				{
					skillBarGrid2.id = DataManager<SkillDataManager>.GetInstance().ChijiSkillBar[i].id;
				}
			}
			if (skillBarGrid.id == 0)
			{
				return;
			}
			ushort id = skillBarGrid.id;
			skillBarGrid.id = skillBarGrid2.id;
			skillBarGrid2.id = id;
			SceneExchangeSkillBarReq sceneExchangeSkillBarReq = new SceneExchangeSkillBarReq();
			sceneExchangeSkillBarReq.skillBars.index = 1;
			sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
			sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
			sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[2];
			sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
			sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid2;
			sceneExchangeSkillBarReq.skillBars.bar[0].grids[1] = skillBarGrid;
			sceneExchangeSkillBarReq.configType = 2;
			NetManager.Instance().SendCommand<SceneExchangeSkillBarReq>(ServerType.GATE_SERVER, sceneExchangeSkillBarReq);
		}

		// Token: 0x0600A6A1 RID: 42657 RVA: 0x0022A10C File Offset: 0x0022850C
		private string GetSkillTypeText(byte effectIndex)
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

		// Token: 0x0600A6A2 RID: 42658 RVA: 0x0022A21D File Offset: 0x0022861D
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A6A3 RID: 42659 RVA: 0x0022A220 File Offset: 0x00228620
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600A6A4 RID: 42660 RVA: 0x0022A224 File Offset: 0x00228624
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mChijiSkillUIListScript = this.mBind.GetCom<ComUIListScript>("ChijiSkillUIListScript");
			this.mRightRoot = this.mBind.GetGameObject("rightRoot");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mSkillIcon = this.mBind.GetCom<Image>("skillIcon");
			this.mRightLevel = this.mBind.GetCom<Text>("rightLevel");
			this.mSkillType = this.mBind.GetCom<Text>("skillType");
			this.mJobtip = this.mBind.GetCom<Text>("jobtip");
			this.attributeGos[0] = this.mBind.GetGameObject("Type0");
			this.attributeGos[1] = this.mBind.GetGameObject("Type1");
			this.attributeGos[2] = this.mBind.GetGameObject("Type2");
			this.attributeGos[3] = this.mBind.GetGameObject("Type3");
			this.attributeGos[4] = this.mBind.GetGameObject("Type4");
			this.attributeGos[5] = this.mBind.GetGameObject("Type5");
			this.attributeTypeTexts[0] = this.mBind.GetCom<Text>("Text0");
			this.attributeTypeTexts[1] = this.mBind.GetCom<Text>("Text1");
			this.attributeTypeTexts[2] = this.mBind.GetCom<Text>("Text2");
			this.attributeTypeTexts[3] = this.mBind.GetCom<Text>("Text3");
			this.attributeTypeTexts[4] = this.mBind.GetCom<Text>("Text4");
			this.attributeTypeTexts[5] = this.mBind.GetCom<Text>("Text5");
			this.mSkillCDNum = this.mBind.GetCom<Text>("skillCDNum");
			this.mSkillConsumeMpText = this.mBind.GetCom<Text>("skillConsumeMPText");
			this.mSkillConsumeThingText = this.mBind.GetCom<Text>("skillConsumeThingText");
			this.mRightContentDes = this.mBind.GetCom<Text>("Content");
		}

		// Token: 0x0600A6A5 RID: 42661 RVA: 0x0022A488 File Offset: 0x00228888
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mChijiSkillUIListScript = null;
			this.mRightRoot = null;
			this.mName = null;
			this.mSkillIcon = null;
			this.mRightLevel = null;
			this.mSkillType = null;
			this.mJobtip = null;
			this.attributeGos[0] = null;
			this.attributeGos[1] = null;
			this.attributeGos[2] = null;
			this.attributeGos[3] = null;
			this.attributeGos[4] = null;
			this.attributeGos[5] = null;
			this.attributeTypeTexts[0] = null;
			this.attributeTypeTexts[1] = null;
			this.attributeTypeTexts[2] = null;
			this.attributeTypeTexts[3] = null;
			this.attributeTypeTexts[4] = null;
			this.attributeTypeTexts[5] = null;
			this.mSkillCDNum = null;
			this.mSkillConsumeMpText = null;
			this.mSkillConsumeThingText = null;
			this.mRightContentDes = null;
		}

		// Token: 0x0600A6A6 RID: 42662 RVA: 0x0022A582 File Offset: 0x00228982
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiSkillFrame>(this, false);
		}

		// Token: 0x04005D2A RID: 23850
		private bool bInit;

		// Token: 0x04005D2B RID: 23851
		private byte bCurSelectSkillLv;

		// Token: 0x04005D2C RID: 23852
		private Dictionary<int, SkillLevelAddInfo> pvpSkillLevelAddInfo = new Dictionary<int, SkillLevelAddInfo>();

		// Token: 0x04005D2D RID: 23853
		[UIControl("skillBarRoot/BarPos{0}", typeof(ComCommonBind), 1)]
		private ComCommonBind[] skillBarPosBind = new ComCommonBind[12];

		// Token: 0x04005D2E RID: 23854
		private GameObject[] attributeGos = new GameObject[6];

		// Token: 0x04005D2F RID: 23855
		private Text[] attributeTypeTexts = new Text[6];

		// Token: 0x04005D30 RID: 23856
		private Button mClose;

		// Token: 0x04005D31 RID: 23857
		private ComUIListScript mChijiSkillUIListScript;

		// Token: 0x04005D32 RID: 23858
		private GameObject mRightRoot;

		// Token: 0x04005D33 RID: 23859
		private Text mName;

		// Token: 0x04005D34 RID: 23860
		private Image mSkillIcon;

		// Token: 0x04005D35 RID: 23861
		private Text mRightLevel;

		// Token: 0x04005D36 RID: 23862
		private Text mSkillType;

		// Token: 0x04005D37 RID: 23863
		private Text mJobtip;

		// Token: 0x04005D38 RID: 23864
		private Text mSkillCDNum;

		// Token: 0x04005D39 RID: 23865
		private Text mSkillConsumeMpText;

		// Token: 0x04005D3A RID: 23866
		private Text mSkillConsumeThingText;

		// Token: 0x04005D3B RID: 23867
		private Text mRightContentDes;
	}
}
