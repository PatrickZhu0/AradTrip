using System;

namespace behaviac
{
	// Token: 0x020027C8 RID: 10184
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node23 : Condition
	{
		// Token: 0x060138CF RID: 80079 RVA: 0x005D4945 File Offset: 0x005D2D45
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node23()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060138D0 RID: 80080 RVA: 0x005D4958 File Offset: 0x005D2D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D32F RID: 54063
		private float opl_p0;
	}
}
