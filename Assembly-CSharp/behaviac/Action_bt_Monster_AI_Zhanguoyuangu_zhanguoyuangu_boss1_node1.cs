using System;

namespace behaviac
{
	// Token: 0x02003F11 RID: 16145
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node11 : Action
	{
		// Token: 0x06016596 RID: 91542 RVA: 0x006C2D31 File Offset: 0x006C1131
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570232;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06016597 RID: 91543 RVA: 0x006C2D6B File Offset: 0x006C116B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDAC RID: 64940
		private BE_Target method_p0;

		// Token: 0x0400FDAD RID: 64941
		private int method_p1;

		// Token: 0x0400FDAE RID: 64942
		private int method_p2;

		// Token: 0x0400FDAF RID: 64943
		private int method_p3;

		// Token: 0x0400FDB0 RID: 64944
		private int method_p4;
	}
}
