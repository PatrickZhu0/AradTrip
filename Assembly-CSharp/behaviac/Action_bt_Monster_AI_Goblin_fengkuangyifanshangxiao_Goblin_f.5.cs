using System;

namespace behaviac
{
	// Token: 0x020033B3 RID: 13235
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node13 : Action
	{
		// Token: 0x06014FBF RID: 85951 RVA: 0x0065289F File Offset: 0x00650C9F
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538501;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FC0 RID: 85952 RVA: 0x006528D9 File Offset: 0x00650CD9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E89F RID: 59551
		private BE_Target method_p0;

		// Token: 0x0400E8A0 RID: 59552
		private int method_p1;

		// Token: 0x0400E8A1 RID: 59553
		private int method_p2;

		// Token: 0x0400E8A2 RID: 59554
		private int method_p3;

		// Token: 0x0400E8A3 RID: 59555
		private int method_p4;
	}
}
