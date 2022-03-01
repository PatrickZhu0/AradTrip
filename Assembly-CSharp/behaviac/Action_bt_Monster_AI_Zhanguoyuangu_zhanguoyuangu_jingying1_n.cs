using System;

namespace behaviac
{
	// Token: 0x02003F40 RID: 16192
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node6 : Action
	{
		// Token: 0x060165F0 RID: 91632 RVA: 0x006C485D File Offset: 0x006C2C5D
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 40000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165F1 RID: 91633 RVA: 0x006C4897 File Offset: 0x006C2C97
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE19 RID: 65049
		private BE_Target method_p0;

		// Token: 0x0400FE1A RID: 65050
		private int method_p1;

		// Token: 0x0400FE1B RID: 65051
		private int method_p2;

		// Token: 0x0400FE1C RID: 65052
		private int method_p3;

		// Token: 0x0400FE1D RID: 65053
		private int method_p4;
	}
}
