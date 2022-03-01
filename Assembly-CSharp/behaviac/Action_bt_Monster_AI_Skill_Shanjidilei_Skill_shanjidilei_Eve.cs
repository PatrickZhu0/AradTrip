using System;

namespace behaviac
{
	// Token: 0x02003743 RID: 14147
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_node2 : Action
	{
		// Token: 0x06015690 RID: 87696 RVA: 0x00675BFB File Offset: 0x00673FFB
		public Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 130501;
			this.method_p2 = 1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015691 RID: 87697 RVA: 0x00675C31 File Offset: 0x00674031
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F065 RID: 61541
		private BE_Target method_p0;

		// Token: 0x0400F066 RID: 61542
		private int method_p1;

		// Token: 0x0400F067 RID: 61543
		private int method_p2;

		// Token: 0x0400F068 RID: 61544
		private int method_p3;

		// Token: 0x0400F069 RID: 61545
		private int method_p4;
	}
}
