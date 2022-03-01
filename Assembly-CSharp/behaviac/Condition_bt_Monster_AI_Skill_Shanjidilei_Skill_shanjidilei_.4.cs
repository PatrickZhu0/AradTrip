using System;

namespace behaviac
{
	// Token: 0x02003746 RID: 14150
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node3 : Condition
	{
		// Token: 0x06015695 RID: 87701 RVA: 0x00675DD5 File Offset: 0x006741D5
		public Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.IDLEE;
		}

		// Token: 0x06015696 RID: 87702 RVA: 0x00675DF4 File Offset: 0x006741F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F06E RID: 61550
		private BE_Target opl_p0;

		// Token: 0x0400F06F RID: 61551
		private BE_Equal opl_p1;

		// Token: 0x0400F070 RID: 61552
		private BE_State opl_p2;
	}
}
