using System;

namespace behaviac
{
	// Token: 0x0200235B RID: 9051
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node55 : Condition
	{
		// Token: 0x06013023 RID: 77859 RVA: 0x0059EFA3 File Offset: 0x0059D3A3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013024 RID: 77860 RVA: 0x0059EFD8 File Offset: 0x0059D3D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA39 RID: 51769
		private int opl_p0;

		// Token: 0x0400CA3A RID: 51770
		private int opl_p1;

		// Token: 0x0400CA3B RID: 51771
		private int opl_p2;

		// Token: 0x0400CA3C RID: 51772
		private int opl_p3;
	}
}
