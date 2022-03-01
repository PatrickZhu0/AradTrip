using System;

namespace behaviac
{
	// Token: 0x02002509 RID: 9481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node53 : Condition
	{
		// Token: 0x0601335C RID: 78684 RVA: 0x005B3F5A File Offset: 0x005B235A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node53()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601335D RID: 78685 RVA: 0x005B3F70 File Offset: 0x005B2370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD7C RID: 52604
		private float opl_p0;
	}
}
