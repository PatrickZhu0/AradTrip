using System;

namespace behaviac
{
	// Token: 0x02003F64 RID: 16228
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node13 : Action
	{
		// Token: 0x06016636 RID: 91702 RVA: 0x006C5B2F File Offset: 0x006C3F2F
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2601;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016637 RID: 91703 RVA: 0x006C5B69 File Offset: 0x006C3F69
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE79 RID: 65145
		private BE_Target method_p0;

		// Token: 0x0400FE7A RID: 65146
		private int method_p1;

		// Token: 0x0400FE7B RID: 65147
		private int method_p2;

		// Token: 0x0400FE7C RID: 65148
		private int method_p3;

		// Token: 0x0400FE7D RID: 65149
		private int method_p4;
	}
}
