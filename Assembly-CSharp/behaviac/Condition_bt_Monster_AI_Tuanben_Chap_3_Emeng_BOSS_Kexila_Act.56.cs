using System;

namespace behaviac
{
	// Token: 0x02003890 RID: 14480
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node45 : Condition
	{
		// Token: 0x06015904 RID: 88324 RVA: 0x00681CD6 File Offset: 0x006800D6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node45()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x06015905 RID: 88325 RVA: 0x00681CEC File Offset: 0x006800EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F299 RID: 62105
		private float opl_p0;
	}
}
