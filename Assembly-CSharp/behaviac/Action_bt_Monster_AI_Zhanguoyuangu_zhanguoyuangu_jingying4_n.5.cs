using System;

namespace behaviac
{
	// Token: 0x02003F75 RID: 16245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node16 : Action
	{
		// Token: 0x06016657 RID: 91735 RVA: 0x006C646F File Offset: 0x006C486F
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570233;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016658 RID: 91736 RVA: 0x006C64A9 File Offset: 0x006C48A9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEAB RID: 65195
		private BE_Target method_p0;

		// Token: 0x0400FEAC RID: 65196
		private int method_p1;

		// Token: 0x0400FEAD RID: 65197
		private int method_p2;

		// Token: 0x0400FEAE RID: 65198
		private int method_p3;

		// Token: 0x0400FEAF RID: 65199
		private int method_p4;
	}
}
