using System;

namespace behaviac
{
	// Token: 0x020024A0 RID: 9376
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node2 : Condition
	{
		// Token: 0x0601328B RID: 78475 RVA: 0x005AFD01 File Offset: 0x005AE101
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node2()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601328C RID: 78476 RVA: 0x005AFD14 File Offset: 0x005AE114
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCA2 RID: 52386
		private float opl_p0;
	}
}
