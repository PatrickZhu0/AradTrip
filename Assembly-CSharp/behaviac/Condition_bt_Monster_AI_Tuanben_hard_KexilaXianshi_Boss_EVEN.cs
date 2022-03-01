using System;

namespace behaviac
{
	// Token: 0x02003CBA RID: 15546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node50 : Condition
	{
		// Token: 0x06016116 RID: 90390 RVA: 0x006AC113 File Offset: 0x006AA513
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node50()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x06016117 RID: 90391 RVA: 0x006AC134 File Offset: 0x006AA534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9B9 RID: 63929
		private BE_Target opl_p0;

		// Token: 0x0400F9BA RID: 63930
		private BE_Equal opl_p1;

		// Token: 0x0400F9BB RID: 63931
		private int opl_p2;
	}
}
