using System;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012D7 RID: 4823
	internal class SecurityLockDataManager : DataManager<SecurityLockDataManager>
	{
		// Token: 0x0600BB07 RID: 47879 RVA: 0x002B4840 File Offset: 0x002B2C40
		public override void Initialize()
		{
			this.m_kSecurityLockData.lockState = SecurityLockState.SECURITY_STATE_UNLOCK;
			this.m_kSecurityLockData.isCommonDev = false;
			this.m_kSecurityLockData.freezeTime = 0U;
			this.m_kSecurityLockData.unFreezeTime = 0U;
			this.m_kSecurityLockData.bBindDevice = false;
			this.m_kSecurityLockData.isUseLock = false;
			this.m_kSecurityLockData.verifyPwdFailedCount = 0U;
			this.m_nApplyStateBtnClickedCount = 0U;
			this._BindNetMsg();
		}

		// Token: 0x0600BB08 RID: 47880 RVA: 0x002B48AE File Offset: 0x002B2CAE
		public override void Clear()
		{
			this.m_bNetBind = false;
			this._UnBindNetMsg();
		}

		// Token: 0x0600BB09 RID: 47881 RVA: 0x002B48BD File Offset: 0x002B2CBD
		public override void Update(float timeElapsed)
		{
		}

		// Token: 0x0600BB0A RID: 47882 RVA: 0x002B48BF File Offset: 0x002B2CBF
		public override void OnApplicationStart()
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kDataFileName, out this.m_kDeviceID);
			if (this.m_kDeviceID == null)
			{
				FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kDataFileName, string.Empty);
				this.m_kDeviceID = string.Empty;
				return;
			}
		}

		// Token: 0x0600BB0B RID: 47883 RVA: 0x002B48FC File Offset: 0x002B2CFC
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(608403U, new Action<MsgDATA>(this._OnWorldSecurityLockDataRes));
				NetProcess.AddMsgHandler(608405U, new Action<MsgDATA>(this._OnWorldSecurityLockOpRes));
				NetProcess.AddMsgHandler(608407U, new Action<MsgDATA>(this._OnWorldChangeSecurityPasswdRes));
				NetProcess.AddMsgHandler(608409U, new Action<MsgDATA>(this._OnWorldBindDeviceRes));
				NetProcess.AddMsgHandler(608410U, new Action<MsgDATA>(this._OnWorldSecurityLockForbidNotifyRes));
				NetProcess.AddMsgHandler(308402U, new Action<MsgDATA>(this._OnGateSecurityLockRemoveRes));
				NetProcess.AddMsgHandler(608411U, new Action<MsgDATA>(this._OnWorldSecurityLockPasswdErrorNum));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600BB0C RID: 47884 RVA: 0x002B49B8 File Offset: 0x002B2DB8
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(608403U, new Action<MsgDATA>(this._OnWorldSecurityLockDataRes));
			NetProcess.RemoveMsgHandler(608405U, new Action<MsgDATA>(this._OnWorldSecurityLockOpRes));
			NetProcess.RemoveMsgHandler(608407U, new Action<MsgDATA>(this._OnWorldChangeSecurityPasswdRes));
			NetProcess.RemoveMsgHandler(608409U, new Action<MsgDATA>(this._OnWorldBindDeviceRes));
			NetProcess.RemoveMsgHandler(608410U, new Action<MsgDATA>(this._OnWorldSecurityLockForbidNotifyRes));
			NetProcess.RemoveMsgHandler(308402U, new Action<MsgDATA>(this._OnGateSecurityLockRemoveRes));
			NetProcess.RemoveMsgHandler(608411U, new Action<MsgDATA>(this._OnWorldSecurityLockPasswdErrorNum));
			this.m_bNetBind = false;
		}

		// Token: 0x0600BB0D RID: 47885 RVA: 0x002B4A66 File Offset: 0x002B2E66
		public SecurityLockData GetSecurityLockData()
		{
			return this.m_kSecurityLockData;
		}

		// Token: 0x0600BB0E RID: 47886 RVA: 0x002B4A6E File Offset: 0x002B2E6E
		public string GetDeviceID()
		{
			return this.m_kDeviceID;
		}

		// Token: 0x17001B69 RID: 7017
		// (get) Token: 0x0600BB0F RID: 47887 RVA: 0x002B4A76 File Offset: 0x002B2E76
		// (set) Token: 0x0600BB10 RID: 47888 RVA: 0x002B4A7E File Offset: 0x002B2E7E
		public uint BtnClickedCount
		{
			get
			{
				return this.m_nApplyStateBtnClickedCount;
			}
			set
			{
				this.m_nApplyStateBtnClickedCount = value;
			}
		}

		// Token: 0x0600BB11 RID: 47889 RVA: 0x002B4A88 File Offset: 0x002B2E88
		public bool CheckSecurityLock(Func<bool> conditionFunc = null, Action UnLockAction = null)
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_SECURITY_LOCK))
			{
				return false;
			}
			SecurityLockState lockState = this.m_kSecurityLockData.lockState;
			if (lockState != SecurityLockState.SECURITY_STATE_LOCK && lockState != SecurityLockState.SECURITY_STATE_APPLY)
			{
				return false;
			}
			bool flag = true;
			if (conditionFunc != null)
			{
				flag = conditionFunc();
			}
			if (flag)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountUnLock>(FrameLayer.Middle, UnLockAction, string.Empty);
				return true;
			}
			return false;
		}

		// Token: 0x0600BB12 RID: 47890 RVA: 0x002B4AF0 File Offset: 0x002B2EF0
		public void SendWorldSecurityLockDataReq()
		{
			WorldSecurityLockDataReq worldSecurityLockDataReq = new WorldSecurityLockDataReq();
			worldSecurityLockDataReq.deviceID = this.m_kDeviceID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSecurityLockDataReq>(ServerType.GATE_SERVER, worldSecurityLockDataReq);
		}

		// Token: 0x0600BB13 RID: 47891 RVA: 0x002B4B20 File Offset: 0x002B2F20
		public void SendWorldSecurityLockOpReq(LockOpType opType, string passWord)
		{
			WorldSecurityLockOpReq worldSecurityLockOpReq = new WorldSecurityLockOpReq();
			worldSecurityLockOpReq.lockOpType = (uint)opType;
			worldSecurityLockOpReq.passwd = passWord;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSecurityLockOpReq>(ServerType.GATE_SERVER, worldSecurityLockOpReq);
		}

		// Token: 0x0600BB14 RID: 47892 RVA: 0x002B4B50 File Offset: 0x002B2F50
		public void SendWorldChangeSecurityPasswdReq(string oldPassword, string newPassword)
		{
			WorldChangeSecurityPasswdReq worldChangeSecurityPasswdReq = new WorldChangeSecurityPasswdReq();
			worldChangeSecurityPasswdReq.oldPasswd = oldPassword;
			worldChangeSecurityPasswdReq.newPasswd = newPassword;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldChangeSecurityPasswdReq>(ServerType.GATE_SERVER, worldChangeSecurityPasswdReq);
		}

		// Token: 0x0600BB15 RID: 47893 RVA: 0x002B4B80 File Offset: 0x002B2F80
		public void SendWorldBindDeviceReq(bool bBind)
		{
			WorldBindDeviceReq worldBindDeviceReq = new WorldBindDeviceReq();
			worldBindDeviceReq.bindType = ((!bBind) ? 0U : 1U);
			worldBindDeviceReq.deviceID = this.m_kDeviceID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldBindDeviceReq>(ServerType.GATE_SERVER, worldBindDeviceReq);
		}

		// Token: 0x0600BB16 RID: 47894 RVA: 0x002B4BC4 File Offset: 0x002B2FC4
		public void SendGateSecurityLockRemoveReq(string passWord)
		{
			GateSecurityLockRemoveReq gateSecurityLockRemoveReq = new GateSecurityLockRemoveReq();
			gateSecurityLockRemoveReq.passwd = passWord;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<GateSecurityLockRemoveReq>(ServerType.GATE_SERVER, gateSecurityLockRemoveReq);
		}

		// Token: 0x0600BB17 RID: 47895 RVA: 0x002B4BF0 File Offset: 0x002B2FF0
		private void _OnWorldSecurityLockDataRes(MsgDATA msg)
		{
			WorldSecurityLockDataRes worldSecurityLockDataRes = new WorldSecurityLockDataRes();
			worldSecurityLockDataRes.decode(msg.bytes);
			this.m_kSecurityLockData.lockState = (SecurityLockState)worldSecurityLockDataRes.lockState;
			this.m_kSecurityLockData.isCommonDev = (worldSecurityLockDataRes.isCommonDev > 0U);
			this.m_kSecurityLockData.freezeTime = worldSecurityLockDataRes.freezeTime;
			this.m_kSecurityLockData.unFreezeTime = worldSecurityLockDataRes.unFreezeTime;
			this.m_kSecurityLockData.isUseLock = (worldSecurityLockDataRes.isUseLock > 0U);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshSecurityLockDataUI, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SecurityLockApplyStateButton, null, null, null, null);
		}

		// Token: 0x0600BB18 RID: 47896 RVA: 0x002B4C90 File Offset: 0x002B3090
		private void _OnWorldSecurityLockOpRes(MsgDATA msg)
		{
			WorldSecurityLockOpRes worldSecurityLockOpRes = new WorldSecurityLockOpRes();
			worldSecurityLockOpRes.decode(msg.bytes);
			if (worldSecurityLockOpRes.ret != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSecurityLockOpRes.ret, string.Empty);
				return;
			}
			this.m_kSecurityLockData.lockState = (SecurityLockState)worldSecurityLockOpRes.lockState;
			this.m_kSecurityLockData.freezeTime = worldSecurityLockOpRes.freezeTime;
			this.m_kSecurityLockData.unFreezeTime = worldSecurityLockOpRes.unFreezeTime;
			if (worldSecurityLockOpRes.lockOpType == 1U)
			{
				if (this.m_kSecurityLockData.isUseLock)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("安全锁上锁成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect("安全锁密码设置成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountLock>(null, false);
			}
			if (worldSecurityLockOpRes.lockOpType == 2U)
			{
				this.m_kSecurityLockData.isUseLock = true;
				SystemNotifyManager.SysNotifyFloatingEffect("安全锁解锁成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountUnLock>(null, false);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshSecurityLockDataUI, null, null, null, null);
		}

		// Token: 0x0600BB19 RID: 47897 RVA: 0x002B4D88 File Offset: 0x002B3188
		private void _OnWorldChangeSecurityPasswdRes(MsgDATA msg)
		{
			WorldChangeSecurityPasswdRes worldChangeSecurityPasswdRes = new WorldChangeSecurityPasswdRes();
			worldChangeSecurityPasswdRes.decode(msg.bytes);
			if (worldChangeSecurityPasswdRes.ret == 0U)
			{
				this.m_kSecurityLockData.isCommonDev = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshSecurityLockDataUI, null, null, null, null);
				SystemNotifyManager.SysNotifyFloatingEffect("密码修改成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountLockChangePwd>(null, false);
				return;
			}
			if (worldChangeSecurityPasswdRes.ret == 3900007U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("原密码输入错误，本日错误次数：{0}/5", worldChangeSecurityPasswdRes.errNum), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			SystemNotifyManager.SystemNotify((int)worldChangeSecurityPasswdRes.ret, string.Empty);
		}

		// Token: 0x0600BB1A RID: 47898 RVA: 0x002B4E28 File Offset: 0x002B3228
		private void _OnWorldBindDeviceRes(MsgDATA msg)
		{
			WorldBindDeviceRes worldBindDeviceRes = new WorldBindDeviceRes();
			worldBindDeviceRes.decode(msg.bytes);
			if (worldBindDeviceRes.ret != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldBindDeviceRes.ret, string.Empty);
				return;
			}
			bool bBindDevice = this.m_kSecurityLockData.bBindDevice;
			this.m_kSecurityLockData.bBindDevice = (worldBindDeviceRes.bindState > 0U);
			if (this.m_kSecurityLockData.bBindDevice)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("绑定成功，下次登陆开始生效", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountLockBindDevice>(null, false);
			}
			else if (!this.m_kSecurityLockData.bBindDevice)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("设备解绑成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			if (this.m_kSecurityLockData.bBindDevice)
			{
				this.m_kDeviceID = worldBindDeviceRes.deviceID;
				this.m_kSecurityLockData.isCommonDev = true;
				try
				{
					if (!string.IsNullOrEmpty(this.m_kDeviceID))
					{
						FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kDataFileName, this.m_kDeviceID);
					}
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
				}
			}
			else
			{
				this.m_kSecurityLockData.isCommonDev = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshSecurityLockDataUI, null, null, null, null);
		}

		// Token: 0x0600BB1B RID: 47899 RVA: 0x002B4F60 File Offset: 0x002B3360
		private void _OnWorldSecurityLockForbidNotifyRes(MsgDATA msg)
		{
			WorldSecurityLockForbidNotify stream = new WorldSecurityLockForbidNotify();
			stream.decode(msg.bytes);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountUnLock>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BB1C RID: 47900 RVA: 0x002B4F94 File Offset: 0x002B3394
		private void _OnGateSecurityLockRemoveRes(MsgDATA msg)
		{
			GateSecurityLockRemoveRes gateSecurityLockRemoveRes = new GateSecurityLockRemoveRes();
			gateSecurityLockRemoveRes.decode(msg.bytes);
			if (gateSecurityLockRemoveRes.ret != 0U)
			{
				SystemNotifyManager.SystemNotify((int)gateSecurityLockRemoveRes.ret, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("安全锁解锁成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountUnLock>(null, false);
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null)
			{
				GateDeleteRoleReq gateDeleteRoleReq = new GateDeleteRoleReq();
				gateDeleteRoleReq.roldId = CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId;
				int level = (int)CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.level;
				gateDeleteRoleReq.deviceId = DataManager<SecurityLockDataManager>.GetInstance().GetDeviceID();
				NetManager.Instance().SendCommand<GateDeleteRoleReq>(ServerType.GATE_SERVER, gateDeleteRoleReq);
			}
		}

		// Token: 0x0600BB1D RID: 47901 RVA: 0x002B5054 File Offset: 0x002B3454
		private void _OnWorldSecurityLockPasswdErrorNum(MsgDATA msg)
		{
			WorldSecurityLockPasswdErrorNum worldSecurityLockPasswdErrorNum = new WorldSecurityLockPasswdErrorNum();
			worldSecurityLockPasswdErrorNum.decode(msg.bytes);
			this.m_kSecurityLockData.verifyPwdFailedCount = worldSecurityLockPasswdErrorNum.error_num;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshVerifyPwdErrorCount, null, null, null, null);
		}

		// Token: 0x0400692A RID: 26922
		private bool m_bNetBind;

		// Token: 0x0400692B RID: 26923
		private string m_kDataFileName = "BindDevice.dat";

		// Token: 0x0400692C RID: 26924
		private string m_kDeviceID = string.Empty;

		// Token: 0x0400692D RID: 26925
		private uint m_nApplyStateBtnClickedCount;

		// Token: 0x0400692E RID: 26926
		private SecurityLockData m_kSecurityLockData;

		// Token: 0x0400692F RID: 26927
		public static int nPwdMinLength = 4;

		// Token: 0x04006930 RID: 26928
		public static int nPwdMaxLength = 8;
	}
}
