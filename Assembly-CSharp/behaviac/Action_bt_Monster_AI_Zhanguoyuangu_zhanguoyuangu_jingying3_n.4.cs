using System;

namespace behaviac
{
	// Token: 0x02003F65 RID: 16229
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node14 : Action
	{
		// Token: 0x06016638 RID: 91704 RVA: 0x006C5B95 File Offset: 0x006C3F95
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2701;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016639 RID: 91705 RVA: 0x006C5BCF File Offset: 0x006C3FCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE7E RID: 65150
		private BE_Target method_p0;

		// Token: 0x0400FE7F RID: 65151
		private int method_p1;

		// Token: 0x0400FE80 RID: 65152
		private int method_p2;

		// Token: 0x0400FE81 RID: 65153
		private int method_p3;

		// Token: 0x0400FE82 RID: 65154
		private int method_p4;
	}
}
