using System;

namespace behaviac
{
	// Token: 0x0200219E RID: 8606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node47 : Condition
	{
		// Token: 0x06012CCC RID: 77004 RVA: 0x0058747E File Offset: 0x0058587E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node47()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012CCD RID: 77005 RVA: 0x00587494 File Offset: 0x00585894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6BF RID: 50879
		private float opl_p0;
	}
}
