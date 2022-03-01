using System;

namespace behaviac
{
	// Token: 0x02002989 RID: 10633
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node31 : Condition
	{
		// Token: 0x06013C46 RID: 80966 RVA: 0x005E9C4D File Offset: 0x005E804D
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node31()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013C47 RID: 80967 RVA: 0x005E9C6C File Offset: 0x005E806C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6AF RID: 54959
		private BE_Target opl_p0;

		// Token: 0x0400D6B0 RID: 54960
		private BE_Equal opl_p1;

		// Token: 0x0400D6B1 RID: 54961
		private BE_State opl_p2;
	}
}
