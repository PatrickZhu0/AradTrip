using System;

namespace behaviac
{
	// Token: 0x020033B9 RID: 13241
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node19 : Action
	{
		// Token: 0x06014FCB RID: 85963 RVA: 0x00652ACB File Offset: 0x00650ECB
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538501;
		}

		// Token: 0x06014FCC RID: 85964 RVA: 0x00652AEC File Offset: 0x00650EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8B4 RID: 59572
		private BE_Target method_p0;

		// Token: 0x0400E8B5 RID: 59573
		private int method_p1;
	}
}
