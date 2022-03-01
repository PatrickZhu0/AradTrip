using System;

namespace behaviac
{
	// Token: 0x020033EC RID: 13292
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node11 : Action
	{
		// Token: 0x0601502C RID: 86060 RVA: 0x00654869 File Offset: 0x00652C69
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2503;
			this.method_p2 = 6000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601502D RID: 86061 RVA: 0x006548A3 File Offset: 0x00652CA3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E918 RID: 59672
		private BE_Target method_p0;

		// Token: 0x0400E919 RID: 59673
		private int method_p1;

		// Token: 0x0400E91A RID: 59674
		private int method_p2;

		// Token: 0x0400E91B RID: 59675
		private int method_p3;

		// Token: 0x0400E91C RID: 59676
		private int method_p4;
	}
}
