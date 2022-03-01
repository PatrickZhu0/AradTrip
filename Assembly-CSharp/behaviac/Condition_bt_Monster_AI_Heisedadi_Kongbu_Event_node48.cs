using System;

namespace behaviac
{
	// Token: 0x020034C5 RID: 13509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node48 : Condition
	{
		// Token: 0x060151D0 RID: 86480 RVA: 0x0065C63B File Offset: 0x0065AA3B
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node48()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521752;
		}

		// Token: 0x060151D1 RID: 86481 RVA: 0x0065C65C File Offset: 0x0065AA5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EADB RID: 60123
		private BE_Target opl_p0;

		// Token: 0x0400EADC RID: 60124
		private BE_Equal opl_p1;

		// Token: 0x0400EADD RID: 60125
		private int opl_p2;
	}
}
