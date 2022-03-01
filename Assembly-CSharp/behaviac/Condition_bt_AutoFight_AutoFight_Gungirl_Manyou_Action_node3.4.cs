using System;

namespace behaviac
{
	// Token: 0x020024E4 RID: 9444
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node36 : Condition
	{
		// Token: 0x06013312 RID: 78610 RVA: 0x005B2B06 File Offset: 0x005B0F06
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node36()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013313 RID: 78611 RVA: 0x005B2B1C File Offset: 0x005B0F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD2F RID: 52527
		private float opl_p0;
	}
}
