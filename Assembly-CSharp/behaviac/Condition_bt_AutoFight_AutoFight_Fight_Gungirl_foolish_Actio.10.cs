using System;

namespace behaviac
{
	// Token: 0x02001FA0 RID: 8096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node23 : Condition
	{
		// Token: 0x060128DF RID: 75999 RVA: 0x0056F533 File Offset: 0x0056D933
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060128E0 RID: 76000 RVA: 0x0056F568 File Offset: 0x0056D968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2D0 RID: 49872
		private int opl_p0;

		// Token: 0x0400C2D1 RID: 49873
		private int opl_p1;

		// Token: 0x0400C2D2 RID: 49874
		private int opl_p2;

		// Token: 0x0400C2D3 RID: 49875
		private int opl_p3;
	}
}
