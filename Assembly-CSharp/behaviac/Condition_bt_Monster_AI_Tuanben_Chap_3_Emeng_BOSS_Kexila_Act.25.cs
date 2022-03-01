using System;

namespace behaviac
{
	// Token: 0x0200385C RID: 14428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node42 : Condition
	{
		// Token: 0x0601589E RID: 88222 RVA: 0x0067FACB File Offset: 0x0067DECB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node42()
		{
			this.opl_p0 = 21219;
		}

		// Token: 0x0601589F RID: 88223 RVA: 0x0067FAE0 File Offset: 0x0067DEE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F250 RID: 62032
		private int opl_p0;
	}
}
