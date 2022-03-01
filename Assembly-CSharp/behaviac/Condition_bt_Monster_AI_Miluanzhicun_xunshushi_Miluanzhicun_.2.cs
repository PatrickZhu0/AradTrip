using System;

namespace behaviac
{
	// Token: 0x020035CA RID: 13770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node6 : Condition
	{
		// Token: 0x060153BE RID: 86974 RVA: 0x00666903 File Offset: 0x00664D03
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060153BF RID: 86975 RVA: 0x00666938 File Offset: 0x00664D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED81 RID: 60801
		private int opl_p0;

		// Token: 0x0400ED82 RID: 60802
		private int opl_p1;

		// Token: 0x0400ED83 RID: 60803
		private int opl_p2;

		// Token: 0x0400ED84 RID: 60804
		private int opl_p3;
	}
}
