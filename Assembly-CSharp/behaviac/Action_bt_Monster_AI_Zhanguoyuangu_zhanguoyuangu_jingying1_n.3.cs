using System;

namespace behaviac
{
	// Token: 0x02003F46 RID: 16198
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node13 : Action
	{
		// Token: 0x060165FC RID: 91644 RVA: 0x006C4A47 File Offset: 0x006C2E47
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2601;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165FD RID: 91645 RVA: 0x006C4A81 File Offset: 0x006C2E81
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE29 RID: 65065
		private BE_Target method_p0;

		// Token: 0x0400FE2A RID: 65066
		private int method_p1;

		// Token: 0x0400FE2B RID: 65067
		private int method_p2;

		// Token: 0x0400FE2C RID: 65068
		private int method_p3;

		// Token: 0x0400FE2D RID: 65069
		private int method_p4;
	}
}
