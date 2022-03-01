using System;

namespace behaviac
{
	// Token: 0x02003F92 RID: 16274
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node11 : Condition
	{
		// Token: 0x0601668E RID: 91790 RVA: 0x006C7893 File Offset: 0x006C5C93
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node11()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601668F RID: 91791 RVA: 0x006C78C8 File Offset: 0x006C5CC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEE0 RID: 65248
		private int opl_p0;

		// Token: 0x0400FEE1 RID: 65249
		private int opl_p1;

		// Token: 0x0400FEE2 RID: 65250
		private int opl_p2;

		// Token: 0x0400FEE3 RID: 65251
		private int opl_p3;
	}
}
