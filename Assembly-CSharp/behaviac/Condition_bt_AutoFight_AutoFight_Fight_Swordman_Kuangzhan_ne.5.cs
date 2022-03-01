using System;

namespace behaviac
{
	// Token: 0x02002398 RID: 9112
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node37 : Condition
	{
		// Token: 0x06013096 RID: 77974 RVA: 0x005A26EC File Offset: 0x005A0AEC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node37()
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

		// Token: 0x06013097 RID: 77975 RVA: 0x005A2758 File Offset: 0x005A0B58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAB2 RID: 51890
		private int opl_p0;

		// Token: 0x0400CAB3 RID: 51891
		private int opl_p1;

		// Token: 0x0400CAB4 RID: 51892
		private int opl_p2;

		// Token: 0x0400CAB5 RID: 51893
		private int opl_p3;

		// Token: 0x0400CAB6 RID: 51894
		private int opl_p4;

		// Token: 0x0400CAB7 RID: 51895
		private int opl_p5;

		// Token: 0x0400CAB8 RID: 51896
		private int opl_p6;

		// Token: 0x0400CAB9 RID: 51897
		private int opl_p7;
	}
}
