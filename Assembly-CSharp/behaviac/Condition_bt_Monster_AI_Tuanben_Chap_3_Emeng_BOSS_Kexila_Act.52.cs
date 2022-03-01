using System;

namespace behaviac
{
	// Token: 0x02003888 RID: 14472
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node37 : Condition
	{
		// Token: 0x060158F4 RID: 88308 RVA: 0x006819CE File Offset: 0x0067FDCE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node37()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060158F5 RID: 88309 RVA: 0x006819E4 File Offset: 0x0067FDE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F28D RID: 62093
		private float opl_p0;
	}
}
