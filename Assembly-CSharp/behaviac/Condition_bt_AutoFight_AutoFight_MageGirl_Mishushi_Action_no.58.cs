using System;

namespace behaviac
{
	// Token: 0x020026FC RID: 9980
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node33 : Condition
	{
		// Token: 0x0601373B RID: 79675 RVA: 0x005CA657 File Offset: 0x005C8A57
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node33()
		{
			this.opl_p0 = 2010;
		}

		// Token: 0x0601373C RID: 79676 RVA: 0x005CA66C File Offset: 0x005C8A6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D192 RID: 53650
		private int opl_p0;
	}
}
