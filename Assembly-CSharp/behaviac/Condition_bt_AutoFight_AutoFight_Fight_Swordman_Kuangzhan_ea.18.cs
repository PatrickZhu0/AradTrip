using System;

namespace behaviac
{
	// Token: 0x0200231E RID: 8990
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node39 : Condition
	{
		// Token: 0x06012FAF RID: 77743 RVA: 0x0059C719 File Offset: 0x0059AB19
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012FB0 RID: 77744 RVA: 0x0059C738 File Offset: 0x0059AB38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9C6 RID: 51654
		private BE_Target opl_p0;

		// Token: 0x0400C9C7 RID: 51655
		private BE_Equal opl_p1;

		// Token: 0x0400C9C8 RID: 51656
		private BE_State opl_p2;
	}
}
