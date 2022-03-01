using System;

namespace behaviac
{
	// Token: 0x020033AF RID: 13231
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node9 : Action
	{
		// Token: 0x06014FB7 RID: 85943 RVA: 0x00652769 File Offset: 0x00650B69
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538503;
		}

		// Token: 0x06014FB8 RID: 85944 RVA: 0x0065278A File Offset: 0x00650B8A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E895 RID: 59541
		private BE_Target method_p0;

		// Token: 0x0400E896 RID: 59542
		private int method_p1;
	}
}
