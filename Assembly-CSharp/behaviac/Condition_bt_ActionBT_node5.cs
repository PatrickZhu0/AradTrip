using System;

namespace behaviac
{
	// Token: 0x020040CE RID: 16590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_ActionBT_node5 : Condition
	{
		// Token: 0x060168F2 RID: 92402 RVA: 0x006D4E56 File Offset: 0x006D3256
		public Condition_bt_ActionBT_node5()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060168F3 RID: 92403 RVA: 0x006D4E68 File Offset: 0x006D3268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010138 RID: 65848
		private int opl_p0;
	}
}
