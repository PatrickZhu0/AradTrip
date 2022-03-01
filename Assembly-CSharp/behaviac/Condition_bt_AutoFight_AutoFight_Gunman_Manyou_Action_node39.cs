using System;

namespace behaviac
{
	// Token: 0x02002633 RID: 9779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node39 : Condition
	{
		// Token: 0x060135AC RID: 79276 RVA: 0x005C1B9D File Offset: 0x005BFF9D
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node39()
		{
			this.opl_p0 = 1006;
		}

		// Token: 0x060135AD RID: 79277 RVA: 0x005C1BB0 File Offset: 0x005BFFB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFFB RID: 53243
		private int opl_p0;
	}
}
