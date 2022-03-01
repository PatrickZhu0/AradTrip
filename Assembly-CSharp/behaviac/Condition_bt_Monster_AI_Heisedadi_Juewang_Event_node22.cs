using System;

namespace behaviac
{
	// Token: 0x0200348E RID: 13454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node22 : Condition
	{
		// Token: 0x06015165 RID: 86373 RVA: 0x0065A5F6 File Offset: 0x006589F6
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node22()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015166 RID: 86374 RVA: 0x0065A618 File Offset: 0x00658A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA62 RID: 60002
		private BE_Target opl_p0;

		// Token: 0x0400EA63 RID: 60003
		private BE_Equal opl_p1;

		// Token: 0x0400EA64 RID: 60004
		private int opl_p2;
	}
}
