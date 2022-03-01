using System;

namespace behaviac
{
	// Token: 0x02001F1D RID: 7965
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node52 : Condition
	{
		// Token: 0x060127DE RID: 75742 RVA: 0x00568DC3 File Offset: 0x005671C3
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060127DF RID: 75743 RVA: 0x00568DE0 File Offset: 0x005671E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1D6 RID: 49622
		private BE_Target opl_p0;

		// Token: 0x0400C1D7 RID: 49623
		private BE_Equal opl_p1;

		// Token: 0x0400C1D8 RID: 49624
		private BE_State opl_p2;
	}
}
