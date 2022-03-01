using System;

namespace behaviac
{
	// Token: 0x02003F6D RID: 16237
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node6 : Action
	{
		// Token: 0x06016647 RID: 91719 RVA: 0x006C61B9 File Offset: 0x006C45B9
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 25000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016648 RID: 91720 RVA: 0x006C61F3 File Offset: 0x006C45F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE91 RID: 65169
		private BE_Target method_p0;

		// Token: 0x0400FE92 RID: 65170
		private int method_p1;

		// Token: 0x0400FE93 RID: 65171
		private int method_p2;

		// Token: 0x0400FE94 RID: 65172
		private int method_p3;

		// Token: 0x0400FE95 RID: 65173
		private int method_p4;
	}
}
