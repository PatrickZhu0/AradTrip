using System;

namespace behaviac
{
	// Token: 0x020023F6 RID: 9206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node39 : Condition
	{
		// Token: 0x0601314B RID: 78155 RVA: 0x005A7FA1 File Offset: 0x005A63A1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601314C RID: 78156 RVA: 0x005A7FC0 File Offset: 0x005A63C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB75 RID: 52085
		private BE_Target opl_p0;

		// Token: 0x0400CB76 RID: 52086
		private BE_Equal opl_p1;

		// Token: 0x0400CB77 RID: 52087
		private BE_State opl_p2;
	}
}
