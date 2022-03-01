using System;

namespace behaviac
{
	// Token: 0x020038D6 RID: 14550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node10 : Condition
	{
		// Token: 0x06015989 RID: 88457 RVA: 0x006851D6 File Offset: 0x006835D6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node10()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x0601598A RID: 88458 RVA: 0x006851EC File Offset: 0x006835EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F340 RID: 62272
		private float opl_p0;
	}
}
