using System;

namespace behaviac
{
	// Token: 0x02002D1E RID: 11550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node7 : Condition
	{
		// Token: 0x06014327 RID: 82727 RVA: 0x00611539 File Offset: 0x0060F939
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521984;
		}

		// Token: 0x06014328 RID: 82728 RVA: 0x0061155C File Offset: 0x0060F95C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCDA RID: 56538
		private BE_Target opl_p0;

		// Token: 0x0400DCDB RID: 56539
		private BE_Equal opl_p1;

		// Token: 0x0400DCDC RID: 56540
		private int opl_p2;
	}
}
