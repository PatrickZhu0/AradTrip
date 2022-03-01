using System;

namespace behaviac
{
	// Token: 0x020023C1 RID: 9153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node51 : Condition
	{
		// Token: 0x060130E8 RID: 78056 RVA: 0x005A5367 File Offset: 0x005A3767
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node51()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 3500;
			this.opl_p2 = 3500;
			this.opl_p3 = 3500;
		}

		// Token: 0x060130E9 RID: 78057 RVA: 0x005A539C File Offset: 0x005A379C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB19 RID: 51993
		private int opl_p0;

		// Token: 0x0400CB1A RID: 51994
		private int opl_p1;

		// Token: 0x0400CB1B RID: 51995
		private int opl_p2;

		// Token: 0x0400CB1C RID: 51996
		private int opl_p3;
	}
}
