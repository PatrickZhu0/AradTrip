using System;

namespace behaviac
{
	// Token: 0x020033E7 RID: 13287
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node6 : Action
	{
		// Token: 0x06015022 RID: 86050 RVA: 0x006546E5 File Offset: 0x00652AE5
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2403;
			this.method_p2 = 6000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015023 RID: 86051 RVA: 0x0065471F File Offset: 0x00652B1F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E90D RID: 59661
		private BE_Target method_p0;

		// Token: 0x0400E90E RID: 59662
		private int method_p1;

		// Token: 0x0400E90F RID: 59663
		private int method_p2;

		// Token: 0x0400E910 RID: 59664
		private int method_p3;

		// Token: 0x0400E911 RID: 59665
		private int method_p4;
	}
}
