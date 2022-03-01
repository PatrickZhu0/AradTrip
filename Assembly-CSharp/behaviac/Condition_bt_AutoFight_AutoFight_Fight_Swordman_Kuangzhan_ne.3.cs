using System;

namespace behaviac
{
	// Token: 0x02002395 RID: 9109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node4 : Condition
	{
		// Token: 0x06013090 RID: 77968 RVA: 0x005A2530 File Offset: 0x005A0930
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node4()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
			this.opl_p4 = 10000;
			this.opl_p5 = 10000;
			this.opl_p6 = 10000;
			this.opl_p7 = 10000;
		}

		// Token: 0x06013091 RID: 77969 RVA: 0x005A259C File Offset: 0x005A099C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAA7 RID: 51879
		private int opl_p0;

		// Token: 0x0400CAA8 RID: 51880
		private int opl_p1;

		// Token: 0x0400CAA9 RID: 51881
		private int opl_p2;

		// Token: 0x0400CAAA RID: 51882
		private int opl_p3;

		// Token: 0x0400CAAB RID: 51883
		private int opl_p4;

		// Token: 0x0400CAAC RID: 51884
		private int opl_p5;

		// Token: 0x0400CAAD RID: 51885
		private int opl_p6;

		// Token: 0x0400CAAE RID: 51886
		private int opl_p7;
	}
}
