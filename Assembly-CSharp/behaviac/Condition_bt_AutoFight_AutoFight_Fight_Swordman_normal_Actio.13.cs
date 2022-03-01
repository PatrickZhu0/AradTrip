using System;

namespace behaviac
{
	// Token: 0x0200244B RID: 9291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node39 : Condition
	{
		// Token: 0x060131EA RID: 78314 RVA: 0x005ABFE9 File Offset: 0x005AA3E9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060131EB RID: 78315 RVA: 0x005AC008 File Offset: 0x005AA408
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC12 RID: 52242
		private BE_Target opl_p0;

		// Token: 0x0400CC13 RID: 52243
		private BE_Equal opl_p1;

		// Token: 0x0400CC14 RID: 52244
		private BE_State opl_p2;
	}
}
