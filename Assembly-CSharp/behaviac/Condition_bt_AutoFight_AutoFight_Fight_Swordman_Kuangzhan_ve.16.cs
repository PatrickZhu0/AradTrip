using System;

namespace behaviac
{
	// Token: 0x02002424 RID: 9252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node71 : Condition
	{
		// Token: 0x060131A1 RID: 78241 RVA: 0x005AA1AA File Offset: 0x005A85AA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node71()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060131A2 RID: 78242 RVA: 0x005AA1E0 File Offset: 0x005A85E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBC9 RID: 52169
		private int opl_p0;

		// Token: 0x0400CBCA RID: 52170
		private int opl_p1;

		// Token: 0x0400CBCB RID: 52171
		private int opl_p2;

		// Token: 0x0400CBCC RID: 52172
		private int opl_p3;
	}
}
