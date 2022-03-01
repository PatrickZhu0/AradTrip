using System;

namespace behaviac
{
	// Token: 0x020028F6 RID: 10486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node73 : Condition
	{
		// Token: 0x06013B23 RID: 80675 RVA: 0x005E2769 File Offset: 0x005E0B69
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node73()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B24 RID: 80676 RVA: 0x005E277C File Offset: 0x005E0B7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D587 RID: 54663
		private float opl_p0;
	}
}
