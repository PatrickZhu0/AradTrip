using System;

namespace behaviac
{
	// Token: 0x02002176 RID: 8566
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node47 : Condition
	{
		// Token: 0x06012C7D RID: 76925 RVA: 0x00585662 File Offset: 0x00583A62
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node47()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06012C7E RID: 76926 RVA: 0x00585678 File Offset: 0x00583A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C670 RID: 50800
		private float opl_p0;
	}
}
