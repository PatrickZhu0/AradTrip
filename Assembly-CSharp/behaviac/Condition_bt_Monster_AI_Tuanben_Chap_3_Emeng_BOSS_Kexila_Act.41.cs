using System;

namespace behaviac
{
	// Token: 0x02003878 RID: 14456
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node24 : Condition
	{
		// Token: 0x060158D4 RID: 88276 RVA: 0x006813A2 File Offset: 0x0067F7A2
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node24()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060158D5 RID: 88277 RVA: 0x006813B8 File Offset: 0x0067F7B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F276 RID: 62070
		private float opl_p0;
	}
}
