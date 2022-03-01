using System;

namespace behaviac
{
	// Token: 0x02003FD6 RID: 16342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node18 : Condition
	{
		// Token: 0x06016714 RID: 91924 RVA: 0x006CA703 File Offset: 0x006C8B03
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node18()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06016715 RID: 91925 RVA: 0x006CA738 File Offset: 0x006C8B38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF65 RID: 65381
		private int opl_p0;

		// Token: 0x0400FF66 RID: 65382
		private int opl_p1;

		// Token: 0x0400FF67 RID: 65383
		private int opl_p2;

		// Token: 0x0400FF68 RID: 65384
		private int opl_p3;
	}
}
