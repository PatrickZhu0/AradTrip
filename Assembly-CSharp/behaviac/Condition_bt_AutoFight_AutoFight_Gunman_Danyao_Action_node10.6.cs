using System;

namespace behaviac
{
	// Token: 0x020025B8 RID: 9656
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node105 : Condition
	{
		// Token: 0x060134B7 RID: 79031 RVA: 0x005BCABB File Offset: 0x005BAEBB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node105()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130804;
		}

		// Token: 0x060134B8 RID: 79032 RVA: 0x005BCADC File Offset: 0x005BAEDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEF2 RID: 52978
		private BE_Target opl_p0;

		// Token: 0x0400CEF3 RID: 52979
		private BE_Equal opl_p1;

		// Token: 0x0400CEF4 RID: 52980
		private int opl_p2;
	}
}
