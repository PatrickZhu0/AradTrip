using System;

namespace behaviac
{
	// Token: 0x02001DE5 RID: 7653
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node27 : Condition
	{
		// Token: 0x06012580 RID: 75136 RVA: 0x0055B427 File Offset: 0x00559827
		public Condition_bt_APC_APC_Nianqishi_Action_node27()
		{
			this.opl_p0 = 9702;
		}

		// Token: 0x06012581 RID: 75137 RVA: 0x0055B43C File Offset: 0x0055983C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF71 RID: 49009
		private int opl_p0;
	}
}
