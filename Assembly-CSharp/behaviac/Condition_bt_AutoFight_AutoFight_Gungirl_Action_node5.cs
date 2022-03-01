using System;

namespace behaviac
{
	// Token: 0x020024A4 RID: 9380
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node5 : Condition
	{
		// Token: 0x06013293 RID: 78483 RVA: 0x005AFF4A File Offset: 0x005AE34A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013294 RID: 78484 RVA: 0x005AFF60 File Offset: 0x005AE360
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCAA RID: 52394
		private float opl_p0;
	}
}
