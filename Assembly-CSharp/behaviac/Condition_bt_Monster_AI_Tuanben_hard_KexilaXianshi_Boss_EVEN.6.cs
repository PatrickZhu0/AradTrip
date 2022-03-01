using System;

namespace behaviac
{
	// Token: 0x02003CC7 RID: 15559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node9 : Condition
	{
		// Token: 0x06016130 RID: 90416 RVA: 0x006AC55F File Offset: 0x006AA95F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x06016131 RID: 90417 RVA: 0x006AC580 File Offset: 0x006AA980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9E0 RID: 63968
		private BE_Target opl_p0;

		// Token: 0x0400F9E1 RID: 63969
		private BE_Equal opl_p1;

		// Token: 0x0400F9E2 RID: 63970
		private int opl_p2;
	}
}
