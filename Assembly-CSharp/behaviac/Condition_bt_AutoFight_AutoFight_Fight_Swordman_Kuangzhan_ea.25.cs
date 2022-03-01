using System;

namespace behaviac
{
	// Token: 0x02002327 RID: 8999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node52 : Condition
	{
		// Token: 0x06012FC1 RID: 77761 RVA: 0x0059CB3D File Offset: 0x0059AF3D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012FC2 RID: 77762 RVA: 0x0059CB5C File Offset: 0x0059AF5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9D9 RID: 51673
		private BE_Target opl_p0;

		// Token: 0x0400C9DA RID: 51674
		private BE_Equal opl_p1;

		// Token: 0x0400C9DB RID: 51675
		private BE_State opl_p2;
	}
}
