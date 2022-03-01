using System;

namespace behaviac
{
	// Token: 0x02003886 RID: 14470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node33 : Condition
	{
		// Token: 0x060158F0 RID: 88304 RVA: 0x006818DB File Offset: 0x0067FCDB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node33()
		{
			this.opl_p0 = 21229;
		}

		// Token: 0x060158F1 RID: 88305 RVA: 0x006818F0 File Offset: 0x0067FCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F28A RID: 62090
		private int opl_p0;
	}
}
