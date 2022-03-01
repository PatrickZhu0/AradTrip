using System;

namespace behaviac
{
	// Token: 0x02003893 RID: 14483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node57 : Condition
	{
		// Token: 0x0601590A RID: 88330 RVA: 0x00681E12 File Offset: 0x00680212
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node57()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601590B RID: 88331 RVA: 0x00681E28 File Offset: 0x00680228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F29D RID: 62109
		private float opl_p0;
	}
}
