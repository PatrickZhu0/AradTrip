using System;

namespace behaviac
{
	// Token: 0x020038FC RID: 14588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node60 : Condition
	{
		// Token: 0x060159D5 RID: 88533 RVA: 0x0068616A File Offset: 0x0068456A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node60()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060159D6 RID: 88534 RVA: 0x00686180 File Offset: 0x00684580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F378 RID: 62328
		private float opl_p0;
	}
}
