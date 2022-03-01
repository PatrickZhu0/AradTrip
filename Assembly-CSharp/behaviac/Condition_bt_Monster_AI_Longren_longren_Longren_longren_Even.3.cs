using System;

namespace behaviac
{
	// Token: 0x020035A2 RID: 13730
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node6 : Condition
	{
		// Token: 0x06015373 RID: 86899 RVA: 0x00665045 File Offset: 0x00663445
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node6()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06015374 RID: 86900 RVA: 0x00665064 File Offset: 0x00663464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED3D RID: 60733
		private BE_Target opl_p0;

		// Token: 0x0400ED3E RID: 60734
		private BE_Equal opl_p1;

		// Token: 0x0400ED3F RID: 60735
		private BE_State opl_p2;
	}
}
