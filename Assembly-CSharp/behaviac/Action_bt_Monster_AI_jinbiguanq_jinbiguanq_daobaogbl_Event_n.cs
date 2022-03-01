using System;

namespace behaviac
{
	// Token: 0x0200358E RID: 13710
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node5 : Action
	{
		// Token: 0x0601534D RID: 86861 RVA: 0x0066445F File Offset: 0x0066285F
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = 2000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601534E RID: 86862 RVA: 0x00664495 File Offset: 0x00662895
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED0E RID: 60686
		private BE_Target method_p0;

		// Token: 0x0400ED0F RID: 60687
		private int method_p1;

		// Token: 0x0400ED10 RID: 60688
		private int method_p2;

		// Token: 0x0400ED11 RID: 60689
		private int method_p3;

		// Token: 0x0400ED12 RID: 60690
		private int method_p4;
	}
}
