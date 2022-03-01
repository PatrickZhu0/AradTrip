using System;

namespace behaviac
{
	// Token: 0x02003CDC RID: 15580
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node1 : Action
	{
		// Token: 0x0601615A RID: 90458 RVA: 0x006ACAFE File Offset: 0x006AAEFE
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570179;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601615B RID: 90459 RVA: 0x006ACB35 File Offset: 0x006AAF35
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA09 RID: 64009
		private BE_Target method_p0;

		// Token: 0x0400FA0A RID: 64010
		private int method_p1;

		// Token: 0x0400FA0B RID: 64011
		private int method_p2;

		// Token: 0x0400FA0C RID: 64012
		private int method_p3;

		// Token: 0x0400FA0D RID: 64013
		private int method_p4;
	}
}
