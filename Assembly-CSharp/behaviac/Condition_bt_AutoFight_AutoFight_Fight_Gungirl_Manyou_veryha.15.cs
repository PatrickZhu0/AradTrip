using System;

namespace behaviac
{
	// Token: 0x0200207E RID: 8318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node37 : Condition
	{
		// Token: 0x06012A95 RID: 76437 RVA: 0x005799AE File Offset: 0x00577DAE
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node37()
		{
			this.opl_p0 = 0.83f;
		}

		// Token: 0x06012A96 RID: 76438 RVA: 0x005799C4 File Offset: 0x00577DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C488 RID: 50312
		private float opl_p0;
	}
}
