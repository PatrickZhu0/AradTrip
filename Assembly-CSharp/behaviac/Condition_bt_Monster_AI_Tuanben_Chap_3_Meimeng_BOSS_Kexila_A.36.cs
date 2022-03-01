using System;

namespace behaviac
{
	// Token: 0x02003908 RID: 14600
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node76 : Condition
	{
		// Token: 0x060159EB RID: 88555 RVA: 0x00687456 File Offset: 0x00685856
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node76()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060159EC RID: 88556 RVA: 0x0068746C File Offset: 0x0068586C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F387 RID: 62343
		private float opl_p0;
	}
}
