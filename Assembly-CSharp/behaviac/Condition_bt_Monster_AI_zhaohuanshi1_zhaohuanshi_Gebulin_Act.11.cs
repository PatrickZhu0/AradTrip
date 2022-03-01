using System;

namespace behaviac
{
	// Token: 0x02004043 RID: 16451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node21 : Condition
	{
		// Token: 0x060167E5 RID: 92133 RVA: 0x006CEDD7 File Offset: 0x006CD1D7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node21()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167E6 RID: 92134 RVA: 0x006CEE0C File Offset: 0x006CD20C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401002F RID: 65583
		private int opl_p0;

		// Token: 0x04010030 RID: 65584
		private int opl_p1;

		// Token: 0x04010031 RID: 65585
		private int opl_p2;

		// Token: 0x04010032 RID: 65586
		private int opl_p3;
	}
}
