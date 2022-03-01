using System;

namespace behaviac
{
	// Token: 0x02003801 RID: 14337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4 : Condition
	{
		// Token: 0x060157F3 RID: 88051 RVA: 0x0067CEED File Offset: 0x0067B2ED
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521623;
		}

		// Token: 0x060157F4 RID: 88052 RVA: 0x0067CF10 File Offset: 0x0067B310
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1B9 RID: 61881
		private BE_Target opl_p0;

		// Token: 0x0400F1BA RID: 61882
		private BE_Equal opl_p1;

		// Token: 0x0400F1BB RID: 61883
		private int opl_p2;
	}
}
