using System;

namespace behaviac
{
	// Token: 0x02002673 RID: 9843
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node86 : Condition
	{
		// Token: 0x0601362B RID: 79403 RVA: 0x005C4BA7 File Offset: 0x005C2FA7
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node86()
		{
			this.opl_p0 = 1007;
		}

		// Token: 0x0601362C RID: 79404 RVA: 0x005C4BBC File Offset: 0x005C2FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D07E RID: 53374
		private int opl_p0;
	}
}
