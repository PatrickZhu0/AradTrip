using System;

namespace behaviac
{
	// Token: 0x02003F26 RID: 16166
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node6 : Action
	{
		// Token: 0x060165BE RID: 91582 RVA: 0x006C3A05 File Offset: 0x006C1E05
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 35000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165BF RID: 91583 RVA: 0x006C3A3F File Offset: 0x006C1E3F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDDD RID: 64989
		private BE_Target method_p0;

		// Token: 0x0400FDDE RID: 64990
		private int method_p1;

		// Token: 0x0400FDDF RID: 64991
		private int method_p2;

		// Token: 0x0400FDE0 RID: 64992
		private int method_p3;

		// Token: 0x0400FDE1 RID: 64993
		private int method_p4;
	}
}
