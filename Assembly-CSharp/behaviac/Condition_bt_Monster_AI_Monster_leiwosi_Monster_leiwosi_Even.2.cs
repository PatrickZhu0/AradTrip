using System;

namespace behaviac
{
	// Token: 0x020036BE RID: 14014
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5 : Condition
	{
		// Token: 0x06015595 RID: 87445 RVA: 0x00670BED File Offset: 0x0066EFED
		public Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06015596 RID: 87446 RVA: 0x00670C0C File Offset: 0x0066F00C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF69 RID: 61289
		private BE_Target opl_p0;

		// Token: 0x0400EF6A RID: 61290
		private BE_Equal opl_p1;

		// Token: 0x0400EF6B RID: 61291
		private BE_State opl_p2;
	}
}
