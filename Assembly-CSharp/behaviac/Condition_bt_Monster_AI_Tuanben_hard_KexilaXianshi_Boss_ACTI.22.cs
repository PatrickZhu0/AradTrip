using System;

namespace behaviac
{
	// Token: 0x02003C84 RID: 15492
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node14 : Condition
	{
		// Token: 0x060160AF RID: 90287 RVA: 0x006A9382 File Offset: 0x006A7782
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node14()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570033;
		}

		// Token: 0x060160B0 RID: 90288 RVA: 0x006A93A4 File Offset: 0x006A77A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F943 RID: 63811
		private BE_Target opl_p0;

		// Token: 0x0400F944 RID: 63812
		private BE_Equal opl_p1;

		// Token: 0x0400F945 RID: 63813
		private int opl_p2;
	}
}
