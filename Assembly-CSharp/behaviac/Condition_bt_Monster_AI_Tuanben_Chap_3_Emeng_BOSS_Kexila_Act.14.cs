using System;

namespace behaviac
{
	// Token: 0x0200384C RID: 14412
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node56 : Condition
	{
		// Token: 0x0601587E RID: 88190 RVA: 0x0067F49F File Offset: 0x0067D89F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node56()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x0601587F RID: 88191 RVA: 0x0067F4B4 File Offset: 0x0067D8B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F239 RID: 62009
		private int opl_p0;
	}
}
