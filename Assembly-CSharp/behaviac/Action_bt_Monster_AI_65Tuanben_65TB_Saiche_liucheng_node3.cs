using System;

namespace behaviac
{
	// Token: 0x02002BCC RID: 11212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3 : Action
	{
		// Token: 0x06014099 RID: 82073 RVA: 0x00604B57 File Offset: 0x00602F57
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 83000;
			this.method_p1 = 1;
		}

		// Token: 0x0601409A RID: 82074 RVA: 0x00604B78 File Offset: 0x00602F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DA8C RID: 55948
		private int method_p0;

		// Token: 0x0400DA8D RID: 55949
		private int method_p1;
	}
}
