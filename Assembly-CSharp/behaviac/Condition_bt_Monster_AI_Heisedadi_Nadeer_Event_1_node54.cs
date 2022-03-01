using System;

namespace behaviac
{
	// Token: 0x02003528 RID: 13608
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node54 : Condition
	{
		// Token: 0x06015293 RID: 86675 RVA: 0x0065FA54 File Offset: 0x0065DE54
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node54()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521774;
		}

		// Token: 0x06015294 RID: 86676 RVA: 0x0065FA78 File Offset: 0x0065DE78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC0C RID: 60428
		private BE_Target opl_p0;

		// Token: 0x0400EC0D RID: 60429
		private BE_Equal opl_p1;

		// Token: 0x0400EC0E RID: 60430
		private int opl_p2;
	}
}
