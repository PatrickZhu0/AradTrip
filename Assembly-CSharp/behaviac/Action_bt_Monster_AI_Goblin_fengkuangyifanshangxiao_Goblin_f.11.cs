using System;

namespace behaviac
{
	// Token: 0x020033BC RID: 13244
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node22 : Action
	{
		// Token: 0x06014FD1 RID: 85969 RVA: 0x00652BA7 File Offset: 0x00650FA7
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538504;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FD2 RID: 85970 RVA: 0x00652BE1 File Offset: 0x00650FE1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8BD RID: 59581
		private BE_Target method_p0;

		// Token: 0x0400E8BE RID: 59582
		private int method_p1;

		// Token: 0x0400E8BF RID: 59583
		private int method_p2;

		// Token: 0x0400E8C0 RID: 59584
		private int method_p3;

		// Token: 0x0400E8C1 RID: 59585
		private int method_p4;
	}
}
