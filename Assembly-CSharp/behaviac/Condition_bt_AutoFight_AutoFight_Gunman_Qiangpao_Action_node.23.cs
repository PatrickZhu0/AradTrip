using System;

namespace behaviac
{
	// Token: 0x0200265C RID: 9820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node22 : Condition
	{
		// Token: 0x060135FD RID: 79357 RVA: 0x005C41AB File Offset: 0x005C25AB
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node22()
		{
			this.opl_p0 = 1201;
		}

		// Token: 0x060135FE RID: 79358 RVA: 0x005C41C0 File Offset: 0x005C25C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D04D RID: 53325
		private int opl_p0;
	}
}
