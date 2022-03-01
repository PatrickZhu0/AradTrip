using System;

namespace behaviac
{
	// Token: 0x0200325A RID: 12890
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node15 : Action
	{
		// Token: 0x06014D33 RID: 85299 RVA: 0x00646183 File Offset: 0x00644583
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 3;
			this.method_p2 = 10000000;
			this.method_p3 = 60;
			this.method_p4 = 1000;
		}

		// Token: 0x06014D34 RID: 85300 RVA: 0x006461BE File Offset: 0x006445BE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E678 RID: 59000
		private BE_Target method_p0;

		// Token: 0x0400E679 RID: 59001
		private int method_p1;

		// Token: 0x0400E67A RID: 59002
		private int method_p2;

		// Token: 0x0400E67B RID: 59003
		private int method_p3;

		// Token: 0x0400E67C RID: 59004
		private int method_p4;
	}
}
