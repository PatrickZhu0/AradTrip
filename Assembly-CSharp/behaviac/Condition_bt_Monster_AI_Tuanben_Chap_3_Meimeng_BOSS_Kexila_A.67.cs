using System;

namespace behaviac
{
	// Token: 0x02003935 RID: 14645
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node40 : Condition
	{
		// Token: 0x06015A45 RID: 88645 RVA: 0x0068877A File Offset: 0x00686B7A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node40()
		{
			this.opl_p0 = 0.11f;
		}

		// Token: 0x06015A46 RID: 88646 RVA: 0x00688790 File Offset: 0x00686B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3D9 RID: 62425
		private float opl_p0;
	}
}
