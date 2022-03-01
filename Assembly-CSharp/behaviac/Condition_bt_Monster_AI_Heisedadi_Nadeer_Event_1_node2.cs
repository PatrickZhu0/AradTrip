using System;

namespace behaviac
{
	// Token: 0x020034E8 RID: 13544
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node2 : Condition
	{
		// Token: 0x06015213 RID: 86547 RVA: 0x0065E512 File Offset: 0x0065C912
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521746;
		}

		// Token: 0x06015214 RID: 86548 RVA: 0x0065E534 File Offset: 0x0065C934
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB2B RID: 60203
		private BE_Target opl_p0;

		// Token: 0x0400EB2C RID: 60204
		private BE_Equal opl_p1;

		// Token: 0x0400EB2D RID: 60205
		private int opl_p2;
	}
}
