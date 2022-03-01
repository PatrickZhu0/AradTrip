using System;

namespace behaviac
{
	// Token: 0x02002434 RID: 9268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node55 : Condition
	{
		// Token: 0x060131C0 RID: 78272 RVA: 0x005AA83B File Offset: 0x005A8C3B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060131C1 RID: 78273 RVA: 0x005AA870 File Offset: 0x005A8C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBE8 RID: 52200
		private int opl_p0;

		// Token: 0x0400CBE9 RID: 52201
		private int opl_p1;

		// Token: 0x0400CBEA RID: 52202
		private int opl_p2;

		// Token: 0x0400CBEB RID: 52203
		private int opl_p3;
	}
}
