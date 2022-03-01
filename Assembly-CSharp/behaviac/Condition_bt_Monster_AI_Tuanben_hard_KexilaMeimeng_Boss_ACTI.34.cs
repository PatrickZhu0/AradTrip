using System;

namespace behaviac
{
	// Token: 0x02003C3B RID: 15419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node37 : Condition
	{
		// Token: 0x06016020 RID: 90144 RVA: 0x006A6936 File Offset: 0x006A4D36
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06016021 RID: 90145 RVA: 0x006A6958 File Offset: 0x006A4D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F896 RID: 63638
		private BE_Target opl_p0;

		// Token: 0x0400F897 RID: 63639
		private BE_Equal opl_p1;

		// Token: 0x0400F898 RID: 63640
		private int opl_p2;
	}
}
