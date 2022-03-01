using System;

namespace behaviac
{
	// Token: 0x020035ED RID: 13805
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node4 : Condition
	{
		// Token: 0x06015401 RID: 87041 RVA: 0x00667EBD File Offset: 0x006662BD
		public Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06015402 RID: 87042 RVA: 0x00667EDC File Offset: 0x006662DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDBC RID: 60860
		private BE_Target opl_p0;

		// Token: 0x0400EDBD RID: 60861
		private BE_Equal opl_p1;

		// Token: 0x0400EDBE RID: 60862
		private BE_State opl_p2;
	}
}
