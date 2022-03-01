using System;

namespace behaviac
{
	// Token: 0x020024E8 RID: 9448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node54 : Condition
	{
		// Token: 0x0601331A RID: 78618 RVA: 0x005B2D6A File Offset: 0x005B116A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node54()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601331B RID: 78619 RVA: 0x005B2D80 File Offset: 0x005B1180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD37 RID: 52535
		private float opl_p0;
	}
}
