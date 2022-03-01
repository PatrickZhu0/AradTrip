using System;

namespace behaviac
{
	// Token: 0x0200385B RID: 14427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node41 : Condition
	{
		// Token: 0x0601589C RID: 88220 RVA: 0x0067FA82 File Offset: 0x0067DE82
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node41()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x0601589D RID: 88221 RVA: 0x0067FA98 File Offset: 0x0067DE98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F24F RID: 62031
		private float opl_p0;
	}
}
