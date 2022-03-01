using System;

namespace behaviac
{
	// Token: 0x02003A7F RID: 14975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node15 : Condition
	{
		// Token: 0x06015CC5 RID: 89285 RVA: 0x00696543 File Offset: 0x00694943
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node15()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06015CC6 RID: 89286 RVA: 0x00696564 File Offset: 0x00694964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5FE RID: 62974
		private BE_Target opl_p0;

		// Token: 0x0400F5FF RID: 62975
		private BE_Equal opl_p1;

		// Token: 0x0400F600 RID: 62976
		private int opl_p2;
	}
}
