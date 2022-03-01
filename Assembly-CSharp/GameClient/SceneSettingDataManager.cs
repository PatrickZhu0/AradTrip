using System;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020012D5 RID: 4821
	public class SceneSettingDataManager : DataManager<SceneSettingDataManager>
	{
		// Token: 0x0600BAFE RID: 47870 RVA: 0x002B461B File Offset: 0x002B2A1B
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600BAFF RID: 47871 RVA: 0x002B4623 File Offset: 0x002B2A23
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
		}

		// Token: 0x0600BB00 RID: 47872 RVA: 0x002B4631 File Offset: 0x002B2A31
		private void ClearData()
		{
		}

		// Token: 0x0600BB01 RID: 47873 RVA: 0x002B4633 File Offset: 0x002B2A33
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(501230U, new Action<MsgDATA>(this.OnReceiveSceneShortcutKeySetRes));
			NetProcess.AddMsgHandler(501231U, new Action<MsgDATA>(this.OnReceiveSceneShortcutKeySetSync));
		}

		// Token: 0x0600BB02 RID: 47874 RVA: 0x002B4661 File Offset: 0x002B2A61
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(501230U, new Action<MsgDATA>(this.OnReceiveSceneShortcutKeySetRes));
			NetProcess.RemoveMsgHandler(501231U, new Action<MsgDATA>(this.OnReceiveSceneShortcutKeySetSync));
		}

		// Token: 0x0600BB03 RID: 47875 RVA: 0x002B4690 File Offset: 0x002B2A90
		public void OnSendSceneShortcutKeySetReq(int type, string value)
		{
			ShortcutKeyInfo info = new ShortcutKeyInfo
			{
				setType = (uint)type,
				setValue = value
			};
			SceneShortcutKeySetReq cmd = new SceneShortcutKeySetReq
			{
				info = info
			};
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneShortcutKeySetReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BB04 RID: 47876 RVA: 0x002B46E0 File Offset: 0x002B2AE0
		public void OnReceiveSceneShortcutKeySetRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneShortcutKeySetRes sceneShortcutKeySetRes = new SceneShortcutKeySetRes();
			sceneShortcutKeySetRes.decode(msgData.bytes);
			if (sceneShortcutKeySetRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneShortcutKeySetRes.retCode, string.Empty);
				return;
			}
			if (sceneShortcutKeySetRes.info == null)
			{
				return;
			}
			ShortcutKeyInfo info = sceneShortcutKeySetRes.info;
			if (info.setType >= 1U && info.setType <= 9U)
			{
				int setType = (int)info.setType;
				DataManager<StorageDataManager>.GetInstance().UpdateRoleStorageSetNameByRoleStorageIndex(setType, info.setValue);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveRoleStorageChangeNameMessage, setType, null, null, null);
				CommonUtility.OnCloseCommonSetContentFrame();
			}
		}

		// Token: 0x0600BB05 RID: 47877 RVA: 0x002B4784 File Offset: 0x002B2B84
		public void OnReceiveSceneShortcutKeySetSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneShortcutKeySetSync sceneShortcutKeySetSync = new SceneShortcutKeySetSync();
			sceneShortcutKeySetSync.decode(msgData.bytes);
			if (sceneShortcutKeySetSync.infos == null || sceneShortcutKeySetSync.infos.Length <= 0)
			{
				return;
			}
			for (int i = 0; i < sceneShortcutKeySetSync.infos.Length; i++)
			{
				ShortcutKeyInfo shortcutKeyInfo = sceneShortcutKeySetSync.infos[i];
				if (shortcutKeyInfo != null)
				{
					if (shortcutKeyInfo.setType >= 1U && shortcutKeyInfo.setType <= 9U)
					{
						DataManager<StorageDataManager>.GetInstance().UpdateRoleStorageSetNameByRoleStorageIndex((int)shortcutKeyInfo.setType, shortcutKeyInfo.setValue);
					}
				}
			}
		}
	}
}
