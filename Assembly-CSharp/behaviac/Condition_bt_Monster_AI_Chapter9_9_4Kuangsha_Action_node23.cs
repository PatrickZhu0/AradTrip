using System;

namespace behaviac
{
	// Token: 0x02003183 RID: 12675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node23 : Condition
	{
		// Token: 0x06014B9D RID: 84893 RVA: 0x0063D877 File Offset: 0x0063BC77
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node23()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014B9E RID: 84894 RVA: 0x0063D8AC File Offset: 0x0063BCAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E508 RID: 58632
		private int opl_p0;

		// Token: 0x0400E509 RID: 58633
		private int opl_p1;

		// Token: 0x0400E50A RID: 58634
		private int opl_p2;

		// Token: 0x0400E50B RID: 58635
		private int opl_p3;
	}
}
