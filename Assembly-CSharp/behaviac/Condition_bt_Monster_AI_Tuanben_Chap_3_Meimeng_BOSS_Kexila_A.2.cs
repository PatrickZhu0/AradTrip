using System;

namespace behaviac
{
	// Token: 0x020038D3 RID: 14547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node16 : Condition
	{
		// Token: 0x06015983 RID: 88451 RVA: 0x0068509B File Offset: 0x0068349B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node16()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x06015984 RID: 88452 RVA: 0x006850B0 File Offset: 0x006834B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F33C RID: 62268
		private float opl_p0;
	}
}
