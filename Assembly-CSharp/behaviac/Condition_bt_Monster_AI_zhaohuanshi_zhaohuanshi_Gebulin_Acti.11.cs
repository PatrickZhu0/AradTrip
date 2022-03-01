using System;

namespace behaviac
{
	// Token: 0x02003F9A RID: 16282
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node21 : Condition
	{
		// Token: 0x0601669E RID: 91806 RVA: 0x006C7BFB File Offset: 0x006C5FFB
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node21()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601669F RID: 91807 RVA: 0x006C7C30 File Offset: 0x006C6030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEF0 RID: 65264
		private int opl_p0;

		// Token: 0x0400FEF1 RID: 65265
		private int opl_p1;

		// Token: 0x0400FEF2 RID: 65266
		private int opl_p2;

		// Token: 0x0400FEF3 RID: 65267
		private int opl_p3;
	}
}
