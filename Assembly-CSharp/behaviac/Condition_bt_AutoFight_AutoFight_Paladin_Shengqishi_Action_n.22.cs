using System;

namespace behaviac
{
	// Token: 0x0200282F RID: 10287
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node3 : Condition
	{
		// Token: 0x0601399C RID: 80284 RVA: 0x005D90B6 File Offset: 0x005D74B6
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node3()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601399D RID: 80285 RVA: 0x005D90EC File Offset: 0x005D74EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F4 RID: 54260
		private int opl_p0;

		// Token: 0x0400D3F5 RID: 54261
		private int opl_p1;

		// Token: 0x0400D3F6 RID: 54262
		private int opl_p2;

		// Token: 0x0400D3F7 RID: 54263
		private int opl_p3;
	}
}
