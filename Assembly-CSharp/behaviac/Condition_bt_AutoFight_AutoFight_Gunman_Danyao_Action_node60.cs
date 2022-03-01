using System;

namespace behaviac
{
	// Token: 0x020025DD RID: 9693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node60 : Condition
	{
		// Token: 0x06013501 RID: 79105 RVA: 0x005BDA06 File Offset: 0x005BBE06
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node60()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013502 RID: 79106 RVA: 0x005BDA3C File Offset: 0x005BBE3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF45 RID: 53061
		private int opl_p0;

		// Token: 0x0400CF46 RID: 53062
		private int opl_p1;

		// Token: 0x0400CF47 RID: 53063
		private int opl_p2;

		// Token: 0x0400CF48 RID: 53064
		private int opl_p3;
	}
}
