using System;

namespace behaviac
{
	// Token: 0x020024F7 RID: 9463
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node4 : Condition
	{
		// Token: 0x06013338 RID: 78648 RVA: 0x005B35DD File Offset: 0x005B19DD
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node4()
		{
			this.opl_p0 = 2510;
		}

		// Token: 0x06013339 RID: 78649 RVA: 0x005B35F0 File Offset: 0x005B19F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD59 RID: 52569
		private int opl_p0;
	}
}
