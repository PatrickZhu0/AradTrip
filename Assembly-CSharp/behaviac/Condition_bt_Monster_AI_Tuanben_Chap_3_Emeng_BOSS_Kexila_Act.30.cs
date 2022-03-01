using System;

namespace behaviac
{
	// Token: 0x02003864 RID: 14436
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node61 : Condition
	{
		// Token: 0x060158AE RID: 88238 RVA: 0x0067FE36 File Offset: 0x0067E236
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node61()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060158AF RID: 88239 RVA: 0x0067FE4C File Offset: 0x0067E24C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F25B RID: 62043
		private float opl_p0;
	}
}
