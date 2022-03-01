using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001185 RID: 4485
	public class BeBaseActorData
	{
		// Token: 0x0600ABA2 RID: 43938 RVA: 0x00238268 File Offset: 0x00236668
		public BeBaseActorData()
		{
			this.AniNames[0] = ActorActionType.AT_IDLE.GetDescription(true);
			this.AniNames[1] = ActorActionType.AT_WALK.GetDescription(true);
			this.AniNames[2] = ActorActionType.AT_RUN.GetDescription(true);
		}

		// Token: 0x17001A46 RID: 6726
		// (get) Token: 0x0600ABA3 RID: 43939 RVA: 0x002382E4 File Offset: 0x002366E4
		// (set) Token: 0x0600ABA4 RID: 43940 RVA: 0x002382EC File Offset: 0x002366EC
		public ulong GUID { get; set; }

		// Token: 0x17001A47 RID: 6727
		// (get) Token: 0x0600ABA5 RID: 43941 RVA: 0x002382F5 File Offset: 0x002366F5
		// (set) Token: 0x0600ABA6 RID: 43942 RVA: 0x002382FD File Offset: 0x002366FD
		public float Scale { get; set; }

		// Token: 0x17001A48 RID: 6728
		// (get) Token: 0x0600ABA7 RID: 43943 RVA: 0x00238306 File Offset: 0x00236706
		// (set) Token: 0x0600ABA8 RID: 43944 RVA: 0x0023830E File Offset: 0x0023670E
		public virtual string Name { get; set; }

		// Token: 0x17001A49 RID: 6729
		// (get) Token: 0x0600ABA9 RID: 43945 RVA: 0x00238317 File Offset: 0x00236717
		// (set) Token: 0x0600ABAA RID: 43946 RVA: 0x0023831F File Offset: 0x0023671F
		public PlayerInfoColor NameColor { get; set; }

		// Token: 0x17001A4A RID: 6730
		// (get) Token: 0x0600ABAB RID: 43947 RVA: 0x00238328 File Offset: 0x00236728
		public ActorMoveData MoveData
		{
			get
			{
				return this._moveData;
			}
		}

		// Token: 0x17001A4B RID: 6731
		// (get) Token: 0x0600ABAC RID: 43948 RVA: 0x00238330 File Offset: 0x00236730
		public ActionPlayData ActionData
		{
			get
			{
				return this._actionPlayData;
			}
		}

		// Token: 0x17001A4C RID: 6732
		// (get) Token: 0x0600ABAD RID: 43949 RVA: 0x00238338 File Offset: 0x00236738
		public List<AttachmentPlayData> arrAttachmentData
		{
			get
			{
				return this.m_arrAttachmentPlayData;
			}
		}

		// Token: 0x0600ABAE RID: 43950 RVA: 0x00238340 File Offset: 0x00236740
		public void SetAttachmentVisible(string a_strAttachment, bool a_bVisible)
		{
			for (int i = 0; i < this.arrAttachmentData.Count; i++)
			{
				if (this.arrAttachmentData[i].attachmentName == a_strAttachment)
				{
					this.arrAttachmentData[i].visible = a_bVisible;
					return;
				}
			}
			AttachmentPlayData attachmentPlayData = new AttachmentPlayData();
			attachmentPlayData.attachmentName = a_strAttachment;
			attachmentPlayData.visible = a_bVisible;
			this.arrAttachmentData.Add(attachmentPlayData);
		}

		// Token: 0x0600ABAF RID: 43951 RVA: 0x002383B8 File Offset: 0x002367B8
		public void PlayAttachmentAction(string a_strAttachment, string a_strAction)
		{
			for (int i = 0; i < this.arrAttachmentData.Count; i++)
			{
				if (this.arrAttachmentData[i].attachmentName == a_strAttachment)
				{
					this.arrAttachmentData[i].ActionName = a_strAction;
					return;
				}
			}
			AttachmentPlayData attachmentPlayData = new AttachmentPlayData();
			attachmentPlayData.attachmentName = a_strAttachment;
			attachmentPlayData.ActionName = a_strAction;
			this.arrAttachmentData.Add(attachmentPlayData);
		}

		// Token: 0x0600ABB0 RID: 43952 RVA: 0x00238430 File Offset: 0x00236830
		public void SetAniInfos(string idle, string walk, string run, string dead)
		{
			this.AniNames[0] = idle;
			this.AniNames[2] = run;
			this.AniNames[1] = walk;
			this.AniNames[3] = dead;
		}

		// Token: 0x0400603E RID: 24638
		public string[] AniNames = new string[4];

		// Token: 0x04006040 RID: 24640
		protected ActorMoveData _moveData = new ActorMoveData();

		// Token: 0x04006041 RID: 24641
		protected ActionPlayData _actionPlayData = new ActionPlayData();

		// Token: 0x04006042 RID: 24642
		protected List<AttachmentPlayData> m_arrAttachmentPlayData = new List<AttachmentPlayData>();
	}
}
