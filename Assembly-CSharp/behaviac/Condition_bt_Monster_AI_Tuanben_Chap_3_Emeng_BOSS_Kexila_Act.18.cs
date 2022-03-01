using System;

namespace behaviac
{
	// Token: 0x02003852 RID: 14418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node15 : Condition
	{
		// Token: 0x0601588A RID: 88202 RVA: 0x0067F6CE File Offset: 0x0067DACE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node15()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x0601588B RID: 88203 RVA: 0x0067F6E4 File Offset: 0x0067DAE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F243 RID: 62019
		private float opl_p0;
	}
}
