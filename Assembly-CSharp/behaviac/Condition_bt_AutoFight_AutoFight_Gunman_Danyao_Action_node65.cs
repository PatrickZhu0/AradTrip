using System;

namespace behaviac
{
	// Token: 0x020025E5 RID: 9701
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node65 : Condition
	{
		// Token: 0x06013511 RID: 79121 RVA: 0x005BDDCA File Offset: 0x005BC1CA
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node65()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06013512 RID: 79122 RVA: 0x005BDE00 File Offset: 0x005BC200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF55 RID: 53077
		private int opl_p0;

		// Token: 0x0400CF56 RID: 53078
		private int opl_p1;

		// Token: 0x0400CF57 RID: 53079
		private int opl_p2;

		// Token: 0x0400CF58 RID: 53080
		private int opl_p3;
	}
}
