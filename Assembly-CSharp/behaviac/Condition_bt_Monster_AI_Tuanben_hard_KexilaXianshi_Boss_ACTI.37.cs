using System;

namespace behaviac
{
	// Token: 0x02003C99 RID: 15513
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node37 : Condition
	{
		// Token: 0x060160D9 RID: 90329 RVA: 0x006A9D2A File Offset: 0x006A812A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570036;
		}

		// Token: 0x060160DA RID: 90330 RVA: 0x006A9D4C File Offset: 0x006A814C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F976 RID: 63862
		private BE_Target opl_p0;

		// Token: 0x0400F977 RID: 63863
		private BE_Equal opl_p1;

		// Token: 0x0400F978 RID: 63864
		private int opl_p2;
	}
}
