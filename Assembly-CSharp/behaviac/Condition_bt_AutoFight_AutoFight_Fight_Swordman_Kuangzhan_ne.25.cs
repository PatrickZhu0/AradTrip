using System;

namespace behaviac
{
	// Token: 0x020023B2 RID: 9138
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node72 : Condition
	{
		// Token: 0x060130CA RID: 78026 RVA: 0x005A425B File Offset: 0x005A265B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node72()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130CB RID: 78027 RVA: 0x005A4290 File Offset: 0x005A2690
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAF6 RID: 51958
		private int opl_p0;

		// Token: 0x0400CAF7 RID: 51959
		private int opl_p1;

		// Token: 0x0400CAF8 RID: 51960
		private int opl_p2;

		// Token: 0x0400CAF9 RID: 51961
		private int opl_p3;
	}
}
