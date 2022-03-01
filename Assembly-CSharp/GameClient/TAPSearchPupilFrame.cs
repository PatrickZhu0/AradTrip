using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BEE RID: 7150
	internal class TAPSearchPupilFrame : ClientFrame
	{
		// Token: 0x06011869 RID: 71785 RVA: 0x005195C6 File Offset: 0x005179C6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPSearchPupilFrame";
		}

		// Token: 0x0601186A RID: 71786 RVA: 0x005195D0 File Offset: 0x005179D0
		private void _UpdateAnnouncement()
		{
			if (null != this.Announcement)
			{
				if (string.IsNullOrEmpty(DataManager<PlayerBaseData>.GetInstance().Announcement))
				{
					this.Announcement.text = TR.Value("tap_default_announcement");
				}
				else
				{
					this.Announcement.text = DataManager<PlayerBaseData>.GetInstance().Announcement;
				}
			}
		}

		// Token: 0x0601186B RID: 71787 RVA: 0x00519634 File Offset: 0x00517A34
		private void _UpdateSetting()
		{
			if (null != this.toggle0)
			{
				this.toggle0.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged0));
				this.toggle0.isOn = DataManager<PlayerBaseData>.GetInstance().getPupil;
				this.toggle0.onValueChanged.AddListener(new UnityAction<bool>(this._OnToggleChanged0));
			}
			if (null != this.toggle1)
			{
				this.toggle1.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged1));
				this.toggle1.isOn = !DataManager<PlayerBaseData>.GetInstance().getPupil;
				this.toggle1.onValueChanged.AddListener(new UnityAction<bool>(this._OnToggleChanged1));
			}
		}

		// Token: 0x0601186C RID: 71788 RVA: 0x00519700 File Offset: 0x00517B00
		private void _OnToggleChanged0(bool bValue)
		{
			if (bValue)
			{
				SetRecvDiscipleState setRecvDiscipleState = new SetRecvDiscipleState();
				setRecvDiscipleState.state = 1;
				NetManager.Instance().SendCommand<SetRecvDiscipleState>(ServerType.GATE_SERVER, setRecvDiscipleState);
			}
		}

		// Token: 0x0601186D RID: 71789 RVA: 0x00519730 File Offset: 0x00517B30
		private void _OnToggleChanged1(bool bValue)
		{
			if (bValue)
			{
				SetRecvDiscipleState setRecvDiscipleState = new SetRecvDiscipleState();
				setRecvDiscipleState.state = 0;
				NetManager.Instance().SendCommand<SetRecvDiscipleState>(ServerType.GATE_SERVER, setRecvDiscipleState);
			}
		}

		// Token: 0x0601186E RID: 71790 RVA: 0x00519760 File Offset: 0x00517B60
		private void _UpdateSearchedPupilList()
		{
			if (null != this.comSearchedPupilList)
			{
				List<RelationData> searchedPupilList = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
				this.comSearchedPupilList.SetElementAmount(searchedPupilList.Count);
			}
			if (null != this.hint)
			{
				this.hint.CustomActive(DataManager<RelationDataManager>.GetInstance().SearchedPupilList.Count <= 0);
			}
		}

		// Token: 0x0601186F RID: 71791 RVA: 0x005197CC File Offset: 0x00517BCC
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<TAPSearchPupilFrame>(this, false);
			});
			base._AddButton("Announcement/BtnModify", delegate
			{
				if (!string.Equals(this.Announcement.text, DataManager<PlayerBaseData>.GetInstance().Announcement))
				{
					SetMasterNote setMasterNote = new SetMasterNote();
					setMasterNote.note = this.Announcement.text;
					if (string.IsNullOrEmpty(this.Announcement.text))
					{
						setMasterNote.note = string.Empty;
					}
					NetManager.Instance().SendCommand<SetMasterNote>(ServerType.GATE_SERVER, setMasterNote);
				}
			});
			this.needPopupMsg = false;
			this.comSearchedPupilList.Initialize();
			this.comSearchedPupilList.onBindItem = ((GameObject go) => go.GetComponent<ComTAPSearchedPupil>());
			this.comSearchedPupilList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (null != item)
				{
					ComTAPSearchedPupil comTAPSearchedPupil = item.gameObjectBindScript as ComTAPSearchedPupil;
					List<RelationData> searchedPupilList = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
					if (null != comTAPSearchedPupil && item.m_index >= 0 && item.m_index < searchedPupilList.Count)
					{
						comTAPSearchedPupil.OnItemVisible(searchedPupilList[item.m_index]);
					}
				}
			};
			base._AddButton("Root/BtnChangeAll", new UnityAction(this._ChangeAll));
			this._RegisterEvent();
			this._UpdateAnnouncement();
			this._UpdateSetting();
			this._UpdateSearchedPupilList();
			DataManager<TAPDataManager>.GetInstance().SendChangeSearchedPupilList();
			DataManager<TAPDataManager>.GetInstance().SendQueryMasterSetting();
		}

		// Token: 0x06011870 RID: 71792 RVA: 0x005198AC File Offset: 0x00517CAC
		private void _ChangeAll()
		{
			this.btnChangeAll.enabled = false;
			this.grayChangeAll.enabled = true;
			this.iChangeAllValue = 5;
			if (null != this.changeAllText)
			{
				this.changeAllText.text = TR.Value("relation_change_all_desc_param", this.iChangeAllValue);
			}
			InvokeMethod.RmoveInvokeIntervalCall(this);
			InvokeMethod.InvokeInterval(this, 0f, 1f, 5f, null, delegate
			{
				this.iChangeAllValue--;
				if (null != this.changeAllText)
				{
					this.changeAllText.text = TR.Value("relation_change_all_desc_param", this.iChangeAllValue);
				}
			}, delegate
			{
				this.btnChangeAll.enabled = true;
				this.grayChangeAll.enabled = false;
				this.iChangeAllValue = 0;
				if (null != this.changeAllText)
				{
					this.changeAllText.text = TR.Value("relation_change_all_desc");
				}
			});
			DataManager<TAPDataManager>.GetInstance().SendChangeSearchedPupilList();
		}

		// Token: 0x06011871 RID: 71793 RVA: 0x00519948 File Offset: 0x00517D48
		protected override void _OnCloseFrame()
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
			this._UnRegisterEvent();
			if (null != this.toggle0)
			{
				this.toggle0.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged0));
			}
			if (null != this.toggle1)
			{
				this.toggle1.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged1));
			}
			InvokeMethod.RmoveInvokeIntervalCall(this);
			DataManager<TAPDataManager>.GetInstance().ClearApplyedPupils();
		}

		// Token: 0x06011872 RID: 71794 RVA: 0x005199EC File Offset: 0x00517DEC
		private void _RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAnnouncementChanged, new ClientEventSystem.UIEventHandler(this._OnAnnouncementChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGetPupilSettingChanged, new ClientEventSystem.UIEventHandler(this._OnGetPupilSettingChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowPupilApplyMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilApplyMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSearchedPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedPupilListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnWanApplyedPupilChanged, new ClientEventSystem.UIEventHandler(this._OnWanApplyedPupilChanged));
			if (null != this.Announcement)
			{
				this.Announcement.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			}
		}

		// Token: 0x06011873 RID: 71795 RVA: 0x00519AE4 File Offset: 0x00517EE4
		private void _UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAnnouncementChanged, new ClientEventSystem.UIEventHandler(this._OnAnnouncementChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGetPupilSettingChanged, new ClientEventSystem.UIEventHandler(this._OnGetPupilSettingChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowPupilApplyMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilApplyMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSearchedPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedPupilListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnWanApplyedPupilChanged, new ClientEventSystem.UIEventHandler(this._OnWanApplyedPupilChanged));
			if (null != this.Announcement)
			{
				this.Announcement.onValueChanged.RemoveListener(new UnityAction<string>(this.OnValueChanged));
			}
		}

		// Token: 0x06011874 RID: 71796 RVA: 0x00519BDC File Offset: 0x00517FDC
		private int _GetMaxContentLength()
		{
			int num = 30;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(279, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			return num / 2;
		}

		// Token: 0x06011875 RID: 71797 RVA: 0x00519C18 File Offset: 0x00518018
		public void OnValueChanged(string content)
		{
			int num = this._GetMaxContentLength();
			content = content.Replace("\r\n", string.Empty);
			if (num < content.Length)
			{
				content = content.Substring(0, num);
			}
			if (null != this.Announcement)
			{
				this.Announcement.onValueChanged.RemoveListener(new UnityAction<string>(this.OnValueChanged));
			}
			this.Announcement.text = content;
			if (null != this.Announcement)
			{
				this.Announcement.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			}
			int length = content.Length;
			if (null != this.process)
			{
				this.process.text = ((length > num) ? string.Format("<color=#ff0000>{0}/{1}</color>", length, num) : string.Format("<color=#ffffff>{0}/{1}</color>", length, num));
			}
		}

		// Token: 0x06011876 RID: 71798 RVA: 0x00519D15 File Offset: 0x00518115
		private void _OnAnnouncementChanged(UIEvent uiEvent)
		{
			this._UpdateAnnouncement();
		}

		// Token: 0x06011877 RID: 71799 RVA: 0x00519D1D File Offset: 0x0051811D
		private void _OnGetPupilSettingChanged(UIEvent uiEvent)
		{
			this._UpdateSetting();
		}

		// Token: 0x06011878 RID: 71800 RVA: 0x00519D25 File Offset: 0x00518125
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			this._UpdateSearchedPupilList();
		}

		// Token: 0x06011879 RID: 71801 RVA: 0x00519D30 File Offset: 0x00518130
		private void _OnSearchedPupilListChanged(UIEvent uiEvent)
		{
			this._UpdateSearchedPupilList();
			if (this.needPopupMsg)
			{
				List<RelationData> searchedPupilList = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
				if (searchedPupilList != null && searchedPupilList.Count > 0)
				{
					SystemNotifyManager.SystemNotify(8928, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(8930, string.Empty);
				}
			}
			this.needPopupMsg = true;
		}

		// Token: 0x0601187A RID: 71802 RVA: 0x00519D95 File Offset: 0x00518195
		private void _OnWanApplyedPupilChanged(UIEvent uiEvent)
		{
			this._UpdateSearchedPupilList();
		}

		// Token: 0x0601187B RID: 71803 RVA: 0x00519DA0 File Offset: 0x005181A0
		protected void _OnShowPupilApplyMenu(UIEvent uiEvent)
		{
			RelationMenuData userData = uiEvent.Param1 as RelationMenuData;
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0601187C RID: 71804 RVA: 0x00519DEF File Offset: 0x005181EF
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x0400B653 RID: 46675
		[UIControl("Announcement/Announcement", typeof(InputField), 0)]
		private InputField Announcement;

		// Token: 0x0400B654 RID: 46676
		[UIControl("Announcement/Process", typeof(Text), 0)]
		private Text process;

		// Token: 0x0400B655 RID: 46677
		private bool needPopupMsg;

		// Token: 0x0400B656 RID: 46678
		[UIControl("Status/TG0", typeof(Toggle), 0)]
		private Toggle toggle0;

		// Token: 0x0400B657 RID: 46679
		[UIControl("Status/TG1", typeof(Toggle), 0)]
		private Toggle toggle1;

		// Token: 0x0400B658 RID: 46680
		[UIControl("Root/Friends", typeof(ComUIListScript), 0)]
		private ComUIListScript comSearchedPupilList;

		// Token: 0x0400B659 RID: 46681
		[UIControl("Root/Hint", typeof(Text), 0)]
		private Text hint;

		// Token: 0x0400B65A RID: 46682
		[UIControl("Root/BtnChangeAll/Text", typeof(Text), 0)]
		private Text changeAllText;

		// Token: 0x0400B65B RID: 46683
		[UIControl("Root/BtnChangeAll", typeof(Button), 0)]
		private Button btnChangeAll;

		// Token: 0x0400B65C RID: 46684
		[UIControl("Root/BtnChangeAll", typeof(UIGray), 0)]
		private UIGray grayChangeAll;

		// Token: 0x0400B65D RID: 46685
		private int iChangeAllValue;

		// Token: 0x0400B65E RID: 46686
		private IClientFrame m_openMenu;
	}
}
