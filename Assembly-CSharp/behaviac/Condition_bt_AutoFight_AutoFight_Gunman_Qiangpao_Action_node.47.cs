using System;

namespace behaviac
{
	// Token: 0x0200267B RID: 9851
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node11 : Condition
	{
		// Token: 0x0601363B RID: 79419 RVA: 0x005C4F15 File Offset: 0x005C3315
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node11()
		{
			this.opl_p0 = 1204;
		}

		// Token: 0x0601363C RID: 79420 RVA: 0x005C4F28 File Offset: 0x005C3328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D08E RID: 53390
		private int opl_p0;
	}
}
