using System;

namespace behaviac
{
	// Token: 0x020038F9 RID: 14585
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node56 : Condition
	{
		// Token: 0x060159CF RID: 88527 RVA: 0x0068602E File Offset: 0x0068442E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node56()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x060159D0 RID: 88528 RVA: 0x00686044 File Offset: 0x00684444
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F374 RID: 62324
		private float opl_p0;
	}
}
