using System;

namespace behaviac
{
	// Token: 0x02003F66 RID: 16230
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node16 : Action
	{
		// Token: 0x0601663A RID: 91706 RVA: 0x006C5BFB File Offset: 0x006C3FFB
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570233;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601663B RID: 91707 RVA: 0x006C5C35 File Offset: 0x006C4035
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE83 RID: 65155
		private BE_Target method_p0;

		// Token: 0x0400FE84 RID: 65156
		private int method_p1;

		// Token: 0x0400FE85 RID: 65157
		private int method_p2;

		// Token: 0x0400FE86 RID: 65158
		private int method_p3;

		// Token: 0x0400FE87 RID: 65159
		private int method_p4;
	}
}
