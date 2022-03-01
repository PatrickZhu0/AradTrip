using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019AB RID: 6571
	public class Pk3v3RoomSettingFrame : ClientFrame
	{
		// Token: 0x06010072 RID: 65650 RVA: 0x00471F92 File Offset: 0x00470392
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3RoomSettingFrame";
		}

		// Token: 0x06010073 RID: 65651 RVA: 0x00471F99 File Offset: 0x00470399
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x06010074 RID: 65652 RVA: 0x00471FA7 File Offset: 0x004703A7
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x06010075 RID: 65653 RVA: 0x00471FB5 File Offset: 0x004703B5
		private void ClearData()
		{
			this.RoomName = string.Empty;
			this.MinLv = 0;
			this.MinRankLv = 0;
			this.bSetMinLv = false;
			this.bSetMinRankLv = false;
		}

		// Token: 0x06010076 RID: 65654 RVA: 0x00471FDE File Offset: 0x004703DE
		protected void BindUIEvent()
		{
			this.mRoomName.onValueChanged.AddListener(new UnityAction<string>(this.OnRoomNameInputEnd));
		}

		// Token: 0x06010077 RID: 65655 RVA: 0x00471FFC File Offset: 0x004703FC
		protected void UnBindUIEvent()
		{
			this.mRoomName.onValueChanged.RemoveListener(new UnityAction<string>(this.OnRoomNameInputEnd));
		}

		// Token: 0x06010078 RID: 65656 RVA: 0x0047201A File Offset: 0x0047041A
		private void OnRoomNameInputEnd(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return;
			}
			this.RoomName = name;
		}

		// Token: 0x06010079 RID: 65657 RVA: 0x00472030 File Offset: 0x00470430
		[UIEventHandle("middle/Levelselect/LevelList/Level{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 6)]
		private void OnSwitchRankLvType(int iIndex, bool value)
		{
			if (!this.bSetMinRankLv)
			{
				this.mRankLvListObj.CustomActive(false);
				return;
			}
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.MinRankLv = DataManager<Pk3v3DataManager>.GetInstance().GetRankLvByIndex(iIndex);
			this.mRankText.text = DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName(this.MinRankLv);
			this.mRankLvListObj.CustomActive(false);
			this.mDownGo.CustomActive(false);
			this.mUpGo.CustomActive(true);
		}

		// Token: 0x0601007A RID: 65658 RVA: 0x004720B4 File Offset: 0x004704B4
		private void InitInterface()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null || roomInfo.roomSimpleInfo == null)
			{
				Logger.LogError("roomInfo is null in pk3v3RoomSettingFrame");
				return;
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!DataManager<Pk3v3DataManager>.GetInstance().RoomSettingData.TryGetValue((RoomType)roomInfo.roomSimpleInfo.roomType, out pk3v3RoomSettingData))
			{
				Logger.LogError("RoomSettingData is null in pk3v3RoomSettingFrame");
				return;
			}
			this.mRoomNum.text = roomInfo.roomSimpleInfo.id.ToString();
			this.mRoomName.text = roomInfo.roomSimpleInfo.name;
			this.mPasswordSet.isOn = (roomInfo.roomSimpleInfo.isPassword > 0);
			this.mPassword.text = DataManager<Pk3v3DataManager>.GetInstance().PassWord;
			this.mMinLvSet.isOn = (roomInfo.roomSimpleInfo.isLimitPlayerLevel > 0);
			this.MinLv = (int)roomInfo.roomSimpleInfo.limitPlayerLevel;
			this.mMinLvText.text = this.MinLv.ToString();
			this.mMinRankSet.isOn = (roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel > 0);
			this.MinRankLv = (int)roomInfo.roomSimpleInfo.limitPlayerSeasonLevel;
			this.mRankText.text = DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName(this.MinRankLv);
			if (roomInfo.roomSimpleInfo.isLimitPlayerLevel == 0)
			{
				this.mDefaultLevel.CustomActive(true);
			}
			else if (roomInfo.roomSimpleInfo.isLimitPlayerLevel == 1)
			{
				this.mDefaultLevel.CustomActive(false);
			}
			if (roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel == 0)
			{
				this.mDefaultSeasonLevel.CustomActive(true);
			}
			else if (roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel == 1)
			{
				this.mDefaultSeasonLevel.CustomActive(false);
			}
		}

		// Token: 0x0601007B RID: 65659 RVA: 0x00472284 File Offset: 0x00470684
		private void _changeLevelSelect(bool isOpen)
		{
			this.mUpGo.CustomActive(isOpen);
			RectTransform component = this.mRankText.gameObject.GetComponent<RectTransform>();
			if (component == null)
			{
				return;
			}
			if (isOpen)
			{
				component.anchoredPosition = new Vector2(-54f, 0f);
			}
			else
			{
				component.anchoredPosition = new Vector2(0f, 0f);
			}
		}

		// Token: 0x0601007C RID: 65660 RVA: 0x004722F0 File Offset: 0x004706F0
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtOK = this.mBind.GetCom<Button>("btOK");
			this.mBtOK.onClick.AddListener(new UnityAction(this._onBtOKButtonClick));
			this.mRoomNum = this.mBind.GetCom<Text>("RoomNum");
			this.mPassword = this.mBind.GetCom<InputField>("Password");
			this.mPasswordSet = this.mBind.GetCom<Toggle>("PasswordSet");
			this.mPasswordSet.onValueChanged.AddListener(new UnityAction<bool>(this._onPasswordSetToggleValueChange));
			this.mMinLvSet = this.mBind.GetCom<Toggle>("MinLvSet");
			this.mMinLvSet.onValueChanged.AddListener(new UnityAction<bool>(this._onMinLvSetToggleValueChange));
			this.mReduce = this.mBind.GetCom<Button>("Reduce");
			this.mReduce.onClick.AddListener(new UnityAction(this._onReduceButtonClick));
			this.mAdd = this.mBind.GetCom<Button>("Add");
			this.mAdd.onClick.AddListener(new UnityAction(this._onAddButtonClick));
			this.mMinRankSet = this.mBind.GetCom<Toggle>("MinRank");
			this.mMinRankSet.onValueChanged.AddListener(new UnityAction<bool>(this._onMinRankSetToggleValueChange));
			this.mBtRankSel = this.mBind.GetCom<Button>("btRankSel");
			this.mBtRankSel.onClick.AddListener(new UnityAction(this._onBtRankSelButtonClick));
			this.mRoomName = this.mBind.GetCom<InputField>("RoomName");
			this.mMinLvText = this.mBind.GetCom<Text>("MinLvText");
			this.mRankText = this.mBind.GetCom<Text>("RankText");
			this.mRankLvListObj = this.mBind.GetGameObject("RankLvListObj");
			this.mUpGo = this.mBind.GetGameObject("upGo");
			this.mDownGo = this.mBind.GetGameObject("downGo");
			this.mCloseLevelList = this.mBind.GetCom<Button>("CloseLevelList");
			this.mCloseLevelList.onClick.AddListener(new UnityAction(this._OnCloseLevelListClick));
			this.mDefaultPassword = this.mBind.GetGameObject("DefaultPassword");
			this.mDefaultLevel = this.mBind.GetGameObject("DefaultLevel");
			this.mDefaultSeasonLevel = this.mBind.GetGameObject("DefaultSeasonLevel");
		}

		// Token: 0x0601007D RID: 65661 RVA: 0x004725B4 File Offset: 0x004709B4
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtOK.onClick.RemoveListener(new UnityAction(this._onBtOKButtonClick));
			this.mBtOK = null;
			this.mRoomNum = null;
			this.mPassword = null;
			this.mPasswordSet.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPasswordSetToggleValueChange));
			this.mPasswordSet = null;
			this.mMinLvSet.onValueChanged.RemoveListener(new UnityAction<bool>(this._onMinLvSetToggleValueChange));
			this.mMinLvSet = null;
			this.mReduce.onClick.RemoveListener(new UnityAction(this._onReduceButtonClick));
			this.mReduce = null;
			this.mAdd.onClick.RemoveListener(new UnityAction(this._onAddButtonClick));
			this.mAdd = null;
			this.mMinRankSet.onValueChanged.RemoveListener(new UnityAction<bool>(this._onMinRankSetToggleValueChange));
			this.mMinRankSet = null;
			this.mBtRankSel.onClick.RemoveListener(new UnityAction(this._onBtRankSelButtonClick));
			this.mBtRankSel = null;
			this.mRoomName = null;
			this.mMinLvText = null;
			this.mRankText = null;
			this.mRankLvListObj = null;
			this.mUpGo = null;
			this.mDownGo = null;
			this.mCloseLevelList.onClick.RemoveListener(new UnityAction(this._OnCloseLevelListClick));
			this.mCloseLevelList = null;
			this.mDefaultPassword = null;
			this.mDefaultLevel = null;
			this.mDefaultSeasonLevel = null;
		}

		// Token: 0x0601007E RID: 65662 RVA: 0x00472749 File Offset: 0x00470B49
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3RoomSettingFrame>(this, false);
		}

		// Token: 0x0601007F RID: 65663 RVA: 0x00472758 File Offset: 0x00470B58
		private void _OnCloseLevelListClick()
		{
			this.mRankLvListObj.CustomActive(false);
			this.mDownGo.CustomActive(false);
			this.mUpGo.CustomActive(true);
		}

		// Token: 0x06010080 RID: 65664 RVA: 0x00472780 File Offset: 0x00470B80
		private void _onBtOKButtonClick()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null when save room setting data.");
				return;
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!DataManager<Pk3v3DataManager>.GetInstance().RoomSettingData.TryGetValue((RoomType)roomInfo.roomSimpleInfo.roomType, out pk3v3RoomSettingData))
			{
				Logger.LogErrorFormat("RoomSettingData is null when TryGetValue : {0}", new object[]
				{
					(RoomType)roomInfo.roomSimpleInfo.roomType
				});
				return;
			}
			WorldUpdateRoomReq worldUpdateRoomReq = new WorldUpdateRoomReq();
			worldUpdateRoomReq.roomId = roomInfo.roomSimpleInfo.id;
			worldUpdateRoomReq.roomType = roomInfo.roomSimpleInfo.roomType;
			worldUpdateRoomReq.name = roomInfo.roomSimpleInfo.name;
			worldUpdateRoomReq.password = DataManager<Pk3v3DataManager>.GetInstance().PassWord;
			worldUpdateRoomReq.isLimitPlayerLevel = roomInfo.roomSimpleInfo.isLimitPlayerLevel;
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel;
			worldUpdateRoomReq.limitPlayerLevel = roomInfo.roomSimpleInfo.limitPlayerLevel;
			worldUpdateRoomReq.limitPlayerSeasonLevel = roomInfo.roomSimpleInfo.limitPlayerSeasonLevel;
			bool flag = false;
			if (this.RoomName != string.Empty && this.RoomName != roomInfo.roomSimpleInfo.name)
			{
				worldUpdateRoomReq.name = this.RoomName;
				flag = true;
			}
			if (this.mPassword.text != DataManager<Pk3v3DataManager>.GetInstance().PassWord)
			{
				worldUpdateRoomReq.password = this.mPassword.text;
				flag = true;
				DataManager<Pk3v3DataManager>.GetInstance().bHasPassword = (this.mPassword.text != string.Empty);
				DataManager<Pk3v3DataManager>.GetInstance().PassWord = this.mPassword.text;
			}
			bool flag2 = roomInfo.roomSimpleInfo.isLimitPlayerLevel > 0;
			if (this.bSetMinLv != flag2)
			{
				if (this.bSetMinLv)
				{
					worldUpdateRoomReq.isLimitPlayerLevel = 1;
				}
				else
				{
					worldUpdateRoomReq.isLimitPlayerLevel = 0;
				}
				flag = true;
				pk3v3RoomSettingData.bSetMinLv = this.bSetMinLv;
				PlayerLocalSetting.SetValue(DataManager<Pk3v3DataManager>.GetInstance().GetPk3v3LocalDataKey((RoomType)roomInfo.roomSimpleInfo.roomType, "bSetMinLv"), this.bSetMinLv.ToString());
			}
			bool flag3 = roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel > 0;
			if (this.bSetMinRankLv != flag3)
			{
				if (this.bSetMinRankLv)
				{
					worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
				}
				else
				{
					worldUpdateRoomReq.isLimitPlayerSeasonLevel = 0;
				}
				flag = true;
				pk3v3RoomSettingData.bSetMinRankLv = this.bSetMinRankLv;
				PlayerLocalSetting.SetValue(DataManager<Pk3v3DataManager>.GetInstance().GetPk3v3LocalDataKey((RoomType)roomInfo.roomSimpleInfo.roomType, "bSetMinRankLv"), this.bSetMinRankLv.ToString());
			}
			if (this.MinLv != (int)roomInfo.roomSimpleInfo.limitPlayerLevel)
			{
				worldUpdateRoomReq.limitPlayerLevel = (ushort)this.MinLv;
				flag = true;
				pk3v3RoomSettingData.MinLv = this.MinLv;
				PlayerLocalSetting.SetValue(DataManager<Pk3v3DataManager>.GetInstance().GetPk3v3LocalDataKey((RoomType)roomInfo.roomSimpleInfo.roomType, "MinLv"), this.MinLv.ToString());
			}
			if ((long)this.MinRankLv != (long)((ulong)roomInfo.roomSimpleInfo.limitPlayerSeasonLevel))
			{
				worldUpdateRoomReq.limitPlayerSeasonLevel = (uint)this.MinRankLv;
				flag = true;
				pk3v3RoomSettingData.MinRankLv = this.MinRankLv;
				PlayerLocalSetting.SetValue(DataManager<Pk3v3DataManager>.GetInstance().GetPk3v3LocalDataKey((RoomType)roomInfo.roomSimpleInfo.roomType, "MinRankLv"), this.MinRankLv.ToString());
			}
			if (flag)
			{
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldUpdateRoomReq>(ServerType.GATE_SERVER, worldUpdateRoomReq);
			}
			PlayerLocalSetting.SaveConfig();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Set3v3RoomName, this.mRoomName.text, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Set3v3RoomPassword, null, null, null, null);
			this.frameMgr.CloseFrame<Pk3v3RoomSettingFrame>(this, false);
		}

		// Token: 0x06010081 RID: 65665 RVA: 0x00472B34 File Offset: 0x00470F34
		private void _onPasswordSetToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.mPassword.text = DataManager<Pk3v3DataManager>.GetInstance().RandPassWord().ToString();
				this.mDefaultPassword.CustomActive(false);
			}
			else
			{
				this.mDefaultPassword.CustomActive(true);
				this.mPassword.text = string.Empty;
			}
		}

		// Token: 0x06010082 RID: 65666 RVA: 0x00472B98 File Offset: 0x00470F98
		private void _onMinLvSetToggleValueChange(bool changed)
		{
			this.bSetMinLv = changed;
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (this.bSetMinLv)
			{
				this.mDefaultLevel.CustomActive(false);
				this.MinLv = (int)roomInfo.roomSimpleInfo.limitPlayerLevel;
			}
			else
			{
				this.mDefaultLevel.CustomActive(true);
				this.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
			}
			this.mMinLvText.text = this.MinLv.ToString();
		}

		// Token: 0x06010083 RID: 65667 RVA: 0x00472C18 File Offset: 0x00471018
		private void _onReduceButtonClick()
		{
			if (!this.bSetMinLv)
			{
				return;
			}
			if (this.MinLv <= Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel))
			{
				return;
			}
			this.MinLv -= 5;
			this.mMinLvText.text = this.MinLv.ToString();
		}

		// Token: 0x06010084 RID: 65668 RVA: 0x00472C70 File Offset: 0x00471070
		private void _onAddButtonClick()
		{
			if (!this.bSetMinLv)
			{
				return;
			}
			if (this.MinLv >= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv)
			{
				return;
			}
			this.MinLv += 5;
			this.mMinLvText.text = this.MinLv.ToString();
		}

		// Token: 0x06010085 RID: 65669 RVA: 0x00472CCC File Offset: 0x004710CC
		private void _onMinRankSetToggleValueChange(bool changed)
		{
			this.bSetMinRankLv = changed;
			this._changeLevelSelect(changed);
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (this.bSetMinRankLv)
			{
				this.mDefaultSeasonLevel.CustomActive(false);
				this.MinRankLv = (int)roomInfo.roomSimpleInfo.limitPlayerSeasonLevel;
			}
			else
			{
				this.mDefaultSeasonLevel.CustomActive(true);
				this.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
			}
			this.mRankText.text = DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName(this.MinRankLv);
		}

		// Token: 0x06010086 RID: 65670 RVA: 0x00472D58 File Offset: 0x00471158
		private void _onBtRankSelButtonClick()
		{
			if (this.bSetMinRankLv)
			{
				this.mRankLvListObj.CustomActive(!this.mRankLvListObj.activeSelf);
				this.mUpGo.CustomActive(!this.mRankLvListObj.activeSelf);
				this.mDownGo.CustomActive(this.mRankLvListObj.activeSelf);
			}
		}

		// Token: 0x0400A1BC RID: 41404
		private const int RankTypeNum = 6;

		// Token: 0x0400A1BD RID: 41405
		private string RoomName = string.Empty;

		// Token: 0x0400A1BE RID: 41406
		private int MinLv;

		// Token: 0x0400A1BF RID: 41407
		private int MinRankLv;

		// Token: 0x0400A1C0 RID: 41408
		private bool bSetMinLv;

		// Token: 0x0400A1C1 RID: 41409
		private bool bSetMinRankLv;

		// Token: 0x0400A1C2 RID: 41410
		private Button mBtClose;

		// Token: 0x0400A1C3 RID: 41411
		private Button mBtOK;

		// Token: 0x0400A1C4 RID: 41412
		private Text mRoomNum;

		// Token: 0x0400A1C5 RID: 41413
		private InputField mPassword;

		// Token: 0x0400A1C6 RID: 41414
		private Toggle mPasswordSet;

		// Token: 0x0400A1C7 RID: 41415
		private Toggle mMinLvSet;

		// Token: 0x0400A1C8 RID: 41416
		private Button mReduce;

		// Token: 0x0400A1C9 RID: 41417
		private Button mAdd;

		// Token: 0x0400A1CA RID: 41418
		private Toggle mMinRankSet;

		// Token: 0x0400A1CB RID: 41419
		private Button mBtRankSel;

		// Token: 0x0400A1CC RID: 41420
		private InputField mRoomName;

		// Token: 0x0400A1CD RID: 41421
		private Text mMinLvText;

		// Token: 0x0400A1CE RID: 41422
		private Text mRankText;

		// Token: 0x0400A1CF RID: 41423
		private GameObject mRankLvListObj;

		// Token: 0x0400A1D0 RID: 41424
		private GameObject mUpGo;

		// Token: 0x0400A1D1 RID: 41425
		private GameObject mDownGo;

		// Token: 0x0400A1D2 RID: 41426
		private Button mCloseLevelList;

		// Token: 0x0400A1D3 RID: 41427
		private GameObject mDefaultPassword;

		// Token: 0x0400A1D4 RID: 41428
		private GameObject mDefaultLevel;

		// Token: 0x0400A1D5 RID: 41429
		private GameObject mDefaultSeasonLevel;
	}
}
