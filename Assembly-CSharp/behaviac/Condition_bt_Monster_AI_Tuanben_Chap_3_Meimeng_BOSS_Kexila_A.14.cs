using System;

namespace behaviac
{
	// Token: 0x020038E5 RID: 14565
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node32 : Condition
	{
		// Token: 0x060159A7 RID: 88487 RVA: 0x00685802 File Offset: 0x00683C02
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node32()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060159A8 RID: 88488 RVA: 0x00685818 File Offset: 0x00683C18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F354 RID: 62292
		private float opl_p0;
	}
}
