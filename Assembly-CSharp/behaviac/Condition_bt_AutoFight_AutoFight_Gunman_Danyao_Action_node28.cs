using System;

namespace behaviac
{
	// Token: 0x020025D6 RID: 9686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node28 : Condition
	{
		// Token: 0x060134F3 RID: 79091 RVA: 0x005BD719 File Offset: 0x005BBB19
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node28()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060134F4 RID: 79092 RVA: 0x005BD72C File Offset: 0x005BBB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF39 RID: 53049
		private float opl_p0;
	}
}
