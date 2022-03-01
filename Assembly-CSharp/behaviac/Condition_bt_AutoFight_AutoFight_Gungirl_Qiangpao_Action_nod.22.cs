using System;

namespace behaviac
{
	// Token: 0x02002530 RID: 9520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node30 : Condition
	{
		// Token: 0x060133A9 RID: 78761 RVA: 0x005B6798 File Offset: 0x005B4B98
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node30()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
			this.opl_p4 = 10000;
			this.opl_p5 = 1000;
			this.opl_p6 = 2000;
			this.opl_p7 = 2000;
		}

		// Token: 0x060133AA RID: 78762 RVA: 0x005B6804 File Offset: 0x005B4C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDCB RID: 52683
		private int opl_p0;

		// Token: 0x0400CDCC RID: 52684
		private int opl_p1;

		// Token: 0x0400CDCD RID: 52685
		private int opl_p2;

		// Token: 0x0400CDCE RID: 52686
		private int opl_p3;

		// Token: 0x0400CDCF RID: 52687
		private int opl_p4;

		// Token: 0x0400CDD0 RID: 52688
		private int opl_p5;

		// Token: 0x0400CDD1 RID: 52689
		private int opl_p6;

		// Token: 0x0400CDD2 RID: 52690
		private int opl_p7;
	}
}
