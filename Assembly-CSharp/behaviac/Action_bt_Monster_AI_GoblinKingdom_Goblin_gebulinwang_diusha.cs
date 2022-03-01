using System;

namespace behaviac
{
	// Token: 0x02003325 RID: 13093
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node9 : Action
	{
		// Token: 0x06014EB0 RID: 85680 RVA: 0x0064D837 File Offset: 0x0064BC37
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x06014EB1 RID: 85681 RVA: 0x0064D858 File Offset: 0x0064BC58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E79B RID: 59291
		private int method_p0;

		// Token: 0x0400E79C RID: 59292
		private int method_p1;
	}
}
