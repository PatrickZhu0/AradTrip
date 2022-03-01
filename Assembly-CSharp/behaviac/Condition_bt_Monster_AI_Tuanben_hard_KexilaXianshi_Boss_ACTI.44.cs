using System;

namespace behaviac
{
	// Token: 0x02003CA2 RID: 15522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node88 : Condition
	{
		// Token: 0x060160EB RID: 90347 RVA: 0x006AA123 File Offset: 0x006A8523
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node88()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570035;
		}

		// Token: 0x060160EC RID: 90348 RVA: 0x006AA144 File Offset: 0x006A8544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F98D RID: 63885
		private BE_Target opl_p0;

		// Token: 0x0400F98E RID: 63886
		private BE_Equal opl_p1;

		// Token: 0x0400F98F RID: 63887
		private int opl_p2;
	}
}
