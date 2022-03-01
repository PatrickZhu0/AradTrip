using System;

namespace behaviac
{
	// Token: 0x02003455 RID: 13397
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node15 : Action
	{
		// Token: 0x060150F6 RID: 86262 RVA: 0x00658566 File Offset: 0x00656966
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521888;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150F7 RID: 86263 RVA: 0x0065859E File Offset: 0x0065699E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9DC RID: 59868
		private BE_Target method_p0;

		// Token: 0x0400E9DD RID: 59869
		private int method_p1;

		// Token: 0x0400E9DE RID: 59870
		private int method_p2;

		// Token: 0x0400E9DF RID: 59871
		private int method_p3;

		// Token: 0x0400E9E0 RID: 59872
		private int method_p4;
	}
}
