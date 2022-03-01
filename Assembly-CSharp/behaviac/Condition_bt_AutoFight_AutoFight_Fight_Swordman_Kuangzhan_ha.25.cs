using System;

namespace behaviac
{
	// Token: 0x02002387 RID: 9095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node52 : Condition
	{
		// Token: 0x06013075 RID: 77941 RVA: 0x005A10D5 File Offset: 0x0059F4D5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013076 RID: 77942 RVA: 0x005A10F4 File Offset: 0x0059F4F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA8B RID: 51851
		private BE_Target opl_p0;

		// Token: 0x0400CA8C RID: 51852
		private BE_Equal opl_p1;

		// Token: 0x0400CA8D RID: 51853
		private BE_State opl_p2;
	}
}
