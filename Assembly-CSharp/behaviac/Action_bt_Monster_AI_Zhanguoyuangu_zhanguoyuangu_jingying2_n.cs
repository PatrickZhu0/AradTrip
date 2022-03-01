using System;

namespace behaviac
{
	// Token: 0x02003F4F RID: 16207
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6 : Action
	{
		// Token: 0x0601660D RID: 91661 RVA: 0x006C50D1 File Offset: 0x006C34D1
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 35000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601660E RID: 91662 RVA: 0x006C510B File Offset: 0x006C350B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE41 RID: 65089
		private BE_Target method_p0;

		// Token: 0x0400FE42 RID: 65090
		private int method_p1;

		// Token: 0x0400FE43 RID: 65091
		private int method_p2;

		// Token: 0x0400FE44 RID: 65092
		private int method_p3;

		// Token: 0x0400FE45 RID: 65093
		private int method_p4;
	}
}
