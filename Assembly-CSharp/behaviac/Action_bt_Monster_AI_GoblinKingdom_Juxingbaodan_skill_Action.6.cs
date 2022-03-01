using System;

namespace behaviac
{
	// Token: 0x020033A4 RID: 13220
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node23 : Action
	{
		// Token: 0x06014FA3 RID: 85923 RVA: 0x00651E36 File Offset: 0x00650236
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node23()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6000;
			this.method_p1 = 2;
		}

		// Token: 0x06014FA4 RID: 85924 RVA: 0x00651E58 File Offset: 0x00650258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E881 RID: 59521
		private int method_p0;

		// Token: 0x0400E882 RID: 59522
		private int method_p1;
	}
}
