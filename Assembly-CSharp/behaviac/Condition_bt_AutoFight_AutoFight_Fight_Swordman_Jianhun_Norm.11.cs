using System;

namespace behaviac
{
	// Token: 0x020022F7 RID: 8951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node9 : Condition
	{
		// Token: 0x06012F67 RID: 77671 RVA: 0x0059AA33 File Offset: 0x00598E33
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node9()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012F68 RID: 77672 RVA: 0x0059AA68 File Offset: 0x00598E68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C97D RID: 51581
		private int opl_p0;

		// Token: 0x0400C97E RID: 51582
		private int opl_p1;

		// Token: 0x0400C97F RID: 51583
		private int opl_p2;

		// Token: 0x0400C980 RID: 51584
		private int opl_p3;
	}
}
