using System;

namespace behaviac
{
	// Token: 0x020021AE RID: 8622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node17 : Condition
	{
		// Token: 0x06012CEB RID: 77035 RVA: 0x00588736 File Offset: 0x00586B36
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012CEC RID: 77036 RVA: 0x0058874C File Offset: 0x00586B4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6DE RID: 50910
		private float opl_p0;
	}
}
