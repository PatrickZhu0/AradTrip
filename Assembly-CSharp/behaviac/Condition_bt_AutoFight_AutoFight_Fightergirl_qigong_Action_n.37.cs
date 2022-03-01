using System;

namespace behaviac
{
	// Token: 0x02001F22 RID: 7970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node19 : Condition
	{
		// Token: 0x060127E8 RID: 75752 RVA: 0x00568FBB File Offset: 0x005673BB
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node19()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060127E9 RID: 75753 RVA: 0x00568FF0 File Offset: 0x005673F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1E0 RID: 49632
		private int opl_p0;

		// Token: 0x0400C1E1 RID: 49633
		private int opl_p1;

		// Token: 0x0400C1E2 RID: 49634
		private int opl_p2;

		// Token: 0x0400C1E3 RID: 49635
		private int opl_p3;
	}
}
