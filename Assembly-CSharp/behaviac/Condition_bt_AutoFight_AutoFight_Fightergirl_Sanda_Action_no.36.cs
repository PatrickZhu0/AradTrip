using System;

namespace behaviac
{
	// Token: 0x02001F53 RID: 8019
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node10 : Condition
	{
		// Token: 0x06012849 RID: 75849 RVA: 0x0056B3F6 File Offset: 0x005697F6
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node10()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601284A RID: 75850 RVA: 0x0056B40C File Offset: 0x0056980C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C243 RID: 49731
		private float opl_p0;
	}
}
