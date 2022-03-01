using System;

namespace behaviac
{
	// Token: 0x02003C79 RID: 15481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node90 : Condition
	{
		// Token: 0x06016099 RID: 90265 RVA: 0x006A8F6B File Offset: 0x006A736B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node90()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570034;
		}

		// Token: 0x0601609A RID: 90266 RVA: 0x006A8F8C File Offset: 0x006A738C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F927 RID: 63783
		private BE_Target opl_p0;

		// Token: 0x0400F928 RID: 63784
		private BE_Equal opl_p1;

		// Token: 0x0400F929 RID: 63785
		private int opl_p2;
	}
}
