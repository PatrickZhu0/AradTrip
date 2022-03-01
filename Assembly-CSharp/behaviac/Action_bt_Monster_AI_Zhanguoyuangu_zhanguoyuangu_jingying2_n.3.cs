using System;

namespace behaviac
{
	// Token: 0x02003F55 RID: 16213
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node13 : Action
	{
		// Token: 0x06016619 RID: 91673 RVA: 0x006C52BB File Offset: 0x006C36BB
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2601;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601661A RID: 91674 RVA: 0x006C52F5 File Offset: 0x006C36F5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE51 RID: 65105
		private BE_Target method_p0;

		// Token: 0x0400FE52 RID: 65106
		private int method_p1;

		// Token: 0x0400FE53 RID: 65107
		private int method_p2;

		// Token: 0x0400FE54 RID: 65108
		private int method_p3;

		// Token: 0x0400FE55 RID: 65109
		private int method_p4;
	}
}
