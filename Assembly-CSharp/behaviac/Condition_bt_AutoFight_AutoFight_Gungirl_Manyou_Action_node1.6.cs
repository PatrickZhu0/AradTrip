using System;

namespace behaviac
{
	// Token: 0x02002505 RID: 9477
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node19 : Condition
	{
		// Token: 0x06013354 RID: 78676 RVA: 0x005B3CF6 File Offset: 0x005B20F6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node19()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013355 RID: 78677 RVA: 0x005B3D0C File Offset: 0x005B210C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD74 RID: 52596
		private float opl_p0;
	}
}
