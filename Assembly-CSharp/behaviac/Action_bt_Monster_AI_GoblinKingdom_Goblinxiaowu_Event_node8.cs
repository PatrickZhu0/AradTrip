using System;

namespace behaviac
{
	// Token: 0x020032E6 RID: 13030
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node8 : Action
	{
		// Token: 0x06014E3A RID: 85562 RVA: 0x0064B167 File Offset: 0x00649567
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521417;
			this.method_p2 = 1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E3B RID: 85563 RVA: 0x0064B19E File Offset: 0x0064959E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E71D RID: 59165
		private BE_Target method_p0;

		// Token: 0x0400E71E RID: 59166
		private int method_p1;

		// Token: 0x0400E71F RID: 59167
		private int method_p2;

		// Token: 0x0400E720 RID: 59168
		private int method_p3;

		// Token: 0x0400E721 RID: 59169
		private int method_p4;
	}
}
