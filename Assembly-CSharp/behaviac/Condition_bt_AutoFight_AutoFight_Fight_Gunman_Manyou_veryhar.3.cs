using System;

namespace behaviac
{
	// Token: 0x020021A6 RID: 8614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node7 : Condition
	{
		// Token: 0x06012CDB RID: 77019 RVA: 0x0058834E File Offset: 0x0058674E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node7()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06012CDC RID: 77020 RVA: 0x00588364 File Offset: 0x00586764
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6CE RID: 50894
		private float opl_p0;
	}
}
