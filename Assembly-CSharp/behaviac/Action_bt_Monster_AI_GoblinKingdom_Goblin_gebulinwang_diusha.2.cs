using System;

namespace behaviac
{
	// Token: 0x02003327 RID: 13095
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node24 : Action
	{
		// Token: 0x06014EB4 RID: 85684 RVA: 0x0064D8A6 File Offset: 0x0064BCA6
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node24()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 200;
			this.method_p1 = 1;
		}

		// Token: 0x06014EB5 RID: 85685 RVA: 0x0064D8C8 File Offset: 0x0064BCC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E79D RID: 59293
		private int method_p0;

		// Token: 0x0400E79E RID: 59294
		private int method_p1;
	}
}
