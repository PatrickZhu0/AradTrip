using System;

namespace behaviac
{
	// Token: 0x020036A9 RID: 13993
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_hengpuli_event_node2 : Action
	{
		// Token: 0x0601556D RID: 87405 RVA: 0x0066FE77 File Offset: 0x0066E277
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_hengpuli_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521236;
			this.method_p2 = 10000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601556E RID: 87406 RVA: 0x0066FEB2 File Offset: 0x0066E2B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF3F RID: 61247
		private BE_Target method_p0;

		// Token: 0x0400EF40 RID: 61248
		private int method_p1;

		// Token: 0x0400EF41 RID: 61249
		private int method_p2;

		// Token: 0x0400EF42 RID: 61250
		private int method_p3;

		// Token: 0x0400EF43 RID: 61251
		private int method_p4;
	}
}
