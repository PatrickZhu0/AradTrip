using System;

namespace behaviac
{
	// Token: 0x02003933 RID: 14643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node38 : Condition
	{
		// Token: 0x06015A41 RID: 88641 RVA: 0x00688687 File Offset: 0x00686A87
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node38()
		{
			this.opl_p0 = 21209;
		}

		// Token: 0x06015A42 RID: 88642 RVA: 0x0068869C File Offset: 0x00686A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3D6 RID: 62422
		private int opl_p0;
	}
}
