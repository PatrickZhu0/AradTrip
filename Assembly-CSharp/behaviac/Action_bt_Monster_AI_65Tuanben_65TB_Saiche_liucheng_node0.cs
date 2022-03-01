using System;

namespace behaviac
{
	// Token: 0x02002BCA RID: 11210
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node0 : Action
	{
		// Token: 0x06014095 RID: 82069 RVA: 0x00604A6A File Offset: 0x00602E6A
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node0()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 8000;
			this.method_p1 = 0;
		}

		// Token: 0x06014096 RID: 82070 RVA: 0x00604A8C File Offset: 0x00602E8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DA86 RID: 55942
		private int method_p0;

		// Token: 0x0400DA87 RID: 55943
		private int method_p1;
	}
}
