using System;

namespace behaviac
{
	// Token: 0x02003861 RID: 14433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node57 : Condition
	{
		// Token: 0x060158A8 RID: 88232 RVA: 0x0067FCFA File Offset: 0x0067E0FA
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node57()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060158A9 RID: 88233 RVA: 0x0067FD10 File Offset: 0x0067E110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F257 RID: 62039
		private float opl_p0;
	}
}
