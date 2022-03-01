using System;

namespace behaviac
{
	// Token: 0x02004037 RID: 16439
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node6 : Condition
	{
		// Token: 0x060167CD RID: 92109 RVA: 0x006CE8BB File Offset: 0x006CCCBB
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167CE RID: 92110 RVA: 0x006CE8F0 File Offset: 0x006CCCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010017 RID: 65559
		private int opl_p0;

		// Token: 0x04010018 RID: 65560
		private int opl_p1;

		// Token: 0x04010019 RID: 65561
		private int opl_p2;

		// Token: 0x0401001A RID: 65562
		private int opl_p3;
	}
}
