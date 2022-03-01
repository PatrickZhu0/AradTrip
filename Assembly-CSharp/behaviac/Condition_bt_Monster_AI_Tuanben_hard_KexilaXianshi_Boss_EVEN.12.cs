using System;

namespace behaviac
{
	// Token: 0x02003CD5 RID: 15573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node5 : Condition
	{
		// Token: 0x0601614C RID: 90444 RVA: 0x006AC944 File Offset: 0x006AAD44
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570144;
		}

		// Token: 0x0601614D RID: 90445 RVA: 0x006AC968 File Offset: 0x006AAD68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9FD RID: 63997
		private BE_Target opl_p0;

		// Token: 0x0400F9FE RID: 63998
		private BE_Equal opl_p1;

		// Token: 0x0400F9FF RID: 63999
		private int opl_p2;
	}
}
