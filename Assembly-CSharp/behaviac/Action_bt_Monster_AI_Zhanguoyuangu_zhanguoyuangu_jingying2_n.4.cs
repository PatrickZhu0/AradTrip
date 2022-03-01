using System;

namespace behaviac
{
	// Token: 0x02003F56 RID: 16214
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node14 : Action
	{
		// Token: 0x0601661B RID: 91675 RVA: 0x006C5321 File Offset: 0x006C3721
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2701;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601661C RID: 91676 RVA: 0x006C535B File Offset: 0x006C375B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE56 RID: 65110
		private BE_Target method_p0;

		// Token: 0x0400FE57 RID: 65111
		private int method_p1;

		// Token: 0x0400FE58 RID: 65112
		private int method_p2;

		// Token: 0x0400FE59 RID: 65113
		private int method_p3;

		// Token: 0x0400FE5A RID: 65114
		private int method_p4;
	}
}
