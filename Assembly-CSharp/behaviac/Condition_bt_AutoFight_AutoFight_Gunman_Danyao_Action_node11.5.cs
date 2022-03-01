using System;

namespace behaviac
{
	// Token: 0x020025D0 RID: 9680
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node114 : Condition
	{
		// Token: 0x060134E7 RID: 79079 RVA: 0x005BD48B File Offset: 0x005BB88B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node114()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130804;
		}

		// Token: 0x060134E8 RID: 79080 RVA: 0x005BD4AC File Offset: 0x005BB8AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF2A RID: 53034
		private BE_Target opl_p0;

		// Token: 0x0400CF2B RID: 53035
		private BE_Equal opl_p1;

		// Token: 0x0400CF2C RID: 53036
		private int opl_p2;
	}
}
