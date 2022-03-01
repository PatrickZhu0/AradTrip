using System;

namespace behaviac
{
	// Token: 0x02002DB2 RID: 11698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node164 : Condition
	{
		// Token: 0x06014445 RID: 83013 RVA: 0x006165AA File Offset: 0x006149AA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node164()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 1500;
			this.opl_p2 = 1300;
			this.opl_p3 = 1300;
		}

		// Token: 0x06014446 RID: 83014 RVA: 0x006165E0 File Offset: 0x006149E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE0C RID: 56844
		private int opl_p0;

		// Token: 0x0400DE0D RID: 56845
		private int opl_p1;

		// Token: 0x0400DE0E RID: 56846
		private int opl_p2;

		// Token: 0x0400DE0F RID: 56847
		private int opl_p3;
	}
}
