using System;

namespace behaviac
{
	// Token: 0x02003CCC RID: 15564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node68 : Condition
	{
		// Token: 0x0601613A RID: 90426 RVA: 0x006AC6CD File Offset: 0x006AAACD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node68()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x0601613B RID: 90427 RVA: 0x006AC6F0 File Offset: 0x006AAAF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9EB RID: 63979
		private BE_Target opl_p0;

		// Token: 0x0400F9EC RID: 63980
		private BE_Equal opl_p1;

		// Token: 0x0400F9ED RID: 63981
		private int opl_p2;
	}
}
