using System;

namespace behaviac
{
	// Token: 0x02003855 RID: 14421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node30 : Condition
	{
		// Token: 0x06015890 RID: 88208 RVA: 0x0067F80A File Offset: 0x0067DC0A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node30()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x06015891 RID: 88209 RVA: 0x0067F820 File Offset: 0x0067DC20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F247 RID: 62023
		private float opl_p0;
	}
}
