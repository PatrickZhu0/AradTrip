using System;

namespace behaviac
{
	// Token: 0x0200334A RID: 13130
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node5 : Action
	{
		// Token: 0x06014EF7 RID: 85751 RVA: 0x0064EE62 File Offset: 0x0064D262
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x06014EF8 RID: 85752 RVA: 0x0064EE84 File Offset: 0x0064D284
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E7D5 RID: 59349
		private int method_p0;

		// Token: 0x0400E7D6 RID: 59350
		private int method_p1;
	}
}
