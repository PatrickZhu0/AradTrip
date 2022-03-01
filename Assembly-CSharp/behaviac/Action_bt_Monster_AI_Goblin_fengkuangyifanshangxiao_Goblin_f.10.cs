using System;

namespace behaviac
{
	// Token: 0x020033BB RID: 13243
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node21 : Action
	{
		// Token: 0x06014FCF RID: 85967 RVA: 0x00652B41 File Offset: 0x00650F41
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538503;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FD0 RID: 85968 RVA: 0x00652B7B File Offset: 0x00650F7B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8B8 RID: 59576
		private BE_Target method_p0;

		// Token: 0x0400E8B9 RID: 59577
		private int method_p1;

		// Token: 0x0400E8BA RID: 59578
		private int method_p2;

		// Token: 0x0400E8BB RID: 59579
		private int method_p3;

		// Token: 0x0400E8BC RID: 59580
		private int method_p4;
	}
}
