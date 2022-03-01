using System;

namespace behaviac
{
	// Token: 0x020024DC RID: 9436
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node26 : Condition
	{
		// Token: 0x06013302 RID: 78594 RVA: 0x005B279A File Offset: 0x005B0B9A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013303 RID: 78595 RVA: 0x005B27B0 File Offset: 0x005B0BB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD1F RID: 52511
		private float opl_p0;
	}
}
