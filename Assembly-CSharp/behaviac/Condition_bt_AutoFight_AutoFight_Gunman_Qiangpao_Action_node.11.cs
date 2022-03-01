using System;

namespace behaviac
{
	// Token: 0x0200264B RID: 9803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node105 : Condition
	{
		// Token: 0x060135DB RID: 79323 RVA: 0x005C3AA5 File Offset: 0x005C1EA5
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node105()
		{
			this.opl_p0 = 1203;
		}

		// Token: 0x060135DC RID: 79324 RVA: 0x005C3AB8 File Offset: 0x005C1EB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D02B RID: 53291
		private int opl_p0;
	}
}
