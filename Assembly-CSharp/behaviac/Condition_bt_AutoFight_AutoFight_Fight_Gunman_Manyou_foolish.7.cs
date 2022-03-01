using System;

namespace behaviac
{
	// Token: 0x02002136 RID: 8502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node17 : Condition
	{
		// Token: 0x06012BFE RID: 76798 RVA: 0x00582CE2 File Offset: 0x005810E2
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node17()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x06012BFF RID: 76799 RVA: 0x00582CF8 File Offset: 0x005810F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5F1 RID: 50673
		private float opl_p0;
	}
}
