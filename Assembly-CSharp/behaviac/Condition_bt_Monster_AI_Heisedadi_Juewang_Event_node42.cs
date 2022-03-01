using System;

namespace behaviac
{
	// Token: 0x02003499 RID: 13465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node42 : Condition
	{
		// Token: 0x0601517B RID: 86395 RVA: 0x0065A942 File Offset: 0x00658D42
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node42()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x0601517C RID: 86396 RVA: 0x0065A964 File Offset: 0x00658D64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA7A RID: 60026
		private BE_Target opl_p0;

		// Token: 0x0400EA7B RID: 60027
		private BE_Equal opl_p1;

		// Token: 0x0400EA7C RID: 60028
		private int opl_p2;
	}
}
