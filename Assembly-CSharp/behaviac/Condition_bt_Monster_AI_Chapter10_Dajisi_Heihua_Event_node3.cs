using System;

namespace behaviac
{
	// Token: 0x020030D6 RID: 12502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node3 : Condition
	{
		// Token: 0x06014A63 RID: 84579 RVA: 0x00637E0E File Offset: 0x0063620E
		public Condition_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522999;
		}

		// Token: 0x06014A64 RID: 84580 RVA: 0x00637E30 File Offset: 0x00636230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3C8 RID: 58312
		private BE_Target opl_p0;

		// Token: 0x0400E3C9 RID: 58313
		private BE_Equal opl_p1;

		// Token: 0x0400E3CA RID: 58314
		private int opl_p2;
	}
}
