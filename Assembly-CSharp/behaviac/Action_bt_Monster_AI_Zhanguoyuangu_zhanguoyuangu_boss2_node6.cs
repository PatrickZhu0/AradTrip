using System;

namespace behaviac
{
	// Token: 0x02003F19 RID: 16153
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node6 : Action
	{
		// Token: 0x060165A5 RID: 91557 RVA: 0x006C32D9 File Offset: 0x006C16D9
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 40000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165A6 RID: 91558 RVA: 0x006C3313 File Offset: 0x006C1713
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDBF RID: 64959
		private BE_Target method_p0;

		// Token: 0x0400FDC0 RID: 64960
		private int method_p1;

		// Token: 0x0400FDC1 RID: 64961
		private int method_p2;

		// Token: 0x0400FDC2 RID: 64962
		private int method_p3;

		// Token: 0x0400FDC3 RID: 64963
		private int method_p4;
	}
}
