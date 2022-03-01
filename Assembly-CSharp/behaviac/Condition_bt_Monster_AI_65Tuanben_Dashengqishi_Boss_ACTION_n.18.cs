using System;

namespace behaviac
{
	// Token: 0x02002DA2 RID: 11682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node40 : Condition
	{
		// Token: 0x06014425 RID: 82981 RVA: 0x00615EAB File Offset: 0x006142AB
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node40()
		{
			this.opl_p0 = 21645;
		}

		// Token: 0x06014426 RID: 82982 RVA: 0x00615EC0 File Offset: 0x006142C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDEC RID: 56812
		private int opl_p0;
	}
}
