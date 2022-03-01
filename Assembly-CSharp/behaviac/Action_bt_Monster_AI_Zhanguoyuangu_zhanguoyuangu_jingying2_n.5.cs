using System;

namespace behaviac
{
	// Token: 0x02003F57 RID: 16215
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node16 : Action
	{
		// Token: 0x0601661D RID: 91677 RVA: 0x006C5387 File Offset: 0x006C3787
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570233;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601661E RID: 91678 RVA: 0x006C53C1 File Offset: 0x006C37C1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE5B RID: 65115
		private BE_Target method_p0;

		// Token: 0x0400FE5C RID: 65116
		private int method_p1;

		// Token: 0x0400FE5D RID: 65117
		private int method_p2;

		// Token: 0x0400FE5E RID: 65118
		private int method_p3;

		// Token: 0x0400FE5F RID: 65119
		private int method_p4;
	}
}
