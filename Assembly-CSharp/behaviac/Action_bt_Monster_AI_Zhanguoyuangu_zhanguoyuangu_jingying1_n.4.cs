using System;

namespace behaviac
{
	// Token: 0x02003F47 RID: 16199
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node14 : Action
	{
		// Token: 0x060165FE RID: 91646 RVA: 0x006C4AAD File Offset: 0x006C2EAD
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2701;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165FF RID: 91647 RVA: 0x006C4AE7 File Offset: 0x006C2EE7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE2E RID: 65070
		private BE_Target method_p0;

		// Token: 0x0400FE2F RID: 65071
		private int method_p1;

		// Token: 0x0400FE30 RID: 65072
		private int method_p2;

		// Token: 0x0400FE31 RID: 65073
		private int method_p3;

		// Token: 0x0400FE32 RID: 65074
		private int method_p4;
	}
}
