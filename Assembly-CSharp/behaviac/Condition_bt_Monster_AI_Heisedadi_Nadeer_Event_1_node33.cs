using System;

namespace behaviac
{
	// Token: 0x020034FD RID: 13565
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node33 : Condition
	{
		// Token: 0x0601523D RID: 86589 RVA: 0x0065EBE9 File Offset: 0x0065CFE9
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node33()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521748;
		}

		// Token: 0x0601523E RID: 86590 RVA: 0x0065EC0C File Offset: 0x0065D00C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB6E RID: 60270
		private BE_Target opl_p0;

		// Token: 0x0400EB6F RID: 60271
		private BE_Equal opl_p1;

		// Token: 0x0400EB70 RID: 60272
		private int opl_p2;
	}
}
