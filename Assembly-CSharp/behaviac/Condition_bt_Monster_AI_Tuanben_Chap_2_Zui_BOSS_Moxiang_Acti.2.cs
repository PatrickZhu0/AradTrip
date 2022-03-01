using System;

namespace behaviac
{
	// Token: 0x0200374B RID: 14155
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node16 : Condition
	{
		// Token: 0x0601569D RID: 87709 RVA: 0x00676017 File Offset: 0x00674417
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node16()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601569E RID: 87710 RVA: 0x0067602C File Offset: 0x0067442C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F079 RID: 61561
		private float opl_p0;
	}
}
