using System;

namespace behaviac
{
	// Token: 0x02002652 RID: 9810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node53 : Condition
	{
		// Token: 0x060135E9 RID: 79337 RVA: 0x005C3DAB File Offset: 0x005C21AB
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node53()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060135EA RID: 79338 RVA: 0x005C3DC0 File Offset: 0x005C21C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D03A RID: 53306
		private float opl_p0;
	}
}
