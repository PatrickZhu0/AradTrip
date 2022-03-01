using System;

namespace behaviac
{
	// Token: 0x0200349A RID: 13466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node43 : Condition
	{
		// Token: 0x0601517D RID: 86397 RVA: 0x0065A9A6 File Offset: 0x00658DA6
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node43()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 69;
		}

		// Token: 0x0601517E RID: 86398 RVA: 0x0065A9C4 File Offset: 0x00658DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA7D RID: 60029
		private BE_Target opl_p0;

		// Token: 0x0400EA7E RID: 60030
		private BE_Equal opl_p1;

		// Token: 0x0400EA7F RID: 60031
		private int opl_p2;
	}
}
