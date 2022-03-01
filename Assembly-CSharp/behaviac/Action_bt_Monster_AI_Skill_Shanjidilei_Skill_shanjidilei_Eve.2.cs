using System;

namespace behaviac
{
	// Token: 0x02003747 RID: 14151
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2 : Action
	{
		// Token: 0x06015697 RID: 87703 RVA: 0x00675E33 File Offset: 0x00674233
		public Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 130501;
			this.method_p2 = 1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015698 RID: 87704 RVA: 0x00675E69 File Offset: 0x00674269
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F071 RID: 61553
		private BE_Target method_p0;

		// Token: 0x0400F072 RID: 61554
		private int method_p1;

		// Token: 0x0400F073 RID: 61555
		private int method_p2;

		// Token: 0x0400F074 RID: 61556
		private int method_p3;

		// Token: 0x0400F075 RID: 61557
		private int method_p4;
	}
}
