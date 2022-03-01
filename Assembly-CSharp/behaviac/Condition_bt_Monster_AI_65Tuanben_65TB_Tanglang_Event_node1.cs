using System;

namespace behaviac
{
	// Token: 0x02002CA2 RID: 11426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node1 : Condition
	{
		// Token: 0x06014239 RID: 82489 RVA: 0x0060CA03 File Offset: 0x0060AE03
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521945;
		}

		// Token: 0x0601423A RID: 82490 RVA: 0x0060CA24 File Offset: 0x0060AE24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF0 RID: 56304
		private BE_Target opl_p0;

		// Token: 0x0400DBF1 RID: 56305
		private BE_Equal opl_p1;

		// Token: 0x0400DBF2 RID: 56306
		private int opl_p2;
	}
}
