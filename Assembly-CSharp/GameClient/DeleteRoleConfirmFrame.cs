using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001166 RID: 4454
	internal class DeleteRoleConfirmFrame : ClientFrame
	{
		// Token: 0x0600AA38 RID: 43576 RVA: 0x002449BB File Offset: 0x00242DBB
		protected override void _bindExUI()
		{
			this.mTxtVerify = this.mBind.GetCom<Text>("txtVerify");
		}

		// Token: 0x0600AA39 RID: 43577 RVA: 0x002449D3 File Offset: 0x00242DD3
		protected override void _unbindExUI()
		{
			this.mTxtVerify = null;
		}

		// Token: 0x0600AA3A RID: 43578 RVA: 0x002449DC File Offset: 0x00242DDC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelecteRoleNew/DeleteRoleFrame";
		}

		// Token: 0x0600AA3B RID: 43579 RVA: 0x002449E4 File Offset: 0x00242DE4
		protected override void _OnOpenFrame()
		{
			this.verifyString = Random.Range(1000, 9999).ToString();
			if (this.mTxtVerify != null)
			{
				this.mTxtVerify.text = this.verifyString;
			}
			if (this.m_kInputField != null)
			{
				this.m_kInputField.keyboardType = 4;
			}
		}

		// Token: 0x0600AA3C RID: 43580 RVA: 0x00244A53 File Offset: 0x00242E53
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600AA3D RID: 43581 RVA: 0x00244A55 File Offset: 0x00242E55
		private bool CheckVerify()
		{
			if (!string.Equals(this.m_kInputField.text, this.verifyString))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("delete_verify_content_error"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			return true;
		}

		// Token: 0x0600AA3E RID: 43582 RVA: 0x00244A88 File Offset: 0x00242E88
		[UIEventHandle("Ok")]
		private void OnClickOk()
		{
			if (!this.CheckVerify())
			{
				return;
			}
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null)
			{
				GateDeleteRoleReq gateDeleteRoleReq = new GateDeleteRoleReq();
				gateDeleteRoleReq.roldId = CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId;
				int roleLevel = (int)CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.level;
				gateDeleteRoleReq.deviceId = DataManager<SecurityLockDataManager>.GetInstance().GetDeviceID();
				NetManager.Instance().SendCommand<GateDeleteRoleReq>(ServerType.GATE_SERVER, gateDeleteRoleReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<GateDeleteRoleRes>(delegate(GateDeleteRoleRes msgRet)
				{
					if (msgRet.result != 0U)
					{
						if (msgRet.result == 200020U)
						{
							SystemNotifyManager.SysNotifyTextAnimation(msgRet.roleUpdateLimit, CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						else if (msgRet.result == 3900005U)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountUnLock>(FrameLayer.Middle, null, string.Empty);
						}
						else
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshRolePreferenceCount, null, null, null, null);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleDeleteOk, msgRet.roleId, null, null, null);
						if (roleLevel <= 10)
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("delete_hint1"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						else
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("delete_hint2"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
				}, true, 15f, null);
			}
			this.frameMgr.CloseFrame<DeleteRoleConfirmFrame>(this, false);
		}

		// Token: 0x0600AA3F RID: 43583 RVA: 0x00244B42 File Offset: 0x00242F42
		[UIEventHandle("Cancel")]
		private void OnClickCancel()
		{
			this.frameMgr.CloseFrame<DeleteRoleConfirmFrame>(this, false);
		}

		// Token: 0x04005F65 RID: 24421
		private Text mTxtVerify;

		// Token: 0x04005F66 RID: 24422
		[UIControl("InputField", typeof(InputField), 0)]
		private InputField m_kInputField;

		// Token: 0x04005F67 RID: 24423
		private string verifyString;
	}
}
