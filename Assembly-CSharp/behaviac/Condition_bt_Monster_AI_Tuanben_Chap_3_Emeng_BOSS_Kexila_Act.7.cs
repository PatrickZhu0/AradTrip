using System;

namespace behaviac
{
	// Token: 0x02003842 RID: 14402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node13 : Condition
	{
		// Token: 0x0601586A RID: 88170 RVA: 0x0067F0A2 File Offset: 0x0067D4A2
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601586B RID: 88171 RVA: 0x0067F0B8 File Offset: 0x0067D4B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F22C RID: 61996
		private float opl_p0;
	}
}
