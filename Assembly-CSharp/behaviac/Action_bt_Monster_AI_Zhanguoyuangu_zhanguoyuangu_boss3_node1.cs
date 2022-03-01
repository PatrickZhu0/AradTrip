using System;

namespace behaviac
{
	// Token: 0x02003F2B RID: 16171
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node11 : Action
	{
		// Token: 0x060165C8 RID: 91592 RVA: 0x006C3B89 File Offset: 0x006C1F89
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570232;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165C9 RID: 91593 RVA: 0x006C3BC3 File Offset: 0x006C1FC3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDE8 RID: 65000
		private BE_Target method_p0;

		// Token: 0x0400FDE9 RID: 65001
		private int method_p1;

		// Token: 0x0400FDEA RID: 65002
		private int method_p2;

		// Token: 0x0400FDEB RID: 65003
		private int method_p3;

		// Token: 0x0400FDEC RID: 65004
		private int method_p4;
	}
}
