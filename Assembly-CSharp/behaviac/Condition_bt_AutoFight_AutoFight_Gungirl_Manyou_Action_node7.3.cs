using System;

namespace behaviac
{
	// Token: 0x0200250C RID: 9484
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node70 : Condition
	{
		// Token: 0x06013362 RID: 78690 RVA: 0x005B411E File Offset: 0x005B251E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node70()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013363 RID: 78691 RVA: 0x005B4134 File Offset: 0x005B2534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD83 RID: 52611
		private float opl_p0;
	}
}
