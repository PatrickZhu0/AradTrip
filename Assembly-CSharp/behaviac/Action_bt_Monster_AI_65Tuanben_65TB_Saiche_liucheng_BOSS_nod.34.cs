using System;

namespace behaviac
{
	// Token: 0x02002C1D RID: 11293
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node91 : Action
	{
		// Token: 0x06014139 RID: 82233 RVA: 0x00606391 File Offset: 0x00604791
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node91()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2;
			this.method_p2 = 90000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601413A RID: 82234 RVA: 0x006063C8 File Offset: 0x006047C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB0B RID: 56075
		private BE_Target method_p0;

		// Token: 0x0400DB0C RID: 56076
		private int method_p1;

		// Token: 0x0400DB0D RID: 56077
		private int method_p2;

		// Token: 0x0400DB0E RID: 56078
		private int method_p3;

		// Token: 0x0400DB0F RID: 56079
		private int method_p4;
	}
}
