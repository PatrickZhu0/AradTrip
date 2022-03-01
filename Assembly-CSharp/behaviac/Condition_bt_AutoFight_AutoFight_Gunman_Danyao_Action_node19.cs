using System;

namespace behaviac
{
	// Token: 0x020025C5 RID: 9669
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node19 : Condition
	{
		// Token: 0x060134D1 RID: 79057 RVA: 0x005BD036 File Offset: 0x005BB436
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node19()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060134D2 RID: 79058 RVA: 0x005BD06C File Offset: 0x005BB46C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF0D RID: 53005
		private int opl_p0;

		// Token: 0x0400CF0E RID: 53006
		private int opl_p1;

		// Token: 0x0400CF0F RID: 53007
		private int opl_p2;

		// Token: 0x0400CF10 RID: 53008
		private int opl_p3;
	}
}
