using System;

namespace behaviac
{
	// Token: 0x0200250E RID: 9486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node73 : Condition
	{
		// Token: 0x06013366 RID: 78694 RVA: 0x005B41E1 File Offset: 0x005B25E1
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node73()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013367 RID: 78695 RVA: 0x005B4200 File Offset: 0x005B2600
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD88 RID: 52616
		private BE_Target opl_p0;

		// Token: 0x0400CD89 RID: 52617
		private BE_Equal opl_p1;

		// Token: 0x0400CD8A RID: 52618
		private BE_State opl_p2;
	}
}
