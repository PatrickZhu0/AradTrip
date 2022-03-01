using System;

namespace behaviac
{
	// Token: 0x02003A25 RID: 14885
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node7 : Condition
	{
		// Token: 0x06015C14 RID: 89108 RVA: 0x0069210A File Offset: 0x0069050A
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015C15 RID: 89109 RVA: 0x0069212C File Offset: 0x0069052C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F52B RID: 62763
		private BE_Target opl_p0;

		// Token: 0x0400F52C RID: 62764
		private BE_Equal opl_p1;

		// Token: 0x0400F52D RID: 62765
		private int opl_p2;
	}
}
