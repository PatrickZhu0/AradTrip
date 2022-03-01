using System;

namespace behaviac
{
	// Token: 0x02003846 RID: 14406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node54 : Condition
	{
		// Token: 0x06015872 RID: 88178 RVA: 0x0067F227 File Offset: 0x0067D627
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node54()
		{
			this.opl_p0 = 21219;
		}

		// Token: 0x06015873 RID: 88179 RVA: 0x0067F23C File Offset: 0x0067D63C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F231 RID: 62001
		private int opl_p0;
	}
}
