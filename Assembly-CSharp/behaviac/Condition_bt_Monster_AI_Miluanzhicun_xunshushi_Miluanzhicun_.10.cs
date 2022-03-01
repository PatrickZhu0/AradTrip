using System;

namespace behaviac
{
	// Token: 0x020035D6 RID: 13782
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node30 : Condition
	{
		// Token: 0x060153D6 RID: 86998 RVA: 0x00666CB3 File Offset: 0x006650B3
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node30()
		{
			this.opl_p0 = 25000;
			this.opl_p1 = 25000;
			this.opl_p2 = 25000;
			this.opl_p3 = 25000;
		}

		// Token: 0x060153D7 RID: 86999 RVA: 0x00666CE8 File Offset: 0x006650E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED99 RID: 60825
		private int opl_p0;

		// Token: 0x0400ED9A RID: 60826
		private int opl_p1;

		// Token: 0x0400ED9B RID: 60827
		private int opl_p2;

		// Token: 0x0400ED9C RID: 60828
		private int opl_p3;
	}
}
