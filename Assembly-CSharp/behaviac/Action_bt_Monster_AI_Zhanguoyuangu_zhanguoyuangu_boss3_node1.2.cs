using System;

namespace behaviac
{
	// Token: 0x02003F2C RID: 16172
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node14 : Action
	{
		// Token: 0x060165CA RID: 91594 RVA: 0x006C3BEF File Offset: 0x006C1FEF
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165CB RID: 91595 RVA: 0x006C3C26 File Offset: 0x006C2026
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDED RID: 65005
		private BE_Target method_p0;

		// Token: 0x0400FDEE RID: 65006
		private int method_p1;

		// Token: 0x0400FDEF RID: 65007
		private int method_p2;

		// Token: 0x0400FDF0 RID: 65008
		private int method_p3;

		// Token: 0x0400FDF1 RID: 65009
		private int method_p4;
	}
}
