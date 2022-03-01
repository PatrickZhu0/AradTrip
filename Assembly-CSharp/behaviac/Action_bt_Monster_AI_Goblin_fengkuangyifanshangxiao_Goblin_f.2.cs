using System;

namespace behaviac
{
	// Token: 0x020033AE RID: 13230
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node8 : Action
	{
		// Token: 0x06014FB5 RID: 85941 RVA: 0x0065272E File Offset: 0x00650B2E
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538502;
		}

		// Token: 0x06014FB6 RID: 85942 RVA: 0x0065274F File Offset: 0x00650B4F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E893 RID: 59539
		private BE_Target method_p0;

		// Token: 0x0400E894 RID: 59540
		private int method_p1;
	}
}
