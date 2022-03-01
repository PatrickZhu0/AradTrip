using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001160 RID: 4448
	internal class BaseJobItem : CachedSelectedObject<JobTable, BaseJobItem>
	{
		// Token: 0x0600A9DF RID: 43487 RVA: 0x00242AD4 File Offset: 0x00240ED4
		public override void Initialize()
		{
			ComCommonBind component = this.goLocal.GetComponent<ComCommonBind>();
			if (component != null)
			{
				this.jobHead = component.GetCom<Image>("imgHead");
				this.jobName = component.GetCom<Image>("imgName");
				this.imgCheckMark = component.GetCom<Image>("imgCheckMark");
				this.tips = component.GetCom<Text>("tips");
				this.goAppointmentRole = component.GetGameObject("AppointmentRole");
			}
			this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
			if (this.toggle != null)
			{
				this.toggle.interactable = (this.data.Open == 1);
			}
			if (this.tips != null)
			{
				this.tips.gameObject.CustomActive(this.data.Open == 0);
			}
		}

		// Token: 0x0600A9E0 RID: 43488 RVA: 0x00242BBD File Offset: 0x00240FBD
		public override void UnInitialize()
		{
			this.jobHead = null;
			this.goCheckMark = null;
			this.jobName = null;
			this.goAppointmentRole = null;
		}

		// Token: 0x0600A9E1 RID: 43489 RVA: 0x00242BDC File Offset: 0x00240FDC
		public override void OnUpdate()
		{
			Utility.createSprite(this.data.JobHead, ref this.jobHead);
			Utility.createSprite(this.data.JobCreateName, ref this.jobName);
			this.goAppointmentRole.CustomActive(ClientApplication.playerinfo.GetRoleHasApponintmentOccu(this.data.ID));
		}

		// Token: 0x0600A9E2 RID: 43490 RVA: 0x00242C35 File Offset: 0x00241035
		public override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
			this.imgCheckMark.gameObject.CustomActive(!bShow);
		}

		// Token: 0x04005F2D RID: 24365
		private Image jobHead;

		// Token: 0x04005F2E RID: 24366
		private GameObject goCheckMark;

		// Token: 0x04005F2F RID: 24367
		private Image jobName;

		// Token: 0x04005F30 RID: 24368
		private Image imgCheckMark;

		// Token: 0x04005F31 RID: 24369
		private Text tips;

		// Token: 0x04005F32 RID: 24370
		private GameObject goAppointmentRole;
	}
}
