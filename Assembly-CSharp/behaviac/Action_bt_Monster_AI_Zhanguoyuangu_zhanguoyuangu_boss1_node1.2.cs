using System;

namespace behaviac
{
	// Token: 0x02003F12 RID: 16146
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node14 : Action
	{
		// Token: 0x06016598 RID: 91544 RVA: 0x006C2D97 File Offset: 0x006C1197
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016599 RID: 91545 RVA: 0x006C2DCE File Offset: 0x006C11CE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDB1 RID: 64945
		private BE_Target method_p0;

		// Token: 0x0400FDB2 RID: 64946
		private int method_p1;

		// Token: 0x0400FDB3 RID: 64947
		private int method_p2;

		// Token: 0x0400FDB4 RID: 64948
		private int method_p3;

		// Token: 0x0400FDB5 RID: 64949
		private int method_p4;
	}
}
