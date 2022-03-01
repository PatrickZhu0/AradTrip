using System;

namespace behaviac
{
	// Token: 0x02003F0C RID: 16140
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node6 : Action
	{
		// Token: 0x0601658C RID: 91532 RVA: 0x006C2BAD File Offset: 0x006C0FAD
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 50003;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601658D RID: 91533 RVA: 0x006C2BE7 File Offset: 0x006C0FE7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDA1 RID: 64929
		private BE_Target method_p0;

		// Token: 0x0400FDA2 RID: 64930
		private int method_p1;

		// Token: 0x0400FDA3 RID: 64931
		private int method_p2;

		// Token: 0x0400FDA4 RID: 64932
		private int method_p3;

		// Token: 0x0400FDA5 RID: 64933
		private int method_p4;
	}
}
