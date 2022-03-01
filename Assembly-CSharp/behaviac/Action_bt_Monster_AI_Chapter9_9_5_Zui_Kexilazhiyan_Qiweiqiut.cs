using System;

namespace behaviac
{
	// Token: 0x020031DB RID: 12763
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node2 : Action
	{
		// Token: 0x06014C45 RID: 85061 RVA: 0x00641A28 File Offset: 0x0063FE28
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570239;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014C46 RID: 85062 RVA: 0x00641A60 File Offset: 0x0063FE60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E599 RID: 58777
		private BE_Target method_p0;

		// Token: 0x0400E59A RID: 58778
		private int method_p1;

		// Token: 0x0400E59B RID: 58779
		private int method_p2;

		// Token: 0x0400E59C RID: 58780
		private int method_p3;

		// Token: 0x0400E59D RID: 58781
		private int method_p4;
	}
}
