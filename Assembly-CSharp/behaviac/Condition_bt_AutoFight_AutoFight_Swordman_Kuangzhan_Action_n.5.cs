using System;

namespace behaviac
{
	// Token: 0x02002948 RID: 10568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node98 : Condition
	{
		// Token: 0x06013BC5 RID: 80837 RVA: 0x005E6CA3 File Offset: 0x005E50A3
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node98()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06013BC6 RID: 80838 RVA: 0x005E6CC0 File Offset: 0x005E50C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D62A RID: 54826
		private BE_Target opl_p0;

		// Token: 0x0400D62B RID: 54827
		private BE_Equal opl_p1;

		// Token: 0x0400D62C RID: 54828
		private BE_State opl_p2;
	}
}
