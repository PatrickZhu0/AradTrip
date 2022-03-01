using System;

namespace behaviac
{
	// Token: 0x02002C09 RID: 11273
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node108 : Action
	{
		// Token: 0x06014111 RID: 82193 RVA: 0x00605DBA File Offset: 0x006041BA
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node108()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
			this.method_p2 = 50000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06014112 RID: 82194 RVA: 0x00605DF4 File Offset: 0x006041F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAEC RID: 56044
		private BE_Target method_p0;

		// Token: 0x0400DAED RID: 56045
		private int method_p1;

		// Token: 0x0400DAEE RID: 56046
		private int method_p2;

		// Token: 0x0400DAEF RID: 56047
		private int method_p3;

		// Token: 0x0400DAF0 RID: 56048
		private int method_p4;
	}
}
