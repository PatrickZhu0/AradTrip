using System;

namespace behaviac
{
	// Token: 0x02002CA8 RID: 11432
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node6 : Action
	{
		// Token: 0x06014245 RID: 82501 RVA: 0x0060CBBC File Offset: 0x0060AFBC
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521947;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014246 RID: 82502 RVA: 0x0060CBF3 File Offset: 0x0060AFF3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBFA RID: 56314
		private BE_Target method_p0;

		// Token: 0x0400DBFB RID: 56315
		private int method_p1;

		// Token: 0x0400DBFC RID: 56316
		private int method_p2;

		// Token: 0x0400DBFD RID: 56317
		private int method_p3;

		// Token: 0x0400DBFE RID: 56318
		private int method_p4;
	}
}
