using System;

namespace behaviac
{
	// Token: 0x020035CD RID: 13773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node18 : Condition
	{
		// Token: 0x060153C4 RID: 86980 RVA: 0x006669EF File Offset: 0x00664DEF
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node18()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060153C5 RID: 86981 RVA: 0x00666A24 File Offset: 0x00664E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED87 RID: 60807
		private int opl_p0;

		// Token: 0x0400ED88 RID: 60808
		private int opl_p1;

		// Token: 0x0400ED89 RID: 60809
		private int opl_p2;

		// Token: 0x0400ED8A RID: 60810
		private int opl_p3;
	}
}
