using System;

namespace behaviac
{
	// Token: 0x020029C8 RID: 10696
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node96 : Condition
	{
		// Token: 0x06013CC4 RID: 81092 RVA: 0x005EB7AD File Offset: 0x005E9BAD
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node96()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013CC5 RID: 81093 RVA: 0x005EB7CC File Offset: 0x005E9BCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D733 RID: 55091
		private BE_Target opl_p0;

		// Token: 0x0400D734 RID: 55092
		private BE_Equal opl_p1;

		// Token: 0x0400D735 RID: 55093
		private BE_State opl_p2;
	}
}
