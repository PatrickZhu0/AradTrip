using System;

namespace behaviac
{
	// Token: 0x02003BD2 RID: 15314
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node70 : Condition
	{
		// Token: 0x06015F51 RID: 89937 RVA: 0x006A2A23 File Offset: 0x006A0E23
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node70()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570215;
		}

		// Token: 0x06015F52 RID: 89938 RVA: 0x006A2A44 File Offset: 0x006A0E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7EB RID: 63467
		private BE_Target opl_p0;

		// Token: 0x0400F7EC RID: 63468
		private BE_Equal opl_p1;

		// Token: 0x0400F7ED RID: 63469
		private int opl_p2;
	}
}
