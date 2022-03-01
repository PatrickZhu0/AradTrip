using System;

namespace behaviac
{
	// Token: 0x02003CA0 RID: 15520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node73 : Condition
	{
		// Token: 0x060160E7 RID: 90343 RVA: 0x006AA062 File Offset: 0x006A8462
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node73()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570033;
		}

		// Token: 0x060160E8 RID: 90344 RVA: 0x006AA084 File Offset: 0x006A8484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F987 RID: 63879
		private BE_Target opl_p0;

		// Token: 0x0400F988 RID: 63880
		private BE_Equal opl_p1;

		// Token: 0x0400F989 RID: 63881
		private int opl_p2;
	}
}
