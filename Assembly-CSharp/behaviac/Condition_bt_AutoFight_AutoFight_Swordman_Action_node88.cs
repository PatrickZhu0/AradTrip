using System;

namespace behaviac
{
	// Token: 0x0200286D RID: 10349
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node88 : Condition
	{
		// Token: 0x06013A17 RID: 80407 RVA: 0x005DC5ED File Offset: 0x005DA9ED
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node88()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013A18 RID: 80408 RVA: 0x005DC60C File Offset: 0x005DAA0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D470 RID: 54384
		private BE_Target opl_p0;

		// Token: 0x0400D471 RID: 54385
		private BE_Equal opl_p1;

		// Token: 0x0400D472 RID: 54386
		private BE_State opl_p2;
	}
}
