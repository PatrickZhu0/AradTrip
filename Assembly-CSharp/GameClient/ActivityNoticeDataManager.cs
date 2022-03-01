using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011C6 RID: 4550
	public class ActivityNoticeDataManager : DataManager<ActivityNoticeDataManager>
	{
		// Token: 0x0600AEE9 RID: 44777 RVA: 0x00263B68 File Offset: 0x00261F68
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600AEEA RID: 44778 RVA: 0x00263B6C File Offset: 0x00261F6C
		public override void Initialize()
		{
			this.Clear();
			NetProcess.AddMsgHandler(501154U, new Action<MsgDATA>(this._OnAddNotify));
		}

		// Token: 0x0600AEEB RID: 44779 RVA: 0x00263B8A File Offset: 0x00261F8A
		public override void Clear()
		{
			this.m_arrNotices.Clear();
			NetProcess.RemoveMsgHandler(501154U, new Action<MsgDATA>(this._OnAddNotify));
		}

		// Token: 0x0600AEEC RID: 44780 RVA: 0x00263BB0 File Offset: 0x00261FB0
		public void AddActivityNotice(NotifyInfo a_info)
		{
			if (DeadLineReminderDataManager.IsDeadlineReminderType((NotifyType)a_info.type))
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.m_arrNotices.Count; i++)
			{
				if (this.m_arrNotices[i].type == a_info.type && this.m_arrNotices[i].param == a_info.param)
				{
					this.m_arrNotices[i] = a_info;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.m_arrNotices.Add(a_info);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityNoticeUpdate, null, null, null, null);
		}

		// Token: 0x0600AEED RID: 44781 RVA: 0x00263C60 File Offset: 0x00262060
		public void DeleteActivityNotice(NotifyInfo a_info)
		{
			for (int i = 0; i < this.m_arrNotices.Count; i++)
			{
				if (this.m_arrNotices[i].type == a_info.type && this.m_arrNotices[i].param == a_info.param)
				{
					this.m_arrNotices.RemoveAt(i);
					this._SendMsgRemoveNotice(a_info);
					break;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityNoticeUpdate, null, null, null, null);
		}

		// Token: 0x0600AEEE RID: 44782 RVA: 0x00263CEC File Offset: 0x002620EC
		public List<NotifyInfo> GetActivityNoticeDataList()
		{
			return this.m_arrNotices;
		}

		// Token: 0x0600AEEF RID: 44783 RVA: 0x00263CF4 File Offset: 0x002620F4
		private List<NotifyInfo> NoticesFilterByJarType()
		{
			List<NotifyInfo> list = new List<NotifyInfo>();
			if (this.m_arrNotices != null && list != null)
			{
				for (int i = 0; i < this.m_arrNotices.Count; i++)
				{
					NotifyInfo notifyInfo = this.m_arrNotices[i];
					if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.LIMITTIME_JAR))
					{
						if ((notifyInfo.type == 3U || notifyInfo.type == 4U) && list.Contains(notifyInfo))
						{
							list.Remove(notifyInfo);
						}
					}
					else
					{
						list.Add(notifyInfo);
					}
				}
			}
			return list;
		}

		// Token: 0x0600AEF0 RID: 44784 RVA: 0x00263D8C File Offset: 0x0026218C
		private void _OnAddNotify(MsgDATA msg)
		{
			SceneUpdateNotifyList sceneUpdateNotifyList = new SceneUpdateNotifyList();
			sceneUpdateNotifyList.decode(msg.bytes);
			this.AddActivityNotice(sceneUpdateNotifyList.notify);
		}

		// Token: 0x0600AEF1 RID: 44785 RVA: 0x00263DB8 File Offset: 0x002621B8
		private void _SendMsgRemoveNotice(NotifyInfo a_info)
		{
			if (a_info != null)
			{
				SceneDeleteNotifyList sceneDeleteNotifyList = new SceneDeleteNotifyList();
				sceneDeleteNotifyList.notify = a_info;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneDeleteNotifyList>(ServerType.GATE_SERVER, sceneDeleteNotifyList);
			}
		}

		// Token: 0x0600AEF2 RID: 44786 RVA: 0x00263DE8 File Offset: 0x002621E8
		private void _OnInitNotifyInfos(MsgDATA data)
		{
			SceneInitNotifyList sceneInitNotifyList = new SceneInitNotifyList();
			sceneInitNotifyList.decode(data.bytes);
			for (int i = 0; i < sceneInitNotifyList.notifys.Length; i++)
			{
				if (!DeadLineReminderDataManager.IsDeadlineReminderType((NotifyType)sceneInitNotifyList.notifys[i].type))
				{
					this.m_arrNotices.Add(sceneInitNotifyList.notifys[i]);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityNoticeUpdate, null, null, null, null);
		}

		// Token: 0x0600AEF3 RID: 44787 RVA: 0x00263E64 File Offset: 0x00262264
		public override void OnBindEnterGameMsg()
		{
			EnterGameBinding enterGameBinding = new EnterGameBinding();
			enterGameBinding.id = 501153U;
			try
			{
				enterGameBinding.method = new Action<MsgDATA>(this._OnInitNotifyInfos);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("错误!! 绑定消息{0}(ID:{1})到方法", new object[]
				{
					Singleton<ProtocolHelper>.instance.GetName(enterGameBinding.id),
					enterGameBinding.id
				});
			}
			this.m_arrEnterGameBindings.Add(enterGameBinding);
		}

		// Token: 0x040061C5 RID: 25029
		private List<NotifyInfo> m_arrNotices = new List<NotifyInfo>();
	}
}
