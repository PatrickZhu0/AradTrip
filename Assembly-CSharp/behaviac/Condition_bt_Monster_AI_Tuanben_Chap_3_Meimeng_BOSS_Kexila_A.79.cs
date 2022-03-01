using System;

namespace behaviac
{
	// Token: 0x02003946 RID: 14662
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node58 : Condition
	{
		// Token: 0x06015A67 RID: 88679 RVA: 0x00688EB9 File Offset: 0x006872B9
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node58()
		{
			this.opl_p0 = 21205;
		}

		// Token: 0x06015A68 RID: 88680 RVA: 0x00688ECC File Offset: 0x006872CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3F6 RID: 62454
		private int opl_p0;
	}
}
