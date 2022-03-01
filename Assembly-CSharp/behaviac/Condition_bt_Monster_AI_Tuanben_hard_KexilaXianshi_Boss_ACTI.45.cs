using System;

namespace behaviac
{
	// Token: 0x02003CA3 RID: 15523
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node89 : Condition
	{
		// Token: 0x060160ED RID: 90349 RVA: 0x006AA183 File Offset: 0x006A8583
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node89()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x060160EE RID: 90350 RVA: 0x006AA1A4 File Offset: 0x006A85A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F990 RID: 63888
		private BE_Target opl_p0;

		// Token: 0x0400F991 RID: 63889
		private BE_Equal opl_p1;

		// Token: 0x0400F992 RID: 63890
		private int opl_p2;
	}
}
