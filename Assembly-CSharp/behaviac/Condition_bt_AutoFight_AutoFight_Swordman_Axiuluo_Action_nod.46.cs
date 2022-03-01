using System;

namespace behaviac
{
	// Token: 0x020028D3 RID: 10451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node65 : Condition
	{
		// Token: 0x06013AE0 RID: 80608 RVA: 0x005E019D File Offset: 0x005DE59D
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node65()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013AE1 RID: 80609 RVA: 0x005E01BC File Offset: 0x005DE5BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D541 RID: 54593
		private BE_Target opl_p0;

		// Token: 0x0400D542 RID: 54594
		private BE_Equal opl_p1;

		// Token: 0x0400D543 RID: 54595
		private BE_State opl_p2;
	}
}
