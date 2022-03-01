using System;

namespace behaviac
{
	// Token: 0x02002186 RID: 8582
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node17 : Condition
	{
		// Token: 0x06012C9C RID: 76956 RVA: 0x0058691A File Offset: 0x00584D1A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node17()
		{
			this.opl_p0 = 0.51f;
		}

		// Token: 0x06012C9D RID: 76957 RVA: 0x00586930 File Offset: 0x00584D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C68F RID: 50831
		private float opl_p0;
	}
}
