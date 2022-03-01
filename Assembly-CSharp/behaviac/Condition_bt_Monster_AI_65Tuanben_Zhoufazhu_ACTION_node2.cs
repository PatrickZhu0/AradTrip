using System;

namespace behaviac
{
	// Token: 0x02002F23 RID: 12067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2 : Condition
	{
		// Token: 0x0601471B RID: 83739 RVA: 0x006268C6 File Offset: 0x00624CC6
		public Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570299;
		}

		// Token: 0x0601471C RID: 83740 RVA: 0x006268E8 File Offset: 0x00624CE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E08E RID: 57486
		private BE_Target opl_p0;

		// Token: 0x0400E08F RID: 57487
		private BE_Equal opl_p1;

		// Token: 0x0400E090 RID: 57488
		private int opl_p2;
	}
}
