using System;

namespace behaviac
{
	// Token: 0x020033BA RID: 13242
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node20 : Action
	{
		// Token: 0x06014FCD RID: 85965 RVA: 0x00652B06 File Offset: 0x00650F06
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538502;
		}

		// Token: 0x06014FCE RID: 85966 RVA: 0x00652B27 File Offset: 0x00650F27
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8B6 RID: 59574
		private BE_Target method_p0;

		// Token: 0x0400E8B7 RID: 59575
		private int method_p1;
	}
}
