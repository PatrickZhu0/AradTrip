using System;

namespace behaviac
{
	// Token: 0x020029D1 RID: 10705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node65 : Condition
	{
		// Token: 0x06013CD6 RID: 81110 RVA: 0x005EBC2D File Offset: 0x005EA02D
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node65()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013CD7 RID: 81111 RVA: 0x005EBC4C File Offset: 0x005EA04C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D746 RID: 55110
		private BE_Target opl_p0;

		// Token: 0x0400D747 RID: 55111
		private BE_Equal opl_p1;

		// Token: 0x0400D748 RID: 55112
		private BE_State opl_p2;
	}
}
