using System;

namespace behaviac
{
	// Token: 0x0200386D RID: 14445
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node10 : Condition
	{
		// Token: 0x060158BE RID: 88254 RVA: 0x00680F5E File Offset: 0x0067F35E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node10()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x060158BF RID: 88255 RVA: 0x00680F74 File Offset: 0x0067F374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F266 RID: 62054
		private float opl_p0;
	}
}
