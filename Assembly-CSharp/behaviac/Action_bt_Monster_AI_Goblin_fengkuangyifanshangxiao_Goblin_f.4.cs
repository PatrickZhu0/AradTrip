using System;

namespace behaviac
{
	// Token: 0x020033B0 RID: 13232
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node10 : Action
	{
		// Token: 0x06014FB9 RID: 85945 RVA: 0x006527A4 File Offset: 0x00650BA4
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538503;
		}

		// Token: 0x06014FBA RID: 85946 RVA: 0x006527C5 File Offset: 0x00650BC5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E897 RID: 59543
		private BE_Target method_p0;

		// Token: 0x0400E898 RID: 59544
		private int method_p1;
	}
}
