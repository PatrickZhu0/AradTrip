using System;

namespace behaviac
{
	// Token: 0x02002749 RID: 10057
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node97 : Condition
	{
		// Token: 0x060137D3 RID: 79827 RVA: 0x005CF2DD File Offset: 0x005CD6DD
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node97()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060137D4 RID: 79828 RVA: 0x005CF2F0 File Offset: 0x005CD6F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D22E RID: 53806
		private float opl_p0;
	}
}
