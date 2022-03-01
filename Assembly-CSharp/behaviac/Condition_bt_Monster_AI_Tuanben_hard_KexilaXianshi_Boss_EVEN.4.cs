using System;

namespace behaviac
{
	// Token: 0x02003CC0 RID: 15552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node51 : Condition
	{
		// Token: 0x06016122 RID: 90402 RVA: 0x006AC325 File Offset: 0x006AA725
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x06016123 RID: 90403 RVA: 0x006AC348 File Offset: 0x006AA748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9CB RID: 63947
		private BE_Target opl_p0;

		// Token: 0x0400F9CC RID: 63948
		private BE_Equal opl_p1;

		// Token: 0x0400F9CD RID: 63949
		private int opl_p2;
	}
}
