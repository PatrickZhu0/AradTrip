using System;

namespace behaviac
{
	// Token: 0x020021AA RID: 8618
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node12 : Condition
	{
		// Token: 0x06012CE3 RID: 77027 RVA: 0x005884EA File Offset: 0x005868EA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node12()
		{
			this.opl_p0 = 0.73f;
		}

		// Token: 0x06012CE4 RID: 77028 RVA: 0x00588500 File Offset: 0x00586900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6D6 RID: 50902
		private float opl_p0;
	}
}
