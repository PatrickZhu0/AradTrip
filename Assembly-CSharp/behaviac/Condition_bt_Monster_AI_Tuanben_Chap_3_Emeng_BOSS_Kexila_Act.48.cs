using System;

namespace behaviac
{
	// Token: 0x02003882 RID: 14466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node15 : Condition
	{
		// Token: 0x060158E8 RID: 88296 RVA: 0x00681756 File Offset: 0x0067FB56
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node15()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x060158E9 RID: 88297 RVA: 0x0068176C File Offset: 0x0067FB6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F285 RID: 62085
		private float opl_p0;
	}
}
