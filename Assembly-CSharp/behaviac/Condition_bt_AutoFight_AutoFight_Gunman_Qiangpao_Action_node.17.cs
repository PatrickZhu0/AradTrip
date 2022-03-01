using System;

namespace behaviac
{
	// Token: 0x02002654 RID: 9812
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node56 : Condition
	{
		// Token: 0x060135ED RID: 79341 RVA: 0x005C3E45 File Offset: 0x005C2245
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node56()
		{
			this.opl_p0 = 1213;
		}

		// Token: 0x060135EE RID: 79342 RVA: 0x005C3E58 File Offset: 0x005C2258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D03D RID: 53309
		private int opl_p0;
	}
}
