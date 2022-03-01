using System;

namespace behaviac
{
	// Token: 0x02002619 RID: 9753
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node42 : Condition
	{
		// Token: 0x06013578 RID: 79224 RVA: 0x005C1052 File Offset: 0x005BF452
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node42()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013579 RID: 79225 RVA: 0x005C1068 File Offset: 0x005BF468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFC2 RID: 53186
		private float opl_p0;
	}
}
