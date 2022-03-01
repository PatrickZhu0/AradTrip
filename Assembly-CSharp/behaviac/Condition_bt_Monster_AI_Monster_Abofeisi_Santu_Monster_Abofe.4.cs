using System;

namespace behaviac
{
	// Token: 0x020035E6 RID: 13798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node24 : Condition
	{
		// Token: 0x060153F4 RID: 87028 RVA: 0x0066799F File Offset: 0x00665D9F
		public Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node24()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060153F5 RID: 87029 RVA: 0x006679BC File Offset: 0x00665DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB0 RID: 60848
		private BE_Target opl_p0;

		// Token: 0x0400EDB1 RID: 60849
		private BE_Equal opl_p1;

		// Token: 0x0400EDB2 RID: 60850
		private BE_State opl_p2;
	}
}
