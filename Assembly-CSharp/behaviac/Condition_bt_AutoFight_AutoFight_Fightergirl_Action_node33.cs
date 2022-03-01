using System;

namespace behaviac
{
	// Token: 0x02001EEC RID: 7916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node33 : Condition
	{
		// Token: 0x0601277D RID: 75645 RVA: 0x00566CBF File Offset: 0x005650BF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node33()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601277E RID: 75646 RVA: 0x00566CDC File Offset: 0x005650DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C172 RID: 49522
		private BE_Target opl_p0;

		// Token: 0x0400C173 RID: 49523
		private BE_Equal opl_p1;

		// Token: 0x0400C174 RID: 49524
		private BE_State opl_p2;
	}
}
