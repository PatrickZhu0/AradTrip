using System;

namespace behaviac
{
	// Token: 0x020035DC RID: 13788
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node7 : Condition
	{
		// Token: 0x060153E1 RID: 87009 RVA: 0x006673DE File Offset: 0x006657DE
		public Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060153E2 RID: 87010 RVA: 0x006673FC File Offset: 0x006657FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA2 RID: 60834
		private BE_Target opl_p0;

		// Token: 0x0400EDA3 RID: 60835
		private BE_Equal opl_p1;

		// Token: 0x0400EDA4 RID: 60836
		private BE_State opl_p2;
	}
}
