using System;

namespace behaviac
{
	// Token: 0x02003BD7 RID: 15319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node68 : Condition
	{
		// Token: 0x06015F5B RID: 89947 RVA: 0x006A2B91 File Offset: 0x006A0F91
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node68()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570218;
		}

		// Token: 0x06015F5C RID: 89948 RVA: 0x006A2BB4 File Offset: 0x006A0FB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7F6 RID: 63478
		private BE_Target opl_p0;

		// Token: 0x0400F7F7 RID: 63479
		private BE_Equal opl_p1;

		// Token: 0x0400F7F8 RID: 63480
		private int opl_p2;
	}
}
