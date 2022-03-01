using System;

namespace behaviac
{
	// Token: 0x020040CC RID: 16588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_ActionBT_node3 : Condition
	{
		// Token: 0x060168EE RID: 92398 RVA: 0x006D4D65 File Offset: 0x006D3165
		public Condition_bt_ActionBT_node3()
		{
			this.opl_p0 = 5000;
		}

		// Token: 0x060168EF RID: 92399 RVA: 0x006D4D78 File Offset: 0x006D3178
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010135 RID: 65845
		private int opl_p0;
	}
}
