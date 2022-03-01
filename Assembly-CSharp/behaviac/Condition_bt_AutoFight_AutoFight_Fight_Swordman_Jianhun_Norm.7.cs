using System;

namespace behaviac
{
	// Token: 0x020022F2 RID: 8946
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node3 : Condition
	{
		// Token: 0x06012F5D RID: 77661 RVA: 0x0059A672 File Offset: 0x00598A72
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node3()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3500;
			this.opl_p3 = 3500;
		}

		// Token: 0x06012F5E RID: 77662 RVA: 0x0059A6A8 File Offset: 0x00598AA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C974 RID: 51572
		private int opl_p0;

		// Token: 0x0400C975 RID: 51573
		private int opl_p1;

		// Token: 0x0400C976 RID: 51574
		private int opl_p2;

		// Token: 0x0400C977 RID: 51575
		private int opl_p3;
	}
}
