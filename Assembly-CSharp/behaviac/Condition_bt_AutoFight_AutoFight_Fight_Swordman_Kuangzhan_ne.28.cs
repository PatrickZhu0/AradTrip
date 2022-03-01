using System;

namespace behaviac
{
	// Token: 0x020023B6 RID: 9142
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node62 : Condition
	{
		// Token: 0x060130D2 RID: 78034 RVA: 0x005A475B File Offset: 0x005A2B5B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node62()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130D3 RID: 78035 RVA: 0x005A4790 File Offset: 0x005A2B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB00 RID: 51968
		private int opl_p0;

		// Token: 0x0400CB01 RID: 51969
		private int opl_p1;

		// Token: 0x0400CB02 RID: 51970
		private int opl_p2;

		// Token: 0x0400CB03 RID: 51971
		private int opl_p3;
	}
}
