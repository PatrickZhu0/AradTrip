using System;

namespace behaviac
{
	// Token: 0x0200388C RID: 14476
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node41 : Condition
	{
		// Token: 0x060158FC RID: 88316 RVA: 0x00681B52 File Offset: 0x0067FF52
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node41()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060158FD RID: 88317 RVA: 0x00681B68 File Offset: 0x0067FF68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F293 RID: 62099
		private float opl_p0;
	}
}
