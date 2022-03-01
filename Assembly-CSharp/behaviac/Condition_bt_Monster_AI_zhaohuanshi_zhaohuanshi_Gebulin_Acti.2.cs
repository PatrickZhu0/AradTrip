using System;

namespace behaviac
{
	// Token: 0x02003F8E RID: 16270
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node6 : Condition
	{
		// Token: 0x06016686 RID: 91782 RVA: 0x006C76DF File Offset: 0x006C5ADF
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016687 RID: 91783 RVA: 0x006C7714 File Offset: 0x006C5B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED8 RID: 65240
		private int opl_p0;

		// Token: 0x0400FED9 RID: 65241
		private int opl_p1;

		// Token: 0x0400FEDA RID: 65242
		private int opl_p2;

		// Token: 0x0400FEDB RID: 65243
		private int opl_p3;
	}
}
