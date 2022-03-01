using System;

namespace behaviac
{
	// Token: 0x020035D0 RID: 13776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node10 : Condition
	{
		// Token: 0x060153CA RID: 86986 RVA: 0x00666ADB File Offset: 0x00664EDB
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node10()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060153CB RID: 86987 RVA: 0x00666B10 File Offset: 0x00664F10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED8D RID: 60813
		private int opl_p0;

		// Token: 0x0400ED8E RID: 60814
		private int opl_p1;

		// Token: 0x0400ED8F RID: 60815
		private int opl_p2;

		// Token: 0x0400ED90 RID: 60816
		private int opl_p3;
	}
}
