using System;

namespace behaviac
{
	// Token: 0x02003F74 RID: 16244
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node14 : Action
	{
		// Token: 0x06016655 RID: 91733 RVA: 0x006C6409 File Offset: 0x006C4809
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2701;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016656 RID: 91734 RVA: 0x006C6443 File Offset: 0x006C4843
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEA6 RID: 65190
		private BE_Target method_p0;

		// Token: 0x0400FEA7 RID: 65191
		private int method_p1;

		// Token: 0x0400FEA8 RID: 65192
		private int method_p2;

		// Token: 0x0400FEA9 RID: 65193
		private int method_p3;

		// Token: 0x0400FEAA RID: 65194
		private int method_p4;
	}
}
