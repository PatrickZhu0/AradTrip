using System;

namespace behaviac
{
	// Token: 0x020027AD RID: 10157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node39 : Condition
	{
		// Token: 0x0601389A RID: 80026 RVA: 0x005D3057 File Offset: 0x005D1457
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node39()
		{
			this.opl_p0 = 3510;
		}

		// Token: 0x0601389B RID: 80027 RVA: 0x005D306C File Offset: 0x005D146C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2FA RID: 54010
		private int opl_p0;
	}
}
