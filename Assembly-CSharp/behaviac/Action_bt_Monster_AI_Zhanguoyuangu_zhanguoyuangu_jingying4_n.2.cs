using System;

namespace behaviac
{
	// Token: 0x02003F72 RID: 16242
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node11 : Action
	{
		// Token: 0x06016651 RID: 91729 RVA: 0x006C633D File Offset: 0x006C473D
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570217;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016652 RID: 91730 RVA: 0x006C6377 File Offset: 0x006C4777
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE9C RID: 65180
		private BE_Target method_p0;

		// Token: 0x0400FE9D RID: 65181
		private int method_p1;

		// Token: 0x0400FE9E RID: 65182
		private int method_p2;

		// Token: 0x0400FE9F RID: 65183
		private int method_p3;

		// Token: 0x0400FEA0 RID: 65184
		private int method_p4;
	}
}
