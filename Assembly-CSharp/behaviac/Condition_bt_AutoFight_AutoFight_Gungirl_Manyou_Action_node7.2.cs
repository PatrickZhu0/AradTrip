using System;

namespace behaviac
{
	// Token: 0x020024F1 RID: 9457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node79 : Condition
	{
		// Token: 0x0601332C RID: 78636 RVA: 0x005B32B6 File Offset: 0x005B16B6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node79()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x0601332D RID: 78637 RVA: 0x005B32CC File Offset: 0x005B16CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD4C RID: 52556
		private float opl_p0;
	}
}
