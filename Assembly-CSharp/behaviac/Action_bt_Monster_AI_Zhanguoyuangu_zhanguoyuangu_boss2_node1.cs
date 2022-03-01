using System;

namespace behaviac
{
	// Token: 0x02003F1E RID: 16158
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node11 : Action
	{
		// Token: 0x060165AF RID: 91567 RVA: 0x006C345D File Offset: 0x006C185D
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570232;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165B0 RID: 91568 RVA: 0x006C3497 File Offset: 0x006C1897
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDCA RID: 64970
		private BE_Target method_p0;

		// Token: 0x0400FDCB RID: 64971
		private int method_p1;

		// Token: 0x0400FDCC RID: 64972
		private int method_p2;

		// Token: 0x0400FDCD RID: 64973
		private int method_p3;

		// Token: 0x0400FDCE RID: 64974
		private int method_p4;
	}
}
