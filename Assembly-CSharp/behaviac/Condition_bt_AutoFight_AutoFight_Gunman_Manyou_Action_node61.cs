using System;

namespace behaviac
{
	// Token: 0x0200260D RID: 9741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node61 : Condition
	{
		// Token: 0x06013560 RID: 79200 RVA: 0x005C0A59 File Offset: 0x005BEE59
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node61()
		{
			this.opl_p0 = 1104;
		}

		// Token: 0x06013561 RID: 79201 RVA: 0x005C0A6C File Offset: 0x005BEE6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFAD RID: 53165
		private int opl_p0;
	}
}
