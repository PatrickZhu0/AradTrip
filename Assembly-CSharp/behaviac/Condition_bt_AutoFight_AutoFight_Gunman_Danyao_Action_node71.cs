using System;

namespace behaviac
{
	// Token: 0x020025E9 RID: 9705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node71 : Condition
	{
		// Token: 0x06013519 RID: 79129 RVA: 0x005BDF7E File Offset: 0x005BC37E
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node71()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601351A RID: 79130 RVA: 0x005BDFB4 File Offset: 0x005BC3B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF5D RID: 53085
		private int opl_p0;

		// Token: 0x0400CF5E RID: 53086
		private int opl_p1;

		// Token: 0x0400CF5F RID: 53087
		private int opl_p2;

		// Token: 0x0400CF60 RID: 53088
		private int opl_p3;
	}
}
