using System;

namespace behaviac
{
	// Token: 0x02002357 RID: 9047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node52 : Condition
	{
		// Token: 0x0601301B RID: 77851 RVA: 0x0059EE09 File Offset: 0x0059D209
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601301C RID: 77852 RVA: 0x0059EE28 File Offset: 0x0059D228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA32 RID: 51762
		private BE_Target opl_p0;

		// Token: 0x0400CA33 RID: 51763
		private BE_Equal opl_p1;

		// Token: 0x0400CA34 RID: 51764
		private BE_State opl_p2;
	}
}
