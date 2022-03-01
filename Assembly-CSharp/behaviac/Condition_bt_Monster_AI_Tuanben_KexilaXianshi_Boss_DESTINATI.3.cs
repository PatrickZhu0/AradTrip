using System;

namespace behaviac
{
	// Token: 0x02003A82 RID: 14978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node79 : Condition
	{
		// Token: 0x06015CCB RID: 89291 RVA: 0x0069664A File Offset: 0x00694A4A
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570105;
		}

		// Token: 0x06015CCC RID: 89292 RVA: 0x0069666C File Offset: 0x00694A6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F606 RID: 62982
		private BE_Target opl_p0;

		// Token: 0x0400F607 RID: 62983
		private BE_Equal opl_p1;

		// Token: 0x0400F608 RID: 62984
		private int opl_p2;
	}
}
