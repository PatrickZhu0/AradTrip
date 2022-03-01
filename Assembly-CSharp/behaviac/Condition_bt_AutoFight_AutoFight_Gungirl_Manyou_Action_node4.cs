using System;

namespace behaviac
{
	// Token: 0x020024F5 RID: 9461
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node41 : Condition
	{
		// Token: 0x06013334 RID: 78644 RVA: 0x005B351A File Offset: 0x005B191A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node41()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013335 RID: 78645 RVA: 0x005B3530 File Offset: 0x005B1930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD54 RID: 52564
		private float opl_p0;
	}
}
