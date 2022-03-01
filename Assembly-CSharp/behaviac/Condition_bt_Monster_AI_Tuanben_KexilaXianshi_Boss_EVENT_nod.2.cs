using System;

namespace behaviac
{
	// Token: 0x02003A88 RID: 14984
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node89 : Condition
	{
		// Token: 0x06015CD5 RID: 89301 RVA: 0x0069694B File Offset: 0x00694D4B
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node89()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570106;
		}

		// Token: 0x06015CD6 RID: 89302 RVA: 0x0069696C File Offset: 0x00694D6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F60C RID: 62988
		private BE_Target opl_p0;

		// Token: 0x0400F60D RID: 62989
		private BE_Equal opl_p1;

		// Token: 0x0400F60E RID: 62990
		private int opl_p2;
	}
}
