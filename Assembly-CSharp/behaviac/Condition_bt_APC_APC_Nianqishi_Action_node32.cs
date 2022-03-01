using System;

namespace behaviac
{
	// Token: 0x02001DE1 RID: 7649
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node32 : Condition
	{
		// Token: 0x06012578 RID: 75128 RVA: 0x0055B277 File Offset: 0x00559677
		public Condition_bt_APC_APC_Nianqishi_Action_node32()
		{
			this.opl_p0 = 9703;
		}

		// Token: 0x06012579 RID: 75129 RVA: 0x0055B28C File Offset: 0x0055968C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF69 RID: 49001
		private int opl_p0;
	}
}
