using System;

namespace behaviac
{
	// Token: 0x02003BCB RID: 15307
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node51 : Condition
	{
		// Token: 0x06015F43 RID: 89923 RVA: 0x006A27E9 File Offset: 0x006A0BE9
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570218;
		}

		// Token: 0x06015F44 RID: 89924 RVA: 0x006A280C File Offset: 0x006A0C0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7D6 RID: 63446
		private BE_Target opl_p0;

		// Token: 0x0400F7D7 RID: 63447
		private BE_Equal opl_p1;

		// Token: 0x0400F7D8 RID: 63448
		private int opl_p2;
	}
}
