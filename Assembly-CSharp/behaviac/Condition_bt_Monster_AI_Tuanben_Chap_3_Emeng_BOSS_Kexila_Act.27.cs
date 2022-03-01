using System;

namespace behaviac
{
	// Token: 0x0200385F RID: 14431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node46 : Condition
	{
		// Token: 0x060158A4 RID: 88228 RVA: 0x0067FC07 File Offset: 0x0067E007
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node46()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x060158A5 RID: 88229 RVA: 0x0067FC1C File Offset: 0x0067E01C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F254 RID: 62036
		private int opl_p0;
	}
}
