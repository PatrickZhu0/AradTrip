using System;

namespace behaviac
{
	// Token: 0x02001F18 RID: 7960
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node54 : Condition
	{
		// Token: 0x060127D4 RID: 75732 RVA: 0x00568BC9 File Offset: 0x00566FC9
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node54()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060127D5 RID: 75733 RVA: 0x00568BDC File Offset: 0x00566FDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1CD RID: 49613
		private float opl_p0;
	}
}
