using System;

namespace behaviac
{
	// Token: 0x02003F48 RID: 16200
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node16 : Action
	{
		// Token: 0x06016600 RID: 91648 RVA: 0x006C4B13 File Offset: 0x006C2F13
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570233;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016601 RID: 91649 RVA: 0x006C4B4D File Offset: 0x006C2F4D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE33 RID: 65075
		private BE_Target method_p0;

		// Token: 0x0400FE34 RID: 65076
		private int method_p1;

		// Token: 0x0400FE35 RID: 65077
		private int method_p2;

		// Token: 0x0400FE36 RID: 65078
		private int method_p3;

		// Token: 0x0400FE37 RID: 65079
		private int method_p4;
	}
}
