using System;

namespace behaviac
{
	// Token: 0x02003FCE RID: 16334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9 : Condition
	{
		// Token: 0x06016704 RID: 91908 RVA: 0x006CA39B File Offset: 0x006C879B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06016705 RID: 91909 RVA: 0x006CA3D0 File Offset: 0x006C87D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF55 RID: 65365
		private int opl_p0;

		// Token: 0x0400FF56 RID: 65366
		private int opl_p1;

		// Token: 0x0400FF57 RID: 65367
		private int opl_p2;

		// Token: 0x0400FF58 RID: 65368
		private int opl_p3;
	}
}
