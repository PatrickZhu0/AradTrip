using System;

namespace behaviac
{
	// Token: 0x02002459 RID: 9305
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node12 : Condition
	{
		// Token: 0x06013204 RID: 78340 RVA: 0x005ACE3F File Offset: 0x005AB23F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013205 RID: 78341 RVA: 0x005ACE5C File Offset: 0x005AB25C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC29 RID: 52265
		private BE_Target opl_p0;

		// Token: 0x0400CC2A RID: 52266
		private BE_Equal opl_p1;

		// Token: 0x0400CC2B RID: 52267
		private BE_State opl_p2;
	}
}
