using System;

namespace behaviac
{
	// Token: 0x02003F73 RID: 16243
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node13 : Action
	{
		// Token: 0x06016653 RID: 91731 RVA: 0x006C63A3 File Offset: 0x006C47A3
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2601;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016654 RID: 91732 RVA: 0x006C63DD File Offset: 0x006C47DD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEA1 RID: 65185
		private BE_Target method_p0;

		// Token: 0x0400FEA2 RID: 65186
		private int method_p1;

		// Token: 0x0400FEA3 RID: 65187
		private int method_p2;

		// Token: 0x0400FEA4 RID: 65188
		private int method_p3;

		// Token: 0x0400FEA5 RID: 65189
		private int method_p4;
	}
}
