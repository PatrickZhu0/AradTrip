using System;

namespace behaviac
{
	// Token: 0x02002DEF RID: 11759
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node18 : Condition
	{
		// Token: 0x060144BB RID: 83131 RVA: 0x00618ED2 File Offset: 0x006172D2
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node18()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060144BC RID: 83132 RVA: 0x00618F08 File Offset: 0x00617308
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE74 RID: 56948
		private int opl_p0;

		// Token: 0x0400DE75 RID: 56949
		private int opl_p1;

		// Token: 0x0400DE76 RID: 56950
		private int opl_p2;

		// Token: 0x0400DE77 RID: 56951
		private int opl_p3;
	}
}
