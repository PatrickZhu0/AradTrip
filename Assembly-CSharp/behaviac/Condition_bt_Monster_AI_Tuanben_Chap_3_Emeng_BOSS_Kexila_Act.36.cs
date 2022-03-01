using System;

namespace behaviac
{
	// Token: 0x0200386E RID: 14446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node52 : Condition
	{
		// Token: 0x060158C0 RID: 88256 RVA: 0x00680FA7 File Offset: 0x0067F3A7
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node52()
		{
			this.opl_p0 = 21229;
		}

		// Token: 0x060158C1 RID: 88257 RVA: 0x00680FBC File Offset: 0x0067F3BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F267 RID: 62055
		private int opl_p0;
	}
}
