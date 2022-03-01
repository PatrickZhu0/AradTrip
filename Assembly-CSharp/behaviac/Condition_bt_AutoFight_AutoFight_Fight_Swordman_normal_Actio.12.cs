using System;

namespace behaviac
{
	// Token: 0x0200244A RID: 9290
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node38 : Condition
	{
		// Token: 0x060131E8 RID: 78312 RVA: 0x005ABF6F File Offset: 0x005AA36F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060131E9 RID: 78313 RVA: 0x005ABFA4 File Offset: 0x005AA3A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC0E RID: 52238
		private int opl_p0;

		// Token: 0x0400CC0F RID: 52239
		private int opl_p1;

		// Token: 0x0400CC10 RID: 52240
		private int opl_p2;

		// Token: 0x0400CC11 RID: 52241
		private int opl_p3;
	}
}
