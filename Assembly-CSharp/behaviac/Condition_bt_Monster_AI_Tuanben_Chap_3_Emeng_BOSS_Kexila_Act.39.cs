using System;

namespace behaviac
{
	// Token: 0x02003874 RID: 14452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node20 : Condition
	{
		// Token: 0x060158CC RID: 88268 RVA: 0x0068121E File Offset: 0x0067F61E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node20()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060158CD RID: 88269 RVA: 0x00681234 File Offset: 0x0067F634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F270 RID: 62064
		private float opl_p0;
	}
}
