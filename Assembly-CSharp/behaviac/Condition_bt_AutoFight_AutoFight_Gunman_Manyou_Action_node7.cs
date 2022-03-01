using System;

namespace behaviac
{
	// Token: 0x020025F7 RID: 9719
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node7 : Condition
	{
		// Token: 0x06013534 RID: 79156 RVA: 0x005C00C2 File Offset: 0x005BE4C2
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node7()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013535 RID: 79157 RVA: 0x005C00D8 File Offset: 0x005BE4D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF7C RID: 53116
		private float opl_p0;
	}
}
