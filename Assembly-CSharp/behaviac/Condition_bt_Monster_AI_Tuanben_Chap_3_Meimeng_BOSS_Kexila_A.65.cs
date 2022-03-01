using System;

namespace behaviac
{
	// Token: 0x02003932 RID: 14642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node36 : Condition
	{
		// Token: 0x06015A3F RID: 88639 RVA: 0x0068863E File Offset: 0x00686A3E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node36()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06015A40 RID: 88640 RVA: 0x00688654 File Offset: 0x00686A54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3D5 RID: 62421
		private float opl_p0;
	}
}
