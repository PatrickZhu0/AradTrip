using System;

namespace behaviac
{
	// Token: 0x02002146 RID: 8518
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node37 : Condition
	{
		// Token: 0x06012C1E RID: 76830 RVA: 0x00583402 File Offset: 0x00581802
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node37()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06012C1F RID: 76831 RVA: 0x00583418 File Offset: 0x00581818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C611 RID: 50705
		private float opl_p0;
	}
}
