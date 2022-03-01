using System;

namespace behaviac
{
	// Token: 0x02003F38 RID: 16184
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node11 : Action
	{
		// Token: 0x060165E1 RID: 91617 RVA: 0x006C42B5 File Offset: 0x006C26B5
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570232;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165E2 RID: 91618 RVA: 0x006C42EF File Offset: 0x006C26EF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE06 RID: 65030
		private BE_Target method_p0;

		// Token: 0x0400FE07 RID: 65031
		private int method_p1;

		// Token: 0x0400FE08 RID: 65032
		private int method_p2;

		// Token: 0x0400FE09 RID: 65033
		private int method_p3;

		// Token: 0x0400FE0A RID: 65034
		private int method_p4;
	}
}
