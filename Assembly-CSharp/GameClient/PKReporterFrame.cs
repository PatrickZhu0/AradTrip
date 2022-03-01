using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200198D RID: 6541
	public class PKReporterFrame : ClientFrame
	{
		// Token: 0x0600FE98 RID: 65176 RVA: 0x00466FCE File Offset: 0x004653CE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKReporter";
		}

		// Token: 0x0600FE99 RID: 65177 RVA: 0x00466FD8 File Offset: 0x004653D8
		protected override void _OnOpenFrame()
		{
			this.mSelectType = 0;
			VideoInfo videoInfo = this.userData as VideoInfo;
			if (videoInfo != null)
			{
				this.isInBattle = videoInfo.isInBattle;
				this.m_SessionId = videoInfo.sessionId;
			}
			int num = 0;
			if (this.mFileDescript != null)
			{
				if (Singleton<RecordServer>.GetInstance() != null)
				{
					if (string.IsNullOrEmpty(this.m_SessionId))
					{
						num = Singleton<RecordServer>.GetInstance().GetCurrentRecordSize();
					}
					else
					{
						num = Singleton<RecordServer>.GetInstance().GetPkRecordSize(this.m_SessionId);
					}
				}
				if (this.isInBattle)
				{
					this.mFileDescript.text = string.Empty;
				}
				else
				{
					this.mFileDescript.text = string.Format("(录像文件:{0:N1}K)", (float)num / 1024f);
				}
			}
		}

		// Token: 0x0600FE9A RID: 65178 RVA: 0x004670A8 File Offset: 0x004654A8
		[UIEventHandle("middle/btUpload")]
		private void _OnConfirmClicked()
		{
			if (this.mSelectType == -1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("请选择反馈类型", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.m_inputField != null && this.m_inputField.text.Length <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("请描述录像问题原因", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<RecordServer>.GetInstance() != null)
			{
				if (this.isInBattle)
				{
					string empty = string.Empty;
					if (!Singleton<RecordServer>.GetInstance().EndRecordInBattle(ref empty, this.mSelectType, (!(this.m_inputField != null)) ? string.Empty : this.m_inputField.text))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(string.Format("上传文件出错 原因:{0}", empty), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUploadFileSucc, this.userData, null, null, null);
						SystemNotifyManager.SysNotifyFloatingEffect("上传成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					this.frameMgr.CloseFrame<PKReporterFrame>(this, false);
					return;
				}
				if (string.IsNullOrEmpty(this.m_SessionId))
				{
					string empty2 = string.Empty;
					if (!Singleton<RecordServer>.GetInstance().UpLoadCurrentRecordFile(ref empty2, this.mSelectType, (!(this.m_inputField != null)) ? string.Empty : this.m_inputField.text))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(string.Format("上传文件出错 原因:{0}", empty2), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUploadFileSucc, null, null, null, null);
						SystemNotifyManager.SysNotifyFloatingEffect("上传成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
				else
				{
					string empty3 = string.Empty;
					if (!Singleton<RecordServer>.GetInstance().UpLoadRecordFile(this.m_SessionId, ref empty3, this.mSelectType, (!(this.m_inputField != null)) ? string.Empty : this.m_inputField.text))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(string.Format("上传文件出错 原因:{0}", empty3), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUploadFileSucc, this.userData, null, null, null);
						SystemNotifyManager.SysNotifyFloatingEffect("上传成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect("系统出错无法上传", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.frameMgr.CloseFrame<PKReporterFrame>(this, false);
		}

		// Token: 0x0600FE9B RID: 65179 RVA: 0x004672D3 File Offset: 0x004656D3
		[UIEventHandle("middle/btClose")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<PKReporterFrame>(this, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUploadFileClose, null, null, null, null);
		}

		// Token: 0x0600FE9C RID: 65180 RVA: 0x004672F5 File Offset: 0x004656F5
		[UIEventHandle("middle/Panel/cbType{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnChangeType(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				this.mSelectType = -1;
				return;
			}
			this.mSelectType = iIndex;
		}

		// Token: 0x0400A092 RID: 41106
		private int mSelectType;

		// Token: 0x0400A093 RID: 41107
		[UIControl("middle/labFileSize", typeof(Text), 0)]
		private Text mFileDescript;

		// Token: 0x0400A094 RID: 41108
		private StateController comState;

		// Token: 0x0400A095 RID: 41109
		[UIControl("middle/InputField", typeof(InputField), 0)]
		private InputField m_inputField;

		// Token: 0x0400A096 RID: 41110
		private string m_SessionId = string.Empty;

		// Token: 0x0400A097 RID: 41111
		private bool isInBattle;
	}
}
