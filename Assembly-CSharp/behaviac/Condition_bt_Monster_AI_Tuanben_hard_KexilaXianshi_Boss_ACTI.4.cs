using System;

namespace behaviac
{
	// Token: 0x02003C6C RID: 15468
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node98 : Condition
	{
		// Token: 0x0601607F RID: 90239 RVA: 0x006A8A1B File Offset: 0x006A6E1B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570035;
		}

		// Token: 0x06016080 RID: 90240 RVA: 0x006A8A3C File Offset: 0x006A6E3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F904 RID: 63748
		private BE_Target opl_p0;

		// Token: 0x0400F905 RID: 63749
		private BE_Equal opl_p1;

		// Token: 0x0400F906 RID: 63750
		private int opl_p2;
	}
}
