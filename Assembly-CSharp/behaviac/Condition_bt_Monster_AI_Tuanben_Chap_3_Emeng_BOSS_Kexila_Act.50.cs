using System;

namespace behaviac
{
	// Token: 0x02003885 RID: 14469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node30 : Condition
	{
		// Token: 0x060158EE RID: 88302 RVA: 0x00681892 File Offset: 0x0067FC92
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node30()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x060158EF RID: 88303 RVA: 0x006818A8 File Offset: 0x0067FCA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F289 RID: 62089
		private float opl_p0;
	}
}
