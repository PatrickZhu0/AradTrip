using System;

namespace behaviac
{
	// Token: 0x020033AD RID: 13229
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node7 : Action
	{
		// Token: 0x06014FB3 RID: 85939 RVA: 0x006526F3 File Offset: 0x00650AF3
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538501;
		}

		// Token: 0x06014FB4 RID: 85940 RVA: 0x00652714 File Offset: 0x00650B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E891 RID: 59537
		private BE_Target method_p0;

		// Token: 0x0400E892 RID: 59538
		private int method_p1;
	}
}
