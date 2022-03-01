using System;

namespace behaviac
{
	// Token: 0x020027DC RID: 10204
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node52 : Condition
	{
		// Token: 0x060138F7 RID: 80119 RVA: 0x005D51C9 File Offset: 0x005D35C9
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node52()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060138F8 RID: 80120 RVA: 0x005D51DC File Offset: 0x005D35DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D357 RID: 54103
		private float opl_p0;
	}
}
