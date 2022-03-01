using System;

namespace behaviac
{
	// Token: 0x02002280 RID: 8832
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node9 : Condition
	{
		// Token: 0x06012E82 RID: 77442 RVA: 0x00593B97 File Offset: 0x00591F97
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012E83 RID: 77443 RVA: 0x00593BB4 File Offset: 0x00591FB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C88E RID: 51342
		private BE_Target opl_p0;

		// Token: 0x0400C88F RID: 51343
		private BE_Equal opl_p1;

		// Token: 0x0400C890 RID: 51344
		private BE_State opl_p2;
	}
}
