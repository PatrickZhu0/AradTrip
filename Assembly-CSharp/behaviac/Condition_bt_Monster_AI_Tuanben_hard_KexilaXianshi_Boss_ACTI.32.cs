using System;

namespace behaviac
{
	// Token: 0x02003C92 RID: 15506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node29 : Condition
	{
		// Token: 0x060160CB RID: 90315 RVA: 0x006A99F2 File Offset: 0x006A7DF2
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node29()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570035;
		}

		// Token: 0x060160CC RID: 90316 RVA: 0x006A9A14 File Offset: 0x006A7E14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F965 RID: 63845
		private BE_Target opl_p0;

		// Token: 0x0400F966 RID: 63846
		private BE_Equal opl_p1;

		// Token: 0x0400F967 RID: 63847
		private int opl_p2;
	}
}
