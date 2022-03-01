using System;

namespace behaviac
{
	// Token: 0x020038EA RID: 14570
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node36 : Condition
	{
		// Token: 0x060159B1 RID: 88497 RVA: 0x00685A02 File Offset: 0x00683E02
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node36()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060159B2 RID: 88498 RVA: 0x00685A18 File Offset: 0x00683E18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F360 RID: 62304
		private float opl_p0;
	}
}
