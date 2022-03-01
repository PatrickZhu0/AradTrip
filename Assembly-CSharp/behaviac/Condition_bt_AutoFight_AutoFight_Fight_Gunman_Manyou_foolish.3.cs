using System;

namespace behaviac
{
	// Token: 0x0200212E RID: 8494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node7 : Condition
	{
		// Token: 0x06012BEE RID: 76782 RVA: 0x005828FA File Offset: 0x00580CFA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node7()
		{
			this.opl_p0 = 0.24f;
		}

		// Token: 0x06012BEF RID: 76783 RVA: 0x00582910 File Offset: 0x00580D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5E1 RID: 50657
		private float opl_p0;
	}
}
