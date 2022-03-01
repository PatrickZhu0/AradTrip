using System;

namespace behaviac
{
	// Token: 0x02002AD0 RID: 10960
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node25 : Condition
	{
		// Token: 0x06013EBB RID: 81595 RVA: 0x005FA087 File Offset: 0x005F8487
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node25()
		{
			this.opl_p0 = 1101;
		}

		// Token: 0x06013EBC RID: 81596 RVA: 0x005FA09C File Offset: 0x005F849C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D92E RID: 55598
		private int opl_p0;
	}
}
