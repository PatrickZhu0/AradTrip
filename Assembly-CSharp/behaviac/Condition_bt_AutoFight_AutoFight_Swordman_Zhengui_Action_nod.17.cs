using System;

namespace behaviac
{
	// Token: 0x02002992 RID: 10642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node119 : Condition
	{
		// Token: 0x06013C58 RID: 80984 RVA: 0x005EA015 File Offset: 0x005E8415
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node119()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013C59 RID: 80985 RVA: 0x005EA034 File Offset: 0x005E8434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6C2 RID: 54978
		private BE_Target opl_p0;

		// Token: 0x0400D6C3 RID: 54979
		private BE_Equal opl_p1;

		// Token: 0x0400D6C4 RID: 54980
		private BE_State opl_p2;
	}
}
