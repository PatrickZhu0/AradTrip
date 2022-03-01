using System;

namespace behaviac
{
	// Token: 0x02003859 RID: 14425
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node38 : Condition
	{
		// Token: 0x06015898 RID: 88216 RVA: 0x0067F98F File Offset: 0x0067DD8F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node38()
		{
			this.opl_p0 = 21213;
		}

		// Token: 0x06015899 RID: 88217 RVA: 0x0067F9A4 File Offset: 0x0067DDA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F24C RID: 62028
		private int opl_p0;
	}
}
