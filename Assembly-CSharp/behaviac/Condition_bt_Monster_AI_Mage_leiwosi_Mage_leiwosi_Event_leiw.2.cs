using System;

namespace behaviac
{
	// Token: 0x020035AE RID: 13742
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3 : Condition
	{
		// Token: 0x0601538A RID: 86922 RVA: 0x006657FD File Offset: 0x00663BFD
		public Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x0601538B RID: 86923 RVA: 0x0066581C File Offset: 0x00663C1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED58 RID: 60760
		private BE_Target opl_p0;

		// Token: 0x0400ED59 RID: 60761
		private BE_Equal opl_p1;

		// Token: 0x0400ED5A RID: 60762
		private BE_State opl_p2;
	}
}
