using System;

namespace behaviac
{
	// Token: 0x0200314A RID: 12618
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node5 : Condition
	{
		// Token: 0x06014B36 RID: 84790 RVA: 0x0063C013 File Offset: 0x0063A413
		public Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522977;
		}

		// Token: 0x06014B37 RID: 84791 RVA: 0x0063C034 File Offset: 0x0063A434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4AE RID: 58542
		private BE_Target opl_p0;

		// Token: 0x0400E4AF RID: 58543
		private BE_Equal opl_p1;

		// Token: 0x0400E4B0 RID: 58544
		private int opl_p2;
	}
}
