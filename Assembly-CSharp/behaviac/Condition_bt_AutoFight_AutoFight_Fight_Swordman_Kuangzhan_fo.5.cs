using System;

namespace behaviac
{
	// Token: 0x0200233A RID: 9018
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node12 : Condition
	{
		// Token: 0x06012FE4 RID: 77796 RVA: 0x0059E123 File Offset: 0x0059C523
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012FE5 RID: 77797 RVA: 0x0059E140 File Offset: 0x0059C540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9FC RID: 51708
		private BE_Target opl_p0;

		// Token: 0x0400C9FD RID: 51709
		private BE_Equal opl_p1;

		// Token: 0x0400C9FE RID: 51710
		private BE_State opl_p2;
	}
}
