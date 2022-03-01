using System;

namespace behaviac
{
	// Token: 0x02003A8B RID: 14987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node5 : Condition
	{
		// Token: 0x06015CDB RID: 89307 RVA: 0x00696A10 File Offset: 0x00694E10
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570144;
		}

		// Token: 0x06015CDC RID: 89308 RVA: 0x00696A34 File Offset: 0x00694E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F612 RID: 62994
		private BE_Target opl_p0;

		// Token: 0x0400F613 RID: 62995
		private BE_Equal opl_p1;

		// Token: 0x0400F614 RID: 62996
		private int opl_p2;
	}
}
