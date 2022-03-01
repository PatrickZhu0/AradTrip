using System;

namespace behaviac
{
	// Token: 0x0200232C RID: 9004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node56 : Condition
	{
		// Token: 0x06012FCB RID: 77771 RVA: 0x0059CD51 File Offset: 0x0059B151
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012FCC RID: 77772 RVA: 0x0059CD70 File Offset: 0x0059B170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9E4 RID: 51684
		private BE_Target opl_p0;

		// Token: 0x0400C9E5 RID: 51685
		private BE_Equal opl_p1;

		// Token: 0x0400C9E6 RID: 51686
		private BE_State opl_p2;
	}
}
