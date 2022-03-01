using System;

namespace behaviac
{
	// Token: 0x02002DAF RID: 11695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node19 : Condition
	{
		// Token: 0x0601443F RID: 83007 RVA: 0x0061643E File Offset: 0x0061483E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node19()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1200;
			this.opl_p3 = 1200;
		}

		// Token: 0x06014440 RID: 83008 RVA: 0x00616474 File Offset: 0x00614874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE05 RID: 56837
		private int opl_p0;

		// Token: 0x0400DE06 RID: 56838
		private int opl_p1;

		// Token: 0x0400DE07 RID: 56839
		private int opl_p2;

		// Token: 0x0400DE08 RID: 56840
		private int opl_p3;
	}
}
