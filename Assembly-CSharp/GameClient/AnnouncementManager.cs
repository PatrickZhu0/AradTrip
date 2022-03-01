using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011DE RID: 4574
	public class AnnouncementManager : DataManager<AnnouncementManager>
	{
		// Token: 0x0600AFF1 RID: 45041 RVA: 0x0026A3A1 File Offset: 0x002687A1
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600AFF2 RID: 45042 RVA: 0x0026A3A5 File Offset: 0x002687A5
		public override void Initialize()
		{
			this.Clear();
		}

		// Token: 0x0600AFF3 RID: 45043 RVA: 0x0026A3AD File Offset: 0x002687AD
		public override void Clear()
		{
			this.TimeInterval = 0.05f;
			this.Interval = 0f;
			this.ContentList.Clear();
		}

		// Token: 0x0600AFF4 RID: 45044 RVA: 0x0026A3D0 File Offset: 0x002687D0
		public void AnnounceFromServer(SysAnnouncement res)
		{
			AnnounceTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AnnounceTable>((int)res.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.ContentList.Count == 0)
			{
				this.Interval = this.TimeInterval + 0.01f;
			}
			AnnounceData item = default(AnnounceData);
			item.ID = (int)res.id;
			item.content = res.word;
			item.priority = tableItem.Priority;
			bool flag = false;
			for (int i = 0; i < this.ContentList.Count; i++)
			{
				if (this.ContentList[i].priority < item.priority)
				{
					this.ContentList.Insert(i, item);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.ContentList.Add(item);
			}
		}

		// Token: 0x0600AFF5 RID: 45045 RVA: 0x0026A4BC File Offset: 0x002688BC
		public void OnUpdate(float timeElapsed)
		{
			this.Interval += timeElapsed;
			if (this.Interval < this.TimeInterval)
			{
				return;
			}
			this.Interval = 0f;
			ClientSystemLogin clientSystemLogin = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemLogin;
			if (clientSystemLogin != null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AnnouncementFrame>(null, false);
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemTown == null && clientSystemBattle == null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AnnouncementFrame>(null, false);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen("AnnouncementFrame"))
			{
				return;
			}
			this.PlayStart();
		}

		// Token: 0x0600AFF6 RID: 45046 RVA: 0x0026A56C File Offset: 0x0026896C
		private void PlayStart()
		{
			if (this.ContentList.Count <= 0)
			{
				return;
			}
			object userData = this.ContentList[0];
			AnnouncementFrame announcementFrame;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FirstPayFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SecondPayFrame>(null))
			{
				announcementFrame = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<AnnouncementFrame>(FrameLayer.BelowMiddle, userData, string.Empty) as AnnouncementFrame);
			}
			else
			{
				announcementFrame = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<AnnouncementFrame>(FrameLayer.HorseLamp, userData, string.Empty) as AnnouncementFrame);
			}
			announcementFrame.ResPlayEnd = new AnnouncementFrame.PlayEnd(this.PlayEnd);
		}

		// Token: 0x0600AFF7 RID: 45047 RVA: 0x0026A614 File Offset: 0x00268A14
		private void PlayEnd()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AnnouncementFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AnnouncementFrame>(null, false);
				if (this.ContentList != null && this.ContentList.Count > 0)
				{
					this.ContentList.RemoveAt(0);
				}
				this.Interval = 0f;
			}
		}

		// Token: 0x0400626B RID: 25195
		private float TimeInterval = 0.08f;

		// Token: 0x0400626C RID: 25196
		private float Interval;

		// Token: 0x0400626D RID: 25197
		private List<AnnounceData> ContentList = new List<AnnounceData>();
	}
}
