using System;

namespace behaviac
{
	// Token: 0x02003F39 RID: 16185
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node14 : Action
	{
		// Token: 0x060165E3 RID: 91619 RVA: 0x006C431B File Offset: 0x006C271B
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165E4 RID: 91620 RVA: 0x006C4352 File Offset: 0x006C2752
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE0B RID: 65035
		private BE_Target method_p0;

		// Token: 0x0400FE0C RID: 65036
		private int method_p1;

		// Token: 0x0400FE0D RID: 65037
		private int method_p2;

		// Token: 0x0400FE0E RID: 65038
		private int method_p3;

		// Token: 0x0400FE0F RID: 65039
		private int method_p4;
	}
}
