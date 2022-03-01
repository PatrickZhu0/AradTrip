using System;

namespace behaviac
{
	// Token: 0x0200236A RID: 9066
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node12 : Condition
	{
		// Token: 0x0601303E RID: 77886 RVA: 0x005A03EF File Offset: 0x0059E7EF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601303F RID: 77887 RVA: 0x005A040C File Offset: 0x0059E80C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA55 RID: 51797
		private BE_Target opl_p0;

		// Token: 0x0400CA56 RID: 51798
		private BE_Equal opl_p1;

		// Token: 0x0400CA57 RID: 51799
		private BE_State opl_p2;
	}
}
