using System;

namespace behaviac
{
	// Token: 0x0200290C RID: 10508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node56 : Condition
	{
		// Token: 0x06013B4E RID: 80718 RVA: 0x005E3BF3 File Offset: 0x005E1FF3
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06013B4F RID: 80719 RVA: 0x005E3C10 File Offset: 0x005E2010
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5B2 RID: 54706
		private BE_Target opl_p0;

		// Token: 0x0400D5B3 RID: 54707
		private BE_Equal opl_p1;

		// Token: 0x0400D5B4 RID: 54708
		private BE_State opl_p2;
	}
}
