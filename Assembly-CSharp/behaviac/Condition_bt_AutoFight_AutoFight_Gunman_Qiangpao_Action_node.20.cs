using System;

namespace behaviac
{
	// Token: 0x02002658 RID: 9816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node60 : Condition
	{
		// Token: 0x060135F5 RID: 79349 RVA: 0x005C3FF7 File Offset: 0x005C23F7
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node60()
		{
			this.opl_p0 = 1218;
		}

		// Token: 0x060135F6 RID: 79350 RVA: 0x005C400C File Offset: 0x005C240C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D045 RID: 53317
		private int opl_p0;
	}
}
