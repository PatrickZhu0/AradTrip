using System;

namespace behaviac
{
	// Token: 0x020027E0 RID: 10208
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node57 : Condition
	{
		// Token: 0x060138FF RID: 80127 RVA: 0x005D537D File Offset: 0x005D377D
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node57()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013900 RID: 80128 RVA: 0x005D5390 File Offset: 0x005D3790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D35F RID: 54111
		private float opl_p0;
	}
}
