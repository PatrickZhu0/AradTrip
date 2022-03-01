using System;

namespace behaviac
{
	// Token: 0x0200344A RID: 13386
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node32 : Condition
	{
		// Token: 0x060150E0 RID: 86240 RVA: 0x00658182 File Offset: 0x00656582
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node32()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521856;
		}

		// Token: 0x060150E1 RID: 86241 RVA: 0x006581A4 File Offset: 0x006565A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9B8 RID: 59832
		private BE_Target opl_p0;

		// Token: 0x0400E9B9 RID: 59833
		private BE_Equal opl_p1;

		// Token: 0x0400E9BA RID: 59834
		private int opl_p2;
	}
}
