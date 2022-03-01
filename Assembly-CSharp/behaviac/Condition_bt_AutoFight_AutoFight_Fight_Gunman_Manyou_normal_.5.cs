using System;

namespace behaviac
{
	// Token: 0x02002182 RID: 8578
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node12 : Condition
	{
		// Token: 0x06012C94 RID: 76948 RVA: 0x005866CE File Offset: 0x00584ACE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node12()
		{
			this.opl_p0 = 0.49f;
		}

		// Token: 0x06012C95 RID: 76949 RVA: 0x005866E4 File Offset: 0x00584AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C687 RID: 50823
		private float opl_p0;
	}
}
