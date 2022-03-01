using System;

namespace behaviac
{
	// Token: 0x02003F45 RID: 16197
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node11 : Action
	{
		// Token: 0x060165FA RID: 91642 RVA: 0x006C49E1 File Offset: 0x006C2DE1
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570217;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165FB RID: 91643 RVA: 0x006C4A1B File Offset: 0x006C2E1B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE24 RID: 65060
		private BE_Target method_p0;

		// Token: 0x0400FE25 RID: 65061
		private int method_p1;

		// Token: 0x0400FE26 RID: 65062
		private int method_p2;

		// Token: 0x0400FE27 RID: 65063
		private int method_p3;

		// Token: 0x0400FE28 RID: 65064
		private int method_p4;
	}
}
