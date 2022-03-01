using System;

namespace behaviac
{
	// Token: 0x02002360 RID: 9056
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node61 : Condition
	{
		// Token: 0x0601302D RID: 77869 RVA: 0x0059F1B7 File Offset: 0x0059D5B7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node61()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601302E RID: 77870 RVA: 0x0059F1EC File Offset: 0x0059D5EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA44 RID: 51780
		private int opl_p0;

		// Token: 0x0400CA45 RID: 51781
		private int opl_p1;

		// Token: 0x0400CA46 RID: 51782
		private int opl_p2;

		// Token: 0x0400CA47 RID: 51783
		private int opl_p3;
	}
}
