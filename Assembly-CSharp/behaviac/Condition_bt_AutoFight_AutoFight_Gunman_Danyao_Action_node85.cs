using System;

namespace behaviac
{
	// Token: 0x020025C1 RID: 9665
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node85 : Condition
	{
		// Token: 0x060134C9 RID: 79049 RVA: 0x005BCE82 File Offset: 0x005BB282
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node85()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060134CA RID: 79050 RVA: 0x005BCEB8 File Offset: 0x005BB2B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF05 RID: 52997
		private int opl_p0;

		// Token: 0x0400CF06 RID: 52998
		private int opl_p1;

		// Token: 0x0400CF07 RID: 52999
		private int opl_p2;

		// Token: 0x0400CF08 RID: 53000
		private int opl_p3;
	}
}
