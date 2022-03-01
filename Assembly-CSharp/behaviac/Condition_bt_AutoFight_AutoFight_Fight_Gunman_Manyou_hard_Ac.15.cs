using System;

namespace behaviac
{
	// Token: 0x0200216E RID: 8558
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node37 : Condition
	{
		// Token: 0x06012C6D RID: 76909 RVA: 0x0058521E File Offset: 0x0058361E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node37()
		{
			this.opl_p0 = 0.72f;
		}

		// Token: 0x06012C6E RID: 76910 RVA: 0x00585234 File Offset: 0x00583634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C660 RID: 50784
		private float opl_p0;
	}
}
