using System;

namespace behaviac
{
	// Token: 0x0200383F RID: 14399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node10 : Condition
	{
		// Token: 0x06015864 RID: 88164 RVA: 0x0067EF66 File Offset: 0x0067D366
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node10()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x06015865 RID: 88165 RVA: 0x0067EF7C File Offset: 0x0067D37C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F228 RID: 61992
		private float opl_p0;
	}
}
