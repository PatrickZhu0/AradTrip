using System;

namespace behaviac
{
	// Token: 0x02003477 RID: 13431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node44 : Condition
	{
		// Token: 0x06015137 RID: 86327 RVA: 0x00659EBD File Offset: 0x006582BD
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node44()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015138 RID: 86328 RVA: 0x00659EE0 File Offset: 0x006582E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA36 RID: 59958
		private BE_Target opl_p0;

		// Token: 0x0400EA37 RID: 59959
		private BE_Equal opl_p1;

		// Token: 0x0400EA38 RID: 59960
		private int opl_p2;
	}
}
