using System;

namespace behaviac
{
	// Token: 0x020033B6 RID: 13238
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node16 : Action
	{
		// Token: 0x06014FC5 RID: 85957 RVA: 0x006529C7 File Offset: 0x00650DC7
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538501;
		}

		// Token: 0x06014FC6 RID: 85958 RVA: 0x006529E8 File Offset: 0x00650DE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8AA RID: 59562
		private BE_Target method_p0;

		// Token: 0x0400E8AB RID: 59563
		private int method_p1;
	}
}
