using System;

namespace behaviac
{
	// Token: 0x020034F7 RID: 13559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node25 : Condition
	{
		// Token: 0x06015231 RID: 86577 RVA: 0x0065E9E9 File Offset: 0x0065CDE9
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node25()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521749;
		}

		// Token: 0x06015232 RID: 86578 RVA: 0x0065EA0C File Offset: 0x0065CE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB5A RID: 60250
		private BE_Target opl_p0;

		// Token: 0x0400EB5B RID: 60251
		private BE_Equal opl_p1;

		// Token: 0x0400EB5C RID: 60252
		private int opl_p2;
	}
}
