using System;

namespace behaviac
{
	// Token: 0x020023C5 RID: 9157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node44 : Condition
	{
		// Token: 0x060130F0 RID: 78064 RVA: 0x005A551B File Offset: 0x005A391B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node44()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060130F1 RID: 78065 RVA: 0x005A5550 File Offset: 0x005A3950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB21 RID: 52001
		private int opl_p0;

		// Token: 0x0400CB22 RID: 52002
		private int opl_p1;

		// Token: 0x0400CB23 RID: 52003
		private int opl_p2;

		// Token: 0x0400CB24 RID: 52004
		private int opl_p3;
	}
}
