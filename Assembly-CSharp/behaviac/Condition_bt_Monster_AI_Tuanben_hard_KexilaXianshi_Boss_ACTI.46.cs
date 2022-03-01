using System;

namespace behaviac
{
	// Token: 0x02003CA4 RID: 15524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node74 : Condition
	{
		// Token: 0x060160EF RID: 90351 RVA: 0x006AA1E3 File Offset: 0x006A85E3
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node74()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x060160F0 RID: 90352 RVA: 0x006AA204 File Offset: 0x006A8604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F993 RID: 63891
		private BE_Target opl_p0;

		// Token: 0x0400F994 RID: 63892
		private BE_Equal opl_p1;

		// Token: 0x0400F995 RID: 63893
		private int opl_p2;
	}
}
