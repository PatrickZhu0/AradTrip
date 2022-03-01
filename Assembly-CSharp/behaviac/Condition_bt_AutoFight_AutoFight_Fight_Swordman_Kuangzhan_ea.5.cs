using System;

namespace behaviac
{
	// Token: 0x0200230A RID: 8970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node12 : Condition
	{
		// Token: 0x06012F8A RID: 77706 RVA: 0x0059BE57 File Offset: 0x0059A257
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012F8B RID: 77707 RVA: 0x0059BE74 File Offset: 0x0059A274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9A3 RID: 51619
		private BE_Target opl_p0;

		// Token: 0x0400C9A4 RID: 51620
		private BE_Equal opl_p1;

		// Token: 0x0400C9A5 RID: 51621
		private BE_State opl_p2;
	}
}
